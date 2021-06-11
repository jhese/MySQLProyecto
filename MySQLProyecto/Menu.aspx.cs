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
    public partial class Menu : System.Web.UI.Page
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);

 

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLibro_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLibro.aspx");
        }

        protected void btnAutor_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAutor.aspx");
        }

        protected void btnPrestamo_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmPrestamo.aspx");
        }


    }
}