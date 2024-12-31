using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class InventarioMD
    {
        public List<InventarioAC> Get()
        {
            InventarioAC inventarioAC = new InventarioAC();
            return inventarioAC.Get();
        }
        public List<InventarioAC> Get(int salon)
        {
            InventarioAC inventarioAC = new InventarioAC();
            return inventarioAC.Get(salon);
        }
        public List<InventarioAC> GetID(int inventario)
        {
            InventarioAC inventarioAC = new InventarioAC();
            return inventarioAC.GetID(inventario);
        }

        public bool Add(int id_salon, int id_modelo, int cantidad)
        {
            InventarioAC inventario = new InventarioAC
            {
                Id_Salon = id_salon,
                Id_Modelo = id_modelo,
                Cantidad = cantidad
            };

            return inventario.Add(inventario);
        }
        public bool Update(int id_salon, int id_modelo, int cantidad, int id_inventario)
        {
            InventarioAC inventario = new InventarioAC
            {
                Id_Inventario = id_inventario,
                Id_Salon = id_salon,
                Id_Modelo = id_modelo,
                Cantidad = cantidad
            };

            return inventario.Update(inventario);
        }
        public bool Delete( int id_inventario)
        {
            InventarioAC inventario = new InventarioAC
            {
                Id_Inventario = id_inventario,
            };

            return inventario.Delete(inventario);
        }

    }
}
