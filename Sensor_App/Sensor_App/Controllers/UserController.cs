using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                resultado = "Sucess";
            }
            return Json(resultado);
        }
        [HttpGet]
        public IActionResult Inicio()
        {
            return View();
        }
    }
}
