using MySqlConnector;
using System;
using System.Data;

namespace CapaDatos {
    public class UsuarioBD {

        #region Atributos
        private int id;
        private string nUsuario;
        private string correo;
        private string contraseña;
        #endregion

        public UsuarioBD() { }

        public UsuarioBD(int id, string nUsuario, string correo, string contraseña) {
            this.id = id;
            this.nUsuario = nUsuario;
            this.correo = correo;
            this.contraseña = contraseña;
        }

        public int Id { get => id; set => id = value; }
        public string NUsuario { get => nUsuario; set => nUsuario = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }

        public bool VerificarUsuario(string usuario, string contraseña) {

            string query = "SELECT contrasena FROM tblUsuario where nombre_usuario = @nUser or correo_electronico = @correo;";
            var conexionSql = new MySqlConnection(AccesoBD.conexion());
            string pass = "";
            try {
                conexionSql.Open();
                var comandoSql = new MySqlCommand(query, conexionSql);
                comandoSql.CommandType = CommandType.Text;
                var parUser = new MySqlParameter("@nUser", MySqlDbType.VarChar, 50);
                parUser.Value = usuario;
                comandoSql.Parameters.Add(parUser);

                var parCorreo = new MySqlParameter("@correo", MySqlDbType.VarChar, 100);
                parCorreo.Value = usuario;
                comandoSql.Parameters.Add(parCorreo);

                MySqlDataReader reader = comandoSql.ExecuteReader();

                if (reader.Read()) {
                    pass = reader.GetString(0);
                } else { return false; }

                if (!pass.Equals(contraseña)) return false;
                //numCod = numCod.Substring(numCod.LastIndexOf("0") + 1);


                //MessageBox.Show(pass.ToString());
            } catch (Exception) {
                return false;
            } finally { if (conexionSql.State == ConnectionState.Open) conexionSql.Close(); }

            return true;

        }

        public string[] recuperarContraseña(string usuario) {
            string[] values = new string[3];
            string query = "SELECT correo_electronico, contrasena, nombre_usuario FROM tblUsuario where nombre_usuario = @nUser or correo_electronico LIKE @correo;";
            var conexionSql = new MySqlConnection(AccesoBD.conexion());
            try {
                conexionSql.Open();
                var comandoSql = new MySqlCommand(query, conexionSql);
                comandoSql.CommandType = CommandType.Text;
                var parUser = new MySqlParameter("@nUser", MySqlDbType.VarChar, 50);
                parUser.Value = usuario;
                comandoSql.Parameters.Add(parUser);

                var parCorreo = new MySqlParameter("@correo", MySqlDbType.VarChar, 100);
                parCorreo.Value = usuario;
                comandoSql.Parameters.Add(parCorreo);

                MySqlDataReader reader = comandoSql.ExecuteReader();

                if (reader.Read()) {
                    values[0] = reader.GetString(0);
                    values[1] = reader.GetString(1);
                    values[2] = reader.GetString(2);
                } else { return null; }

            } catch (Exception) {
                return null;
            } finally { if (conexionSql.State == ConnectionState.Open) conexionSql.Close(); }

            return values;
        }
    }
}
