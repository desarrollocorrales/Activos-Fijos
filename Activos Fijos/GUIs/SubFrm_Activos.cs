using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Activos_Fijos.Entity;
using DevExpress.XtraEditors;
using System.IO;
using System.Drawing.Imaging;

namespace Activos_Fijos.GUIs
{
    public partial class SubFrm_Activos : UserControl
    {
        public bool hidden;
        private ActivosFijosEntities Contexto;
        public SubFrm_Activos()
        {
            InitializeComponent();
        }

        private void SubFrm_Activos_Load(object sender, EventArgs e)
        {
            hidden = false;
            try
            {
                Contexto = new ActivosFijosEntities();
                CargarComboClasificaciones();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarComboClasificaciones()
        {
            var lstClasificaciones = Contexto.clasificaciones.ToList();
            cmbAClasificacion.DataSource = lstClasificaciones;
            cmbAClasificacion.DisplayMember = "nombre";
        }

        private void btnBuscarImagen_Click(object sender, EventArgs e)
        {
            BuscarImagen();
        }
        private void BuscarImagen()
        {
            ofdImagen.ShowDialog();
            if (ofdImagen.FileName != null)
            {
                pbAImagen.Image = new Bitmap(ofdImagen.FileName);
                pbAImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void txbACosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnMCancelar_Click(object sender, EventArgs e)
        {
            hidden = true;
            this.Hide();
        }

        private void btnECancelar_Click(object sender, EventArgs e)
        {
            hidden = true;
            this.Hide();
        }

        private void btnACancelar_Click(object sender, EventArgs e)
        {
            hidden = true;
            this.Hide();  
        }

        private void btnAGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarNuevoActivo();
            }
            catch (Exception ex)
            {
                MostrarExcepcion(ex);
            }
        }
        private void GuardarNuevoActivo()
        {
            if (ValidarDatosNuevoActivo() == true)
            {
                if (ValidarDatosOpcionalesNuevoActivo() == true)
                {
                    if (ValidacionFinal() == true)
                    {
                        Contexto = new ActivosFijosEntities();
                        Contexto.Connection.Open();
                        var Transaccion = Contexto.Connection.BeginTransaction();

                        try
                        {
                            activos NuevoActivo = new activos();
                            NuevoActivo.nombre_corto = txbANombre.Text.ToUpper();
                            NuevoActivo.descripcion_detallada = txbADescripcion.Text.ToUpper();
                            NuevoActivo.fecha_adquisicion = dtpAFechaAdquisicion.Value;
                            NuevoActivo.costo = Convert.ToDecimal(txbACosto.Text);
                            NuevoActivo.id_clasificacion = ((clasificaciones)cmbAClasificacion.SelectedItem).id_clasificacion;
                            NuevoActivo.codigo_barras = "XXX" + dtpAFechaAdquisicion.Value.ToString("ddMMyyyy");
                            NuevoActivo.idcompra = Convert.ToInt64(txbAIDCompra.Text);
                            NuevoActivo.estatus = "C";
                            NuevoActivo.imagen = ObtenerImagen();

                            Contexto.activos.AddObject(NuevoActivo);
                            Contexto.SaveChanges();

                            var Activo = Contexto.activos.ToList().Last();
                            Activo.codigo_barras = Activo.id_activo.ToString();

                            Contexto.SaveChanges();

                            Transaccion.Commit();
                            LimpiarControles();

                            XtraMessageBox.Show("El activo ha sido creado con exito! Código: " + Activo.codigo_barras, "Activo Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MostrarExcepcion(ex);
                            Transaccion.Rollback();
                        }

                        if (Contexto.Connection.State != ConnectionState.Closed)
                            Contexto.Connection.Close();
                    }
                }
            }
        }
        private Byte[] ObtenerImagen()
        {
            Byte[] byteArray = null;
            MemoryStream ms = new MemoryStream();

            if (pbAImagen.Image != null)
            {
                pbAImagen.Image.Save(ms, ImageFormat.Png);
                byteArray = ms.ToArray();
            }

            return byteArray;
        }
        private bool ValidarDatosNuevoActivo()
        {
            if (txbANombre.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Escriba el nombre del activo por favor...", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txbADescripcion.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Escriba una descripción detallada para el activo por favor...", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txbACosto.Text == string.Empty)
            {
                XtraMessageBox.Show("Asigne un costo al activo por favor...", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txbAIDCompra.Text == string.Empty)
            {
                XtraMessageBox.Show("Especifique el ID de compra del activo...", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool ValidarDatosOpcionalesNuevoActivo()
        {
            if (pbAImagen.Image == null)
            {
                DialogResult dr = XtraMessageBox.Show("¿Deseas agregar una imagen al activo?", "Validar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    return false;
            }

            return true;
        }
        private bool ValidacionFinal()
        {
            DialogResult dr = XtraMessageBox.Show("¿Todos los datos son correctos?", "Validar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                return true;

            return false;
        }
        private void LimpiarControles()
        {
            txbANombre.Text = string.Empty;
            txbADescripcion.Text = string.Empty;
            txbACosto.Text = string.Empty;
            txbAIDCompra.Text = string.Empty;
            pbAImagen.Image = null;
        }

        private void MostrarExcepcion(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            var exaux = ex;
            while (exaux != null)
            {
                sb.AppendLine(exaux.Message);
                exaux = exaux.InnerException;
            }

            XtraMessageBox.Show(sb.ToString(), ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
