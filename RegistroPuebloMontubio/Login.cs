using RegistroPuebloMontubio.Properties;
using System;
using System.Text;
using System.Windows.Forms;
using CapaNegocio;
using System.Net.Mail;
using System.Drawing;
using System.Net.Mime;
using System.Net;


namespace RegistroPuebloMontubio {
    public partial class Login : Form {

        #region ATRIBUTOS
        private StringBuilder _pressedKeys = new StringBuilder();
        
        #endregion

        #region Constructor
        
        public Login() {
            InitializeComponent();


            //this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

        }
        #endregion

        #region BUTTONS

        #region btn Cerrar
        private void btnCerrar_MouseHover(object sender, EventArgs e) {
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e) {
            btnCerrar.BackgroundImage = Resources.icone_fermer_et_x_vert;
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e) {
            btnCerrar.BackgroundImage = Resources.equis_blanca;
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Dispose();
        }
        #endregion

        #region btn Ingresar
        private void btnIngresar_Click(object sender, EventArgs e) {
            if (!(this.txtUser.Text.Equals("Usuario o correo") || this.txtContraseña.Text.Equals("Contraseña"))) {
                bool verificar = UsuarioN.verificarUsuario(this.txtUser.Text, this.txtContraseña.Text);
                if (verificar) {
                    Menu menu = new Menu(false);
                    this.Hide();
                    menu.ShowDialog();
                    this.Dispose();
                } else {
                    MessageBox.Show("Usuario o contraseña incorrectos!!", "Credenciales erroneas!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    limpiarDatos();
                }
            } else { MessageBox.Show("Ingrese su usuario y contraseña!!", "Datos incompletos!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

        }
        #endregion

        #region btn Recuperar Contraseña
        private void lblFPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string[] values = new string[2];
            values = UsuarioN.obtenerContraseña(txtUser.Text);

            if (values != null) {
                MailMessage ms = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                ms.From = new MailAddress("mi_From");

                ms.Subject = "Recuperacion de Contraseña - Registro Nacional Montubio";

                string styles = @"
                                    body {
                                      font-family: Arial, sans-serif;
                                      background-color: #f1f1f1;
                                      margin: 0;
                                      padding: 0;
                                    }
                                
                                    .container {
                                      max-width: 600px;
                                      margin: 50px auto;
                                      background-color: #fff;
                                      border-radius: 30px;
                                      box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16);
                                      padding: 30px;
                                      border: 7px solid #5D5D5D;
                                    }
                                
                                    .logo {
                                      display: flex;
                                      justify-content: center;
                                      align-items: center;
                                      margin-bottom: 30px;
                                    }
                                
                                    .logo img {
                                      max-width: 150px;
                                    }
                                
                                    h1 {
                                      color: #34b37e;
                                      margin-bottom: 30px;
                                    }
                                
                                    p {
                                      color: #555;
                                      font-size: 16px;
                                      line-height: 1.6;
                                      margin-bottom: 20px;
                                    }
                                
                                    .password {
                                      background-color: #34b37e;
                                      padding: 15px;
                                      border-radius: 5px;
                                      font-size: 18px;
                                      color: #fff;
                                      text-align: center;
                                      margin-bottom: 20px;
                                    }
                                
                                    .warning {
                                      background-color: #ffc107;
                                      color: #555;
                                      font-size: 20px;
                                      padding: 15px;
                                      border-radius: 5px;
                                      text-align: center;
                                      margin-top: 30px;
                                    }";

                string html = $@"
                                <!DOCTYPE html>
                                <html lang=""en"">
                                <head>
                                  <meta charset=""UTF-8"">
                                  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                                  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                  <title>Recuperación de contraseña</title>
                                  <style>
                                    {styles}
                                  </style>
                                </head>
                                <body>
                                  <div class=""container"">
                                    <div class=""logo"">
                                      <img src=""https://files.fm/thumb_show.php?i=n9anbcbpb"" alt=""Logo"">
                                    </div>
                                    <h1>Recuperación de contraseña</h1>
                                    <p>Hola {values[2]},</p>
                                    <p>Hemos recibido una solicitud para restablecer tu contraseña.</p>
                                    <div class=""password"">
                                      CONTRASEÑA: {values[1]}
                                    </div>
                                    <p>Utiliza esta contraseña para iniciar sesión en tu cuenta.</p>
                                    <div class=""warning"">
                                      ¡Advertencia! Si no solicitaste restablecer tu contraseña, avisa a la organización.
                                    </div>
                                    <p>Gracias,</p>
                                    <p>El equipo de PUEBLO MONTUBIO DEL ECUADOR - PME</p>
                                  </div>
                                </body>
                                </html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
                ms.AlternateViews.Add(htmlView);

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                smtp.Credentials = new NetworkCredential("mi_correo_gmail", "mi_service_password");
                smtp.EnableSsl = true;

                try {
                    ms.To.Add(new MailAddress(values[0]));
                    smtp.Send(ms);
                    MessageBox.Show("Se han enviado sus credenciales al correo :\n" + HideEmail(values[0]) + "\n\nNota: Si no encuentras el correo\nbuscalo en no deseados", "Recuperar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarDatos();
                } catch (Exception) {
                    MessageBox.Show("Error al recuperar contraseña, correo no enviado!!", "Recuperar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Usuario no registrado!!", "Recuperar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        #region TEXTBOXS

        #region txt User

        private void txtUser_Enter(object sender, EventArgs e) {
            if (txtUser.Text.Equals("Usuario o correo")) {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e) {
            if (txtUser.Text.Equals("")) {
                txtUser.Text = "Usuario o correo";
                txtUser.ForeColor = System.Drawing.SystemColors.ScrollBar;
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) { this.btnIngresar.PerformClick(); }
        }

        #endregion

        #region txt Contraseña
        private void txtContraseña_Enter(object sender, EventArgs e) {
            if (txtContraseña.Text.Equals("Contraseña")) {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.Black;
                txtContraseña.UseSystemPasswordChar = true;
                if (Control.IsKeyLocked(Keys.CapsLock)) {
                    //this.lblMayus.Text = "Las mayusculas estan activadas"; 
                } else {
                    //this.lblMayus.Text = "";
                }

            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e) {
            if (txtContraseña.Text.Equals("")) {
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = System.Drawing.SystemColors.ScrollBar;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) { this.btnIngresar.PerformClick(); }
        }
        #endregion

        #endregion

        #region LOAD
        private void Login_Load(object sender, EventArgs e) {

        }
        #endregion

        #region METODOS
        static string HideEmail(string email) {
            // Encontrar el índice de "@" para dividir el nombre de usuario y el dominio
            int atIndex = email.IndexOf("@");

            // Obtener el nombre de usuario y el dominio
            string username = email.Substring(0, atIndex);
            string domain = email.Substring(atIndex);

            // Ocultar parte del nombre de usuario
            string hiddenUsername = username[0] + new string('*', username.Length - 2) + username[username.Length - 1];

            // Combinar el nombre de usuario oculto con el dominio
            return hiddenUsername + domain;
        }

        private void limpiarDatos() {
            this.txtContraseña.Text = "Contraseña";
            this.txtContraseña.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtContraseña.UseSystemPasswordChar = false;
            this.txtUser.Text = "Usuario o correo";
            this.txtUser.ForeColor = System.Drawing.SystemColors.ScrollBar;
        }

        #endregion

       

    }
}
