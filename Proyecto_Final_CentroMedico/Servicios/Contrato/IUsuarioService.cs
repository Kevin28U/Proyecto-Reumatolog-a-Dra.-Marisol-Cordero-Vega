
namespace Proyecto_Final_CentroMedico.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string CorreoElectronico, string Contrasena);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
