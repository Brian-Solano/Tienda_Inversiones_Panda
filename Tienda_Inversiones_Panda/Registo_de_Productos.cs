using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Tienda_Inversiones_Panda
{
    public partial class Registo_de_Productos : Form
    {
        

        public string cadena_conexion = @"Database=Tienda_Inversiones_Panda; Data Source=localhost;User id = root;Password=Huaweiz5";
        public Registo_de_Productos()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string consulta = "select * from producto";
                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "producto");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "producto";
            }
            catch (MySqlException)
            {

                MessageBox.Show("Error de conexion", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Registo_de_Productos_Load(object sender, EventArgs e)
        {

        }
     
       
        private void btnatras_Click(object sender, EventArgs e)
        {
            Form formulario = new Menu_Principal();
            this.Hide();
            formulario.Show();
        }
    }
}
