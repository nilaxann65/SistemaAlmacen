using Data.Models;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace SistemaAlmacen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private VentaService ventaService;
        public VentaController(AlmacenContext context)
        {
            ventaService = new VentaService(new Data.VentaRepository(context));
        }

        [HttpGet]
        public ResponseBody Get()
        {
            try {
                IEnumerable<VentaModel> ventas = ventaService.Get();
                return Responses.Success(data: ventas);
            }
            catch
            {
                return Responses.InternalServerError();
            }
        }


        [HttpPost]
        public ResponseBody Post([FromBody] VentaDTO ventaModel)
        {
            try
            {
                bool result = ventaService.Post(ventaModel);
                if (!result)
                    return Responses.BadRequest("No hay suficiente stock para los productos requeridos");
                return Responses.Success();
            }
            catch
            {
                return Responses.InternalServerError();
            }
        }

    }
}
