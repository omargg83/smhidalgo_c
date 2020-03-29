using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace smhidalgo
{
    public partial class inicio : Form
    {
        private MySqlConnection connection;
        MySqlDataAdapter myDA = new MySqlDataAdapter();

        public inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aceptar();
        }
        private void Aceptar() {
            string consulta;
            string cadena;
            string source = txt_pass.Text;
            
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);
                cadena = hash;
                cadena = cadena.ToUpper();
            }


            session_sistema.connectionString = "SERVER=sagyc.com.mx;DATABASE=sagycrmr_smhidalgo;UID=sagyccom_esponda;PASSWORD=esponda123$";
            connection = new MySqlConnection(session_sistema.connectionString);
            connection.Open();

            consulta = "select * from et_usuario where user = '" + txt_user.Text.Trim() + "' and pass='" + cadena.Trim() + "'";
            MySqlCommand mycmd = new MySqlCommand();
            mycmd.Connection = connection;
            mycmd.CommandText = consulta;
            MySqlDataReader myreader = mycmd.ExecuteReader();
            if (myreader.HasRows)
            {
                myreader.Read();
               
                
                session_sistema.idtienda = 1;
                session_sistema.idpersona = Convert.ToInt32(myreader["idusuario"]);
                this.Hide();

                imprime frm = new imprime();
                frm.ShowDialog();
            }
            else {
                MessageBox.Show("Contraseña incorrecta",session_sistema.nombre_sis);
            }
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
