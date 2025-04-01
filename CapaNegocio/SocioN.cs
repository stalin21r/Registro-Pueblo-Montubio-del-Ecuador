using CapaDatos;

namespace CapaNegocio {
    public class SocioN {
        public static string insertarSocio(int id, string code, string pnombre, string snombre, string papellido, string sapellido, string cedula, string celular, string rutaFoto, string rutaFirma, int rolFk, int provinciaFk, bool estado) {
            SocioBD socio = new SocioBD() {
                Id = id,
                Cod = code,
                Pnombre = pnombre,
                Snombre = snombre,
                Papellido = papellido,
                Sapellido = sapellido,
                Cedula = cedula,
                Celular = celular,
                RutaFoto = rutaFoto,
                RutaFirma = rutaFirma,
                RolFk = rolFk,
                ProvinciaFk = provinciaFk,
                Estado = estado
            };

            return socio.InsertarSocio(socio);
        }

        public static string obtenerUltimoCod(int provinciaId) {
            return new SocioBD().recuperarUltimoCodigo(provinciaId);
        }
    }
}
