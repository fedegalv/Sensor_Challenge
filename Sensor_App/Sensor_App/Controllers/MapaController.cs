using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sensor_App.Controllers
{
    public class MapaController : Controller
    {
        [Authorize(Roles = "Visualizacion_Mapa")]
        public IActionResult VerMapa()
        {
            return View();
        }
    }
}
