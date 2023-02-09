using Data;
using Data.Models;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Services
{
    public class VentaService
    {
        private readonly VentaRepository _ventaRepository;
        private ProductoRepository _productoRepository;
        public VentaService(VentaRepository ventaRepository)
        {
            this._ventaRepository = ventaRepository;
            this._productoRepository = new ProductoRepository(_ventaRepository.context);
        }

        public IEnumerable<VentaModel> Get()
        {
            IEnumerable<Venta> ventas = _ventaRepository.Get();
            List<VentaModel> ventaModels = new List<VentaModel>();

            foreach (Venta venta in ventas)
            {
                VentaModel ventaModel = new VentaModel();
                ventaModel += venta;
                ventaModels.Add(ventaModel);
            }
            return ventaModels;
        }

        public bool Post(VentaDTO ventaModel)
        {
            Venta venta = new Venta
            {
                total = 0,
                tazas = 0,
                fecha = DateTime.Now,
                Productos_Venta = new List<Producto_Venta>()
            };
            List<Producto> updatedProducts = new List<Producto>();
  
            foreach (var item in ventaModel.Productos)
            {   
                Producto producto = _productoRepository.Get(item.id_Producto);
                if (producto.stock < item.cantidad)
                    return false;
                
                producto.stock -= item.cantidad;
                updatedProducts.Add(producto);
                
                venta.total += producto.precio * item.cantidad;
                Producto_Venta producto_Venta = new Producto_Venta
                {
                    id_Producto = item.id_Producto,
                    cantidad = item.cantidad,
                    precio = producto.precio
                };
                venta.Productos_Venta.Add(producto_Venta);
            }
            venta.tazas = (venta.total * 13) / 100;
            venta.total += venta.tazas;

            foreach (var item in updatedProducts)
                _productoRepository.Update(item);
            
            _ventaRepository.Add(venta);
            return true;
        }
    }
}
