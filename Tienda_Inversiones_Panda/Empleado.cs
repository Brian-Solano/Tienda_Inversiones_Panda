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
    public partial class Empleado : Form
    {
        public string cadena_conexion = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
        public Empleado()
        {
            InitializeComponent();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            try
            {
                string consulta = "select * from empleados";
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

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Form formulario = new Menu_Principal();
            this.Close();
            formulario.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO empleados(Nombre, Apellido, Turno_de, Turno_a, Area, Id) VALUES (?Nombre, ?Apellido, ?Turno_de, ?Turno_a, ?Area, ?Id)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Nombre", MySqlDbType.VarChar, 30).Value = txtNombre.Text;
            myCommand.Parameters.Add("?Apellido", MySqlDbType.VarChar, 30).Value = txtApellido.Text;
            myCommand.Parameters.Add("?Turno_de", MySqlDbType.VarChar, 30).Value = txtTurno.Text;
            myCommand.Parameters.Add("?Turno_a", MySqlDbType.VarChar, 50).Value = txtTurno1.Text;
            myCommand.Parameters.Add("?Area", MySqlDbType.VarChar, 30).Value = txtArea.Text;
            myCommand.Parameters.Add("?Id", MySqlDbType.VarChar, 30).Value = txtid.Text;


            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            MessageBox.Show("Empleados agregado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            string consulta = "select * from empleados";

            MySqlConnection conexion = new MySqlConnection(cadena_conexion);
            MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
            System.Data.DataSet ds = new System.Data.DataSet();
            comando.Fill(ds, "inventario");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "inventario";



            MessageBox.Show("Se ha Guardado el dato en la tabla Clientes");

            // Limpiar campos de texto
            txtNombre.Clear();
            txtApellido.Clear();
            txtArea.Clear();
            txtid.Clear();
        
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";

                using (MySqlConnection myConnection = new MySqlConnection(myConnectionString))
                {
                    string myInsertQuery = "DELETE FROM empleados WHERE empleados.ID = @Id";

                    using (MySqlCommand myCommand = new MySqlCommand(myInsertQuery))
                    {
                        myCommand.Parameters.AddWithValue("@Id", txtid.Text);
                        myCommand.Connection = myConnection;

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Eliminado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

             

                string cad = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
                string query = "SELECT * FROM empleados";

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

            // Limpiar campos de texto
            txtNombre.Clear();
            txtApellido.Clear();
            txtArea.Clear();
            txtid.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0]; // Obtén la fila seleccionada

                // Accede a los valores de las celdas individuales dentro de la fila
                string apellido = GetCellValue(row, "Apellido");
                string nombre = GetCellValue(row, "Nombre");
                string area = GetCellValue(row, "Area");
                string id = GetCellValue(row, "Id"); // Cambiado a string para manejar tanto números como texto

                // Asigna los valores a los TextBoxes correspondientes
                txtApellido.Text = apellido;
                txtNombre.Text = nombre;
                txtArea.Text = area;
                txtid.Text = id;
            }

        }


        // Método auxiliar para obtener el valor de una celda como cadena
        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            return row.Cells[columnName]?.Value?.ToString() ?? string.Empty;
        }
    }
}
