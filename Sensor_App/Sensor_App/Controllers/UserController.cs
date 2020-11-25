using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sensor_App.DBContext;
using Sensor_App.Interfaces;
using Sensor_App.Models;

namespace Sensor_App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginUserModel user)
        {
            string resultado = "Fail";
            var getUser = await _unitOfWork.UserRepository.AuthenticationAsync(user.Usuario, user.Contrasenia);
            if (getUser != null)
            {
                ClaimsIdentity identity = null;
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, getUser.NombreUsuario),
                    new Claim(ClaimTypes.Role,"Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                foreach (var item in getUser.Permisos)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, item.Permiso.ToString()));
                }
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                HttpContext.Session.SetString("LoginName", getUser.Nombre);
                resultado = "Sucess";
            }
            return Json(resultado);
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            var resultado = "Fail";
            try
            {
                await HttpContext.SignOutAsync();
                HttpContext.Session.Clear();
                resultado = "Success";
                return Json(resultado);
            }
            catch (Exception e)
            {

                return Json(resultado);
            }
            
        }

        [HttpGet]
        public IActionResult Inicio()
        {
            return View();
        }

        [Authorize(Roles = "Listado_Usuario")]
        [HttpGet]
        public async Task<ActionResult> ListaUsuarios()
        {
            return View(await _unitOfWork.UserRepository.GetAllAsync());
        }

        [Authorize(Roles = "Alta_Usuario")]
        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }
    }
}
