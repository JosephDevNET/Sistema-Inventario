using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccess;

namespace Models
{
    public class CategoriaMD
    {
        public List<CategoriaAC> Get()
        {
            CategoriaAC categoriaAC = new CategoriaAC();
            return categoriaAC.Get();
        }
        public List<CategoriaAC> Get(string nombre)
        {
            CategoriaAC categoriaAC = new CategoriaAC();
            return categoriaAC.Get(nombre);
        }
        public CategoriaAC Get(int id)
        {
            CategoriaAC categoriaAC = new CategoriaAC();
            return categoriaAC.Get(id);
        }

        public bool Add(string nombre, string url)
        {
            CategoriaAC categoriaAC = new CategoriaAC();
            categoriaAC.Nombre_Categoria = nombre;
            categoriaAC.URL_Categoria = url;
            return categoriaAC.Add(categoriaAC);
        }
        public bool Update(string nombre, string url,int id)
        {
            CategoriaAC categoriaAC = new CategoriaAC();
            categoriaAC.IdCategoria = id;
            categoriaAC.Nombre_Categoria = nombre;
            categoriaAC.URL_Categoria = url;
            return categoriaAC.Update(categoriaAC);
        }
        public bool Delete(int id)
        {
            CategoriaAC categoriaAC = new CategoriaAC();
            return categoriaAC.Delete(id);
        }
    }
}
