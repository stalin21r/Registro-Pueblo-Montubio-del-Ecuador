namespace RegistroPuebloMontubio {
    partial class Menu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.lblDirigente = new System.Windows.Forms.Label();
            this.lblSocio = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dropArea = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReporte = new System.Windows.Forms.Label();
            this.lblAdm = new System.Windows.Forms.Label();
            this.btnAdm = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSocio = new System.Windows.Forms.Button();
            this.btnDirigente = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.dropArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDirigente
            // 
            this.lblDirigente.AutoSize = true;
            this.lblDirigente.BackColor = System.Drawing.Color.Transparent;
            this.lblDirigente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirigente.Location = new System.Drawing.Point(78, 300);
            this.lblDirigente.Name = "lblDirigente";
            this.lblDirigente.Size = new System.Drawing.Size(98, 25);
            this.lblDirigente.TabIndex = 14;
            this.lblDirigente.Text = "Dirigente";
            // 
            // lblSocio
            // 
            this.lblSocio.AutoSize = true;
            this.lblSocio.BackColor = System.Drawing.Color.Transparent;
            this.lblSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocio.Location = new System.Drawing.Point(280, 300);
            this.lblSocio.Name = "lblSocio";
            this.lblSocio.Size = new System.Drawing.Size(66, 25);
            this.lblSocio.TabIndex = 15;
            this.lblSocio.Text = "Socio";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(121)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dropArea);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 133);
            this.panel1.TabIndex = 16;
            // 
            // dropArea
            // 
            this.dropArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(121)))), ((int)(((byte)(45)))));
            this.dropArea.Controls.Add(this.btnMinimizar);
            this.dropArea.Controls.Add(this.btnCerrar);
            this.dropArea.Location = new System.Drawing.Point(1, 3);
            this.dropArea.Name = "dropArea";
            this.dropArea.Size = new System.Drawing.Size(816, 26);
            this.dropArea.TabIndex = 22;
            this.dropArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dropArea_MouseDown);
            this.dropArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dropArea_MouseMove);
            this.dropArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dropArea_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(731, 91);
            this.label1.TabIndex = 11;
            this.label1.Text = "MENU PRINCIPAL";
            // 
            // lblReporte
            // 
            this.lblReporte.AutoSize = true;
            this.lblReporte.BackColor = System.Drawing.Color.Transparent;
            this.lblReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReporte.Location = new System.Drawing.Point(454, 300);
            this.lblReporte.Name = "lblReporte";
            this.lblReporte.Size = new System.Drawing.Size(99, 25);
            this.lblReporte.TabIndex = 19;
            this.lblReporte.Text = "Reportes";
            // 
            // lblAdm
            // 
            this.lblAdm.AutoSize = true;
            this.lblAdm.BackColor = System.Drawing.Color.Transparent;
            this.lblAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdm.Location = new System.Drawing.Point(635, 300);
            this.lblAdm.Name = "lblAdm";
            this.lblAdm.Size = new System.Drawing.Size(120, 25);
            this.lblAdm.TabIndex = 21;
            this.lblAdm.Text = "Administrar";
            // 
            // btnAdm
            // 
            this.btnAdm.BackgroundImage = global::RegistroPuebloMontubio.Properties.Resources.adm1;
            this.btnAdm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdm.Location = new System.Drawing.Point(619, 171);
            this.btnAdm.Name = "btnAdm";
            this.btnAdm.Size = new System.Drawing.Size(135, 126);
            this.btnAdm.TabIndex = 4;
            this.btnAdm.UseVisualStyleBackColor = true;
            // 
            // btnReporte
            // 
            this.btnReporte.BackgroundImage = global::RegistroPuebloMontubio.Properties.Resources.reportes;
            this.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Location = new System.Drawing.Point(430, 171);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(135, 126);
            this.btnReporte.TabIndex = 3;
            this.btnReporte.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(121)))), ((int)(((byte)(45)))));
            this.panel2.BackgroundImage = global::RegistroPuebloMontubio.Properties.Resources.pie_de_pag;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(0, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(820, 133);
            this.panel2.TabIndex = 17;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizar.BackgroundImage = global::RegistroPuebloMontubio.Properties.Resources.window_minimize;
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(176)))), ((int)(((byte)(67)))));
            this.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(225)))), ((int)(((byte)(84)))));
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(778, 0);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(19, 19);
            this.btnMinimizar.TabIndex = 23;
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::RegistroPuebloMontubio.Properties.Resources.equis_blanca;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(797, 0);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(19, 19);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            this.btnCerrar.MouseHover += new System.EventHandler(this.btnCerrar_MouseHover);
            // 
            // btnSocio
            // 
            this.btnSocio.BackgroundImage = global::RegistroPuebloMontubio.Properties.Resources.socio;
            this.btnSocio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSocio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSocio.Location = new System.Drawing.Point(240, 171);
            this.btnSocio.Name = "btnSocio";
            this.btnSocio.Size = new System.Drawing.Size(135, 126);
            this.btnSocio.TabIndex = 2;
            this.btnSocio.UseVisualStyleBackColor = true;
            this.btnSocio.Click += new System.EventHandler(this.btnSocio_Click);
            // 
            // btnDirigente
            // 
            this.btnDirigente.BackgroundImage = global::RegistroPuebloMontubio.Properties.Resources.dirigente;
            this.btnDirigente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDirigente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirigente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDirigente.Location = new System.Drawing.Point(56, 171);
            this.btnDirigente.Name = "btnDirigente";
            this.btnDirigente.Size = new System.Drawing.Size(135, 126);
            this.btnDirigente.TabIndex = 1;
            this.btnDirigente.UseVisualStyleBackColor = true;
            this.btnDirigente.Click += new System.EventHandler(this.btnDirigente_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 476);
            this.Controls.Add(this.lblAdm);
            this.Controls.Add(this.btnAdm);
            this.Controls.Add(this.lblReporte);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSocio);
            this.Controls.Add(this.lblDirigente);
            this.Controls.Add(this.btnSocio);
            this.Controls.Add(this.btnDirigente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.dropArea.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnDirigente;
        private System.Windows.Forms.Button btnSocio;
        private System.Windows.Forms.Label lblDirigente;
        private System.Windows.Forms.Label lblSocio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblReporte;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Label lblAdm;
        private System.Windows.Forms.Button btnAdm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel dropArea;
        private System.Windows.Forms.Button btnMinimizar;
    }
}