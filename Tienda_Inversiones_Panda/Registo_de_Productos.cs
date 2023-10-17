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
        

        public string cadena_conexion = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
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

                MessageBox.Show("Error de conexion 1", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Registo_de_Productos_Load(object sender, EventArgs e)
        {
            idCounter = 1;
            txtId.Text = idCounter.ToString();
        }
     
       
        private void btnatras_Click(object sender, EventArgs e)
        {
           Form formulario = new Menu_Principal();
           this.Hide();
            formulario.Show();
        }

        private void btnNuevoP_Click(object sender, EventArgs e)
        {
            btnEliminar.Visible = true;
            btnIngre.Visible = true;


            txtNombre.Text = "";
            txtDistri.Text = "";
            txtDispo.Text = "";
            txtId.Text = "";



        }

        private void btnIngre_Click(object sender, EventArgs e)
        {
            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO producto(Nombre, Distribuidor, Disponibles, ID) VALUES (?Nombre, ?Distribuidor, ?Disponibles, ?ID)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Nombre", MySqlDbType.VarChar, 40).Value = txtNombre.Text;
            myCommand.Parameters.Add("?Distribuidor", MySqlDbType.VarChar, 45).Value = txtDistri.Text;
            myCommand.Parameters.Add("?Disponibles", MySqlDbType.Int32, 50).Value = txtDispo.Text;

            // Obtiene el último ID de la base de datos y agregar 1
            string getLastIdQuery = "SELECT MAX(ID) FROM producto";
            MySqlCommand getLastIdCommand = new MySqlCommand(getLastIdQuery, myConnection);
            myConnection.Open();
            var result = getLastIdCommand.ExecuteScalar();
            myConnection.Close();
            int newId = result == DBNull.Value ? 1 : Convert.ToInt32(result) + 1;

            // Asignar el nuevo ID al parámetro y al campo de texto correspondiente
            myCommand.Parameters.Add("?ID", MySqlDbType.Int32, 40).Value = newId;
            txtId.Text = newId.ToString();

            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            MessageBox.Show("Productos agregado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
            string consulta = "select * from producto";

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
                string connectionString = "Server=localhost;Database=inventario;User Id=BrianSolano;Password=12345";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM producto WHERE ID = @Producto";
                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@Producto", txtId.Text);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Producto Eliminado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El producto no se encontró en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Luego, realiza la consulta nuevamente para actualizar el DataGridView.
                    string selectQuery = "SELECT * FROM producto";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectQuery, connection);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "inventario");
                    dataGridView1.DataSource = dataSet.Tables["inventario"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtIngresarProducto_TextChanged(object sender, EventArgs e)
        {

        }



        // Variable para almacenar el contador de ID.
        private int idCounter = 0;

        // Evento TextChanged para el control txtId
        private void txtId_TextChanged(object sender, EventArgs e)
        {

            if (!int.TryParse(txtId.Text, out idCounter)) // Comprueba si el texto es un número entero válido
            {
                // Si no es un número válido, establece el ID en el valor actual del contador.
                txtId.Text = idCounter.ToString();
            }
        }






        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0]; // Obtén la fila seleccionada

                // Accede a los valores de las celdas individuales dentro de la fila
                string nombre = row.Cells["Nombre"].Value.ToString();
                string distribuidor = row.Cells["Distribuidor"].Value.ToString();
                string disponibilidad = row.Cells["Disponibles"].Value.ToString();
                int id = Convert.ToInt32(row.Cells["ID"].Value); 

                // Asigna los valores a los TextBoxes correspondientes
                txtNombre.Text = nombre;
                txtDistri.Text = distribuidor;
                txtDispo.Text = disponibilidad;
                txtId.Text = id.ToString();
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=inventario;User Id=BrianSolano;Password=12345";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Aquí verifica la validez de los datos antes de realizar la actualización en la base de datos.

                    if (EsValido(txtNombre.Text, txtDistri.Text, txtDispo.Text))
                    {
                        

                        string updateQuery = "UPDATE producto SET Nombre = @Nombre, Distribuidor = @Distribuidor, Disponibles = @Disponibles WHERE ID = @ID";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);

                     
                        updateCommand.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        updateCommand.Parameters.AddWithValue("@Distribuidor", txtDistri.Text);
                        updateCommand.Parameters.AddWithValue("@Disponibles", txtDispo.Text);
                        updateCommand.Parameters.AddWithValue("@ID", txtId.Text);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Producto actualizado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar el producto en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        string selectQuery = "SELECT * FROM producto";
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectQuery, connection);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet, "inventario");
                        dataGridView1.DataSource = dataSet.Tables["inventario"];
                    }
                    else
                    {
                        MessageBox.Show("Por favor, introduzca datos válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Función para verificar la validez de los datos ingresados
            bool EsValido(string nombre, string distribuidor, string disponibilidad)
            {
               
                // realizar comprobaciones como la verificación de cadenas vacías, valores nulos, formatos de datos y otros requisitos de validación.

              
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(distribuidor) || string.IsNullOrWhiteSpace(disponibilidad))
                {
                    return false;
                }

               

                return true; // Devuelve true si todos los datos son válidos.
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text) && dataGridView1.DataSource == null)
            {
                // Si el campo de búsqueda está vacío y el DataGridView también está vacío, no muestra el MessageBox.
                // Limpiar el campo de búsqueda y el DataGridView aquí si es necesario.
                txtBuscar.Clear(); // Limpiar el campo de búsqueda
            }
            else if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                string consulta = string.Empty;

                if (RavId.Checked) // Verificar si se selecciona el radio button de ID
                {
                   
                    // Utiliza el valor de txtBuscar.Text para realizar la búsqueda por ID
                    consulta = "SELECT * FROM producto WHERE Id = '" + txtBuscar.Text + "'";
                }
                else if (RavNombre.Checked) // Verificar si se selecciona el radio button de nombre
                {
                    
                    // Utiliza el valor de txtBuscar.Text para realizar la búsqueda por nombre
                    consulta = "SELECT * FROM producto WHERE Nombre = '" + txtBuscar.Text + "'";
                }

                // Ejecutar la consulta y vincular los resultados al DataGridView
                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "resultado");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "resultado";
            }
        }

        private void RavId_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RavNombre_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

       

    
}
