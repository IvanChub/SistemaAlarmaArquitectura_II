using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalArquitectura_II
{
    public partial class Form1 : Form
    {
        classConectar bdCon = new classConectar();
        int index = 0;
        bool IsClose = false;
        //int contadorI = 3;
        public Form1()
        {
            InitializeComponent();

            lblFecha.Text = "";
            lblHora.Text = "";

            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy"); //Agrega la fecha del sistema
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt"); //Agrega la hora del sistema
            timer1.Enabled = false;

            //serialPort1.Open();
            //try
            //{
            //    serialPort1.Open();
            //}
            //catch
            //{
            //    MessageBox.Show("El arduino no esta conectado");
            //}

            //serialPort1.DataReceived += serialPort1_DataReceived;
            lbl1.Text = "";
            lbl2.Text = "";
            lbl3.Text = "";
            lbl4.Text = "";
            lbl5.Text = "";
            lbl6.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarUsr frm2 = new agregarUsr();
            frm2.Show();
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            registroAc frm3 = new registroAc();
            frm3.Show();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            //serialPort1.Close();
            string usuario = txtUsrA.Text;
            string pass = txtPassA.Text;
            string fecha = lblFecha.Text;
            string hora = lblHora.Text;

            try
            {
                Thread cadena = new Thread(escuchar);
                cadena.Start();
                //serialPort1.Open();
                //timer1.Enabled = true;
                //timer1.Start();
                bdCon.activarA(usuario, pass, fecha, hora);
                
            }
            catch
            {
                MessageBox.Show("Usuario y o contraseña invalidos, intentelo nuevamente");
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsrD.Text;
            string pass = txtPassD.Text;

            string fecha = lblFecha.Text;
            string hora = lblHora.Text;

            string mensaje = lblMensaje.Text;

            try
            {
                bdCon.desactivarA(usuario, pass, fecha, hora, mensaje);
            }
            catch
            {
                MessageBox.Show("Usuario y o contraseña invalidos, intentelo nuevamente");
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //string[] datos = serialPort1.ReadLine().Split(' ');

            //int puerta1 = Convert.ToInt32(datos[0]);
            //int puerta2 = Convert.ToInt32(datos[1]);
            //int ventana1 = Convert.ToInt32(datos[2]);
            //int ventana2 = Convert.ToInt32(datos[3]);
            //int ventana3 = Convert.ToInt32(datos[4]);
            //int ventana4 = Convert.ToInt32(datos[5]);

            //Invoke(new Action(() => lbl1.Text = puerta1.ToString()));
            //Invoke(new Action(() => lbl2.Text = puerta2.ToString()));
            //Invoke(new Action(() => lbl3.Text = ventana1.ToString()));
            //Invoke(new Action(() => lbl4.Text = ventana2.ToString()));
            //Invoke(new Action(() => lbl5.Text = ventana3.ToString()));
            //Invoke(new Action(() => lbl6.Text = ventana4.ToString()));
        }

        private void escuchar()
        {
            while(!IsClose)
            {
                try
                {
                    string[] datos = serialPort1.ReadLine().Split(' ');
                    int puerta1 = Convert.ToInt32(datos[0]);
                    int puerta2 = Convert.ToInt32(datos[1]);
                    int ventana1 = Convert.ToInt32(datos[2]);
                    int ventana2 = Convert.ToInt32(datos[3]);
                    int ventana3 = Convert.ToInt32(datos[4]);
                    int ventana4 = Convert.ToInt32(datos[5]);

                    lbl1.Invoke(new MethodInvoker(delegate { lbl1.Text = puerta1.ToString(); }));
                    lbl2.Invoke(new MethodInvoker(delegate { lbl2.Text = puerta2.ToString(); }));
                    lbl3.Invoke(new MethodInvoker(delegate { lbl3.Text = ventana1.ToString(); }));
                    lbl4.Invoke(new MethodInvoker(delegate { lbl4.Text = ventana2.ToString(); }));
                    lbl5.Invoke(new MethodInvoker(delegate { lbl5.Text = ventana3.ToString(); }));
                    lbl6.Invoke(new MethodInvoker(delegate { lbl6.Text = ventana4.ToString(); }));
                }
                catch
                {

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            serialPort1.Write("a");

            //string p1 = serialPort1.ReadLine();
            //string p2 = serialPort1.ReadLine();
            //string v1 = serialPort1.ReadLine();
            //string v2 = serialPort1.ReadLine();
            //string v3 = serialPort1.ReadLine();
            //string v4 = serialPort1.ReadLine();

            //lbl1.Text = p1;
            //lbl2.Text = p2;
            //lbl3.Text = v1;
            //lbl4.Text = v2;
            //lbl5.Text = v3;
            //lbl6.Text = v4;

            index++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            serialPort1.Write("s");

            index++;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsClose = true;
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
            timer1.Enabled = true;
            timer1.Start();
            string mensaje = "";
            MessageBox.Show("Alarma Activada");
            //evalua los sensores y datos que arrojan cada uno de ellos
            int p1 = 0;//Convert.ToInt32(lbl1.Text);
            int p2 = 0;//Convert.ToInt32(lbl2.Text);
            int v1 = 0;//Convert.ToInt32(lbl3.Text);
            int v2 = 0;//Convert.ToInt32(lbl4.Text);
            int v3 = 0;//Convert.ToInt32(lbl5.Text);
            int v4 = 0;//Convert.ToInt32(lbl6.Text);

            //p1 = Int32.Parse(lbl1.Text);
            //p2 = Int32.Parse(lbl2.Text);
            //v1 = Int32.Parse(lbl3.Text);
            //v2 = Int32.Parse(lbl4.Text);
            //v3 = Int32.Parse(lbl5.Text);
            //v4 = Int32.Parse(lbl6.Text);

            lbl1.Text = p1.ToString();
            lbl2.Text = p2.ToString();
            lbl3.Text = v1.ToString();
            lbl4.Text = v2.ToString();
            lbl5.Text = v3.ToString();
            lbl6.Text = v4.ToString();

            if (p1 > 10)
            {
                timer2.Enabled = true;
                timer2.Start();
                timer1.Stop();
                mensaje = "Intruso detectado en la puerta 1";
                MessageBox.Show("Presencia de extraño, sistema disparado");
            }
            if (p2 == 3)
            {
                timer2.Enabled = true;
                timer2.Start();
                timer1.Stop();
                mensaje = "Intruso detectado en la puerta 2";
                MessageBox.Show("Presencia de extraño, sistema disparado");
            }
            if (v1 == 4)
            {
                timer2.Enabled = true;
                timer2.Start();
                timer1.Stop();
                mensaje = "Intruso detectado en la ventana 1";
                MessageBox.Show("Presencia de extraño, sistema disparado");
            }
            if (v2 == 5)
            {
                timer2.Enabled = true;
                timer2.Start();
                timer1.Stop();
                mensaje = "Intruso detectado en la ventana 2";
                MessageBox.Show("Presencia de extraño, sistema disparado");
            }
            if (v3 == 6)
            {
                timer2.Enabled = true;
                timer2.Start();
                timer1.Stop();
                mensaje = "Intruso detectado en la ventana 3";
                MessageBox.Show("Presencia de extraño, sistema disparado");
            }
            if (v4 == 7)
            {
                timer2.Enabled = true;
                timer2.Start();
                timer1.Stop();
                mensaje = "Intruso detectado en la ventana 4";
                MessageBox.Show("Presencia de extraño, sistema disparado");
            }
            else
            {
                timer1.Enabled = true;
                timer1.Start();
                timer2.Enabled = false;
                timer2.Stop();
                mensaje = "No se detecto ningun intruso";
            }
            // muestra los campos para desabilitar la alarma
            label7.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            txtPassD.Visible = true;
            txtUsrD.Visible = true;
            btnAgregar.Visible = true;
            btnDesactivar.Visible = true;
            btnRegistros.Visible = true;
            button2.Visible = true;


            //oculta los campos para habilitar la alarma
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            label4.Visible = false;
            txtUsrA.Visible = false;
            txtPassA.Visible = false;
            btnActivar.Visible = false;
            button1.Visible = false;

            lblMensaje.Text = "";
            lblMensaje.Text = mensaje;

            //vacia los campos
            txtUsrA.Text = "";
            txtPassA.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //detenemos la deteccion de todos los sensores
            //serialPort1.Open();
            timer1.Enabled = false;
            timer1.Stop();
            timer2.Enabled = false;
            timer2.Stop();
            serialPort1.Write("d");

            serialPort1.Close();
            //muestra los campos para activar la alarma
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            label4.Visible = true;
            txtUsrA.Visible = true;
            txtPassA.Visible = true;
            btnActivar.Visible = true;
            button1.Visible = true;



            //limpiamos campos
            txtUsrD.Text = "";
            txtPassD.Text = "";

            //oculta los campos para desabilitar la alarma
            label7.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            txtPassD.Visible = false;
            txtUsrD.Visible = false;
            btnAgregar.Visible = false;
            btnDesactivar.Visible = false;
            btnRegistros.Visible = false;
            button2.Visible = false;
            MessageBox.Show("Alarma Desactivada");
        }
    }
}
