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
            TipoInfraccion obj = CTipoInfraccion.GetTipoInfraccion("C01");
            obj.infraccion = "infraccion modificada";
            obj.guardar();
            System.Windows.Forms.MessageBox.Show(obj.infraccion);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Infraccion());
        }
    }
}
