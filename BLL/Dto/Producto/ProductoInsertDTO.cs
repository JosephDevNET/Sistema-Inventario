using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto.NewFolder1.Producto
{
    public class ProductoInsertDTO
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int ProveedorID { get; set; }
        public int CategoriaID { get; set; }
    }
}
