using RegistroPuebloMontubio.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RegistroPuebloMontubio {
    public partial class Menu : Form {
        #region ATRIBUTOS
        private Boolean adm;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        #endregion

        #region CONTRUCTOR
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
        public Menu(Boolean adm) {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(this.dropArea_MouseDown);
            this.MouseMove += new MouseEventHandler(this.dropArea_MouseMove);
            this.MouseUp += new MouseEventHandler(this.dropArea_MouseUp);
            this.adm = adm;

        }
        #endregion

        #region LOAD
        private void Menu_Load(object sender, EventArgs e) {
            if (this.adm) {
                this.lblReporte.Location = new System.Drawing.Point(454, 300);
                this.lblAdm.Location = new System.Drawing.Point(635, 300);
                this.btnAdm.Location = new System.Drawing.Point(619, 171);
                this.btnReporte.Location = new System.Drawing.Point(430, 171);
                this.lblDirigente.Location = new System.Drawing.Point(78, 300);
                this.lblSocio.Location = new System.Drawing.Point(280, 300);
                this.btnSocio.Location = new System.Drawing.Point(240, 171);
                this.btnDirigente.Location = new System.Drawing.Point(56, 171);
            } else {
                this.btnDirigente.Location = new System.Drawing.Point(156, 171);
                this.btnSocio.Location = new System.Drawing.Point(512, 171);
                this.lblDirigente.Location = new System.Drawing.Point(178, 300);
                this.lblSocio.Location = new System.Drawing.Point(552, 300);
                this.btnAdm.Visible = false;
                this.lblAdm.Visible = false;
                this.btnReporte.Visible = false;
                this.lblReporte.Visible = false;
            }

        }
        #endregion

        #region BUTTONS

        #region btn SOCIO
        private void btnSocio_Click(object sender, EventArgs e) {
            Socio socio = new Socio();
            this.AddOwnedForm(socio);
            this.Hide();
            socio.ShowDialog();
        }
        #endregion

        #region btn DIRIGENTE
        private void btnDirigente_Click(object sender, EventArgs e) {
            Dirigente dirigente = new Dirigente();
            this.AddOwnedForm(dirigente);
            this.Hide();
            dirigente.ShowDialog();
        }
        #endregion

        #region btn Cerrar
        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Dispose();
        }
        private void btnCerrar_MouseHover(object sender, EventArgs e) {
            btnCerrar.BackgroundImage = Resources._55icone_fermer_et_x_vert;
        }
        private void btnCerrar_MouseLeave(object sender, EventArgs e) {
            btnCerrar.BackgroundImage = Resources.equis_blanca;
        }
        #endregion

        #region btn Minimizar
        private void btnMinimizar_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #endregion

        #region DROPAREA
        //funciones para poder mover la ventana
        private void dropArea_MouseDown(object sender, MouseEventArgs e) {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void dropArea_MouseMove(object sender, MouseEventArgs e) {
            if (dragging) {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void dropArea_MouseUp(object sender, MouseEventArgs e) {
            dragging = false;
        }
        #endregion

    }
}
