using AplicacionBiblioteca.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionBiblioteca.PL
{
    public partial class frm_categoria : Form
    {
        CategoriaDAL categoria = new CategoriaDAL();
        public frm_categoria()
        {
            InitializeComponent();
            FillComboBox();
        }

        public void FillComboBox()
        {
            List<string> categoryNames = categoria.GetCategoryNames();
            comboBox1.DataSource = categoryNames;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedValue = comboBox1.SelectedValue;
            dataGridView1.DataSource = categoria.ShowData(selectedValue).Tables[0];
        }

    }
}
