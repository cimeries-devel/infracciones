using System;
using System.Data.SQLite;
using System.IO;

namespace infracciones.modelos
{
    public class Sqlite
    {
        protected SQLiteConnection conexion;
        protected SQLiteCommand consulta;
        protected SQLiteDataReader datos;

        public Sqlite()
        {
            conexion = new SQLiteConnection("Data Source = H:\\Proyectos\\infracciones\\infracciones\\db.sqlite3");
        }
        protected bool establecerConexion()
        {
            try
            {
                conexion.Open();
                return false;
            } catch (SQLiteException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message + " : establecerConexion de Sqlite");
            }
            return true;
        }
        protected void cerrarConexion()
        {
            if (consulta!=null)
            {
                if (datos != null)
                {
                    datos.Close();
                }
                consulta.Dispose();
            }
        }
    }
}
