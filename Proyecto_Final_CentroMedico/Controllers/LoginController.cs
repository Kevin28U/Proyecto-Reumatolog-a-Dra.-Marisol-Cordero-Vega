using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using Proyecto_Final_CentroMedico.Recursos;
using Proyecto_Final_CentroMedico.Servicios.Contrato;
using System.Security.Claims;

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
       
            var usuarioExistente = _context.Usuarios.Any(u => u.CorreoElectronico == modelo.CorreoElectronico);
            if (usuarioExistente)
            {
                return Json(new { error = "El CorreoElectronico ya existe" });
            }

       
            var correoExistente = _context.Usuarios.Any(u => u.NombreUsuario == modelo.NombreUsuario);
            if (correoExistente)
            {
                return Json(new { error = "Nombre de usuario en uso" });
            }

          
            modelo.Contrasena = Utilidades.EncriptarClave(modelo.Contrasena);

          
            modelo.IdRol = 4; 

            Usuario usuarioCreado = await _usuarioServicio.SaveUsuario(modelo);

            
            if (!string.IsNullOrEmpty(usuarioCreado.CorreoElectronico))
                return RedirectToAction("IniciarSesion", "Login");


            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
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
                ViewData["Mensaje"] = "No se encontraron coincidencias";
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
