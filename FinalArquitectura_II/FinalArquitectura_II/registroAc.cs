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
    public partial class registroAc : Form
    {
        classConectar bdCon = new classConectar();
        public registroAc()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void registroAc_Load(object sender, EventArgs e)
        {
            bdCon.mostrarRegistro(tbAcciones);
        }
    }
}
