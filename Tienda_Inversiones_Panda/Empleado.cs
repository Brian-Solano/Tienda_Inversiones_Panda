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
            string myInsertQuery = "INSERT INTO empleados(Nombre, Apellido, Turno_de, Turno_a, Area) VALUES (?Nombre, ?Apellido, ?Turno_de, ?Turno_a, ?Area)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Nombre", MySqlDbType.VarChar, 30).Value = txtNombre.Text;
            myCommand.Parameters.Add("?Apellido", MySqlDbType.VarChar, 30).Value = txtApellido.Text;
            myCommand.Parameters.Add("?Turno_de", MySqlDbType.VarChar, 30).Value = txtTurno.Text;
            myCommand.Parameters.Add("?Turno_a", MySqlDbType.VarChar, 50).Value = txtTurno1.Text;
            myCommand.Parameters.Add("?Area", MySqlDbType.VarChar, 30).Value = txtArea.Text;


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
        }
    }
}
