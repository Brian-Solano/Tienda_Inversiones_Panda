
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
            this.lbldispo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDistri = new System.Windows.Forms.TextBox();
            this.txtDispo = new System.Windows.Forms.TextBox();
            this.btnNuevoP = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.RavId = new System.Windows.Forms.RadioButton();
            this.RavNombre = new System.Windows.Forms.RadioButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(904, 8);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(108, 26);
            this.btnatras.TabIndex = 0;
            this.btnatras.Text = "ATRAS";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // btnIngre
            // 
            this.btnIngre.Location = new System.Drawing.Point(144, 353);
            this.btnIngre.Name = "btnIngre";
            this.btnIngre.Size = new System.Drawing.Size(102, 26);
            this.btnIngre.TabIndex = 1;
            this.btnIngre.Text = "INGRESAR";
            this.btnIngre.UseVisualStyleBackColor = true;
            this.btnIngre.Click += new System.EventHandler(this.btnIngre_Click);
            // 
            // lblNombreP
            // 
            this.lblNombreP.AutoSize = true;
            this.lblNombreP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreP.Location = new System.Drawing.Point(22, 111);
            this.lblNombreP.Name = "lblNombreP";
            this.lblNombreP.Size = new System.Drawing.Size(199, 18);
            this.lblNombreP.TabIndex = 2;
            this.lblNombreP.Text = "NOMBRE DEL PRODUCTO";
            // 
            // lblDistribuidor
            // 
            this.lblDistribuidor.AutoSize = true;
            this.lblDistribuidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistribuidor.Location = new System.Drawing.Point(23, 170);
            this.lblDistribuidor.Name = "lblDistribuidor";
            this.lblDistribuidor.Size = new System.Drawing.Size(113, 18);
            this.lblDistribuidor.TabIndex = 3;
            this.lblDistribuidor.Text = "DISTRIBUIDOR";
            // 
            // lbldispo
            // 
            this.lbldispo.AutoSize = true;
            this.lbldispo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldispo.Location = new System.Drawing.Point(23, 233);
            this.lbldispo.Name = "lbldispo";
            this.lbldispo.Size = new System.Drawing.Size(106, 18);
            this.lbldispo.TabIndex = 5;
            this.lbldispo.Text = "DISPONIBLES";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(247, 109);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(216, 20);
            this.txtNombre.TabIndex = 7;
            this.txtNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtDistri
            // 
            this.txtDistri.Location = new System.Drawing.Point(247, 171);
            this.txtDistri.Name = "txtDistri";
            this.txtDistri.Size = new System.Drawing.Size(216, 20);
            this.txtDistri.TabIndex = 8;
            // 
            // txtDispo
            // 
            this.txtDispo.Location = new System.Drawing.Point(247, 231);
            this.txtDispo.Name = "txtDispo";
            this.txtDispo.Size = new System.Drawing.Size(68, 20);
            this.txtDispo.TabIndex = 9;
            // 
            // btnNuevoP
            // 
            this.btnNuevoP.Location = new System.Drawing.Point(51, 353);
            this.btnNuevoP.Name = "btnNuevoP";
            this.btnNuevoP.Size = new System.Drawing.Size(73, 26);
            this.btnNuevoP.TabIndex = 12;
            this.btnNuevoP.Text = "NUEVO";
            this.btnNuevoP.UseVisualStyleBackColor = true;
            this.btnNuevoP.Click += new System.EventHandler(this.btnNuevoP_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(543, 353);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(111, 26);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(469, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(525, 216);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(396, 353);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(117, 26);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(22, 296);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 20);
            this.lblID.TabIndex = 16;
            this.lblID.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(247, 286);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(68, 20);
            this.txtId.TabIndex = 17;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(263, 353);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(113, 26);
            this.btnActualizar.TabIndex = 18;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // RavId
            // 
            this.RavId.AutoSize = true;
            this.RavId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RavId.Location = new System.Drawing.Point(488, 39);
            this.RavId.Name = "RavId";
            this.RavId.Size = new System.Drawing.Size(39, 20);
            this.RavId.TabIndex = 19;
            this.RavId.TabStop = true;
            this.RavId.Text = "ID";
            this.RavId.UseVisualStyleBackColor = true;
            this.RavId.CheckedChanged += new System.EventHandler(this.RavId_CheckedChanged);
            // 
            // RavNombre
            // 
            this.RavNombre.AutoSize = true;
            this.RavNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RavNombre.Location = new System.Drawing.Point(488, 74);
            this.RavNombre.Name = "RavNombre";
            this.RavNombre.Size = new System.Drawing.Size(75, 20);
            this.RavNombre.TabIndex = 20;
            this.RavNombre.TabStop = true;
            this.RavNombre.Text = "Nombre";
            this.RavNombre.UseVisualStyleBackColor = true;
            this.RavNombre.CheckedChanged += new System.EventHandler(this.RavNombre_CheckedChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(574, 71);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(223, 20);
            this.txtBuscar.TabIndex = 21;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(629, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "BUSCADOR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tienda_Inversiones_Panda.Properties.Resources.panda;
            this.pictureBox1.Location = new System.Drawing.Point(0, 398);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // Registo_de_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 459);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.RavNombre);
            this.Controls.Add(this.RavId);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevoP);
            this.Controls.Add(this.txtDispo);
            this.Controls.Add(this.txtDistri);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbldispo);
            this.Controls.Add(this.lblDistribuidor);
            this.Controls.Add(this.lblNombreP);
            this.Controls.Add(this.btnIngre);
            this.Controls.Add(this.btnatras);
            this.Name = "Registo_de_Productos";
            this.Text = "Registo_de_Productos";
            this.Load += new System.EventHandler(this.Registo_de_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.Button btnIngre;
        private System.Windows.Forms.Label lblNombreP;
        private System.Windows.Forms.Label lblDistribuidor;
        private System.Windows.Forms.Label lbldispo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDistri;
        private System.Windows.Forms.TextBox txtDispo;
        private System.Windows.Forms.Button btnNuevoP;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.RadioButton RavId;
        private System.Windows.Forms.RadioButton RavNombre;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}