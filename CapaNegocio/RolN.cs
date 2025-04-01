using System.Data;
using CapaDatos;

namespace CapaNegocio {
    public class RolN {

        public static DataTable Obtener() {
            return new RolBD().obtenerRol();
        }
    }
}
