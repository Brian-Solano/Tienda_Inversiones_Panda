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
    public partial class Login : Form
    {
        public string cadena_conexion = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";

        public Login()
        {
            InitializeComponent();
        }

        private void lblContra_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            // Verificar si los campos de usuario y contraseña no están vacíos
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtContra.Text))
            {
                // Mostrar un mensaje si no se rellenan los campos
                MessageBox.Show("Por favor, rellene todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string usuarioIngresado = txtUser.Text;
                string contraseñaIngresada = txtContra.Text;

                // Verificar la autenticidad del usuario y la contraseña en la base de datos
                string cadena_conexion = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345"; 
                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                conexion.Open();

                string query = "SELECT COUNT(*) FROM login WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Usuario", usuarioIngresado);
                comando.Parameters.AddWithValue("@Contraseña", contraseñaIngresada);
                int count = Convert.ToInt32(comando.ExecuteScalar());

                if (count > 0)
                {
                    // Usuario autenticado, pasar a la siguiente pantalla
                    Menu_Principal MM = new Menu_Principal();
                    MM.Show();
                    this.Hide();
                }
                else
                {
                    // Usuario no autenticado, mostrar un mensaje de error
                    MessageBox.Show("Usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.", "Autenticación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conexion.Close();
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
