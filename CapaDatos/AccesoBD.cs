namespace CapaDatos {
    public class AccesoBD {
        #region Metodo para crear la conexion a la base de datos

        public static string conexion() {
            //cadena de conexion

            string server = "mi_server\r\n";
            string database = "mi_database\r\n";
            string user = "mi_user";
            string password = "mi_password";
            string cadenaCon = "Database=" + database +
                "; DataSource=" + server +
                "; User Id=" + user +
                "; Password=" + password;

            //se realiza la conexion dent   ro de un try catch en caso de que la conexion sea nula.
            return cadenaCon;

        }
        #endregion
    }
}
