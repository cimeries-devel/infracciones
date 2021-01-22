using System;
using System.Data.SQLite;

namespace infracciones.modelos
{
    public class TipoInfraccion : Sqlite
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string infraccion { get; set; }
        public bool esNuevo { get; set; }

        public TipoInfraccion() : base()
        {
            esNuevo = true;
        }
        public TipoInfraccion guardar()
        {
            try
            {
                if (establecerConexion())
                {
                    return null;
                }
                if (esNuevo)
                {
                    consulta = new SQLiteCommand("INSERT INTO TipoInfraccion VALUES(NULL, @codigo, @infraccion)", conexion);
                } else
                {
                    consulta = new SQLiteCommand("UPDATE TipoInfraccion SET codigo=@codigo, infraccion=@infraccion WHERE id=@id", conexion);
                    consulta.Parameters.Add("@id", System.Data.DbType.Int32).Value = id;
                }
                consulta.Parameters.Add("@codigo", System.Data.DbType.String).Value = codigo;
                consulta.Parameters.Add("@infraccion", System.Data.DbType.String).Value = infraccion;
                consulta.ExecuteNonQuery();
                return this;

            } catch (SQLiteException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message + " : guardar de TipoInfraccion");
            } finally
            {
                cerrarConexion();
            }
            return null;
        }
        public class Consultas : Sqlite {
            public TipoInfraccion getTipoInfraccion(string _codigo)
            {
                try
                {
                    if (establecerConexion())
                    {
                        return null;
                    }
                    consulta = new SQLiteCommand("SELECT id, codigo, infraccion FROM TipoInfraccion WHERE codigo=@codigo", conexion);
                    consulta.Parameters.Add("@codigo", System.Data.DbType.String).Value = _codigo;
                    datos = consulta.ExecuteReader();

                    if (datos.HasRows)
                    {
                        datos.Read();
                        TipoInfraccion ti = new TipoInfraccion();
                        ti.id = Convert.ToInt32(datos[0]);
                        ti.codigo = Convert.ToString(datos[1]);
                        ti.infraccion = Convert.ToString(datos[2]);
                        ti.esNuevo = false;
                        return ti;
                    }
                } catch (SQLiteException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message + " : getTipoInfraccion de TipoInfraccion");
                } finally
                {
                    cerrarConexion();
                }
                return null;
            }
        }
    }
}
