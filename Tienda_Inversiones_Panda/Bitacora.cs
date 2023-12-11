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
    public partial class Bitacora : Form
    {
        public string cadena_conexion = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
        public Bitacora()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Bitacora_Load(object sender, EventArgs e)
        {

            try
            {
                string consulta = "select * from bitacora";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que no haya campos vacíos en los campos de texto
            if (string.IsNullOrWhiteSpace(txtTarea.Text) ||
                string.IsNullOrWhiteSpace(txtEncargado.Text) ||
                string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtFecha.Text) ||
                string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("No se permiten campos vacíos en los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detener la ejecución si hay campos vacíos
            }

            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO bitacora(Tarea, Encargado, Id, Fecha, Estado) VALUES (?Tarea, ?Encargado, ?Id, ?Fecha, ?Estado)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Tarea", MySqlDbType.VarChar, 30).Value = txtTarea.Text.Trim();
            myCommand.Parameters.Add("?Encargado", MySqlDbType.VarChar, 30).Value = txtEncargado.Text.Trim();
            myCommand.Parameters.Add("?Id", MySqlDbType.VarChar, 30).Value = txtId.Text.Trim();
            myCommand.Parameters.Add("?Fecha", MySqlDbType.VarChar, 30).Value = txtFecha.Text.Trim();
            myCommand.Parameters.Add("?Estado", MySqlDbType.VarChar, 50).Value = txtEstado.Text.Trim();

            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            MessageBox.Show("Agregado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar campos de texto
            txtId.Clear();
            txtEncargado.Clear();
            txtEstado.Clear();
            txtTarea.Clear();

            string consulta = "select * from bitacora";

            MySqlConnection conexion = new MySqlConnection(cadena_conexion);
            MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
            System.Data.DataSet ds = new System.Data.DataSet();
            comando.Fill(ds, "inventario");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "inventario";

            MessageBox.Show("Se ha Guardado el dato en la tabla");


        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado un registro antes de intentar eliminar
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, seleccione un registro antes de eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string myConnectionString = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";

                using (MySqlConnection myConnection = new MySqlConnection(myConnectionString))
                {
                    string myInsertQuery = "DELETE FROM bitacora WHERE bitacora.ID = @Id";

                    using (MySqlCommand myCommand = new MySqlCommand(myInsertQuery))
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
                txtEncargado.Clear();
                txtEstado.Clear();
                txtTarea.Clear();

                // Recargar los datos en el DataGridView después de la eliminación
                CargarDatosEnDataGridView();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No se ha podido hacer la eliminación. Error: " + ex.Message);
            }
        }

        // Función para cargar datos en el DataGridView
        private void CargarDatosEnDataGridView()
        {
            string cad = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
            string query = "SELECT * FROM bitacora";

            using (MySqlConnection cnn = new MySqlConnection(cad))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "inventario");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "inventario";
            }
        }


        private void btnAtras_Click(object sender, EventArgs e)
        {
            Form formulario = new Menu_Principal();
            this.Close();
            formulario.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0]; // Obtén la fila seleccionada

                // Accede a los valores de las celdas individuales dentro de la fila
                string tarea = GetCellValue(row, "Tarea");
                string encargado = GetCellValue(row, "Encargado");
                string estado = GetCellValue(row, "Estado");
                string Id = GetCellValue(row, "ID"); // Cambiado a string para manejar tanto números como texto

                // Asigna los valores a los TextBoxes correspondientes
                txtTarea.Text = tarea;
                txtEncargado.Text = encargado;
                txtEstado.Text = estado;
                txtId.Text = Id;

                // Agrega código para obtener y mostrar la fecha
                string fecha = GetCellValue(row, "Fecha");
                txtFecha.Text = fecha;
            }
        }

        // Función para obtener el valor de una celda específica
        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            return row.Cells[columnName].Value.ToString();
        }


        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
