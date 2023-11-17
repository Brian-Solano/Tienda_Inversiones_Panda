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
    public partial class Clientes : Form
    {
        public string cadena_conexion = @"Database=inventario; Data Source=localhost;User id = BrianSolano;Password=12345";
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnEliminar.Visible = true;
            btnGuardar.Visible = true;

            txtNombre.Visible = true;
            txtDui.Visible = true;
            txtApellido.Visible = true;
            txtId.Visible = true;
            txtTimer.Visible = true;
            txtDesc.Visible = true;
            txtTel.Visible = true;
        }
    }
}
