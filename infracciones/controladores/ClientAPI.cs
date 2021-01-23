using System;
using System.Collections.Generic;
using infracciones.modelos;

namespace infracciones.controladores
{
    public class ClientAPI
    {
        private static ClientApiPeru.Consulta clientApi = new ClientApiPeru.Consulta();

        public static Dni GetDni(string dni)
        {
            return clientApi.GetDni(dni);
        }
    }
}
