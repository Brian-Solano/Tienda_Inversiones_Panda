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
    public partial class Clientes : Form
    {
        public string cadena_conexion = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            try
            {
                string consulta = "select * from cliente";
                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "inventario");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "inventario";
            }
            catch (MySqlException)
            {

                MessageBox.Show("Error de conexion", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnEliminar.Visible = true;
            btnGuardar.Visible = true;

            txtNombre.Text = "";
            txtDui.Text = "";
            txtApellido.Text = "";
            txtId.Text = "";
            txtTimer.Text = "";
            txtDesc.Text= "";
            txtTel.Text = "";
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Form formulario = new Menu_Principal();
            this.Hide();
            formulario.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO cliente(Nombre, Apellido, DUI, Telefono, Fecha_de_Nacimiento,  Direccion, Id) VALUES (?Nombre,?Apellido,?DUI,?Telefono,?Fecha_de_Nacimiento,?Direccion, ?Id)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Nombre", MySqlDbType.VarChar, 30).Value = txtNombre.Text;
            myCommand.Parameters.Add("?Apellido", MySqlDbType.VarChar, 30).Value = txtApellido.Text;
            myCommand.Parameters.Add("?DUI", MySqlDbType.VarChar, 30).Value = txtDui.Text;
            myCommand.Parameters.Add("?Telefono", MySqlDbType.VarChar, 50).Value = txtTel.Text;
            myCommand.Parameters.Add("?Direccion", MySqlDbType.VarChar, 30).Value = txtDesc.Text;
            myCommand.Parameters.Add("?Fecha_de_Nacimiento", MySqlDbType.VarChar, 30).Value = txtTimer.Text;
            myCommand.Parameters.Add("?Id", MySqlDbType.VarChar, 30).Value = txtId.Text;

            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            MessageBox.Show("Cliente agregado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            string consulta = "select * from cliente";

            MySqlConnection conexion = new MySqlConnection(cadena_conexion);
            MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
            System.Data.DataSet ds = new System.Data.DataSet();
            comando.Fill(ds, "inventario");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "inventario";



            MessageBox.Show("Se ha Guardado el dato en la tabla Clientes");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";

                using (MySqlConnection myConnection = new MySqlConnection(myConnectionString))
                {
                    string myDeleteQuery = "DELETE FROM cliente WHERE cliente.ID = @Id";

                    using (MySqlCommand myCommand = new MySqlCommand(myDeleteQuery))
                    {
                        myCommand.Parameters.AddWithValue("@Id", txtId.Text);
                        myCommand.Connection = myConnection;

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Eliminado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos de texto
                txtId.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtDesc.Clear();
                txtDui.Clear();
                txtTel.Clear();

                // Recargar datos en el DataGridView
                string cad = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
                string query = "SELECT * FROM cliente";

                using (MySqlConnection cnn = new MySqlConnection(cad))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    da.Fill(ds, "inventario");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "inventario";
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No se ha podido hacer la eliminación. Error: " + ex.Message);
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0]; // Obtén la fila seleccionada

                // Accede a los valores de las celdas individuales dentro de la fila
                string nombre = GetCellValue(row, "Nombre");
                string dui = GetCellValue(row, "Dui");
                string apellido = GetCellValue(row, "Apellido");
                string desc = GetCellValue(row, "Direccion");
                string tel = GetCellValue(row, "Telefono");
                string Id = GetCellValue(row, "Id"); // Cambiado a string para manejar tanto números como texto


                // Asigna los valores a los TextBoxes correspondientes
                txtNombre.Text = nombre;
                txtDui.Text = dui;
                txtApellido.Text = apellido;
                txtDesc.Text = desc;
                txtTel.Text = tel;
                txtId.Text = Id;


            }

          
        }

        // Método auxiliar para obtener el valor de una celda como cadena
        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            return row.Cells[columnName]?.Value?.ToString() ?? string.Empty;
        }
    }
}
