using System.Data;
using CapaDatos;

namespace CapaNegocio {
    public class ProvinciaN {
        public static DataTable Obtener() {
            return new ProvinciaBD().ObtenerProvincias();
        }

        public static string ObtenerCodigo(int provinciaId) {
            return new ProvinciaBD().ObtenerCodigoDeProvincia(provinciaId);
        }
    }
}
