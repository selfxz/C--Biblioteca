using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AplicacionBiblioteca.BLL;
using AplicacionBiblioteca.DAL;

namespace AplicacionBiblioteca.PL
{
    public partial class frm_Usuarios : Form
    {
        // 2. Creando variables generales
        usuariosDAL ousuariosDAL;

        // 3. Procedim8eitno que carga los datos al DataGridView
        public void LlenarGrid()
        {
            dataGridViewUsuarios.DataSource = ousuariosDAL.MostrarUsuarios().Tables[0];
        }
        public frm_Usuarios()
        {
            ousuariosDAL = new usuariosDAL();
            InitializeComponent();
            LlenarGrid();
        }

        private usuariosBLL RecuperarInformacion()
        {
            usuariosBLL ousuariosBLL = new usuariosBLL();
            int codigo = 0; int.TryParse(txtDni.Text, out codigo);
            ousuariosBLL.dni = codigo;
            ousuariosBLL.nombre = txtNombre.Text;
            ousuariosBLL.apellidos = txtApellidos.Text;
            ousuariosBLL.direccion = txtDireccion.Text;
            ousuariosBLL.ocupaciones = txtOcupacion.Text;
            return ousuariosBLL;
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            txtDni.Text = dataGridViewUsuarios.Rows[indice].Cells[0].Value.ToString();
            txtNombre.Text = dataGridViewUsuarios.Rows[indice].Cells[1].Value.ToString();
            txtApellidos.Text = dataGridViewUsuarios.Rows[indice].Cells[2].Value.ToString();
            txtDireccion.Text = dataGridViewUsuarios.Rows[indice].Cells[3].Value.ToString();
            txtOcupacion.Text = dataGridViewUsuarios.Rows[indice].Cells[4].Value.ToString();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            ousuariosDAL.eliminar(RecuperarInformacion());
            LlenarGrid();
            MessageBox.Show("Registro Eliminado con Éxito");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RecuperarInformacion();
            ConexionDAL conexion = new ConexionDAL();
            ousuariosDAL.Agregar(RecuperarInformacion());
            LlenarGrid();
            MessageBox.Show("Registrado con Éxito");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ousuariosDAL.modificar(RecuperarInformacion());
            LlenarGrid();
            MessageBox.Show("Registro Modificado con Éxito");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
