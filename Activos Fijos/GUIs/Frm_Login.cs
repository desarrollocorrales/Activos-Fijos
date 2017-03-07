using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Activos_Fijos.Entity;
using System.Linq;

namespace Activos_Fijos.GUIs
{
    public partial class Frm_Login : DevExpress.XtraEditors.XtraForm
    {
        private Portal_Entities ContextoPortal;

        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }
        private void IniciarSesion()
        {
            try
            {
                var user = txbUser.Text.ToUpper();
                var pass = txbPass.Text.ToUpper();
                var encriptedpass = Rot13(Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes(pass))))).ToUpper();

                List<usuarios> lstUsuarios = ContextoPortal.usuarios.ToList();
                var usuario = lstUsuarios.FirstOrDefault(o => o.usuario.ToUpper() == user && o.clave.ToUpper() == encriptedpass);
                if (usuario == null)
                {
                    XtraMessageBox.Show("Error de nombre de usuario o contraseña", "Inicio de Sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Frm_Principal frmPrincipal = new Frm_Principal();
                    this.Hide();
                    frmPrincipal.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MostrarExcepcion(ex);
            }
        }

        private void Frm_Login_Shown(object sender, EventArgs e)
        {
            try
            {
                ContextoPortal = new Portal_Entities();
            }
            catch (Exception ex)
            {
                MostrarExcepcion(ex);
            }
        }

        private void MostrarExcepcion(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            var exaux = ex;
            while (exaux != null)
            {
                sb.AppendLine(ex.Message);
                exaux = exaux.InnerException;
            }

            XtraMessageBox.Show(sb.ToString(), ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            var s = "ISITEIIeoRWHnxy3GIESCD==";
            var x = Rot13(s);
            MessageBox.Show(x);

            var y = Encoding.UTF8.GetString(Convert.FromBase64String(x));
            MessageBox.Show(y);
            var z = Encoding.UTF8.GetString(Convert.FromBase64String(y));
            MessageBox.Show(z);
        }

        private string Rot13(string cadena)
        {
            char[] array = cadena.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                int number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                        number -= 13;
                    else
                        number += 13;
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                        number -= 13;
                    else
                        number += 13;
                }
                array[i] = (char)number;
            }

            return new string(array);
        }
    }
}