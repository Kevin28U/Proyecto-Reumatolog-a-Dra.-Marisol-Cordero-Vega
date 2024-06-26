using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_CentroMedico.Recursos;
using Proyecto_Final_CentroMedico.Servicios.Contrato;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;

namespace Proyecto_Final_CentroMedico.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;
        private readonly ClinicaReumatologiaContext _context;
        public LoginController(IUsuarioService usuarioServicio, ClinicaReumatologiaContext context)
        {
            _usuarioServicio = usuarioServicio;
            _context = context;
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {

  
            if (modelo.Contrasena.Length < 5)
            {
                TempData["ErrorMessage"] = "La contraseña debe tener al menos 5 caracteres.";
                return RedirectToAction("IniciarSesion");
            }


            var correoExistente = _context.Usuarios.Any(u => u.CorreoElectronico == modelo.CorreoElectronico);
            if (correoExistente)
            {
                TempData["ErrorMessage"] = "El correo  ya esta registrado.";
                return RedirectToAction("IniciarSesion");
            }


            var usuarioExistente = _context.Usuarios.Any(u => u.NombreUsuario == modelo.NombreUsuario);
            if (usuarioExistente)
            {
                TempData["ErrorMessage"] = "El nombre de usuario ya esta registrado.";
                return RedirectToAction("IniciarSesion");
            }

            modelo.Contrasena = Utilidades.EncriptarClave(modelo.Contrasena);
            modelo.IdRol = 4;

            Usuario usuarioCreado = await _usuarioServicio.SaveUsuario(modelo);

            if (!string.IsNullOrEmpty(usuarioCreado.CorreoElectronico))
            {
                TempData["SuccessMessage"] = "Usuario registrado exitosamente.";
                return RedirectToAction("IniciarSesion");
            }

            TempData["ErrorMessage"] = "No se pudo crear el usuario.";
            return RedirectToAction("IniciarSesion");
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string CorreoElectronico, string Contrasena)
        {
            Usuario usuario_encontrado = await _usuarioServicio.GetUsuario(CorreoElectronico, Utilidades.EncriptarClave(Contrasena));

            if (usuario_encontrado == null)
            {
                TempData["ErrorMessage"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, usuario_encontrado.Nombre),
                new Claim("CorreoElectronico", usuario_encontrado.CorreoElectronico)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Index", "Home");
        }
    }
}
