using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace MySQLProyecto.CapaNegocio
{
    public class Autor : IAutor
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);
        public bool Actualizar(string codAutor, string apellidos, string nombres, string nacionalidad)
        {
            try
            {

                //string profesion = txtProfesion.Text.Trim();
                string consulta = "update tautor SET Apellidos=@apellidos, Nombres=@nombres, Nacionalidad=@nacionalidad where CodAutor=@codautor";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //envio de parametros
                comando.Parameters.AddWithValue("@codautor", codAutor);
                comando.Parameters.AddWithValue("@apellidos", apellidos);
                comando.Parameters.AddWithValue("@nombres", nombres);
                comando.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                //ejecutar insert
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1)
                    Listar();
                else
                    return false;
                //Response.Write("No se actualizó");
                return true;
            }
            catch (Exception ex)
            {
                conexion.Close();
                return false;
            }
        }

        public bool Agregar(string codAutor, string apellidos, string nombres, string nacionalidad)
        {
            try
            {
             
                string consulta= "insert into tautor values(@codautor,@apellidos,@nombres,@nacionalidad)";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codautor", codAutor);
                comando.Parameters.AddWithValue("@apellidos", apellidos);
                comando.Parameters.AddWithValue("@nombres", nombres);
                comando.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1)
                    Listar();
                else
                    return false;
                return true;

            }
            catch(Exception ex)
            {
                conexion.Close();
                return false;
            }
        }

        public DataTable Buscar(string codAutor)
        {
            try
            {
                string consulta = "select * from tautor where CodAutor=@codautor";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //envio de parametros
                if (codAutor != "")
                {
                    comando.Parameters.AddWithValue("@codautor", codAutor);
                    //ejecutar insert
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    return tabla;
                }
                else
                {
                    return Listar();
                }
            }
            catch (Exception ex)
            {
                conexion.Close();
                return Listar();
            }
        }

        public bool Eliminar(string codAutor)
        {
            
                try
                {
                    string consulta = "delete from tautor where CodAutor=@codautor";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    //envio de parametros
                    comando.Parameters.AddWithValue("@codautor", codAutor);
                    //ejecutar insert
                    conexion.Open();
                    byte i = Convert.ToByte(comando.ExecuteNonQuery());
                    conexion.Close();
                    if (i == 1)
                        Listar();
                    else
                        //Response.Write("No se eliminó");
                        return false;
                    return true;
                }
                catch (Exception ex)
                {
                    conexion.Close();
                    return false;
                    //Response.Write("error: " + ex.Message);
                }
            
            }

        public DataTable Listar()
        {
            string consulta = "select * from tautor";
            MySqlCommand comnado = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comnado);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
    }
}