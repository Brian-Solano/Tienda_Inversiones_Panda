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
    public partial class Form1 : Form
    {
        public string cadena_conexion = @"Database=Tienda_Inversiones_Panda; Data Source=localhost;User id = root;Password=Huaweiz5";
       
        public Form1()
        {
            InitializeComponent();
        }

        private void lblContra_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtContra.Text))
            {
                //Muestra un mensaje si no rellena campos
                MessageBox.Show("Por favor, rellena todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Pasar a siguiente pantalla
                Menu_Principal MM = new Menu_Principal();
                MM.Show();
                this.Hide();
            }
        }
    }
}
