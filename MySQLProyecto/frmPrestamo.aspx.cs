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
    public partial class frmPrestamo : System.Web.UI.Page
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);
        private CapaNegocio.Prestamo f = new CapaNegocio.Prestamo();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvPrestamo.DataSource = f.Listar();
            gvPrestamo.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            f.Agregar(txtCodAutor.Text, txtCodLibro.Text, txtFecha.Text);
            gvPrestamo.DataSource = f.Listar();
            gvPrestamo.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            f.Eliminar(txtCodAutor.Text, txtCodLibro.Text, txtFecha.Text);
            gvPrestamo.DataSource = f.Listar();
            gvPrestamo.DataBind();
        }

        protected void btnBuscarLibro_Click(object sender, EventArgs e)
        {
            gvPrestamo.DataSource = f.BuscarLibro(txtCodLibro.Text); ;
            gvPrestamo.DataBind();
        }

        protected void btnBuscarAutor_Click(object sender, EventArgs e)
        {
            gvPrestamo.DataSource = f.BuscarAutor(txtCodLibro.Text); ;
            gvPrestamo.DataBind();
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}