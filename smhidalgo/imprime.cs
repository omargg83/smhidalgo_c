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
using System.Drawing.Printing;

namespace smhidalgo
{
    public partial class imprime : Form
    {
        private MySqlConnection connection;
        MySqlDataAdapter myDA = new MySqlDataAdapter();
        DataSet tablex = new DataSet();

        string idtienda="1";
        public imprime()
        {
            InitializeComponent();
            tablex.Tables.Add("tiendas");
            tablex.Tables.Add("ticket");
            tablex.Tables.Add("venta");

            tablex.Tables.Add("ventas_tmp2");
            tablex.Tables.Add("ventas_impresion2");
            tablex.Tables.Add("vendedor_imprime2");
            tablex.Tables.Add("ventas_tienda");
            
            idtienda = AppConfig.recuperarvalor("idtienda", "1");
            toolStripStatusLabel1.Text = idtienda;
            Prueba();
        }
        public void Prueba() {
            connection = new MySqlConnection(session_sistema.connectionString);
            connection.Open();

            string consulta = "select * from et_tienda where id="+session_sistema.idtienda.ToString();
          
            myDA.SelectCommand = new MySqlCommand(consulta, connection);
            tablex.Tables["tiendas"].Clear();
            myDA.Fill(tablex, "tiendas");

            cmb_oficios.DataSource = tablex.Tables["tiendas"];
            cmb_oficios.DisplayMember = "nombre";
            cmb_oficios.ValueMember = "id";
            cmb_oficios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_oficios.SelectedValue = idtienda;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prueba();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmb_oficios.SelectedValue.ToString().Length > 0)
            {
                idtienda = cmb_oficios.SelectedValue.ToString();
                AppConfig.Establecervalor("idtienda", idtienda);
                toolStripStatusLabel1.Text = idtienda;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pendientes();
        }
        private void pendientes()
        {
            string sql = "";
            DateTime hoy = DateTime.Now;
            string modificado = hoy.Year.ToString() + "-" + hoy.Month.ToString() + "-" + hoy.Day.ToString() + " " + hoy.Hour.ToString() + ":" + hoy.Minute.ToString() + ":" + hoy.Second.ToString();
            MySqlDataAdapter myDA = new MySqlDataAdapter();
            toolStripStatusLabel1.Text = idtienda;

            sql = "select idventa from et_venta where idtienda='" + idtienda + "' and estado='Pagada' and imprimir=1 limit 1";
            myDA.SelectCommand = new MySqlCommand(sql, connection);
            tablex.Tables["ticket"].Clear();
            myDA.Fill(tablex, "ticket");

            grid_buscar.DataSource = tablex.Tables["ticket"];
            grid_buscar.Columns[0].HeaderText = "Folio";
            grid_buscar.Columns[0].Visible = false;
            grid_buscar.Update();

            if (tablex.Tables["ticket"].Rows.Count > 0)
            {
                ////////////////////////////imprimir
                PrintDialog dlg = new PrintDialog();
                dlg.Document = printDocument1;
                string csql = "";
                int rows_tmp = 0;
                try
                {
                    string idventa = tablex.Tables["ticket"].Rows[0]["idventa"].ToString();
                    notifyIcon1.BalloonTipText = "Imprimiendo Ticket: " + idventa;
                    notifyIcon1.BalloonTipTitle = "SMHIDALGO";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.ShowBalloonTip(5000);

                    csql = "select * from et_venta where idventa='" + idventa + "'";
                    myDA.SelectCommand = new MySqlCommand(csql, connection);
                    tablex.Tables["ventas_tmp2"].Reset();
                    myDA.Fill(tablex, "ventas_tmp2");
                    rows_tmp = tablex.Tables["ventas_tmp2"].Rows.Count;
                    if (rows_tmp <= 0)
                    {
                        MessageBox.Show("Registro no encontrado", session_sistema.nombre_sis);
                        return;
                    }

                    csql = "select * from bodega where idventa='" + idventa + "'";
                    myDA.SelectCommand = new MySqlCommand(csql, connection);
                    tablex.Tables["ventas_impresion2"].Reset();
                    myDA.Fill(tablex, "ventas_impresion2");

                    csql = "select * from et_usuario where idusuario='" + tablex.Tables["ventas_tmp2"].Rows[0]["idusuario"].ToString() + "'";
                    myDA.SelectCommand = new MySqlCommand(csql, connection);
                    tablex.Tables["vendedor_imprime2"].Reset();
                    myDA.Fill(tablex, "vendedor_imprime2");


                    csql = "select * from et_tienda where id='" + tablex.Tables["ventas_tmp2"].Rows[0]["idtienda"].ToString() + "'";
                    myDA.SelectCommand = new MySqlCommand(csql, connection);
                    tablex.Tables["ventas_tienda"].Reset();
                    myDA.Fill(tablex, "ventas_tienda");

                    string query = "update et_venta set imprimir=0, fimpresa=@hoy, idimprime=@imprime where idventa=@idventa";
                    MySqlCommand com = connection.CreateCommand();
                    com.CommandText = query;
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@idventa", idventa);
                    com.Parameters.AddWithValue("@hoy", modificado);
                    com.Parameters.AddWithValue("@imprime", session_sistema.idpersona);
                    if (com.ExecuteNonQuery() > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("error", session_sistema.nombre_sis);
                    }

                    printDocument1.Print();                    
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("La excepción es: " + ex, session_sistema.nombre_sis);
                }
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int contador, rows_tmp, valy, incremento, valx, inicio;
            incremento = 15;
            valy = 0;
            valx = 10;
            contador = 0;
            inicio = 0;

            Font letra = new Font("Courier New", 10);
            e.Graphics.DrawString("*********************************", letra, Brushes.Black, valx, inicio);
            valy = inicio + incremento;
            e.Graphics.DrawString("           SMH MÓVIL       ", letra, Brushes.Black, valx, valy);
            valy = valy + incremento;
            e.Graphics.DrawString("Sucursal: "+tablex.Tables["tiendas"].Rows[0]["nombre"].ToString(), letra, Brushes.Black, valx, valy);
            valy = valy + incremento;

           e.Graphics.DrawString("********************************", letra, Brushes.Black, valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString("REMISION # " + tablex.Tables["ventas_tmp2"].Rows[0]["idventa"].ToString(), letra, Brushes.Black, valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString("FECHA:", letra, Brushes.Black, valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString(tablex.Tables["ventas_tmp2"].Rows[0]["fecha"].ToString(), letra, Brushes.Black, valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString("ATENDIÓ:", letra, Brushes.Black, valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString(tablex.Tables["vendedor_imprime2"].Rows[0]["nombre"].ToString(), letra, Brushes.Black, valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString("================================", letra, Brushes.Black, valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString("CANT    DESCRIP.        PRECIO", letra, Brushes.Black, valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString("================================", letra, Brushes.Black, valx, valy);

           rows_tmp = tablex.Tables["ventas_impresion2"].Rows.Count;
           valy = valy + incremento;
         
           while (contador < rows_tmp)
           {
               e.Graphics.DrawString(tablex.Tables["ventas_impresion2"].Rows[contador]["v_total"].ToString(), letra, Brushes.Black, valx, valy);
               e.Graphics.DrawString(tablex.Tables["ventas_impresion2"].Rows[contador]["nombre"].ToString().PadRight(15).Substring(0, 10), letra, Brushes.Black, 70 + valx, valy);
               e.Graphics.DrawString(Math.Round(Convert.ToDouble(tablex.Tables["ventas_impresion2"].Rows[contador]["v_precio"]), 2).ToString("0.00").PadLeft(8), letra, Brushes.Black, 200 + valx, valy);
               valy = valy + incremento;
               if (tablex.Tables["ventas_impresion2"].Rows[contador]["observaciones"].ToString().Length > 0)
               {
                   e.Graphics.DrawString(tablex.Tables["ventas_impresion2"].Rows[contador]["observaciones"].ToString().PadRight(15).Substring(0, 10), letra, Brushes.Black, valx, valy);
                   valy = valy + incremento;
               }
               contador++;
           }
           e.Graphics.DrawString("================================", letra, Brushes.Black, valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString("SUBTOTAL:", letra, Brushes.Black, valx, valy);

           e.Graphics.DrawString(Math.Round(Convert.ToDouble(tablex.Tables["ventas_tmp2"].Rows[0]["subtotal"]), 2).ToString("0.00").PadLeft(8), letra, Brushes.Black, 200 + valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString("IVA:", letra, Brushes.Black, valx, valy);
           e.Graphics.DrawString(Math.Round(Convert.ToDouble(tablex.Tables["ventas_tmp2"].Rows[0]["iva"]), 2).ToString("0.00").PadLeft(8), letra, Brushes.Black, 200 + valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString("TOTAL:", letra, Brushes.Black, valx, valy);
           e.Graphics.DrawString(Math.Round(Convert.ToDouble(tablex.Tables["ventas_tmp2"].Rows[0]["total"]), 2).ToString("0.00").PadLeft(8), letra, Brushes.Black, 200 + valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString("================================", letra, Brushes.Black, valx, valy);
           valy = valy + incremento;
           e.Graphics.DrawString("================================", letra, Brushes.Black, valx, valy);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.BalloonTipText = "Minimizado a área de notificaciones";
                notifyIcon1.BalloonTipTitle = "SMHIDALGO";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(5000);
            }
        }

        private void imprime_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void imprime_Load(object sender, EventArgs e)
        {

        }
    }
}
