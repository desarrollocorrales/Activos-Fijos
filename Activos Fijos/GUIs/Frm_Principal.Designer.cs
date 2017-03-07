namespace Activos_Fijos.GUIs
{
    partial class Frm_Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Principal));
            this.label3 = new System.Windows.Forms.Label();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.nBarMenu = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiActivos = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiGrupos = new DevExpress.XtraNavBar.NavBarItem();
            this.SubFormsArea = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubFormsArea)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(70)))));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1034, 38);
            this.label3.TabIndex = 5;
            this.label3.Text = "Control de Activos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.nBarMenu;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nBarMenu});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbiActivos,
            this.nbiGrupos});
            this.navBarControl1.Location = new System.Drawing.Point(0, 38);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 206;
            this.navBarControl1.Size = new System.Drawing.Size(206, 623);
            this.navBarControl1.TabIndex = 6;
            this.navBarControl1.Text = "Menú";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Caramel");
            // 
            // nBarMenu
            // 
            this.nBarMenu.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nBarMenu.Appearance.Options.UseFont = true;
            this.nBarMenu.Caption = "Menú";
            this.nBarMenu.Expanded = true;
            this.nBarMenu.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiActivos),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiGrupos)});
            this.nBarMenu.Name = "nBarMenu";
            // 
            // nbiActivos
            // 
            this.nbiActivos.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbiActivos.Appearance.Options.UseFont = true;
            this.nbiActivos.Caption = "Activos";
            this.nbiActivos.Name = "nbiActivos";
            this.nbiActivos.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiActivos_LinkClicked);
            // 
            // nbiGrupos
            // 
            this.nbiGrupos.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbiGrupos.Appearance.Options.UseFont = true;
            this.nbiGrupos.Caption = "Grupos";
            this.nbiGrupos.Name = "nbiGrupos";
            this.nbiGrupos.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiGrupos_LinkClicked);
            // 
            // SubFormsArea
            // 
            this.SubFormsArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubFormsArea.Location = new System.Drawing.Point(206, 38);
            this.SubFormsArea.Name = "SubFormsArea";
            this.SubFormsArea.Size = new System.Drawing.Size(828, 623);
            this.SubFormsArea.TabIndex = 7;
            // 
            // Frm_Principal
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 661);
            this.Controls.Add(this.SubFormsArea);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Principal";
            this.Text = "Control de Activos";
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubFormsArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup nBarMenu;
        private DevExpress.XtraEditors.PanelControl SubFormsArea;
        private DevExpress.XtraNavBar.NavBarItem nbiActivos;
        private DevExpress.XtraNavBar.NavBarItem nbiGrupos;
    }
}