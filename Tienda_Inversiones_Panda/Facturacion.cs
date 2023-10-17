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
    public partial class Facturacion : Form
    {
        public string cadena_conexion = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
        public Facturacion()
        {
            InitializeComponent();
            
        }

       


        private void Facturacion_Load(object sender, EventArgs e)
        {
            try
            {
                string consulta = "select * from pedidos";
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
            this.Hide(); 
            formulario.Show(); 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO pedidos(Nombre_Cliente, Id, Precio, Cantidad, Total, Fecha_de_Pedido, Producto) VALUES (?Nombre_Cliente, ?Id, ?Cantidad, ?Precio, ?Total, ?Fecha_de_Pedido, ?Producto)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Nombre_Cliente", MySqlDbType.VarChar, 30).Value = txtNom.Text;
            myCommand.Parameters.Add("?Fecha_de_Pedido", MySqlDbType.VarChar, 30).Value = dtmFecha.Text;
            myCommand.Parameters.Add("?Producto", MySqlDbType.VarChar, 50).Value = txtPro.Text;
            myCommand.Parameters.Add("?Id", MySqlDbType.VarChar, 30).Value = txtId.Text;
            myCommand.Parameters.Add("?Precio", MySqlDbType.VarChar, 30).Value = txtPrecio1.Text;
            myCommand.Parameters.Add("?Cantidad", MySqlDbType.VarChar, 30).Value = txtCantidad1.Text;
            myCommand.Parameters.Add("?Total", MySqlDbType.VarChar, 30).Value = txtCantidad1.Text;
          



            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            MessageBox.Show("Empleados agregado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            string consulta = "select * from pedidos";

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
                MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                string myInsertQuery = "DELETE FROM pedidos WHERE pedidos.ID = @Id";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Parameters.AddWithValue("@Id", txtId.Text); 
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                MessageBox.Show("Eliminado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string cad = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
                string query = "select * from pedidos";
                MySqlConnection cnn = new MySqlConnection(cad);
                MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "inventario");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "inventario";
            }
            catch (System.Exception)
            {
                MessageBox.Show("No se ha podido hacer la eliminación");
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnEliminar.Visible = true;
            btnGuardar.Visible = true;


            txtNom.Text = "";
            txtPrecio1.Text = "";
            txtCantidad1.Text = "";
            txtPro.Text = "";
            dtmFecha.Text = "";
            txtId.Text = "";
            txtTotal.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0]; // Obtiene la fila seleccionada

                // Accede a los valores de las celdas individuales dentro de la fila
                string nombre = row.Cells["Nombre_Cliente"].Value.ToString();
                string producto = row.Cells["Producto"].Value.ToString();
                string cantidad = row.Cells["Cantidad"].Value.ToString();
                string precio = row.Cells["Precio"].Value.ToString();
                string fecha = row.Cells["Fecha_de_Pedido"].Value.ToString();
                string id = row.Cells["Id"].Value.ToString();
                string total = row.Cells["Total"].Value.ToString();

                // Asigna los valores a los TextBoxes correspondientes
                txtNom.Text = nombre;
                txtPro.Text = producto;
                txtCantidad1.Text = cantidad;
                txtId.Text = id;
                txtPrecio1.Text = precio;
                dtmFecha.Text = fecha;
                txtTotal.Text = total;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Lee los valores de precio y cantidad desde los controles correspondientes
                if (double.TryParse(txtPrecio1.Text, out double txtPrecio) && int.TryParse(txtCantidad1.Text, out int txtCantidad))
                {
                    // Calcula el total multiplicando precio y cantidad
                    double txtT1otal = txtCantidad + txtPrecio;
                    // Establece el valor calculado en el control txtTotal
                    txtTotal.Text = txtTotal.ToString();
                }
                else
                {
                    // Maneja el caso en el que la conversión de precio o cantidad falle
                    txtTotal.Text = "Error";
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante el cálculo del total
                txtTotal.Text = "Error: " + ex.Message;
            }
        }
    }
}
