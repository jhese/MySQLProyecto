using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using System.Configuration;
using MySql.Data.MySqlClient;

namespace MySQLProyecto.CapaNegocio
{
    public class Prestamo : IPrestamo
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);
        public bool Agregar(string codAutor, string codLibro, string fechaPrestamo)
        {
            try
            {
                string consulta = "insert into tprestamo values(@codautor,@codlibro,@fechaprestamo)";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //envio de parametros
                comando.Parameters.AddWithValue("@codautor", codAutor);
                comando.Parameters.AddWithValue("@codlibro", codLibro);
                comando.Parameters.AddWithValue("@fechaprestamo", fechaPrestamo);
                //ejecutar insert
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1)
                    Listar();
                else
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

        public DataTable BuscarAutor(string codAutor)
        {
            try
            {
                string consulta = "select * from tprestamo where CodAutor=@codautor";
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
                //Response.Write("error: " + ex.Message);
            }
        }

        public DataTable BuscarLibro(string codLibro)
        {
            try
            {
                string consulta = "select * from tprestamo where CodLibro=@codlibro";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //envio de parametros
                if (codLibro != "")
                {
                    comando.Parameters.AddWithValue("@codlibro", codLibro);
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
                //Response.Write("error: " + ex.Message);
            }
        }

        public bool Eliminar(string codAutor, string codLibro, string fechaPrestamo)
        {
            try
            {
                string consulta = "delete from tprestamo where CodAutor=@codautor AND Codlibro=@codlibro AND FechaPrestamo=@fechaprestamo";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //envio de parametros
                comando.Parameters.AddWithValue("@codautor", codAutor);
                comando.Parameters.AddWithValue("@codlibro", codLibro);
                comando.Parameters.AddWithValue("@fechaprestamo", fechaPrestamo);
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
            string consulta = "select * from tprestamo";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
    }
}