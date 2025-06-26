using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Application.Interfaces;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Tienda.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly TiendaDbContext _context;

        public ProductoService(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> ListarProductosAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> ObtenerProductoPorIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task CrearProductoAsync(Producto producto)
        {
            producto.Validar(); // Validación de dominio
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarProductoAsync(Producto producto)
        {
            producto.Validar();

            var productoExistente = await _context.Productos.FindAsync(producto.Id);
            if (productoExistente == null)
            {
                throw new KeyNotFoundException("Producto no encontrado.");
            }

            productoExistente.Talla = producto.Talla;
            productoExistente.Color = producto.Color;
            productoExistente.Precio = producto.Precio;
            productoExistente.Descripcion = producto.Descripcion;

            await _context.SaveChangesAsync();
        }

        public async Task EliminarProductoAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                throw new KeyNotFoundException("Producto no encontrado.");
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }
    }
}

