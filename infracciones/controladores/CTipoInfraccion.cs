using System;
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
    }
}
