using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalArquitectura_II
{
    public class classConectar
    {
        private MySqlConnection conectar;
        public classConectar()
        {
            Iniciar();
        }

        private void Iniciar()
        {
            string ConsultaConectar = "Server=192.168.1.26; Database=bdSistemaAlarma; user id=abelardo; Pwd=5538ivan;";
            //string ConsultaConectar = "Server=localhost; Database=bdsistemaalarma; user id=root;";

            conectar = new MySqlConnection(ConsultaConectar);
        }

        public bool OpenConnection()
        {
            try
            {
                conectar.Open();
                Console.WriteLine("Conexion exitosa");
                return true;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Error de conexion [" + ex + "]");
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                conectar.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Error al cerrar la conexion [" +ex+"]");
                return false;
            }
        }

        public void insertarUsuario(string nombres, string apellidos, string usuario, string passw, string cPassw)
        {
            agregarUsr frm2 = new agregarUsr();
            string cadenaE = classSeguridad.Encriptar(passw);

            string insertUsuario = "INSERT INTO tb_usuario(nombres, apellidos, usuario, passw) VALUES ('" + nombres + "','" + apellidos + "','" + usuario + "','" + cadenaE + "')";

            if (passw == cPassw)
            {
                //abrimos conexion
                if(this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(insertUsuario, conectar);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario agregado con exito");

                    //cerramos conexion
                    this.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Asegurese de escribir correctamente la contraseña de confirmación");
            }
        }
                
        public void mostarUsuarios(DataGridView dgv)
        {
            DataTable tabla = new DataTable();
            if (this.OpenConnection() == true)
            {
                tabla.AcceptChanges();
                string mUsuarios = "SELECT tb_usuario.id AS 'No.', tb_usuario.nombres AS 'Nombres', tb_usuario.apellidos AS 'Apellidos', tb_usuario.usuario AS 'Usuario' FROM tb_usuario";
                MySqlCommand cmd = new MySqlCommand(mUsuarios, conectar);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
                dgv.DataSource = tabla;

                this.CloseConnection();
            }
        }
        public void mostrarRegistro(DataGridView dgv)
        {
            DataTable tabla = new DataTable();
            if (this.OpenConnection() == true)
            {
                string consulta = "SELECT tb_usuario.usuario AS 'Usuario', tb_registro.accionRealizada AS 'Accion Realizada', tb_registro.sensor AS 'Sensor Accionado', tb_registro.fechaHora AS 'Fecha y Hora' FROM tb_registro INNER JOIN tb_usuario ON tb_usuario.id = tb_registro.idUsuario";
                MySqlCommand cmd = new MySqlCommand(consulta, conectar);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
                dgv.DataSource = tabla;

                this.CloseConnection();
            }
        }

        public void activarA(string usuario, string passwd, string fecha, string hora)
        {
            string id = "";
            //comparar la contraseña del usuario ingresado para desencriptarla y ver si es la correcta
            string consulta = "SELECT tb_usuario.id, tb_usuario.passw FROM tb_usuario WHERE usuario = @usuario LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(consulta, conectar);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            this.OpenConnection();

            MySqlDataReader reader = cmd.ExecuteReader();

            string passEncrip = "";


            if (reader.Read())
            {
                id = reader["id"].ToString();
                passEncrip = reader.GetString(1);
                //passEncrip = reader["passw"].ToString();
                //reader("tb_usuario.passw");
            }

            this.CloseConnection();
            //desencriptamos la cadena
            string cadenaD = classSeguridad.Desencriptar(passEncrip);


            if (passwd == cadenaD)
            {
                MessageBox.Show("Usuario y o Contraseña ingresados correctamente");
            }

            this.OpenConnection();
            int idUsuario = Convert.ToInt32(id);
            string fechaHora = "" + fecha + " | " + hora;

            string insertarRA = "INSERT INTO tb_registro(idUsuario, accionRealizada, sensor, fechaHora) VALUES ('" + idUsuario + "','Activación de alarma','na','" + fechaHora + "')";
            MySqlCommand cmdI = new MySqlCommand(insertarRA, conectar);
            cmdI.ExecuteNonQuery();

            this.CloseConnection();
        }
        public void desactivarA(string usuario, string passwd, string fecha, string hora, string mensaje)
        {
            string id = "";
            //comparar la contraseña del usuario ingresado para desencriptarla y ver si es la correcta
            string consulta = "SELECT tb_usuario.id, tb_usuario.passw FROM tb_usuario WHERE usuario = @usuario LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(consulta, conectar);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            this.OpenConnection();

            MySqlDataReader reader = cmd.ExecuteReader();

            string passEncrip = "";


            if (reader.Read())
            {
                id = reader["id"].ToString();
                passEncrip = reader.GetString(1);
                //passEncrip = reader["passw"].ToString();
                //reader("tb_usuario.passw");
            }

            this.CloseConnection();
            //desencriptamos la cadena
            string cadenaD = classSeguridad.Desencriptar(passEncrip);


            if (passwd == cadenaD)
            {
                MessageBox.Show("Usuario y o Contraseña ingresados correctamente");
            }

            this.OpenConnection();
            int idUsuario = Convert.ToInt32(id);
            string fechaHora = "" + fecha + " | " + hora;

            string insertarRA = "INSERT INTO tb_registro(idUsuario, accionRealizada, sensor, fechaHora) VALUES ('" + idUsuario + "','Desactivación de alarma','" + mensaje + "','" + fechaHora + "')";
            MySqlCommand cmdI = new MySqlCommand(insertarRA, conectar);
            cmdI.ExecuteNonQuery();

            this.CloseConnection();
        }
    }
}
