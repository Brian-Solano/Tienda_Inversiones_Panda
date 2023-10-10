
namespace Tienda_Inversiones_Panda
{
    partial class Registo_de_Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnatras = new System.Windows.Forms.Button();
            this.btnIngre = new System.Windows.Forms.Button();
            this.lblNombreP = new System.Windows.Forms.Label();
            this.lblDistribuidor = new System.Windows.Forms.Label();
            this.lblFechaV = new System.Windows.Forms.Label();
            this.lbldispo = new System.Windows.Forms.Label();
            this.lblProductoIngre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDistri = new System.Windows.Forms.TextBox();
            this.txtDispo = new System.Windows.Forms.TextBox();
            this.dtmFecha = new System.Windows.Forms.DateTimePicker();
            this.txtIngresarProducto = new System.Windows.Forms.TextBox();
            this.btnNuevoP = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(689, 353);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(108, 26);
            this.btnatras.TabIndex = 0;
            this.btnatras.Text = "ATRAS";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // btnIngre
            // 
            this.btnIngre.Location = new System.Drawing.Point(199, 353);
            this.btnIngre.Name = "btnIngre";
            this.btnIngre.Size = new System.Drawing.Size(138, 26);
            this.btnIngre.TabIndex = 1;
            this.btnIngre.Text = "INGRESAR";
            this.btnIngre.UseVisualStyleBackColor = true;
            this.btnIngre.Click += new System.EventHandler(this.btnIngre_Click);
            // 
            // lblNombreP
            // 
            this.lblNombreP.AutoSize = true;
            this.lblNombreP.Location = new System.Drawing.Point(86, 42);
            this.lblNombreP.Name = "lblNombreP";
            this.lblNombreP.Size = new System.Drawing.Size(142, 13);
            this.lblNombreP.TabIndex = 2;
            this.lblNombreP.Text = "NOMBRE DEL PRODUCTO";
            // 
            // lblDistribuidor
            // 
            this.lblDistribuidor.AutoSize = true;
            this.lblDistribuidor.Location = new System.Drawing.Point(86, 103);
            this.lblDistribuidor.Name = "lblDistribuidor";
            this.lblDistribuidor.Size = new System.Drawing.Size(85, 13);
            this.lblDistribuidor.TabIndex = 3;
            this.lblDistribuidor.Text = "DISTRIBUIDOR";
            // 
            // lblFechaV
            // 
            this.lblFechaV.AutoSize = true;
            this.lblFechaV.Location = new System.Drawing.Point(86, 166);
            this.lblFechaV.Name = "lblFechaV";
            this.lblFechaV.Size = new System.Drawing.Size(137, 13);
            this.lblFechaV.TabIndex = 4;
            this.lblFechaV.Text = "FECHA DE VENCIMIENTO";
            // 
            // lbldispo
            // 
            this.lbldispo.AutoSize = true;
            this.lbldispo.Location = new System.Drawing.Point(86, 229);
            this.lbldispo.Name = "lbldispo";
            this.lbldispo.Size = new System.Drawing.Size(78, 13);
            this.lbldispo.TabIndex = 5;
            this.lbldispo.Text = "DISPONIBLES";
            // 
            // lblProductoIngre
            // 
            this.lblProductoIngre.AutoSize = true;
            this.lblProductoIngre.Location = new System.Drawing.Point(86, 289);
            this.lblProductoIngre.Name = "lblProductoIngre";
            this.lblProductoIngre.Size = new System.Drawing.Size(137, 13);
            this.lblProductoIngre.TabIndex = 6;
            this.lblProductoIngre.Text = "PRODUCTO A INGRESAR";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(341, 35);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(216, 20);
            this.txtNombre.TabIndex = 7;
            this.txtNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtDistri
            // 
            this.txtDistri.Location = new System.Drawing.Point(341, 103);
            this.txtDistri.Name = "txtDistri";
            this.txtDistri.Size = new System.Drawing.Size(216, 20);
            this.txtDistri.TabIndex = 8;
            // 
            // txtDispo
            // 
            this.txtDispo.Location = new System.Drawing.Point(341, 222);
            this.txtDispo.Name = "txtDispo";
            this.txtDispo.Size = new System.Drawing.Size(216, 20);
            this.txtDispo.TabIndex = 9;
            // 
            // dtmFecha
            // 
            this.dtmFecha.Location = new System.Drawing.Point(341, 160);
            this.dtmFecha.Name = "dtmFecha";
            this.dtmFecha.Size = new System.Drawing.Size(200, 20);
            this.dtmFecha.TabIndex = 10;
            // 
            // txtIngresarProducto
            // 
            this.txtIngresarProducto.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtIngresarProducto.Location = new System.Drawing.Point(341, 286);
            this.txtIngresarProducto.Name = "txtIngresarProducto";
            this.txtIngresarProducto.Size = new System.Drawing.Size(63, 20);
            this.txtIngresarProducto.TabIndex = 11;
            this.txtIngresarProducto.TextChanged += new System.EventHandler(this.txtIngresarProducto_TextChanged);
            // 
            // btnNuevoP
            // 
            this.btnNuevoP.Location = new System.Drawing.Point(22, 353);
            this.btnNuevoP.Name = "btnNuevoP";
            this.btnNuevoP.Size = new System.Drawing.Size(132, 26);
            this.btnNuevoP.TabIndex = 12;
            this.btnNuevoP.Text = "NUEVO";
            this.btnNuevoP.UseVisualStyleBackColor = true;
            this.btnNuevoP.Click += new System.EventHandler(this.btnNuevoP_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(367, 353);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(134, 26);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(565, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(223, 144);
            this.dataGridView1.TabIndex = 14;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(537, 353);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(117, 26);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // Registo_de_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevoP);
            this.Controls.Add(this.txtIngresarProducto);
            this.Controls.Add(this.dtmFecha);
            this.Controls.Add(this.txtDispo);
            this.Controls.Add(this.txtDistri);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblProductoIngre);
            this.Controls.Add(this.lbldispo);
            this.Controls.Add(this.lblFechaV);
            this.Controls.Add(this.lblDistribuidor);
            this.Controls.Add(this.lblNombreP);
            this.Controls.Add(this.btnIngre);
            this.Controls.Add(this.btnatras);
            this.Name = "Registo_de_Productos";
            this.Text = "Registo_de_Productos";
            this.Load += new System.EventHandler(this.Registo_de_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.Button btnIngre;
        private System.Windows.Forms.Label lblNombreP;
        private System.Windows.Forms.Label lblDistribuidor;
        private System.Windows.Forms.Label lblFechaV;
        private System.Windows.Forms.Label lbldispo;
        private System.Windows.Forms.Label lblProductoIngre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDistri;
        private System.Windows.Forms.TextBox txtDispo;
        private System.Windows.Forms.DateTimePicker dtmFecha;
        private System.Windows.Forms.TextBox txtIngresarProducto;
        private System.Windows.Forms.Button btnNuevoP;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnModificar;
    }
}