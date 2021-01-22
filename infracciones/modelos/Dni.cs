using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infracciones.modelos
{
    public class Dni
    {
        public int origen { get; set; }
        public string numero { get; set; }
        public string nombre_completo { get; set; }
        public string nombres { get; set; }
        public string  apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public int codigo_verificacion { get; set; }
        public string fecha_nacimiento { get; set; }
        public string sexo { get; set; }
    }
}
