using System;
using System.Collections.Generic;
using infracciones.modelos;

namespace infracciones.controladores
{
    public class CTipoInfraccion
    {
        private static TipoInfraccion.Consultas consultas = new TipoInfraccion.Consultas();

        public static TipoInfraccion GetTipoInfraccion(string codigo)
        {
            return consultas.getTipoInfraccion(codigo);
        }
        public static List<TipoInfraccion> allTipoInfraccion(string codigo)
        {
            return consultas.allTipoInfraccion();
        }
    }
}
