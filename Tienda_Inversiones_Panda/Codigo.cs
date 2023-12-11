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
    public partial class Codigo : Form
    {
        public string cadena_conexion = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
        public Codigo()
        {
            InitializeComponent();
        }

        private void Codigo_Load(object sender, EventArgs e)
        {
            try
            {
                string consulta = "select * from code";
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
            // Generar el código automáticamente
            string codigoEmpleado = GenerarCodigoEmpleado();
            txtid.Text = codigoEmpleado;

            // Eliminar espacios en blanco al principio y al final de las cadenas
            string nombreEmpleado = txtNomC.Text.Trim();
            string area = txtArea.Text.Trim();

            // Validar que los campos no estén en blanco después de eliminar espacios
            if (string.IsNullOrWhiteSpace(nombreEmpleado) || string.IsNullOrWhiteSpace(area))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO code(Codigo, Nombre_de_Empleado, Area) VALUES (?Codigo, ?Nombre_de_Empleado, ?Area)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Codigo", MySqlDbType.VarChar, 30).Value = txtid.Text;
            myCommand.Parameters.Add("?Nombre_de_Empleado", MySqlDbType.VarChar, 30).Value = nombreEmpleado;
            myCommand.Parameters.Add("?Area", MySqlDbType.VarChar, 30).Value = area;

            try
            {
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Agregado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myCommand.Connection.Close();
            }

            // Actualizar la tabla después de agregar un nuevo registro
            ActualizarTabla();

            txtNomC.Clear();
            txtid.Clear();
            txtArea.Clear();
        }


        private string GenerarCodigoEmpleado()
        {
            
            Random random = new Random();
            int numeroAleatorio = random.Next(1000, 9999); // Número aleatorio de 4 dígitos
            string codigoEmpleado = $"EMP-{numeroAleatorio}";

            return codigoEmpleado;
        }

        // Método para actualizar la tabla
        private void ActualizarTabla()
        {
            string consulta = "select * from code";

            MySqlConnection conexion = new MySqlConnection(cadena_conexion);
            MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
            System.Data.DataSet ds = new System.Data.DataSet();
            comando.Fill(ds, "inventario");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "inventario";
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";

                using (MySqlConnection myConnection = new MySqlConnection(myConnectionString))
                {
                    string myInsertQuery = "DELETE FROM code WHERE code.Codigo = @Codigo";

                    using (MySqlCommand myCommand = new MySqlCommand(myInsertQuery))
                    {
                        myCommand.Parameters.AddWithValue("@Codigo", txtid.Text);
                        myCommand.Connection = myConnection;

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Eliminado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string cad = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
                string query = "SELECT * FROM code";

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
            txtNomC.Clear();
            txtid.Clear();
            txtArea.Clear();
          
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0]; // Obtén la fila seleccionada

                // Accede a los valores de las celdas individuales dentro de la fila
              
                string nombre = GetCellValue(row, "Nombre_de_Empleado");
                string area = GetCellValue(row, "Area");
                string codigo = GetCellValue(row, "Codigo"); // Cambiado a string para manejar tanto números como texto

                // Asigna los valores a los TextBoxes correspondientes
               
                txtNomC.Text = nombre;
                txtArea.Text = area;
                txtid.Text = codigo;
            }

        }

        // Método auxiliar para obtener el valor de una celda como cadena
        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            return row.Cells[columnName]?.Value?.ToString() ?? string.Empty;
        }
    }
}
