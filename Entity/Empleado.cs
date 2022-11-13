using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSW_CL1_JOSUE_CHUPICA.Entity
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public String apeEmpleado{ get;set; }
        public String nombEmpleado { get; set; }
        public DateTime FecNac { get; set; }
        public String dirEmpleado { get; set; }
        public int idDistrito { get; set; }
        public String celEmpleado { get; set; }
        public int idCargo { get; set; }
        public DateTime fecContrato { get; set; }
    }
}