using Data;
using Data.Models;
using Models;

namespace Service
{
    public class ProductoService
    {
        private readonly ProductoRepository _productoRepository;
        public ProductoService(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public void Add(ProductoModel productoModel)
        {
            Producto productoEntity = new Producto();
            productoEntity += productoModel;
            _productoRepository.Add(productoEntity);
        }
        public ProductoModel Get(int id)
        {
            Producto productoEntity = _productoRepository.Get(id);
            if (productoEntity == null) return null;
            
            ProductoModel productoModel = new ProductoModel();
            productoModel += productoEntity;
            return productoModel;
        }
        public IEnumerable<ProductoModel> Get(int limit, int page)
        {
            limit = limit <= 0  || limit > 10 ? 10 : limit;
            page = (page - 1) * limit;
            
            var productoEntities = _productoRepository.Get(limit, page);
            List<ProductoModel> productoModels = new List<ProductoModel>();
            
            foreach (Producto item in productoEntities)
            {
                ProductoModel temp = new ProductoModel();
                temp += item;
                productoModels.Add(temp);
            }
            return productoModels;
        }
        public void Update(ProductoModel producto)
        {
            Producto productoEntity = new Producto();
            productoEntity += producto;
            _productoRepository.Update(productoEntity);
        }
        public void Delete(ProductoModel producto)
        {
            Producto productoEntity = new Producto();
            productoEntity += producto;
            _productoRepository.Delete(productoEntity);
        }
    }
}