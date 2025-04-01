using System;
using System.Windows.Forms;
using CapaNegocio;
using System.IO;
using RegistroPuebloMontubio.Properties;
using System.Drawing;

namespace RegistroPuebloMontubio {
    public partial class Dirigente : Form {

        #region ATRIBUTOS
        private string rutaFoto;
        private string rutaFirma;
        private SocioN socio;
        private string cod;
        private string pnombre;
        private string snombre;
        private string papellido;
        private string sapellido;
        private string cedula;
        private string celular;
        private string rutaFotog;
        private string rutaFirmag;
        private int rolFk;
        private int provinciaFk;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        #endregion

        #region CONSTRUCTOR
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
        public Dirigente() {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(this.dropArea_MouseDown);
            this.MouseMove += new MouseEventHandler(this.dropArea_MouseMove);
            this.MouseUp += new MouseEventHandler(this.dropArea_MouseUp);
        }
        #endregion

        #region BUTTONS

        #region btn Guardar
        private void btnGuardar_Click(object sender, EventArgs e) {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de ingresar este registro?", "Registrar socio!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes) {

                string codnum = SocioN.obtenerUltimoCod(int.Parse(cbxProvincia.SelectedValue.ToString()));
                codnum = (long.Parse(codnum) + 1).ToString();
                this.cod = ProvinciaN.ObtenerCodigo(int.Parse(cbxProvincia.SelectedValue.ToString()));
                string cerosIntermedios = codnum.ToString().PadLeft(8, '0');
                this.cod = this.cod + cerosIntermedios + codnum.ToString();
                this.cod = this.cod.Substring(0, 10);

                this.pnombre = txtPnombre.Text;
                this.snombre = txtSnombre.Text;
                this.papellido = txtPapellido.Text;
                this.sapellido = txtSapellido.Text;
                this.cedula = txtCedula.Text;
                this.celular = txtCelular.Text;
                this.provinciaFk = int.Parse(cbxProvincia.SelectedValue.ToString());
                this.rolFk = int.Parse(cbxRol.SelectedValue.ToString());

                // Obtener la ruta del escritorio
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string rutaCarpetaDestino = Path.Combine(desktopPath, "ImagenesPME");

                if (!Directory.Exists(rutaCarpetaDestino)) {
                    Directory.CreateDirectory(rutaCarpetaDestino);
                }

                string nombreSubcarpeta = this.pnombre + "_" + this.sapellido + "_" + this.cedula;
                string rutaSubcarpetaDestino = Path.Combine(rutaCarpetaDestino, nombreSubcarpeta);

                if (!Directory.Exists(rutaSubcarpetaDestino)) {
                    Directory.CreateDirectory(rutaSubcarpetaDestino);
                }

                string nombreArchivoFoto = this.pnombre + "_" + this.papellido + "_" + this.cedula + "_Foto.jpg";
                string nombreArchivoFirma = this.pnombre + "_" + this.papellido + "_" + this.cedula + "_Firma.jpg";

                this.rutaFotog = Path.Combine(rutaSubcarpetaDestino, nombreArchivoFoto);
                this.rutaFirmag = Path.Combine(rutaSubcarpetaDestino, nombreArchivoFirma);

                File.Copy(this.rutaFoto, this.rutaFotog, true);
                File.Copy(this.rutaFirma, this.rutaFirmag, true);

                // Guardar la ruta relativa a la carpeta "Imagenes"
                this.rutaFotog = Path.Combine("Imagenes", nombreSubcarpeta, nombreArchivoFoto);
                this.rutaFirmag = Path.Combine("Imagenes", nombreSubcarpeta, nombreArchivoFirma);

                string mensaje = SocioN.insertarSocio(0, this.cod, this.pnombre, this.snombre, this.papellido, this.sapellido, this.cedula, this.celular, this.rutaFotog, this.rutaFirmag, this.rolFk, this.provinciaFk, false);
                MessageBox.Show(mensaje, "Registrar Socio!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.limpiarDatos();
            }
        }

        #endregion

        #region btn Abrir Foto
        private void btnAbrirFoto_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string rutaImagen = openFileDialog.FileName;
                pbFoto.ImageLocation = rutaImagen;
                pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                this.rutaFoto = rutaImagen;
            }
            this.verificarCampos();
        }
        #endregion

        #region btn Abrir Firma
        private void btnAbrirFirma_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string rutaImagen = openFileDialog.FileName;
                pbFirma.ImageLocation = rutaImagen;
                pbFirma.SizeMode = PictureBoxSizeMode.StretchImage;
                this.rutaFirma = rutaImagen;
            }
            this.verificarCampos();
        }
        #endregion

        #region btn Cerrar
        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Owner.Dispose();
            this.Dispose();

        }
        private void btnCerrar_MouseHover(object sender, EventArgs e) {
            btnCerrar.BackgroundImage = Resources._55icone_fermer_et_x_vert;
        }
        private void btnCerrar_MouseLeave(object sender, EventArgs e) {
            btnCerrar.BackgroundImage = Resources.equis_blanca;
        }
        #endregion

        #region btn MINIMIZAR
        private void btnMinimizar_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region btn Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e) {
            this.limpiarDatos();
        }
        #endregion

        #region btn Regresar
        private void btnRegresar_Click(object sender, EventArgs e) {
            this.Owner.Show();
            this.Dispose();
        }
        #endregion

        #endregion

        #region TEXTBOXS

        #region Nombres

        #region txt Primer Nombre
        private void txtPnombre_TextChanged(object sender, EventArgs e) {
            this.txtPnombre.Text.ToUpper();
            this.verificarCampos();
        }
        #endregion

        #region txt Segundo Nombre
        private void txtSnombre_TextChanged(object sender, EventArgs e) {
            this.txtSnombre.Text.ToUpper();
            this.verificarCampos();
        }
        #endregion

        #endregion

        #region Apellidos

        #region Primer Apellido
        private void txtPapellido_TextChanged(object sender, EventArgs e) {
            this.txtPapellido.Text.ToUpper();
            this.verificarCampos();
        }
        #endregion

        #region Segundo Apellido
        private void txtSapellido_TextChanged(object sender, EventArgs e) {
            this.txtSapellido.Text.ToUpper();
            this.verificarCampos();
        }
        #endregion

        #endregion

        #region Cedula
        private void txtCedula_TextChanged(object sender, EventArgs e) {
            this.verificarCampos();
        }
        private void txtCedula_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) {
            this.verificarCampos();
        }
        private void txtCedula_Enter(object sender, EventArgs e) {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtCedula.Select(0, 0);
            });
        }
        #endregion

        #region Celular
        private void txtCelular_TextChanged(object sender, EventArgs e) {
            this.verificarCampos();
        }
        private void txtCelular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) {
            this.verificarCampos();
        }
        private void txtCelular_Enter(object sender, EventArgs e) {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtCelular.Select(0, 0);
            });
        }
        #endregion

        #endregion

        #region COMBOBOX

        #region cbx Provincia
        private void cbxProvincia_SelectedIndexChanged(object sender, EventArgs e) {
            this.verificarCampos();
        }
        #endregion

        #region cbx Rol
        private void cbxRol_SelectedIndexChanged(object sender, EventArgs e) {
            this.verificarCampos();
        }

        #endregion

        #endregion

        #region LOAD
        private void Dirigente_Load(object sender, EventArgs e) {
            this.MostrarProvincias();
            this.MostrarRoles();
            this.verificarCampos();
            this.limpiarDatos();
        }
        #endregion

        #region METODOS

        #region Mapeo Provincias
        private void MostrarProvincias() {
            cbxProvincia.DataSource = ProvinciaN.Obtener();
            cbxProvincia.DisplayMember = "provincia";
            cbxProvincia.ValueMember = "id";

        }
        #endregion

        #region Mapeo Roles
        private void MostrarRoles() {
            cbxRol.DataSource = RolN.Obtener();
            cbxRol.DisplayMember = "cargo";
            cbxRol.ValueMember = "id";
        }
        #endregion

        #region Verificar Campos
        private void verificarCampos() {
            if (!(txtCedula.Text.Length != 10 || string.IsNullOrEmpty(txtPnombre.Text) ||
                string.IsNullOrEmpty(txtPapellido.Text) || txtCelular.Text.Length != 10 ||
                pbFoto.Image == null || pbFirma == null || string.IsNullOrEmpty(cbxProvincia.Text) ||
                string.IsNullOrEmpty(cbxRol.Text))) {
                btnGuardar.Enabled = true;
            } else { btnGuardar.Enabled = false; }
        }
        #endregion

        #region Limpiar Campos
        private void limpiarDatos() {
            this.txtPnombre.Text = string.Empty;
            this.txtSnombre.Text = string.Empty;
            this.txtPapellido.Text = string.Empty;
            this.txtSapellido.Text = string.Empty;
            this.txtCedula.Text = string.Empty;
            this.txtCelular.Text = string.Empty;
            this.cbxProvincia.Text = string.Empty;
            this.cbxRol.Text = string.Empty;
            this.pbFoto.Image = null;
            this.pbFirma.Image = null;

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
