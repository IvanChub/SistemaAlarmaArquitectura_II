using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalArquitectura_II
{
    public partial class agregarUsr : Form
    {
        classConectar bdCon = new classConectar();
        public agregarUsr()
        {
            InitializeComponent();
            this.ActiveControl = txtNombres;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            string usuario = txtUsr.Text;
            string passw = txtPass.Text;
            string cPassw = txtCPass.Text;

            bdCon.insertarUsuario(nombres, apellidos, usuario, passw, cPassw);
        }

        private void agregarUsr_Load(object sender, EventArgs e)
        {
            bdCon.mostarUsuarios(tbUsuarios);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            bdCon.mostarUsuarios(tbUsuarios);
        }
    }
}
