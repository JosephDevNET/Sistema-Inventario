using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModeloMD
    {
        public List<ModeloAC> Get()
        {
            ModeloAC modeloAC = new ModeloAC();
            return modeloAC.Get();
        }
        public List<ModeloAC> Get(string nombre)
        {
            ModeloAC modeloAC = new ModeloAC();
            return modeloAC.Get(nombre);
        }
        public ModeloAC Get(int id)
        {
            ModeloAC modeloAC = new ModeloAC();
            return modeloAC.Get(id);
        }
        public List<ModeloAC> GetinCat(int id)
        {
            ModeloAC modeloAC = new ModeloAC();
            return modeloAC.GetinCat(id);
        }

        public bool Add(string nombre_modelo, string marca, string url_modelo, int id_categoria)
        {
            ModeloAC inventarioAC = new ModeloAC
            {
                Nombre_Modelo = nombre_modelo,
                Marca = marca,
                URL_Modelo = url_modelo,
                Id_Categoria = id_categoria
            };

            return inventarioAC.Add(inventarioAC);
        }
        public bool Update(string nombre_modelo, string marca, string url_modelo, int id_categoria, int id_modelo)
        {
            ModeloAC inventarioAC = new ModeloAC
            {
                Id_Modelo = id_modelo,
                Nombre_Modelo = nombre_modelo,
                Marca = marca,
                URL_Modelo = url_modelo,
                Id_Categoria = id_categoria
            };

            return inventarioAC.Update(inventarioAC);
        }
        public bool Delete(int id_modelo)
        {
            ModeloAC modeloAC = new ModeloAC();
            modeloAC.Id_Modelo = id_modelo;
            return modeloAC.Delete(modeloAC);
        }

    }
}
