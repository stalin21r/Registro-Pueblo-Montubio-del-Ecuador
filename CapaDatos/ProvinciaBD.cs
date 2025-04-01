using MySqlConnector;
using System.Data;

namespace CapaDatos {
    public class ProvinciaBD {
        private int id;
        private string provincia;

        public ProvinciaBD() { }
        public ProvinciaBD(int id, string provincia) {
            this.id = id;
            this.provincia = provincia;
        }

        public int Id { get => id; set => id = value; }
        public string Provincia { get => provincia; set => provincia = value; }

        public DataTable ObtenerProvincias() {
            var resultadoTabla = new DataTable("provincias");
            var conexionSql = new MySqlConnection(AccesoBD.conexion());

            try {
                var comandoSql = new MySqlCommand("SELECT * FROM tblProvincia;", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                var sqlDat = new MySqlDataAdapter(comandoSql);
                sqlDat.Fill(resultadoTabla);
            } catch (MySqlException) {
                resultadoTabla = null;

            }
            return resultadoTabla;
        }

        public string ObtenerCodigoDeProvincia(int provinciaId) {

            string query = "SELECT codProvincia FROM tblProvincia WHERE id = @provinciaId;";
            var conexionSql = new MySqlConnection(AccesoBD.conexion());
            string numCod = "0";
            try {
                conexionSql.Open();
                var comandoSql = new MySqlCommand(query, conexionSql);
                comandoSql.CommandType = CommandType.Text;
                var parProvinciaId = new MySqlParameter("@provinciaId", MySqlDbType.Int64); ;
                parProvinciaId.Value = provinciaId;
                comandoSql.Parameters.Add(parProvinciaId);
                MySqlDataReader reader = comandoSql.ExecuteReader();

                if (reader.Read()) {
                    // Obtiene el valor de la columna codProvincia
                    numCod = reader.GetString(0);

                    // Realiza la operación deseada con el valor codProvincia
                    //Console.WriteLine("Código de provincia: " + codProvincia);
                }

            } catch (MySqlException) {
                numCod = "0";

            } finally { if (conexionSql.State == ConnectionState.Open) conexionSql.Close(); }
            return numCod;
        }
    }
}
