﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sensor_App.Interfaces;
using Sensor_App.Models;
using Sensor_App.Models.Enums;

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
        [Authorize(Roles = "Alta_Cliente")]
        [HttpGet]
        public ActionResult Crear(int id = 0)
        {
            return View(new Cliente());
        }
        [HttpPost]
        [Authorize(Roles = "Alta_Cliente")]
        public async Task<ActionResult> Crear(int id, string RazonSocial, int NroRuc, string Direccion, string Pais, string Ciudad, int CodPostal, ZonaEnum Zona, string Telefono, string Fax, string Email, string Web, EstadoTransitoEnum uruguayTransito, EstadoTransitoEnum cargaSuelta, bool Activo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cliente cliente = new Cliente
                    {
                        RazonSocial = RazonSocial,
                        NroRuc = NroRuc,
                        Direccion = Direccion,
                        Pais = Pais,
                        Ciudad = Ciudad,
                        CodPostal = CodPostal,
                        Zona = Zona,
                        Telefono = Telefono,
                        Fax = Fax,
                        Email = Email,
                        Web = Web,
                        Activo = Activo
                    };

                    if (id == 0)
                    {
                        await _unitOfWork.ClienteRepository.Add(cliente);
                        await _unitOfWork.SaveChangesAsync();
                        //var res = _unitOfWork.ClienteRepository.
                        Seguro seguro = new Seguro
                        {
                            ClienteId = cliente.ClienteId,
                            Uruguay_Transitos = uruguayTransito,
                            Uruguay_Transitos_Carga_Suelta = cargaSuelta
                        };
                        await _unitOfWork.SeguroRepository.Add(seguro);
                        await _unitOfWork.SaveChangesAsync();
                    }
                    return Json(new { isValid = true });
                }
                return Json(new { isValid = false });
            }
            catch (Exception e)
            {

                return Json(new { isValid = false });
            }

        }

        [Authorize(Roles = "Modificacion_Cliente")]
        [HttpGet]
        public async Task<ActionResult> Editar(int id = 0)
        {
            if (id == 0)
            {
                return View(new User());
            }
            else
            {
                var user = await _unitOfWork.ClienteRepository.GetClienteByIdAsync(id);
                return View(user);
            }

        }
    }
}
