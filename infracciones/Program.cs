using System;
using System.Windows.Forms;
using infracciones.modelos;
using infracciones.controladores;

namespace infracciones
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
<<<<<<< HEAD
            ClientApiPeru.Consulta query = new ClientApiPeru.Consulta();
            query.GetDni("47624426");
=======
>>>>>>> bbfa962ab81f7cba5f6f429f701992501356ea50
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Infraccion());
        }
    }
}
