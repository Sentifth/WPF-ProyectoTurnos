using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
namespace capaAccesoaDatos
{
    public class clsManejador
    {
        private string Servidor_InstanciaBD = "";
        private string BaseDatos = "gestion_turnos2";
        private string CadenaConexion = "";
        private SqlConnection conexion;
        private static string file_server = "server.dll";
        public void Limpiar_CadenaConexion()
        {
            this.Servidor_InstanciaBD = "";
            this.CadenaConexion = "";
        }
        private void Preparar_Conexion()
        {
            if (this.Servidor_InstanciaBD.Equals(""))
            {
                this.Servidor_InstanciaBD = this.Leer(clsManejador.file_server);
            }
            if (this.CadenaConexion.Equals(""))
            {
                this.CadenaConexion = string.Concat(new string[]
                {
                    "Server=",
                    this.Servidor_InstanciaBD,
                    "; DataBase=",
                    this.BaseDatos,
                    "; User Id=admin_gt2; Password=xyz12345678;"
                });
            }
            if (this.conexion == null)
            {
                this.conexion = new SqlConnection(this.CadenaConexion);
            }
        }
        public bool Probar_Conexion()
        {
            bool result = false;
            this.Preparar_Conexion();
            SqlConnection sqlConnection = new SqlConnection(this.CadenaConexion);
            try
            {
                sqlConnection.Open();
                sqlConnection.Close();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;
        }
        private void abrir_conexion()
        {
            if (this.conexion.State == ConnectionState.Closed)
            {
                this.conexion.Open();
            }
        }
        private void cerrar_conexion()
        {
            if (this.conexion.State == ConnectionState.Open)
            {
                this.conexion.Close();
            }
        }
        public void Ejecutar_SP(string NombreSP, List<clsParametros> lst)
        {
            try
            {
                this.Preparar_Conexion();
                this.abrir_conexion();
                SqlCommand sqlCommand = new SqlCommand(NombreSP, this.conexion);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].Direccion == ParameterDirection.Input)
                        {
                            sqlCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                        }
                        if (lst[i].Direccion == ParameterDirection.Output)
                        {
                            sqlCommand.Parameters.Add(lst[i].Nombre, lst[i].TipoDato, lst[i].Tamanio).Direction = ParameterDirection.Output;
                        }
                    }
                    sqlCommand.ExecuteNonQuery();
                    for (int j = 0; j < lst.Count; j++)
                    {
                        if (sqlCommand.Parameters[j].Direction == ParameterDirection.Output)
                        {
                            lst[j].Valor = sqlCommand.Parameters[j].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            this.cerrar_conexion();
        }
        public DataTable Listar_SP(string NombreSP, List<clsParametros> lst)
        {
            DataTable dataTable = new DataTable();
            try
            {
                this.Preparar_Conexion();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(NombreSP, this.conexion);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                    }
                }
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }
        private string Leer(string archivo)
        {
            string str = Directory.GetCurrentDirectory() + "\\";
            string result = "";
            try
            {
                if (!File.Exists(str + archivo))
                {
                    return result;
                }
                StreamReader streamReader = new StreamReader(str + archivo);
                result = streamReader.ReadLine();
                streamReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
    public class clsParametros
    {
        public string Nombre
        {
            get;
            set;
        }
        public object Valor
        {
            get;
            set;
        }
        public SqlDbType TipoDato
        {
            get;
            set;
        }
        public int Tamanio
        {
            get;
            set;
        }
        public ParameterDirection Direccion
        {
            get;
            set;
        }
        public clsParametros(string objNombre, object objValor)
        {
            this.Nombre = objNombre;
            this.Valor = objValor;
            this.Direccion = ParameterDirection.Input;
        }
        public clsParametros(string objNombre, SqlDbType objTipoDato, int objTamanio)
        {
            this.Nombre = objNombre;
            this.TipoDato = objTipoDato;
            this.Tamanio = objTamanio;
            this.Direccion = ParameterDirection.Output;
        }
    }
}

