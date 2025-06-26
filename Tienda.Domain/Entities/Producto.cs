using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        public string Talla { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Talla))
                throw new ArgumentException("La talla es obligatoria");

            if (string.IsNullOrWhiteSpace(Color))
                throw new ArgumentException("El color es obligatorio");

            if (Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0");

            if (string.IsNullOrWhiteSpace(Descripcion))
                throw new ArgumentException("La descripción es obligatoria");
        }
    }
}

