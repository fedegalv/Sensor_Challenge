using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sensor_App.BusinessLogic;
using Sensor_App.Interfaces;
using Sensor_App.Models;

namespace Sensor_App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
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

            var passwordEncriptada = PasswordHandler.GetSHA256(user.Contrasenia);
            user.Contrasenia = passwordEncriptada;

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
            var users = await _unitOfWork.UserRepository.GetAllUsersAsync();
            return View(users);
        }

        //FUERA DE USO
        //[Authorize(Roles = "Alta_Usuario, Modificacion_Usuario")]
        //[HttpGet]
        //public async Task<ActionResult> CrearOEditar(int id = 0)
        //{
        //    if (id == 0)
        //    {
        //        return View(new User());
        //    }
        //    else
        //    {
        //        var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
        //        return View(user);
        //    }

        //}
        [Authorize(Roles = "Alta_Usuario")]
        [HttpGet]
        public async Task<ActionResult> Crear(int id = 0)
        {
            if (id == 0)
            {
                return View(new User());
            }
            else
            {
                var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
                return View(user);
            }

        }
        [Authorize(Roles = "Modificacion_Usuario")]
        [HttpGet]
        public async Task<ActionResult> Editar(int id = 0)
        {
            if (id == 0)
            {
                return View(new User());
            }
            else
            {
                var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
                return View(user);
            }

        }

        //FUERA DE USO
        //[Authorize(Roles = "Alta_Usuario, Modificacion_Usuario")]
        //[HttpPost]
        //public async Task<ActionResult> CrearOEditar(int id, [Bind("Id, Nombre, Descripcion, NombreUsuario, Contrasenia, Cliente, Permisos")] User user, string Cliente, string[] Permisos)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (id == 0)
        //        {
        //            //GET CLIENTE
        //            //var cliente = await _unitOfWork.ClienteRepository.GetById(Int32.Parse(Cliente));
        //            //PERMISOS
        //            user.ClienteID = Int32.Parse(Cliente);
        //            await _unitOfWork.UserRepository.Add(user);
        //            await _unitOfWork.SaveChangesAsync();
        //            await _unitOfWork.PermisoTipoRepository.AddParameterizedPermiso(Permisos, user.Id);
        //        }
        //        else
        //        {
        //            try
        //            {
        //                user.ClienteID = Int32.Parse(Cliente);
        //                _unitOfWork.UserRepository.Update(user);
        //                await _unitOfWork.SaveChangesAsync();
        //                await _unitOfWork.PermisoTipoRepository.CleanPermisos(user.Id);
        //                await _unitOfWork.PermisoTipoRepository.AddParameterizedPermiso(Permisos, user.Id);
        //            }
        //            catch (Exception)
        //            {
        //                return NotFound();
        //            }
        //        }
        //        return Json(new { isValid = true });
        //    }
        //    return Json(new { isValid = false });
        //}

        [Authorize(Roles = "Modificacion_Usuario")]
        [HttpPost]
        public async Task<ActionResult> Editar(int id, [Bind("Id, Nombre, Descripcion, NombreUsuario, Contrasenia, Cliente, Permisos")] User user, string Cliente, string[] Permisos)
        {
            if (ModelState.IsValid)
            {
                if (id != 0)
                {
                    try
                    {
                        user.ClienteID = Int32.Parse(Cliente);

                        var passwordEncriptada = PasswordHandler.GetSHA256(user.Contrasenia);
                        user.Contrasenia = passwordEncriptada;

                        _unitOfWork.UserRepository.Update(user);
                        await _unitOfWork.SaveChangesAsync();

                        await _unitOfWork.PermisoTipoRepository.CleanPermisos(user.Id);
                        await _unitOfWork.PermisoTipoRepository.AddParameterizedPermiso(Permisos, user.Id);
                    }
                    catch (Exception)
                    {
                        return NotFound();
                    }

                    return Json(new { isValid = true });
                }
                
            }
            return Json(new { isValid = false });
        }

        [Authorize(Roles = "Alta_Usuario")]
        [HttpPost]
        public async Task<ActionResult> Crear(int id, [Bind("Id, Nombre, Descripcion, NombreUsuario, Contrasenia, Cliente, Permisos")] User user, string Cliente, string[] Permisos)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    user.ClienteID = Int32.Parse(Cliente);

                    var passwordEncriptada = PasswordHandler.GetSHA256(user.Contrasenia);
                    user.Contrasenia = passwordEncriptada;

                    await _unitOfWork.UserRepository.Add(user);
                    await _unitOfWork.SaveChangesAsync();

                    await _unitOfWork.PermisoTipoRepository.AddParameterizedPermiso(Permisos, user.Id);
                }
                return Json(new { isValid = true });
            }
            return Json(new { isValid = false });
        }
        [HttpPost]
        [Authorize(Roles = "Baja_Usuario")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            try
            {
                await _unitOfWork.UserRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.PermisoTipoRepository.CleanPermisos(id);
                return Json(new { isValid = true });

            }
            catch (Exception e)
            {
                return Json(new { isValid = false });
            }

        }


    }
}
