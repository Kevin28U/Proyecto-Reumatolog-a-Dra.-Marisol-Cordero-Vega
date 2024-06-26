using Microsoft.EntityFrameworkCore;
using Proyecto_Final_CentroMedico.Servicios.Contrato;


namespace Proyecto_Final_CentroMedico.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ClinicaReumatologiaContext _dbContext;
        public UsuarioService(ClinicaReumatologiaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string CorreoElectronico, string Contrasena)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.CorreoElectronico == CorreoElectronico && u.Contrasena == Contrasena)
                 .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
