using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoriaAC
    {
        public int IdCategoria {  get; set; }
        public string Nombre_Categoria { get; set; }
        public string URL_Categoria { get; set; }
        public List<CategoriaAC> Get()
        {
            List<CategoriaAC> categoriaACs = new List<CategoriaAC>();
            string query = "SP_SHOW_CATEGORIA";

            using (SqlConnection sqlConnection = new SqlConnection(Connection.Cn))
            {
                SqlCommand Cmd = new SqlCommand(query, sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = Cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        CategoriaAC categoriaAC = new CategoriaAC()
                        {
                            IdCategoria = Reader.GetInt32(0),
                            Nombre_Categoria = Reader.GetString(1),
                            URL_Categoria = Reader.GetString(2)
                        };
                        categoriaACs.Add(categoriaAC);
                    }
                    Reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener las categorias " + ex.Message);
                }
            }

            return categoriaACs;
        }
        public List<CategoriaAC> Get(string nombre)
        {
            List<CategoriaAC> categoriaACs = new List<CategoriaAC>();
            string query = "SP_SHOWNAME_CATEGORIA";

            using (SqlConnection sqlConnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(query, sqlConnection);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter PmNombre = new SqlParameter();
                    PmNombre.ParameterName = "@NOMBRE_CATEGORIA";
                    PmNombre.Value = nombre;
                    PmNombre.SqlDbType = SqlDbType.VarChar;
                    PmNombre.Size = 50;
                    Cmd.Parameters.Add(PmNombre);
                    sqlConnection.Open();
                    SqlDataReader Reader = Cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        CategoriaAC categoriaAC = new CategoriaAC()
                        {
                            IdCategoria = Reader.GetInt32(0),
                            Nombre_Categoria = Reader.GetString(1),
                            URL_Categoria = Reader.GetString(2)
                        };
                        categoriaACs.Add(categoriaAC);
                    }
                    Reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener la categorias " + ex.Message);
                }
            }

            return categoriaACs;
        }
        public CategoriaAC Get(int id)
        {
            string query = "SP_SHOWID_CATEGORIA";

            using (SqlConnection sqlConnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(query, sqlConnection);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParId = new SqlParameter();
                    ParId.ParameterName = "@ID";
                    ParId.Value = id;
                    ParId.SqlDbType = SqlDbType.Int;
                    Cmd.Parameters.Add(ParId);

                    sqlConnection.Open();
                    SqlDataReader Reader = Cmd.ExecuteReader();
                    Reader.Read();
                    CategoriaAC categoriaAC = new CategoriaAC()
                    {
                         IdCategoria = Reader.GetInt32(0),
                        Nombre_Categoria = Reader.GetString(1),
                        URL_Categoria = Reader.GetString(2)
                    };
                    Reader.Close();
                    sqlConnection.Close();
                    return categoriaAC;

                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener la categorias " + ex.Message);
                }
            }

        }

        public bool Add(CategoriaAC categoria)
        {
            string query = "SP_INSERT_CATEGORIA";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@NOMBRE_CATEGORIA";
                    ParNombre.Value = categoria.Nombre_Categoria;
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 50;
                    sqlCommand.Parameters.Add(ParNombre);

                    SqlParameter ParURL = new SqlParameter();
                    ParURL.ParameterName = "@URL_CATEGORIA";
                    ParURL.Value = categoria.URL_Categoria;
                    ParURL.SqlDbType = SqlDbType.VarChar;
                    ParURL.Size = 260;
                    sqlCommand.Parameters.Add(ParURL);

                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo ingresar la categoria " + ex.Message);
                }
            }
        }
        public bool Update(CategoriaAC categoria)
        {
            string query = "SP_UPDATE_CATEGORIA";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParId = new SqlParameter();
                    ParId.ParameterName = "@IDCATEGORIA";
                    ParId.Value = categoria.IdCategoria;
                    ParId.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParId);

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@NOMBRE_CATEGORIA";
                    ParNombre.Value = categoria.Nombre_Categoria;
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 50;
                    sqlCommand.Parameters.Add(ParNombre);

                    SqlParameter ParURL = new SqlParameter();
                    ParURL.ParameterName = "@URL_CATEGORIA";
                    ParURL.Value = categoria.URL_Categoria;
                    ParURL.SqlDbType = SqlDbType.VarChar;
                    ParURL.Size = 260;
                    sqlCommand.Parameters.Add(ParURL);

                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo actualizar la categoria " + ex.Message);
                }
            }
        }
        public bool Delete(int id)
        {
            string query = "SP_DELETE_CATEGORIA";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParId = new SqlParameter();
                    ParId.ParameterName = "@IDCATEGORIA";
                    ParId.Value = id;
                    ParId.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParId);

                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo eliminar la categoria " + ex.Message);
                }
            }
        }
    }
}
