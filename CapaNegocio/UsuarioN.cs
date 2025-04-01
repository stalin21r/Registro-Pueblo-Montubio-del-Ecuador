using CapaDatos;

namespace CapaNegocio {
    public class UsuarioN {
        public static bool verificarUsuario(string user, string pass) {
            UsuarioBD usuario = new UsuarioBD();
            return usuario.VerificarUsuario(user, pass);
        }

        public static string[] obtenerContraseña(string user) {
            UsuarioBD usuario = new UsuarioBD();
            return usuario.recuperarContraseña(user);
        }
    }
}
