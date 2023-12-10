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
    public partial class Registro_de_Facturas : Form
    {
        public string cadena_conexion = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
        public Registro_de_Facturas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string consulta = "select * from facturacion";
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0]; // Obtén la fila seleccionada

                // Accede a los valores de las celdas individuales dentro de la fila

                string nombre = GetCellValue(row, "Nombre");
                string cantidad = GetCellValue(row, "Cantidad");
                string precio = GetCellValue(row, "Precio");
                string sub = GetCellValue(row, "Sub_Total");
                string codigo = GetCellValue(row, "Codigo"); // Cambiado a string para manejar tanto números como texto

               

                txtPrecio.Text = precio;
                txtSub.Text = sub;
                txtCliente.Text = nombre;
                txtCantidad.Text = cantidad;
                txtCodigo.Text = codigo;
            }
        }
        // Método auxiliar para obtener el valor de una celda como cadena
        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            return row.Cells[columnName]?.Value?.ToString() ?? string.Empty;
        }

        private string GenerarNuevoCodigo()
        {
            string nuevoCodigo = "001"; // Valor por defecto si no hay registros en la base de datos

            try
            {
                string consulta = "SELECT MAX(CAST(Codigo AS SIGNED)) FROM facturacion";
                MySqlConnection conexion = new MySqlConnection(cadena_conexion);

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    conexion.Open();
                    object resultado = comando.ExecuteScalar();

                    if (resultado != DBNull.Value)
                    {
                        int ultimoCodigo = Convert.ToInt32(resultado) + 1;
                        nuevoCodigo = ultimoCodigo.ToString("D3"); // Formato con ceros a la izquierda
                    }
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al generar el nuevo código", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return nuevoCodigo;
        }

        private void CalcularTotales()
        {
            // Obtener todos los productos de la base de datos
            string consulta = "SELECT Cantidad, Precio FROM facturacion";
            decimal sumaSubtotal = 0;

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Obtener la cantidad y el precio de cada producto
                            int cantidad = reader.GetInt32("Cantidad");
                            decimal precio = reader.GetDecimal("Precio");

                            // Calcular y sumar el subtotal de cada producto
                            sumaSubtotal += cantidad * precio;
                        }
                    }
                }
            }

            // Calcular el IVA (aquí puedes ajustar la tasa de IVA según tus necesidades)
            decimal tasaIVA = 0.13m; // Ahora el IVA es del 13%
            decimal iva = sumaSubtotal * tasaIVA;

            // Calcular la suma total
            decimal sumaTotal = sumaSubtotal + iva;

            // Mostrar los resultados en los TextBox con dos decimales
            txtSuma.Text = sumaSubtotal.ToString("N2");
            txtIva.Text = iva.ToString("N2");
            txtTotal.Text = sumaTotal.ToString("N2");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
                string nuevoCodigo = GenerarNuevoCodigo(); // Obtener nuevo código

                // Validar y obtener la cantidad como entero
                if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Por favor, ingrese una cantidad válida (número entero mayor que cero).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar y obtener el precio
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("Por favor, ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calcular el subtotal
                decimal subTotal = cantidad * precio;

                // Resto del código para la inserción
                string myInsertQuery = "INSERT INTO facturacion(Codigo, Nombre, Cantidad, Precio, Sub_Total) VALUES (?Codigo, ?Nombre, ?Cantidad, ?Precio, ?Sub_Total)";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

                myCommand.Parameters.Add("?Codigo", MySqlDbType.VarChar, 30).Value = nuevoCodigo;
                myCommand.Parameters.Add("?Nombre", MySqlDbType.VarChar, 30).Value = txtCliente.Text;
                myCommand.Parameters.Add("?Cantidad", MySqlDbType.Int32).Value = cantidad;
                myCommand.Parameters.Add("?Precio", MySqlDbType.Decimal).Value = precio;
                myCommand.Parameters.Add("?Sub_Total", MySqlDbType.Decimal).Value = subTotal;

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                // Actualizar la tabla después de agregar un nuevo registro
                ActualizarTabla();

                // Llamar a la función para recalcular totales
                CalcularTotales();

                MessageBox.Show("Agregado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos de texto
                txtCodigo.Text = nuevoCodigo; // Mostrar el nuevo código generado
                txtCliente.Clear();
                txtCantidad.Clear();
                txtPrecio.Clear();
                txtSub.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ingresar la factura. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Método para actualizar la tabla
        private void ActualizarTabla()
        {
            string consulta = "select * from facturacion";

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
                // Obtener la cantidad y el subtotal del producto a eliminar
                string obtenerDatosQuery = "SELECT Cantidad, Precio, Sub_Total FROM facturacion WHERE Codigo = @Codigo";
                using (MySqlConnection obtenerDatosConexion = new MySqlConnection(cadena_conexion))
                {
                    obtenerDatosConexion.Open();
                    using (MySqlCommand obtenerDatosCommand = new MySqlCommand(obtenerDatosQuery, obtenerDatosConexion))
                    {
                        obtenerDatosCommand.Parameters.AddWithValue("@Codigo", txtCodigo.Text);

                        using (MySqlDataReader reader = obtenerDatosCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int cantidadAEliminar = reader.GetInt32("Cantidad");
                                decimal subTotalAEliminar = reader.GetDecimal("Sub_Total");

                                // Validar que la cantidad no sea negativa
                                if (cantidadAEliminar < 0)
                                {
                                    MessageBox.Show("No se puede eliminar un producto con cantidad negativa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Resto del código para eliminar el producto
                                string eliminarQuery = "DELETE FROM facturacion WHERE Codigo = @Codigo";
                                using (MySqlConnection eliminarConexion = new MySqlConnection(cadena_conexion))
                                {
                                    eliminarConexion.Open();
                                    using (MySqlCommand eliminarCommand = new MySqlCommand(eliminarQuery, eliminarConexion))
                                    {
                                        eliminarCommand.Parameters.AddWithValue("@Codigo", txtCodigo.Text);
                                        eliminarCommand.ExecuteNonQuery();
                                    }
                                }

                                // Actualizar la tabla después de eliminar un registro
                                ActualizarTabla();

                                // Recalcular suma y total para ajustar el IVA y el total al valor inicial antes de borrar un producto
                                if (decimal.TryParse(txtSuma.Text, out decimal sumaInicial))
                                {
                                    sumaInicial -= subTotalAEliminar;
                                    decimal ivaInicial = sumaInicial * 0.13m; // Tasa de IVA del 13%
                                    decimal totalInicial = sumaInicial + ivaInicial;

                                    // Mostrar los resultados en los TextBox con dos decimales
                                    txtSuma.Text = sumaInicial.ToString("N2");
                                    txtIva.Text = ivaInicial.ToString("N2");
                                    txtTotal.Text = totalInicial.ToString("N2");

                                    MessageBox.Show("Eliminado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Error al convertir la suma inicial a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No se ha podido hacer la eliminación. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Limpiar campos de texto
            txtCodigo.Clear();
            txtCliente.Clear();
            txtCantidad.Clear();
            txtSub.Clear();
            txtPrecio.Clear();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // No establecer un formato específico para permitir mostrar todos los decimales
            dataGridView1.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Alineación a la derecha
        }
    }

}
