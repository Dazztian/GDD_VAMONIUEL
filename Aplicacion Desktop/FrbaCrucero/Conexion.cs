﻿using System;
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
            public static string MenorIgual(string valor)
            {
                return "<= " + valor;
            }

            internal static string MayorIgual(string valor)
            {
                return ">= " + valor;
            }
        }

        //Nombres de tablas basicas de la BD
        public static class Tabla
        {

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
                        return Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (Exception e)
            {
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


    }
}