﻿using System;
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
        

        public string cadena_conexion = @"Database=Tienda_Inversiones_Panda; Data Source=localhost;User id = root;Password=Huaweiz5";
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

                MessageBox.Show("Error de conexion", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            txtNombre.Visible = true;
            txtDistri.Visible = true;
            txtPrecio.Visible = true;
            txtIngresarProducto.Visible = true;





        }

        private void btnIngre_Click(object sender, EventArgs e)
        {
            MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
            string myInsertQuery = "INSERT INTO producto(Nombre,Distribuidor,Disponibles) Values(?Nombre,?Distribuidor,?Disponibles)";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Parameters.Add("?Nombre", MySqlDbType.VarChar, 40).Value = txtNombre.Text;
            myCommand.Parameters.Add("?Distribuidor", MySqlDbType.VarChar, 45).Value = txtDistri.Text;
            

            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();

            MessageBox.Show("Producto agregado con éxito", "Ok", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            string consulta = "select * from producto";

            MySqlConnection conexion = new MySqlConnection(cadena_conexion);
            MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
            System.Data.DataSet ds = new System.Data.DataSet();
            comando.Fill(ds, "tienda");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tienda";


            MessageBox.Show("Se ha guardado el dato en la tabla Productos");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = "";
                if (myConnectionString == "")
                {
                    myConnectionString = @"Database=Tienda_Inversiones_Panda; Data Source=localhost;User id = root;Password=Huaweiz5"; ;
                    MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                    string myInsertQuery = "DELETE FROM producto WHERE producto.ID = " + txtNombre.Text + "";
                    MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                    myCommand.Connection = myConnection;
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myCommand.Connection.Close();

                    MessageBox.Show("Producto Eliminado con éxito", "Ok", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                    string cad = @"Database=restaurante;Data Source=localhost;User Id=AndradePeña;Password=Huaweiz5";
                    string query = "select * from producto";
                    MySqlConnection cnn = new MySqlConnection(cad);
                    MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    da.Fill(ds, "tienda");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "tienda";
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("No se ha podido hacer la eliminacion");

            }

        }
    }
}
