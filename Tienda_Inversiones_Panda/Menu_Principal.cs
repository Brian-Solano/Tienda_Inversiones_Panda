using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_Inversiones_Panda
{
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresarU_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
            Form formulario = new Login();
            formulario.Show();
        }

        private void btnIngresoP_Click(object sender, EventArgs e)
        {
            Registo_de_Productos RP = new Registo_de_Productos();
            RP.Show();
            this.Close();
        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {

        }

       /* private void btnFacturacion_Click(object sender, EventArgs e)
        {

            Facturacion FT = new Facturacion();
            FT.Show();
            this.Close();
        }*/

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistroF_Click(object sender, EventArgs e)
        {
            Registro_de_Facturas RI =  new Registro_de_Facturas();
            RI.Show();
            this.Close();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            Bitacora BI = new Bitacora();
            BI.Show();
            this.Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes CL = new Clientes();
            CL.Show();
            this.Close();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Empleado EM = new Empleado();
            EM.Show();
            this.Close();
        }

        private void btnCodigo_Click(object sender, EventArgs e)
        {
            Codigo CO = new Codigo();
            CO.Show();
            this.Close();
        }
    }
}
