using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 1. Importar Librerias para acceso de datos
using System.Data;
using System.Data.SqlClient;


namespace AplicacionBiblioteca.DAL
{
    internal class ConexionDAL
    {
        // 2. Realizar la conexión a SQL server
        private string cadenaConexion= "data source=.; initial catalog=bdbiblioteca; integrated security=true";
        // 3. Crear variable de tipo conexion
        SqlConnection conexion;
        // 4. Crear Programa que realicé la conexion
        public SqlConnection EstabrecerConexion()
        {
            this.conexion = new SqlConnection(this.cadenaConexion);
            return this.conexion;
        }
        // 5. Crear una funcion para traer los datos
         public DataSet EjecutarSentencia(SqlCommand sqlcomando)
        {
            // creaccion de tabla virtual
            DataSet DS = new DataSet();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            try
            {
                // Creacion de objeto sqlcommand
                SqlCommand comando = new SqlCommand();
                comando = sqlcomando; // Asignando el comando recibido
                // Establecer la ruta de conexion al comando
                comando.Connection = EstabrecerConexion();
                adaptador.SelectCommand = comando; // Asignando el comando sql
                conexion.Open(); // Abriendo conexión
                adaptador.Fill(DS); // Llenando datos a la tabla virtual
                conexion.Close(); // Cerrando conexión
                return DS; // Retornando la tabla de datos
            }catch (Exception)
            {
                return DS;
            }
        }
        public bool ejecutarComandosinRetornoDatos(SqlCommand SQLcommando)
        {
            try
            {
                SqlCommand comando = SQLcommando;
                comando.Connection = this.EstabrecerConexion();
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                return true;
            } catch
            {
                return false;
            }
        }

        public object ExecuteScalar(SqlCommand cmd) 
        {
            object result = null;
            using (SqlConnection conexion = EstabrecerConexion()) 
            {
                conexion.Open();
                cmd.Connection = conexion;
                result = cmd.ExecuteScalar();
            }
            return result;
        }
    }
}
