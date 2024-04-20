using AplicacionBiblioteca.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionBiblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        private void AbrirFormularioEnPanel(Form form)
        {
            form.TopLevel = false;
            PanelPadre.Controls.Clear();
            PanelPadre.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        }
        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frm_Materias frm = new frm_Materias();
            AbrirFormularioEnPanel(frm);
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_categoria consultas = new frm_categoria();
            AbrirFormularioEnPanel(consultas);
        }

        private void ejemplaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Usuarios frm = new frm_Usuarios();
            AbrirFormularioEnPanel(frm);
        }

    }
}
