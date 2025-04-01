using MySqlConnector;
using System.Data;

namespace CapaDatos {
    public class RolBD {

        private int id;
        private string cargo;
        private string tipo;

        public RolBD() { }

        public RolBD(int id, string cargo, string tipo) {
            this.id = id;
            this.cargo = cargo;
            this.tipo = tipo;
        }

        public int Id { get => id; set => id = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public DataTable obtenerRol() {

            var resultadoTabla = new DataTable("roles");
            var conexionSql = new MySqlConnection(AccesoBD.conexion());

            try {
                var comandoSql = new MySqlCommand("SELECT id, cargo as cargo FROM tblRol;", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                var sqlDat = new MySqlDataAdapter(comandoSql);
                sqlDat.Fill(resultadoTabla);
            } catch (MySqlException) {
                resultadoTabla = null;

            }
            return resultadoTabla;
        }
    }
}
