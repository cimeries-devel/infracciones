using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace infracciones.modelos
{
    public class TipoInfraccion : Sqlite
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string infraccion { get; set; }
        public string calificacion { get; set; }
        public string sancion { get; set; }
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
                    consulta = new SQLiteCommand("INSERT INTO tipo_infraccion_tbl VALUES(NULL, @codigo, @infraccion, @calificacion, @sancion)", conexion);
                } else
                {
                    consulta = new SQLiteCommand("UPDATE TipoInfraccion SET codigo=@codigo, infraccion=@infraccion, calificacion=@calificacion, sancion=@sancion WHERE id=@id", conexion);
                    consulta.Parameters.Add("@id", System.Data.DbType.Int32).Value = id;
                }
                consulta.Parameters.Add("@codigo", System.Data.DbType.String).Value = codigo;
                consulta.Parameters.Add("@infraccion", System.Data.DbType.String).Value = infraccion;
                consulta.Parameters.Add("@calificacion", System.Data.DbType.String).Value = calificacion;
                consulta.Parameters.Add("@sancion", System.Data.DbType.String).Value = sancion;
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
                    consulta = new SQLiteCommand("SELECT id, codigo, infraccion, calificacion, sancion FROM TipoInfraccion WHERE codigo=@codigo", conexion);
                    consulta.Parameters.Add("@codigo", System.Data.DbType.String).Value = _codigo;
                    datos = consulta.ExecuteReader();

                    if (datos.HasRows)
                    {
                        datos.Read();
                        TipoInfraccion ti = new TipoInfraccion();
                        ti.id = Convert.ToInt32(datos[0]);
                        ti.codigo = Convert.ToString(datos[1]);
                        ti.infraccion = Convert.ToString(datos[2]);
                        ti.calificacion = Convert.ToString(datos[3]);
                        ti.sancion = Convert.ToString(datos[4]);
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
            public List<TipoInfraccion> allTipoInfraccion()
            {
                try
                {
                    if (establecerConexion())
                    {
                        return null;
                    }
                    consulta = new SQLiteCommand("SELECT id, codigo, infraccion, calificacion, sancion FROM TipoInfraccion", conexion);
                    datos = consulta.ExecuteReader();

                    if (datos.HasRows)
                    {
                        List<TipoInfraccion> todos = new List<TipoInfraccion>();
                        while(datos.Read())
                        {
                            TipoInfraccion ti = new TipoInfraccion();
                            ti.id = Convert.ToInt32(datos[0]);
                            ti.codigo = Convert.ToString(datos[1]);
                            ti.infraccion = Convert.ToString(datos[2]);
                            ti.calificacion = Convert.ToString(datos[3]);
                            ti.sancion = Convert.ToString(datos[4]);
                            ti.esNuevo = false;
                            todos.Add(ti);
                        }
                        return todos;
                    }
                }
                catch (SQLiteException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message + " : allTipoInfraccion de TipoInfraccion");
                }
                finally
                {
                    cerrarConexion();
                }
                return null;
            }
        }
    }
}
