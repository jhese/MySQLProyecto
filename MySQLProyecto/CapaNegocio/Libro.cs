using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using System.Configuration;
using MySql.Data.MySqlClient;

namespace MySQLProyecto.CapaNegocio
{
    public class Libro : ILibro
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);
        public bool Actualizar(string codLibro, string titulo, string editorial)
        {
            try
            {
                //string profesion = txtProfesion.Text.Trim();
                string consulta = "update tlibro SET Titulo=@titulo, Editorial=@editorial where CodLibro=@codlibro";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //envio de parametros
                comando.Parameters.AddWithValue("@codlibro", codLibro);
                comando.Parameters.AddWithValue("@titulo", titulo);
                comando.Parameters.AddWithValue("@editorial", editorial);
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
                //Response.Write("error: " + ex.Message);
            }
        }

        public bool Agregar(string codLibro, string titulo, string editorial)
        {
            try
            {
                string consulta = "insert into tlibro values(@codlibro,@titulo,@editorial)";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //envio de parametros
                comando.Parameters.AddWithValue("@codlibro", codLibro);
                comando.Parameters.AddWithValue("@titulo", titulo);
                comando.Parameters.AddWithValue("@editorial", editorial);
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

        public DataTable Buscar(string codLibro)
        {
            try
            {
                string consulta = "select * from tlibro where CodLibro=@codlibro";
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

        public bool Eliminar(string codLibro)
        {
            try
            {
                string consulta = "delete from tautor where Codlibro=@codlibro";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //envio de parametros
                comando.Parameters.AddWithValue("@CodLibro", codLibro);
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
            string consulta = "select * from tlibro";
            MySqlCommand comnado = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comnado);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
    }
}