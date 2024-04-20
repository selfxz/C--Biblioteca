using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 1. Importando Libreria de ado .net
using System.Data;
using System.Data.SqlClient;
using AplicacionBiblioteca.BLL;

namespace AplicacionBiblioteca.DAL
{
    internal class MateriasDAL
    {
        // 2.  Creacion de objetos de la clase para el acceso a sus atributos
        ConexionDAL conexion = new ConexionDAL();

        // 3. Programa que retorna la lista de materias
        public DataSet MostrarMaterias()
        {
            SqlCommand sentencia = new SqlCommand("select * from materia");
            return conexion.EjecutarSentencia(sentencia);
        }
        // 4. Programa para Agregar Materia y retorna valor logico
        public bool Agregar(MateriaBLL omateriasBLL)
        {
            SqlCommand SQLcomando = new SqlCommand("insert into materia values(@materia)");
            SQLcomando.Parameters.AddWithValue("@materia", omateriasBLL.materia);
            return conexion.ejecutarComandosinRetornoDatos(SQLcomando);
        }
        // 5. Programa que elimina un registro
        public int eliminar (MateriaBLL omateriasBLL)
        {
            SqlCommand SQLcomando = new SqlCommand("delete from materia where Codigo = @codigo");
            SQLcomando.Parameters.AddWithValue("@codigo", omateriasBLL.codigo);
            conexion.ejecutarComandosinRetornoDatos (SQLcomando);
            return 1;
        }
        // 4. Programa para Modificar un registro
        public int modificar(MateriaBLL omateriasBLL)
        {
            SqlCommand SQLcomando = new SqlCommand("update materia set Nombre = @materia where Codigo = @codigo");
            SQLcomando.Parameters.AddWithValue("@materia", omateriasBLL.materia);
            SQLcomando.Parameters.AddWithValue("@Codigo", omateriasBLL.codigo);
            conexion.ejecutarComandosinRetornoDatos(SQLcomando);
            return 1;
        }
    }
}
