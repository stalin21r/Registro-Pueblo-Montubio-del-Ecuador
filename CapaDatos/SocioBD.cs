using MySqlConnector;
using System;
using System.Data;

namespace CapaDatos {
    public class SocioBD {

        #region Atributos
        private int id;
        private string cod;
        private string pnombre;
        private string snombre;
        private string papellido;
        private string sapellido;
        private string cedula;
        private string celular;
        private string rutaFoto;
        private string rutaFirma;
        private int rolFk;
        private int provinciaFk;
        private bool estado;
        #endregion

        #region Constructores
        public SocioBD() { }
        public SocioBD(int id, string code, string pnombre, string snombre, string papellido, string sapellido, string cedula, string celular, string rutaFoto, string rutaFirma, int rolFk, int provinciaFk, bool estado) {
            this.id = id;
            this.cod = code;
            this.pnombre = pnombre;
            this.snombre = snombre;
            this.papellido = papellido;
            this.sapellido = sapellido;
            this.cedula = cedula;
            this.celular = celular;
            this.rutaFoto = rutaFoto;
            this.rutaFirma = rutaFirma;
            this.rolFk = rolFk;
            this.provinciaFk = provinciaFk;
            this.estado = estado;
        }
        #endregion

        #region Propiedades
        public int Id { get => id; set => id = value; }
        public string Cod { get => cod; set => cod = value; }
        public string Pnombre { get => pnombre; set => pnombre = value; }
        public string Snombre { get => snombre; set => snombre = value; }
        public string Papellido { get => papellido; set => papellido = value; }
        public string Sapellido { get => sapellido; set => sapellido = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Celular { get => celular; set => celular = value; }
        public string RutaFoto { get => rutaFoto; set => rutaFoto = value; }
        public string RutaFirma { get => rutaFirma; set => rutaFirma = value; }
        public int RolFk { get => rolFk; set => rolFk = value; }
        public int ProvinciaFk { get => provinciaFk; set => provinciaFk = value; }
        public bool Estado { get => estado; set => estado = value; }
        #endregion

        #region Metodo Insertar
        public string InsertarSocio(SocioBD socio) {

            string respuesta = " ";
            var conexionSql = new MySqlConnection(AccesoBD.conexion());

            try {
                conexionSql.Open();
                string query = "INSERT INTO tblSocio (cod, pnombre, snombre, papellido, sapellido, cedula, celular, rutaFoto, rutaFirma, rolFk, provinciaFk)\n" +
                               "Values(@cod, @pnombre, @snombre, @papellido, @sapellido, @cedula, @celular, @rutaFoto, @rutaFirma, @rolFk, @provinciaFk);";

                var comandoSql = new MySqlCommand(query, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                var parCod = new MySqlParameter("@cod", MySqlDbType.VarChar, 50);
                parCod.Value = socio.Cod;
                comandoSql.Parameters.Add(parCod);

                var parPnombre = new MySqlParameter("@pnombre", MySqlDbType.VarChar, 30);
                parPnombre.Value = socio.Pnombre;
                comandoSql.Parameters.Add(parPnombre);

                var parSnombre = new MySqlParameter("@snombre", MySqlDbType.VarChar, 30);
                parSnombre.Value = socio.Snombre;
                comandoSql.Parameters.Add(parSnombre);

                var parPapellido = new MySqlParameter("@papellido", MySqlDbType.VarChar, 30);
                parPapellido.Value = socio.Papellido;
                comandoSql.Parameters.Add(parPapellido);

                var parSapellido = new MySqlParameter("@sapellido", MySqlDbType.VarChar, 30);
                parSapellido.Value = socio.Sapellido;
                comandoSql.Parameters.Add(parSapellido);

                var parCedula = new MySqlParameter("@cedula", MySqlDbType.VarChar, 10);
                parCedula.Value = socio.Cedula;
                comandoSql.Parameters.Add(parCedula);

                var parCelular = new MySqlParameter("@celular", MySqlDbType.VarChar, 10);
                parCelular.Value = socio.Celular;
                comandoSql.Parameters.Add(parCelular);

                var parRutaFoto = new MySqlParameter("@rutaFoto", MySqlDbType.VarChar, 100);
                parRutaFoto.Value = socio.RutaFoto;
                comandoSql.Parameters.Add(parRutaFoto);

                var parrutaFirma = new MySqlParameter("@rutaFirma", MySqlDbType.VarChar, 100);
                parrutaFirma.Value = socio.RutaFirma;
                comandoSql.Parameters.Add(parrutaFirma);

                var parRolFk = new MySqlParameter("@rolFk", MySqlDbType.Int64);
                parRolFk.Value = socio.RolFk;
                comandoSql.Parameters.Add(parRolFk);

                var parProvinciaFk = new MySqlParameter("@provinciaFk", MySqlDbType.Int64);
                parProvinciaFk.Value = socio.ProvinciaFk;
                comandoSql.Parameters.Add(parProvinciaFk);

                respuesta = comandoSql.ExecuteNonQuery() == 1 ? "Socio registrado con Exito!!" : "No se pudo insertar el registro!!";

            } catch (MySqlException e) {
                respuesta = e.Message;
            } finally {
                if (conexionSql.State == ConnectionState.Open) conexionSql.Close();
            }

            return respuesta;

        }
        #endregion

        #region Metodo Recuperar Ultimo Codigo
        public string recuperarUltimoCodigo(int provinciaId) {

            string query = "SELECT max(cod) FROM tblSocio where provinciaFk = @provinciaId limit 1;";
            var conexionSql = new MySqlConnection(AccesoBD.conexion());
            string numCod = "0";

            try {
                conexionSql.Open();
                var comandoSql = new MySqlCommand(query, conexionSql);
                comandoSql.CommandType = CommandType.Text;
                var parProvinciaId = new MySqlParameter("@provinciaId", MySqlDbType.Int64);
                parProvinciaId.Value = provinciaId;
                comandoSql.Parameters.Add(parProvinciaId);
                MySqlDataReader reader = comandoSql.ExecuteReader();

                if (reader.Read()) {
                    numCod = reader.GetString(0);
                }
                int ultimoCeroIndex = 1;

                for (int i = 2; i < numCod.Length; i++) {
                    if (numCod[i] != '0') { break; }
                    ultimoCeroIndex++;
                }


                if (ultimoCeroIndex != -1) {
                    numCod = numCod.Substring(ultimoCeroIndex + 1);
                }

                //numCod = numCod.Substring(numCod.LastIndexOf("0") + 1);


                //MessageBox.Show(numCod.ToString());
            } catch (Exception) {
                numCod = "0";
            } finally { if (conexionSql.State == ConnectionState.Open) conexionSql.Close(); }

            return numCod;

        }
        #endregion
    }
}
