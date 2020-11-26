using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sensor_App.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ViewComponentSample.ViewComponents
{
    public class ListaClientesViewComponent: ViewComponent
    {
        private readonly SensorDbContext _context;

        public ListaClientesViewComponent(SensorDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clientes = await _context.Clientes
                .Where(p => p.Activo == true)
                .ToListAsync();

            return View(clientes);
        }
    }
}
