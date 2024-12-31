using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SalonAC
    {
        public int Id_Salon {  get; set; }
        public string Nombre_Salon { get; set; }
        public string Ubicacion {  get; set; }
        public List<SalonAC> Get()
        {
            List<SalonAC> salonACs = new List<SalonAC>();
            string query = "SP_SHOW_SALON";

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
                        SalonAC salonAC = new SalonAC()
                        {
                            Id_Salon = Reader.GetInt32(0),
                            Nombre_Salon = Reader.GetString(1),
                            Ubicacion = Reader.GetString(2)
                        };
                        salonACs.Add(salonAC);
                    }
                    Reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener los salones " + ex.Message);
                }

                return salonACs;
            }
        }
        public List<SalonAC> Get(string name)
        {
            List<SalonAC> salonACs = new List<SalonAC>();
            string query = "SP_SHOWNAME_SALON";

            using (SqlConnection sqlConnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(query, sqlConnection);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@NOMBRE_SALON";
                    ParNombre.Value = name;
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 50;
                    Cmd.Parameters.Add(ParNombre);

                    sqlConnection.Open();
                    SqlDataReader Reader = Cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        SalonAC salonAC = new SalonAC()
                        {
                            Id_Salon = Reader.GetInt32(0),
                            Nombre_Salon = Reader.GetString(1),
                            Ubicacion = Reader.GetString(2)
                        };
                        salonACs.Add(salonAC);
                    }
                    Reader.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener los salones " + ex.Message);
                }

                return salonACs;
            }
        }
        public SalonAC Get(int id)
        {
            string query = "SP_SHOWID_SALON";

            using (SqlConnection sqlConnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(query, sqlConnection);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParID = new SqlParameter();
                    ParID.ParameterName = "@ID";
                    ParID.Value = id;
                    ParID.SqlDbType = SqlDbType.Int;
                    Cmd.Parameters.Add(ParID);

                    sqlConnection.Open();
                    SqlDataReader Reader = Cmd.ExecuteReader();
                    Reader.Read();
                    SalonAC salonAC = new SalonAC()
                    {
                        Id_Salon = Reader.GetInt32(0),
                        Nombre_Salon = Reader.GetString(1),
                        Ubicacion = Reader.GetString(2)
                    };
                    Reader.Close();
                    sqlConnection.Close();
                    return salonAC;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo obtener los salones " + ex.Message);
                }

            }
        }

        public bool Add(SalonAC salonAC)
        {
            string query = "SP_INSERT_SALON";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@NOMBRE_SALON";
                    ParNombre.Value = salonAC.Nombre_Salon;
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 50;
                    sqlCommand.Parameters.Add(ParNombre);

                    SqlParameter ParUbicacion = new SqlParameter();
                    ParUbicacion.ParameterName = "@UBICACION";
                    ParUbicacion.Value = salonAC.Ubicacion;
                    ParUbicacion.SqlDbType = SqlDbType.VarChar;
                    ParUbicacion.Size = 150;
                    sqlCommand.Parameters.Add(ParUbicacion);

                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo ingresar el salon " + ex.Message);
                }
            }
        }
        public bool Update(SalonAC salonAC)
        {
            string query = "SP_UPDATE_SALON";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParId = new SqlParameter();
                    ParId.ParameterName = "@IDSALON";
                    ParId.Value = salonAC.Id_Salon;
                    ParId.SqlDbType = SqlDbType.Int;
                    sqlCommand.Parameters.Add(ParId);

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@NOMBRE_SALON";
                    ParNombre.Value = salonAC.Nombre_Salon;
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 50;
                    sqlCommand.Parameters.Add(ParNombre);

                    SqlParameter ParUbicacion = new SqlParameter();
                    ParUbicacion.ParameterName = "@UBICACION";
                    ParUbicacion.Value = salonAC.Ubicacion;
                    ParUbicacion.SqlDbType = SqlDbType.VarChar;
                    ParUbicacion.Size = 150;
                    sqlCommand.Parameters.Add(ParUbicacion);

                    sqlconnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo ingresar el salon " + ex.Message);
                }
            }
        }
        public bool Delete(int id)
        {
            string query = "SP_DELETE_SALON";

            using (SqlConnection sqlconnection = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParId = new SqlParameter();
                    ParId.ParameterName = "@IDSALON";
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
                    throw new Exception("No se pudo eliminar el salon " + ex.Message);
                }
            }
        }

    }
}
