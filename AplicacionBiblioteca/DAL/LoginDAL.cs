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
    internal class LoginDAL
    {
        ConexionDAL conexion = new ConexionDAL();
        public bool verificar(LoginBLL ologinBLL)
        {
            SqlCommand SQLcomando = new SqlCommand("select COUNT(*) from administrador where nom_admin = @user and password = @pass");
            SQLcomando.Parameters.AddWithValue("@user",ologinBLL.user);
            SQLcomando.Parameters.AddWithValue("@pass", ologinBLL.password);

            int rowCount = (int)conexion.ExecuteScalar(SQLcomando);
            return rowCount > 0;
        }
    }
}
