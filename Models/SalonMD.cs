using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalonMD
    {
        public List<SalonAC> Get()
        {
            SalonAC salon = new SalonAC();
            return salon.Get();
        }
        public List<SalonAC> Get(string nombre)
        {
            SalonAC salon = new SalonAC();
            return salon.Get(nombre);
        }
        public SalonAC Get(int id)
        {
            SalonAC salon = new SalonAC();
            return salon.Get(id);
        }

        public bool Add(string nombre, string ubicacion)
        {
            SalonAC salon = new SalonAC();
            salon.Nombre_Salon = nombre;
            salon.Ubicacion = ubicacion;
            return salon.Add(salon);
        }
        public bool Update(string nombre, string ubicacion, int id)
        {
            SalonAC salon = new SalonAC();
            salon.Id_Salon = id;
            salon.Nombre_Salon = nombre;
            salon.Ubicacion = ubicacion;
            return salon.Update(salon);
        }
        public bool Delete(int id)
        {
            SalonAC salon = new SalonAC();
            return salon.Delete(id);
        }
    }
}
