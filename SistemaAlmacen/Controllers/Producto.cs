using Data.Models;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace SistemaAlmacen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ProductoService productoService;
        public ProductoController(AlmacenContext context)
        {
            productoService = new ProductoService(new Data.ProductoRepository(context));
        }

        [HttpGet]
        public ResponseBody Get([FromQuery] string page, [FromQuery] string limit)
        {
            try
            {
                int pageResult = 0;
                int limitResult = 0;
                int.TryParse(page, out pageResult);
                int.TryParse(limit, out limitResult);

                IEnumerable<ProductoModel> result = productoService.Get(limitResult, pageResult);
                return Responses.Success(data: result);
            }
            catch
            {
                return Responses.InternalServerError();
            }
            
            
        }

        [HttpGet("{id}")]
        public ResponseBody Get(int id)
        {
            try
            {
                ProductoModel productoModel = productoService.Get(id);
                if(productoModel == null) 
                    return Responses.NotFound();               

                return Responses.Success(data: productoModel);
            }
            catch
            {
                return Responses.InternalServerError();
            }
        }

        [HttpPost]
        public ResponseBody Post([FromBody] ProductoModel productoModel)
        {
            try
            {
                productoService.Add(productoModel);
                return Responses.Success("Producto Creado Correctamente");
            }
            catch {
                return Responses.InternalServerError();
            }
        }

        [HttpPut("{id}")]
        public ResponseBody Put(int id, [FromBody] ProductoModel productoModel)
        {
            try
            {        
                productoModel.idProducto = id;
                productoService.Update(productoModel);
                return Responses.Success();
            }
            catch
            {
                return Responses.InternalServerError();
            }
        }

        [HttpDelete("{id}")]
        public ResponseBody Delete(int id)
        {
            try
            {
                ProductoModel productoModel = productoService.Get(id);
                if (productoModel == null) 
                    return Responses.NotFound();
                
                productoService.Delete(productoModel);
                return Responses.Success();
            }
            catch
            {
                return Responses.InternalServerError();
            }

        }
    }
}
