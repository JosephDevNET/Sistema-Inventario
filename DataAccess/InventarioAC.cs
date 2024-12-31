using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InventarioAC
    {
        public int Id_Inventario {  get; set; }
        public string Nombre_Salon { get; set; }
        public string Nombre_Modelo { get; set; }
        public int Id_Salon { get; set; }
        public int Id_Modelo { get; set; }
        public int Cantidad {  get; set; }

        public List<InventarioAC> Get()
        {
            List<InventarioAC> inventarioACs = new List<InventarioAC>();
            string query = "SP_SHOW_INVENTARIO";

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
                        InventarioAC inventarioAC = new InventarioAC()
                        {
                            Id_Inventario = Reader.GetInt32(0),
                            Nombre_Salon = Reader.GetString(1),
                            Nombre_Modelo = Reader.GetString(2),
                            Cantidad = Reader.GetInt32(3),

                        };
                        inventarioACs.Add(inventarioAC);
                    }
                    Reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener el inventario " + ex.Message);
                }
            }

            return inventarioACs;
        }
        public List<InventarioAC> Get(int salon)
        {
            List<InventarioAC> inventarioACs = new List<InventarioAC>();
            string query = "SP_SHOWSALON_INVENTARIO";

            using (SqlConnection sqlConnection = new SqlConnection(Connection.Cn))
            {
                SqlCommand Cmd = new SqlCommand(query, sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlParameter ParIdSalon = new SqlParameter();
                    ParIdSalon.ParameterName = "@IDSALON";
                    ParIdSalon.Value = salon;
                    ParIdSalon.SqlDbType = SqlDbType.Int;
                    Cmd.Parameters.Add(ParIdSalon);

                    sqlConnection.Open();
                    SqlDataReader Reader = Cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        InventarioAC inventarioAC = new InventarioAC()
                        {
                            Id_Inventario = Reader.GetInt32(0),
                            Nombre_Salon = Reader.GetString(1),
                            Nombre_Modelo = Reader.GetString(2),
                            Cantidad = Reader.GetInt32(3),

                        };
                        inventarioACs.Add(inventarioAC);
                    }
                    Reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener el inventario " + ex.Message);
                }
            }

            return inventarioACs;
        }
        public List<InventarioAC> GetID(int inventarioc)
        {
            List<InventarioAC> inventarioACs = new List<InventarioAC>();
            string query = "SP_SHOWID_INVENTARIO";

            using (SqlConnection sqlConnection = new SqlConnection(Connection.Cn))
            {
                SqlCommand Cmd = new SqlCommand(query, sqlConnection);
                Cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlParameter ParIdSalon = new SqlParameter();
                    ParIdSalon.ParameterName = "@IDINVENTARIO";
                    ParIdSalon.Value = inventarioc;
                    ParIdSalon.SqlDbType = SqlDbType.Int;
                    Cmd.Parameters.Add(ParIdSalon);

                    sqlConnection.Open();
                    SqlDataReader Reader = Cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        InventarioAC inventarioAC = new InventarioAC()
                        {
                            Id_Inventario = Reader.GetInt32(0),
                            Nombre_Salon = Reader.GetString(1),
                            Nombre_Modelo = Reader.GetString(2),
                            Cantidad = Reader.GetInt32(3),

                        };
                        inventarioACs.Add(inventarioAC);
                    }
                    Reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener el inventario " + ex.Message);
                }
            }

            return inventarioACs;
        }

        public bool Add(InventarioAC inventario)
        {
            string query = "SP_INSERT_INVENTARIO";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    
                    SqlParameter ParSALON = new SqlParameter();
                    ParSALON.ParameterName = "@IDSALON";
                    ParSALON.Value = inventario.Id_Salon;
                    ParSALON.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParSALON);

                    SqlParameter ParMODELO = new SqlParameter();
                    ParMODELO.ParameterName = "@IDMODELO";
                    ParMODELO.Value = inventario.Id_Modelo;
                    ParMODELO.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParMODELO);

                    SqlParameter ParCANTIDAD = new SqlParameter();
                    ParCANTIDAD.ParameterName = "@CANTIDAD";
                    ParCANTIDAD.Value = inventario.Cantidad;
                    ParCANTIDAD.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParCANTIDAD);

                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo ingresar el inventario " + ex.Message);
                }
            }
        }
        public bool Update(InventarioAC inventario)
        {
            string query = "SP_UPDATE_INVENTARIO";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParINVENTARIO = new SqlParameter();
                    ParINVENTARIO.ParameterName = "@IDINVENTARIO";
                    ParINVENTARIO.Value = inventario.Id_Inventario;
                    ParINVENTARIO.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParINVENTARIO);

                    SqlParameter ParSALON = new SqlParameter();
                    ParSALON.ParameterName = "@IDSALON";
                    ParSALON.Value = inventario.Id_Salon;
                    ParSALON.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParSALON);

                    SqlParameter ParMODELO = new SqlParameter();
                    ParMODELO.ParameterName = "@IDMODELO";
                    ParMODELO.Value = inventario.Id_Modelo;
                    ParMODELO.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParMODELO);

                    SqlParameter ParCANTIDAD = new SqlParameter();
                    ParCANTIDAD.ParameterName = "@CANTIDAD";
                    ParCANTIDAD.Value = inventario.Cantidad;
                    ParCANTIDAD.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParCANTIDAD);

                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo actualizar el inventario " + ex.Message);
                }
            }
        }
        public bool Delete(InventarioAC inventario)
        {
            string query = "SP_DELETE_INVENTARIO";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParINVENTARIO = new SqlParameter();
                    ParINVENTARIO.ParameterName = "@IDINVENTARIO";
                    ParINVENTARIO.Value = inventario.Id_Inventario;
                    ParINVENTARIO.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParINVENTARIO);

                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo eliminar el inventario " + ex.Message);
                }
            }
        }

    }
}
