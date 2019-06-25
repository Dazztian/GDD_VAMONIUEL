using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCrucero
{
    class Conexion
    {
        private static Conexion instance = null;
        protected const string comandoInsert = "INSERT INTO ";
        protected const string comandoUpdate = "UPDATE ";
        protected const string comandoSelect = "SELECT ";
        private static string conectionString = ConfigurationHelper.ConnectionString;

        protected Conexion() { }

        public static Conexion getInstance()
        {
            if (instance == null)
                instance = new Conexion();
            return instance;
        }

        //Conversion de string a filtro de busqueda necesario
        public static class Filtro
        {
            public static string Libre(string var)
            {
                return "LIKE '%" + var + "%'";
            }
            public static string Exacto(string var)
            {
                return " = '" + var + "'";
            }
            public static string Distinto(string var)
            {
                return " != '" + var + "'";
            }
            public static string Between(string menor, string mayor)
            {
                return "BETWEEN " + menor + " AND " + mayor;
            }
            public static string NotBetween(string menor, string mayor)
            {
                return "NOT BETWEEN " + menor + " AND " + mayor;
            }
            public static string MenorIgual(string valor)
            {
                return "<= " + valor;
            }
            public static string IN(string valor)
            {
                return "IN ( " + valor + ")";
            }

            internal static string MayorIgual(string valor)
            {
                return ">= " + valor;
            }
            internal static string NotNull()
            {
                return "IS NOT NULL ";
            }
        }

        //Nombres de tablas basicas de la BD
        public static class Tabla
        {
            //public static string NombreTabla { get { return "VAMONIUEL.[NombreTabla]"; } }
            public static string Recorrido { get { return "[VAMONIUEL].[RECORRIDO]"; } }
            public static string Puerto { get { return "[VAMONIUEL].[Puerto]"; } }
            public static string Cabina { get { return "VAMONIUEL.CABINA"; } }
            public static string TramoXPuerto { get { return "VAMONIUEL.TramoXPuerto"; } }
            public static string RecorridoXViaje { get { return "VAMONIUEL.RecorridoXViaje"; } }
            public static string TramoXRecorrido { get { return "VAMONIUEL.TramoXRecorrido"; } }
            public static string tramo { get { return "VAMONIUEL.tramo"; } }
            public static string ViajeXRecorrido { get { return "VAMONIUEL.ViajeXRecorrido"; } }
            public static string VIAJE { get { return "VAMONIUEL.VIAJE"; } }
            public static string RESERVA { get { return "VAMONIUEL.RESERVA"; } }
            public static string CRUCERO { get { return "VAMONIUEL.CRUCERO"; } }
            public static string Rol_X_Funcion { get { return "VAMONIUEL.Rol_X_Funcion"; } }
            public static string Rol_X_Usuario { get { return "VAMONIUEL.Rol_X_Usuario"; } }
            public static string Rol { get { return "VAMONIUEL.Rol"; } }
            public static string Funcion { get { return "VAMONIUEL.Funcion"; } }
            public static string PASAJE { get { return "[VAMONIUEL].[PASAJE]"; } }
            public static string Pago { get { return "[VAMONIUEL].[Pago]"; } }
            public static string Cliente { get { return "VAMONIUEL.Cliente"; } }
            public static string Usuario { get { return "VAMONIUEL.Usuario"; } }
            public static string Cruceros_ocupados_por_fecha { get { return "VAMONIUEL.cruceros_ocupados_por_fecha"; } }
            public static string Tramos_asociados_a_recorridos { get { return "VAMONIUEL.tramos_asociados_a_recorridos"; } }
            public static string Marca { get { return "VAMONIUEL.Marca"; } }
            public static string TipoCabina { get { return "VAMONIUEL.TipoCabina"; } }
            public static string Estado_del_crucero { get { return "VAMONIUEL.Estado_del_Crucero"; } }
            public static string top5Pasajes { get { return "VAMONIUEL.recorridos_mayor_pasajes_comprados"; } }
            public static string top5CabinasLibres { get { return "VAMONIUEL.recorridos_mas_cabinas_libres_xviaje"; } }
            public static string top5CrucerosDeshabilitados { get { return "VAMONIUEL.cruceros_mayor_cant_dias_fuera_servicio"; } }
            public static string RolesUsuario { get { return "[VAMONIUEL].Roles_usuario"; } }
            public static string idDelCliente { get { return "[VAMONIUEL].idClientexNombreUsuario"; } }
            public static string FuncionesUsuarios { get { return "[VAMONIUEL].funciones_usuarios"; } }
            public static string AnioMinimo { get { return "VAMONIUEL.anio_minimo_de_viaje"; } }
            public static string viaje_oyd { get { return "VAMONIUEL.viajes_con_oyd"; } }
            public static string reco_completo { get { return "VAMONIUEL.recorrido_completo_xviaje"; } }
            public static string cabi_viaje { get { return "VAMONIUEL.cabinas_del_viaje"; } }
            public static string precio_base_recorrido { get { return "VAMONIUEL.precio_base_recorrido"; } }
            public static string recargo_cabina { get { return "VAMONIUEL.recargo_cabina_viaje"; } }
            public static string cabinaxviaje { get { return "[VAMONIUEL].[CabinaXViaje]"; } }
            public static string proxima_reserva_codigo_a_ins { get { return "[VAMONIUEL].[proxima_reserva_codigo_a_ins]"; } }
        }

            private string PonerFiltros(string comando, Dictionary<string, string> filtros)
            {
                comando += " WHERE ";
                foreach (KeyValuePair<string, string> entry in filtros)
                {
                    comando += entry.Key + " " + entry.Value + " AND ";

                }
                comando = comando.Substring(0, comando.Length - 4);
                return comando;
            }
            public int logueoAdmin()
            {
                using (SqlConnection sqlConnection = new SqlConnection(conectionString))
                using (var command = 
                    new SqlCommand("VAMONIUEL.dar_de_baja_reservas_por_logueo_de_admin", sqlConnection)
                {CommandType = CommandType.StoredProcedure })
                {
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
                return 1;
            }

            public int InsertarCustomizado(string tabla, Dictionary<string, object> data)
            {
                try
                {
                    string comandoString = string.Copy(comandoInsert) + tabla + " (";
                    data.Keys.ToList().ForEach(k => comandoString += k + ", ");
                    comandoString = comandoString.Substring(0, comandoString.Length - 2) + ") VALUES (";
                    data.Keys.ToList().ForEach(k => comandoString += "@" + k + ", ");
                    comandoString = comandoString.Substring(0, comandoString.Length - 2) + "); SELECT SCOPE_IDENTITY();";
                    using (SqlConnection sqlConnection = new SqlConnection(conectionString))
                    {
                        sqlConnection.Open();
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = sqlConnection;
                            command.CommandType = CommandType.Text;
                            command.CommandText = comandoString;
                            foreach (KeyValuePair<string, object> entry in data)
                            {
                                command.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                            }
                            //Esto es un fix para que no tire error la pantalla, pero no estoy seguro si debe retornar 1 o -1
                            if (DBNull.Value.Equals(command.ExecuteScalar())) { return -1; }
                            else { return Convert.ToInt32(command.ExecuteScalar()); }

                        }
                    }
                }
                catch (Exception e)
                {
                    //Esto para poder ver el error
                    MessageBox.Show(e.ToString());
                    return -1;

                }

            }

            //Recibe el nombre de la tabla sacada de Conexion.Tabla, y un diccionario con el par 
            //("nombre de columna en BD", dato a insertar)
            //retorna true si se pudo realizar, false si fallo
            public int Insertar(string tabla, Dictionary<string, object> data)
            {
                try
                {
                    string comandoString = string.Copy(comandoInsert) + tabla + " (";
                    data.Keys.ToList().ForEach(k => comandoString += k + ", ");
                    comandoString = comandoString.Substring(0, comandoString.Length - 2) + ") VALUES (";
                    data.Keys.ToList().ForEach(k => comandoString += "@" + k + ", ");
                    comandoString = comandoString.Substring(0, comandoString.Length - 2) + "); SELECT SCOPE_IDENTITY();";
                    using (SqlConnection sqlConnection = new SqlConnection(conectionString))
                    {
                        sqlConnection.Open();
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = sqlConnection;
                            command.CommandType = CommandType.Text;
                            command.CommandText = comandoString;
                            foreach (KeyValuePair<string, object> entry in data)
                            {
                                command.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                            }
                        object result = command.ExecuteScalar();
                        if (DBNull.Value.Equals(result))
                            return -1;
                        else return Convert.ToInt32(result);

                        }
                    }
                }
                catch (Exception e)
                {
                    //Esto para poder ver el error
                    MessageBox.Show(e.ToString());
                    return -1;

                }

            }

            public bool InsertarTablaIntermedia(string tabla, string col1, string col2, int pk1, int pk2)
            {
                string comando = "INSERT INTO " + tabla + "( " + col1 + ", " + col2 + ") VALUES (@pk1, @pk2)";
                using (SqlConnection connection = new SqlConnection(conectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        try
                        {
                            command.Connection = connection;
                            command.CommandText = comando;
                            command.CommandType = CommandType.Text;
                            command.Parameters.AddWithValue("@pk1", pk1);
                            command.Parameters.AddWithValue("@pk2", pk2);

                            command.ExecuteNonQuery();
                        }
                        catch (SqlException)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            //Recibe el id de la fila, nombre de la tabla sacada de Conexion.Tabla, y 
            //un diccionario con el par ("nombre de columna en BD", dato a insertar
            //retorna true si se pudo realizar, false si fallo
            public bool Modificar(int pk, string tabla, Dictionary<string, object> data)
            {
                try
                {
                    string comandoString = string.Copy(comandoUpdate) + tabla + " SET ";
                    foreach (KeyValuePair<string, object> entry in data)
                    {
                        comandoString += entry.Key + " = @" + entry.Key + ", ";
                    }
                    comandoString = comandoString.Substring(0, comandoString.Length - 2) + " WHERE id = @id";
                    using (SqlConnection sqlConnection = new SqlConnection(conectionString))
                    {
                        sqlConnection.Open();
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = sqlConnection;
                            command.CommandType = CommandType.Text;
                            command.CommandText = comandoString;
                            command.Parameters.AddWithValue("@id", pk);
                            foreach (KeyValuePair<string, object> entry in data)
                            {
                                command.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                            }
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception e)
                {
                    string a = e.StackTrace;
                    return false;
                }
                return true;
            }

            //Recibe el nombre de la tabla de Conexion.Tabla, el dataGrid POR REFERENCIA, y los filtros de busqueda sacados 
            //de Conexion.Filtro 
            public void LlenarDataGridView(string tabla, ref DataGridView dataGrid, Dictionary<string, string> filtros)
            {
                dataGrid.DataSource = conseguirTabla(tabla, filtros);
            }

            public DataTable conseguirTabla(string tabla, Dictionary<string, string> filtros)
            {
                string comandoString = string.Copy(comandoSelect) + " * FROM " + tabla;
                if (filtros != null && filtros.Count > 0)
                    comandoString = PonerFiltros(comandoString, filtros);
                using (SqlConnection sqlConnection = new SqlConnection(conectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.Connection = sqlConnection;
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = comandoString;
                        SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                        DataTable dtRecord = new DataTable();
                        sqlDataAdap.Fill(dtRecord);

                        return dtRecord;
                    }
                }
            }

            public bool eliminarTablaIntermedia(string tabla, string col1, string col2, int pk1, int pk2)
            {
                string comando = "DELETE FROM " + tabla + " WHERE " + col1 + "= @pk1 AND " + col2 + " = @pk2";
                using (SqlConnection connection = new SqlConnection(conectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        try
                        {
                            command.Connection = connection;
                            command.CommandText = comando;
                            command.CommandType = CommandType.Text;
                            command.Parameters.AddWithValue("@pk1", pk1);
                            command.Parameters.AddWithValue("@pk2", pk2);

                            command.ExecuteNonQuery();
                        }
                        catch (SqlException)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            public bool existeRegistro(string tabla, List<string> columnas, Dictionary<string, string> filtros)
            {
                var datos = ConsultaPlana(tabla, columnas, filtros);
                return (datos[columnas[0]].Count > 0);
            }

            private Dictionary<string, List<object>> HacerDictinary(List<string> colum)
            {
                Dictionary<string, List<object>> retorno = new Dictionary<string, List<object>>();
                colum.ForEach(c => retorno.Add(c.Split(' ').Last(), new List<object>()));
                return retorno;
            }

            //SOLO TIENE SENTIDO USARLA A LA HORA DE FILTRAR ELEMENTOS DE LA BD
            public string darFormatoFechaYYYYMMDD(DateTimePicker dtp)
            {
                String formatoFechaInicio = String.Concat("'", String.Concat(dtp.Value.ToString("yyyy/MM/dd"), "'"));
                return formatoFechaInicio;
            }



            //Recibe el nombre de la tabla sacado de Conexion.Tabla, una lista de strings con los nombres de las columnas a buscar
            //y un diccionario con el par ("nombre de columna", valor) como filtro. Si no se quiere filtrar, se pasa null.
            //Retorna un diccionario con el par ("nombre de columna", lista de valores retornados)
            public Dictionary<string, List<object>> ConsultaPlana(string tabla, List<string> columnas, Dictionary<string, string> filtros)
            {
                Dictionary<string, List<object>> retorno = HacerDictinary(columnas);

                string comandoString = string.Copy(comandoSelect);

                columnas.ForEach(c => comandoString += c + ", ");
                comandoString = comandoString.Substring(0, comandoString.Length - 2);

                comandoString += " FROM " + tabla;
                if (filtros != null && filtros.Count > 0)
                    comandoString = PonerFiltros(comandoString, filtros);

                using (SqlConnection connection = new SqlConnection(conectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = comandoString;
                        command.CommandType = CommandType.Text;

                        command.Connection = connection;

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                            columnas.ForEach(c => retorno[c.Split(' ').Last()].Add(reader[c.Split(' ').Last()]));
                    }
                }
                return retorno;
            }

            private void cambiarHabilitacion(string tabla, int id, string cambio)
            {
                string comandoString = string.Copy(comandoUpdate) + tabla + " SET habilitado = " + cambio + " WHERE id = @id";
                using (SqlConnection connection = new SqlConnection(conectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = comandoString;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }

            public void deshabilitar(string tabla, int id)
            {
                cambiarHabilitacion(tabla, id, "0");
            }

            public void habilitar(string tabla, int id)
            {
                cambiarHabilitacion(tabla, id, "1");
            }
            public bool ActualizarContraseña(string contraseña, string usuario)
            {
                string comandoString = string.Copy(comandoUpdate) + Tabla.Usuario + " SET contrasenia = HASHBYTES('SHA2_256', @contrasenia), contrasena_autogenerada = 0 WHERE usuario = @usuario";
                try
                {
                    using (SqlConnection connection = new SqlConnection(conectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandType = CommandType.Text;
                            command.CommandText = comandoString;
                            command.Parameters.AddWithValue("@contrasenia", contraseña);
                            command.Parameters.AddWithValue("@usuario", usuario);

                            command.ExecuteNonQuery();

                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            public bool ValidarLogin(string usuario, string contraseña, ref bool contraseñaAutogenerada)
            {
                using (SqlConnection connection = new SqlConnection(conectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "[VAMONIUEL].existe_usuario";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("@Usuario", SqlDbType.NVarChar);
                        parameter1.Direction = ParameterDirection.Input;
                        parameter1.Value = usuario;
                        SqlParameter parameter2 = new SqlParameter("@Contrasenia", SqlDbType.NVarChar);
                        parameter2.Direction = ParameterDirection.Input;
                        parameter2.Value = contraseña;
                        SqlParameter parameter3 = new SqlParameter("@resultado", SqlDbType.Bit);
                        parameter3.Direction = ParameterDirection.Output;
                        SqlParameter parameter4 = new SqlParameter("@autogenerada", SqlDbType.Bit);
                        parameter4.Direction = ParameterDirection.Output;

                        command.Parameters.Add(parameter1);
                        command.Parameters.Add(parameter2);
                        command.Parameters.Add(parameter3);
                        command.Parameters.Add(parameter4);

                        command.ExecuteNonQuery();

                        bool resultado = Convert.ToBoolean(command.Parameters["@resultado"].Value);
                        if (resultado)
                            contraseñaAutogenerada = Convert.ToBoolean(command.Parameters["@autogenerada"].Value);
                        return resultado;
                    }
                }
            }
            public int InsertarUsuario(string usuario, string contraseña, string rol)
            {
                using (SqlConnection connection = new SqlConnection(conectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        try
                        {
                            command.Connection = connection;
                            command.CommandText = "[VAMONIUEL].insertar_usuario";
                            command.CommandType = CommandType.StoredProcedure;

                            SqlParameter parameter1 = new SqlParameter("@usuario", SqlDbType.NVarChar);
                            parameter1.Direction = ParameterDirection.Input;
                            parameter1.Value = usuario;
                            SqlParameter parameter2 = new SqlParameter("@contrasenia", SqlDbType.NVarChar);
                            parameter2.Direction = ParameterDirection.Input;
                            parameter2.Value = contraseña;
                            SqlParameter parameter3 = new SqlParameter("@nombreTipo", SqlDbType.NVarChar);
                            parameter3.Direction = ParameterDirection.Input;
                            parameter3.Value = rol;
                            SqlParameter retorno = new SqlParameter("@ReturnVal", SqlDbType.Int);
                            retorno.Direction = ParameterDirection.ReturnValue;

                            command.Parameters.Add(parameter1);
                            command.Parameters.Add(parameter2);
                            command.Parameters.Add(parameter3);
                            command.Parameters.Add(retorno);

                            command.ExecuteNonQuery();
                            return Convert.ToInt32(retorno.Value);
                        }
                        catch (SqlException)
                        {
                            return -1;
                        }

                    }
                }
            }



        }
    }
