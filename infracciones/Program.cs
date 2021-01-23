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
            Dni dni = ClientAPI.GetDni("73299966");
            System.Windows.Forms.MessageBox.Show(dni.nombre_completo);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Infraccion());

        }
    }
}
