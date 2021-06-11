using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MySQLProyecto.CapaNegocio
{
    interface IPrestamo
    {
        DataTable Listar();
        bool Agregar(string codAutor, string codLibro, string fechaPrestamo);
        bool Eliminar(string codAutor, string codLibro, string fechaPrestamo);
        //bool Actualizar(string codAutor, string codLibro, string fechaPrestamo);
        DataTable BuscarLibro(string codLibro);
        DataTable BuscarAutor(string codAutor);
    }
}
