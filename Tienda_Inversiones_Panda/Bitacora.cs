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
            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO bitacora(Tarea, Encargado, Id, Fecha, Estado) VALUES (?Tarea, ?Encargado, ?Id, ?Fecha, ?Estado)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Tarea", MySqlDbType.VarChar, 30).Value = txtTarea.Text;
            myCommand.Parameters.Add("?Encargado", MySqlDbType.VarChar, 30).Value = txtEncargado.Text;
            myCommand.Parameters.Add("?Id", MySqlDbType.VarChar, 30).Value = txtId.Text;
            myCommand.Parameters.Add("?Fecha", MySqlDbType.VarChar, 30).Value = txtFecha.Text;
            myCommand.Parameters.Add("?Estado", MySqlDbType.VarChar, 50).Value = txtEstado.Text;



            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            MessageBox.Show("Agregado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

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
            catch (MySqlException ex)
            {
                MessageBox.Show("No se ha podido hacer la eliminación. Error: " + ex.Message);
            }
        }


        private void btnAtras_Click(object sender, EventArgs e)
        {
            Form formulario = new Menu_Principal();
            this.Hide();
            formulario.Show();
        }
    }
}
