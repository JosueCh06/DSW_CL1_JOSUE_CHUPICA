using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSW_CL1_JOSUE_CHUPICA.Services
{
    public interface IEmpleadoDAO<T>
    {
        void InsertarEmpleado(T e);
        void ActualizarEmpleado(T e);
        void BajaEmpleado(T e);
        List<T> listarEmpleado();
        T BuscarEmpleado(int id);
    }
}
