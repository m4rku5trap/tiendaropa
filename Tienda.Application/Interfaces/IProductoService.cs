using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;

namespace Tienda.Application.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> ListarProductosAsync();
        Task<Producto?> ObtenerProductoPorIdAsync(int id);
        Task CrearProductoAsync(Producto producto);
        Task ActualizarProductoAsync(Producto producto);
        Task EliminarProductoAsync(int id);
    }
}
