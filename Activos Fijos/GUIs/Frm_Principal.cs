using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Activos_Fijos.GUIs
{
    public partial class Frm_Principal : DevExpress.XtraEditors.XtraForm
    {
        SubFrm_Activos sfActivos = new SubFrm_Activos();
        SubFrm_Grupos sfGrupos = new SubFrm_Grupos();

        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void QuitarTodosLosControles()
        {
            foreach (Control ctrl in SubFormsArea.Controls)
                SubFormsArea.Controls.Remove(ctrl);
        }

        private void nbiActivos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (sfActivos.hidden == true)
            {
                sfActivos.hidden = false;
                sfActivos.Show();
            }

            QuitarTodosLosControles();
            SubFormsArea.Controls.Add(sfActivos);
            sfActivos.Dock = DockStyle.Fill;
        }

        private void nbiGrupos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            QuitarTodosLosControles();
            SubFormsArea.Controls.Add(sfGrupos);
            sfGrupos.Dock = DockStyle.Fill;
        }
    }
}