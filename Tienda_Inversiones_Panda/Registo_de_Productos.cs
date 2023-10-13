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
            string myInsertQuery = "INSERT INTO producto(Nombre,Distribuidor,Disponibles,ID) Values(?Nombre,?Distribuidor,?Disponibles,?ID)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Nombre", MySqlDbType.VarChar, 40).Value = txtNombre.Text;
            myCommand.Parameters.Add("?Distribuidor", MySqlDbType.VarChar, 45).Value = txtDistri.Text;
            myCommand.Parameters.Add("?Disponibles", MySqlDbType.Int32, 50).Value = txtDispo.Text;
            myCommand.Parameters.Add("?ID", MySqlDbType.Int32, 40).Value = txtId.Text;
           

            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            MessageBox.Show("Productos agregado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            string consulta = "select * from producto";

            MySqlConnection conexion = new MySqlConnection(cadena_conexion);
            MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
            System.Data.DataSet ds = new System.Data.DataSet();
            comando.Fill(ds, "inventario");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "inventario";


            MessageBox.Show("Se ha guardado el dato en la tabla Producto");
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

                    // Luego, puedes realizar la consulta nuevamente para actualizar el DataGridView.
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

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

      



        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=inventario;User Id=BrianSolano;Password=12345";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Aquí debes verificar la validez de los datos antes de realizar la actualización en la base de datos.

                    if (EsValido(txtNombre.Text, txtDistri.Text, txtDispo.Text))
                    {
                        // La función EsValido() debe implementarse para verificar la validez de los datos ingresados.
                        // Si los datos son válidos, puedes proceder con la actualización en la base de datos.

                        string updateQuery = "UPDATE producto SET Nombre = @Nombre, Distribuidor = @Distribuidor, Disponibles = @Disponibles WHERE ID = @ID";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);

                        // Asegúrate de reemplazar los parámetros con los valores de los campos de texto correspondientes.
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

                        // Luego, puedes actualizar el DataGridView para reflejar los cambios en la base de datos.
                        string selectQuery = "SELECT * FROM producto";
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectQuery, connection);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet, "inventario");
                        dataGridView1.DataSource = dataSet.Tables["inventario"];
                    }
                    else
                    {
                        MessageBox.Show("Por favor, introduzca datos válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Aquí puedes implementar la lógica adicional para permitir que el usuario corrija los datos inválidos.
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
                // Aquí debes implementar la lógica para verificar la validez de los datos ingresados.
                // Puedes realizar comprobaciones como la verificación de cadenas vacías, valores nulos, formatos de datos y otros requisitos de validación.

                // Por ejemplo, puedes verificar si los campos de texto no están vacíos.
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(distribuidor) || string.IsNullOrWhiteSpace(disponibilidad))
                {
                    return false;
                }

                // Aquí puedes agregar más validaciones según tus requisitos.

                return true; // Devuelve true si todos los datos son válidos.
            }

        }

    }

       

    
}
