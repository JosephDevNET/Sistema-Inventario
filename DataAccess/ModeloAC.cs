using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ModeloAC
    {
        public int? Id_Modelo {  get; set; }
        public string Nombre_Modelo { get; set; }
        public string Marca {  get; set; }
        public string URL_Modelo { get; set; }
        public int Id_Categoria { get; set; }
        public List<ModeloAC> Get()
        {
            List<ModeloAC> modeloACs = new List<ModeloAC>();
            string query = "SP_SHOW_MODELO";

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
                        ModeloAC modeloAc = new ModeloAC()
                        {
                            Id_Modelo = Reader.GetInt32(0),
                            Nombre_Modelo = Reader.GetString(1),
                            Marca = Reader.GetString(2),
                            URL_Modelo = Reader.GetString(3),
                            Id_Categoria = Reader.GetInt32(4)

                        };
                        modeloACs.Add(modeloAc);
                    }
                    Reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener los modelos " + ex.Message);
                }
            }

            return modeloACs;
        }
        public List<ModeloAC> GetinCat(int id)
        {
            List<ModeloAC> modeloACs = new List<ModeloAC>();
            string query = "SP_SHOWCAT_MODELO";

            using (SqlConnection sqlConnection = new SqlConnection(Connection.Cn))
            {
                SqlCommand Cmd = new SqlCommand(query, sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter PmNombre = new SqlParameter();
                PmNombre.ParameterName = "@IDCATEGORIA";
                PmNombre.Value = id;
                PmNombre.SqlDbType = SqlDbType.Int;
                PmNombre.Size = 50;
                Cmd.Parameters.Add(PmNombre);
                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = Cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        ModeloAC modeloAc = new ModeloAC()
                        {
                            Id_Modelo = Reader.GetInt32(0),
                            Nombre_Modelo = Reader.GetString(1),
                            Marca = Reader.GetString(2),
                            URL_Modelo = Reader.GetString(3),
                            Id_Categoria = Reader.GetInt32(4)

                        };
                        modeloACs.Add(modeloAc);
                    }
                    Reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener los modelos " + ex.Message);
                }
            }

            return modeloACs;
        }
        public List<ModeloAC> Get(string nombre)
        {
            List<ModeloAC> modeloACs = new List<ModeloAC>();
            string query = "SP_SHOWNAME_MODELO";

            using (SqlConnection sqlConnection = new SqlConnection(Connection.Cn))
            {
                SqlCommand Cmd = new SqlCommand(query, sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter PmNombre = new SqlParameter();
                PmNombre.ParameterName = "@NOMBRE_MODELO";
                PmNombre.Value = nombre;
                PmNombre.SqlDbType = SqlDbType.VarChar;
                PmNombre.Size = 50;
                Cmd.Parameters.Add(PmNombre);
                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = Cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        ModeloAC modeloAc = new ModeloAC()
                        {
                            Id_Modelo = Reader.GetInt32(0),
                            Nombre_Modelo = Reader.GetString(1),
                            Marca = Reader.GetString(2),
                            URL_Modelo = Reader.GetString(3),
                            Id_Categoria = Reader.GetInt32(4)

                        };
                        modeloACs.Add(modeloAc);
                    }
                    Reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener los modelos " + ex.Message);
                }
            }

            return modeloACs;
        }
        public ModeloAC Get(int id)
        {
            string query = "SP_SHOWID_MODELO";

            using (SqlConnection sqlConnection = new SqlConnection(Connection.Cn))
            {
                SqlCommand Cmd = new SqlCommand(query, sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@ID";
                ParId.Value = id;
                ParId.SqlDbType = SqlDbType.Int;

                Cmd.Parameters.Add(ParId);
                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = Cmd.ExecuteReader();
                    Reader.Read();
                        ModeloAC modeloAc = new ModeloAC()
                        {
                            Id_Modelo = Reader.GetInt32(0),
                            Nombre_Modelo = Reader.GetString(1),
                            Marca = Reader.GetString(2),
                            URL_Modelo = Reader.GetString(3),
                            Id_Categoria = Reader.GetInt32(4)

                        };
                    Reader.Close();
                    sqlConnection.Close();
                    return modeloAc;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener el modelo " + ex.Message);
                }
            }

        }

        public bool Add(ModeloAC modelo)
        {
            string query = "SP_INSERT_MODELO";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@NOMBRE_MODELO";
                    ParNombre.Value = modelo.Nombre_Modelo;
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 60;
                    sqlCommand.Parameters.Add(ParNombre);

                    SqlParameter ParMarca = new SqlParameter();
                    ParMarca.ParameterName = "@MARCA";
                    ParMarca.Value = modelo.Marca;
                    ParMarca.SqlDbType = SqlDbType.VarChar;
                    ParMarca.Size = 30;
                    sqlCommand.Parameters.Add(ParMarca);

                    SqlParameter ParURL = new SqlParameter();
                    ParURL.ParameterName = "@URL_MODELO";
                    ParURL.Value = modelo.URL_Modelo;
                    ParURL.SqlDbType = SqlDbType.VarChar;
                    ParURL.Size = 260;
                    sqlCommand.Parameters.Add(ParURL);

                    SqlParameter ParId = new SqlParameter();
                    ParId.ParameterName = "@IDCATEGORIA";
                    ParId.Value = modelo.Id_Categoria;
                    ParId.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParId);

                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo ingresar el modelo " + ex.Message);
                }
            }
        }
        public bool Update(ModeloAC modelo)
        {
            string query = "SP_UPDATE_MODELO";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter Id = new SqlParameter();
                    Id.ParameterName = "@IDMODELO";
                    Id.Value = modelo.Id_Modelo;
                    Id.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(Id);

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@NOMBRE_MODELO";
                    ParNombre.Value = modelo.Nombre_Modelo;
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 60;
                    sqlCommand.Parameters.Add(ParNombre);

                    SqlParameter ParMarca = new SqlParameter();
                    ParMarca.ParameterName = "@MARCA";
                    ParMarca.Value = modelo.Marca;
                    ParMarca.SqlDbType = SqlDbType.VarChar;
                    ParMarca.Size = 30;
                    sqlCommand.Parameters.Add(ParMarca);

                    SqlParameter ParURL = new SqlParameter();
                    ParURL.ParameterName = "@URL_MODELO";
                    ParURL.Value = modelo.URL_Modelo;
                    ParURL.SqlDbType = SqlDbType.VarChar;
                    ParURL.Size = 260;
                    sqlCommand.Parameters.Add(ParURL);

                    SqlParameter ParId = new SqlParameter();
                    ParId.ParameterName = "@IDCATEGORIA";
                    ParId.Value = modelo.Id_Categoria;
                    ParId.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParId);

                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo actualizar el modelo " + ex.Message);
                }
            }
        }
        public bool Delete(ModeloAC modelo)
        {
            string query = "SP_DELETE_MODELO";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter Id = new SqlParameter();
                    Id.ParameterName = "@IDMODELO";
                    Id.Value = modelo.Id_Modelo;
                    Id.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(Id);

                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo eliminar el modelo " + ex.Message);
                }
            }
        }
    }
}
