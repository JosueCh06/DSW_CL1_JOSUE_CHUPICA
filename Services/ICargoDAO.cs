using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSW_CL1_JOSUE_CHUPICA.Services
{
    public interface ICargoDAO<T>
    {
        List<T> listarCargos();
    }
}
