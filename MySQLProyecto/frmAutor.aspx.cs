using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using MySQLProyecto;


namespace MySQLProyecto
{
    public partial class Default : System.Web.UI.Page
    {
        //Cadena de conexion
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);
        private CapaNegocio.Autor autor = new CapaNegocio.Autor();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvAutor.DataSource = autor.Listar();
            gvAutor.DataBind();
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            autor.Agregar(txtCodAutor.Text, txtApellidos.Text, txtNombres.Text, txtNacionalidad.Text);
            gvAutor.DataSource = autor.Listar();
            gvAutor.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            autor.Eliminar(txtCodAutor.Text);
            gvAutor.DataSource = autor.Listar();
            gvAutor.DataBind();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            autor.Actualizar(txtCodAutor.Text, txtApellidos.Text, txtNombres.Text, txtNacionalidad.Text);
            gvAutor.DataSource = autor.Listar();
            gvAutor.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvAutor.DataSource = autor.Buscar(txtCodAutor.Text); ;
            gvAutor.DataBind();
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}