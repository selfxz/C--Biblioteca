using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 1. Importar librerias
using AplicacionBiblioteca.BLL;
using AplicacionBiblioteca.DAL;

namespace AplicacionBiblioteca.PL
{
    public partial class frm_Materias : Form
    {   
        // 2. Creando variables generales
        MateriasDAL omateriaDAL;

        // 3. Procedim8eitno que carga los datos al DataGridView
        public void LlenarGrid()
        {
            dataGridViewMateria.DataSource = omateriaDAL.MostrarMaterias().Tables[0];
        }
        public frm_Materias()
        {
            // 4. cargar datos al ejecutar el formulario
            // a. Creacion de objetos a partir de la clase MateriasDAL
            omateriaDAL = new MateriasDAL();
            InitializeComponent();
            // b. Llamando al procedimiento que carga datos al DataGridView
            LlenarGrid();
        }
        private MateriaBLL RecuperarInformacion()
        {
            MateriaBLL omateriaBLL = new MateriaBLL();
            int codigo = 0; int.TryParse(txtCodigo.Text, out codigo);
            omateriaBLL.codigo = codigo;
            omateriaBLL.materia = txtMateria.Text;
            return omateriaBLL;
        }

     
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 7. Estbalecer datos de Dgv en texBox
            // obtener indice
            int indice = e.RowIndex;
            // Estableciendo datos en los controles
            txtCodigo.Text = dataGridViewMateria.Rows[indice].Cells[0].Value.ToString();
            txtMateria.Text = dataGridViewMateria.Rows[indice].Cells[1].Value.ToString();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // 8. eliminar datos en la bd
            omateriaDAL.eliminar(RecuperarInformacion());
            LlenarGrid();
            MessageBox.Show("Registro Eliminado con Éxito");
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            // 6. Guarda datos en la bd
            RecuperarInformacion();
            ConexionDAL conexion = new ConexionDAL();
            omateriaDAL.Agregar(RecuperarInformacion());
            LlenarGrid();
            MessageBox.Show("Registrado con Éxito");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // 9. Actualizar datos
            omateriaDAL.modificar(RecuperarInformacion());
            LlenarGrid();
            MessageBox.Show("Registro Modificado con Éxito");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
