using AplicacionBiblioteca.BLL;
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
using System.Runtime.InteropServices;

namespace AplicacionBiblioteca.PL
{
    public partial class frm_login : Form
    {
        LoginDAL oLogin = new LoginDAL();
        public frm_login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void txtUsu_Enter(object sender, EventArgs e)
        {
            if(txtUsu.Text == "USUARIO")
            {
                txtUsu.Text = "";
                txtUsu.ForeColor = Color.Black;
            }
        }

        private void txtUsu_Leave(object sender, EventArgs e)
        {
            if (txtUsu.Text=="")
            {
                txtUsu.Text = "USUARIO";
                txtUsu.ForeColor= Color.Black;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "PASSWORD")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "PASSWORD";
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private LoginBLL recuperarinfo()
        {
            LoginBLL ologinBLL = new LoginBLL();
            ologinBLL.user = txtUsu.Text;
            ologinBLL.password = txtPass.Text;
            return ologinBLL;
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            bool isValid = oLogin.verificar(recuperarinfo());

            if (!isValid)
            {
                MessageBox.Show("Credenciales incorrectas");

            }else
            {
                this.Hide();
                Form1 frm = new Form1();
                frm.Show();
                
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

    }
}
