using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class VentaRepository
    {
        public AlmacenContext context;
        public VentaRepository(AlmacenContext context)
        {
            this.context = context;
        }

        public Venta Add(Venta venta)
        {
            context.Ventas.Add(venta);
            context.SaveChanges();
            return venta;
        }
        public IEnumerable<Venta> Get() 
        {
            return context.Ventas.ToList();
        }
    }
}
