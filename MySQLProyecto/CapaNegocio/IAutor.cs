using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MySQLProyecto.CapaNegocio
{
    interface IAutor

    {
        DataTable Listar();
        bool Agregar(string codAutor, string apellidos, string nombres, string  nacionalidad);
        bool Eliminar(string codAutor);
        bool Actualizar(string codAutor, string apellidos, string nombres, string nacionalidad);
        DataTable Buscar(string codAutor);
    }
}
