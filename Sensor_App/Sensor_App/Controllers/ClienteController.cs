using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sensor_App.Interfaces;
using Sensor_App.Models;

namespace Sensor_App.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClienteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles = "Listado_Cliente")]
        [HttpGet]
        public async Task<ActionResult> ListaClientes()
        {
            var clientes = await _unitOfWork.ClienteRepository.GetAllAsync();
            return View(clientes);
        }

        public ActionResult Crear()
        {
            return View(new Cliente());
        }
    }
}
