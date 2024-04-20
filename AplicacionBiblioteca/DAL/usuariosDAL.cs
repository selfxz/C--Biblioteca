using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AplicacionBiblioteca.BLL;


namespace AplicacionBiblioteca.DAL
{
    internal class usuariosDAL
    {
        ConexionDAL conexion = new ConexionDAL();

        public DataSet MostrarUsuarios()
        {
            SqlCommand sentencia = new SqlCommand("select * from usuario");
            return conexion.EjecutarSentencia(sentencia);
        }
        // 4. Programa para Agregar Materia y retorna valor logico
        public bool Agregar(usuariosBLL ousuariosBLL)
        {
            SqlCommand SQLcomando = new SqlCommand("insert into usuario values(@dni,@nombre,@apellidos,@direcion,@ocupacion)");
            SQLcomando.Parameters.AddWithValue("@dni", ousuariosBLL.dni);
            SQLcomando.Parameters.AddWithValue("@nombre", ousuariosBLL.nombre);
            SQLcomando.Parameters.AddWithValue("@apellidos", ousuariosBLL.apellidos);
            SQLcomando.Parameters.AddWithValue("@direcion", ousuariosBLL.direccion);
            SQLcomando.Parameters.AddWithValue("@ocupacion", ousuariosBLL.ocupaciones);
            return conexion.ejecutarComandosinRetornoDatos(SQLcomando);
        }
        // 5. Programa que elimina un registro
        public int eliminar(usuariosBLL ousuariosBLL)
        {
            SqlCommand SQLcomando = new SqlCommand("delete from Usuario where dni = @dni");
            SQLcomando.Parameters.AddWithValue("@dni", ousuariosBLL.dni);
            conexion.ejecutarComandosinRetornoDatos(SQLcomando);
            return 1;
        }
        // 4. Programa para Modificar un registro
        public int modificar(usuariosBLL ousuariosBLL)
        {
            SqlCommand SQLcomando = new SqlCommand("update usuario set nombre = @nombre , apellidos = @apellidos, direccion = @direcion, ocupacion = @ocupacion where dni = @dni");
            SQLcomando.Parameters.AddWithValue("@dni", ousuariosBLL.dni);
            SQLcomando.Parameters.AddWithValue("@nombre", ousuariosBLL.nombre);
            SQLcomando.Parameters.AddWithValue("@apellidos", ousuariosBLL.apellidos);
            SQLcomando.Parameters.AddWithValue("@direcion", ousuariosBLL.direccion);
            SQLcomando.Parameters.AddWithValue("@ocupacion", ousuariosBLL.ocupaciones);
            conexion.ejecutarComandosinRetornoDatos(SQLcomando);
            return 1;
        }
    }
    
}
