
namespace Tienda_Inversiones_Panda
{
    partial class Menu_Principal
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
            this.lblInicio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalir2 = new System.Windows.Forms.Button();
            this.btnIngresoP = new System.Windows.Forms.Button();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.btnRegistroF = new System.Windows.Forms.Button();
            this.btnIngresarU = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblInicio.Location = new System.Drawing.Point(36, 14);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(39, 13);
            this.lblInicio.TabIndex = 0;
            this.lblInicio.Text = "INICIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(358, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "¡BIENVENIDO!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(303, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "SELECCIONE LO QUE DESEE HACER";
            // 
            // btnSalir2
            // 
            this.btnSalir2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir2.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSalir2.Location = new System.Drawing.Point(684, 4);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(104, 28);
            this.btnSalir2.TabIndex = 3;
            this.btnSalir2.Text = "SALIR";
            this.btnSalir2.UseVisualStyleBackColor = true;
            this.btnSalir2.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnIngresoP
            // 
            this.btnIngresoP.BackColor = System.Drawing.Color.Black;
            this.btnIngresoP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngresoP.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIngresoP.Location = new System.Drawing.Point(96, 7);
            this.btnIngresoP.Name = "btnIngresoP";
            this.btnIngresoP.Size = new System.Drawing.Size(156, 27);
            this.btnIngresoP.TabIndex = 5;
            this.btnIngresoP.Text = "INGRESO DE PRODUCTOS";
            this.btnIngresoP.UseVisualStyleBackColor = false;
            this.btnIngresoP.Click += new System.EventHandler(this.btnIngresoP_Click);
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.BackColor = System.Drawing.Color.Black;
            this.btnFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFacturacion.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFacturacion.Location = new System.Drawing.Point(258, 4);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(99, 30);
            this.btnFacturacion.TabIndex = 6;
            this.btnFacturacion.Text = "FACTURACIÓN";
            this.btnFacturacion.UseVisualStyleBackColor = false;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
            // 
            // btnRegistroF
            // 
            this.btnRegistroF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistroF.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRegistroF.Location = new System.Drawing.Point(363, 4);
            this.btnRegistroF.Name = "btnRegistroF";
            this.btnRegistroF.Size = new System.Drawing.Size(150, 30);
            this.btnRegistroF.TabIndex = 7;
            this.btnRegistroF.Text = "REGISTRO DE FACTURAS";
            this.btnRegistroF.UseVisualStyleBackColor = true;
            this.btnRegistroF.Click += new System.EventHandler(this.btnRegistroF_Click);
            // 
            // btnIngresarU
            // 
            this.btnIngresarU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngresarU.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIngresarU.Location = new System.Drawing.Point(519, 4);
            this.btnIngresarU.Name = "btnIngresarU";
            this.btnIngresarU.Size = new System.Drawing.Size(159, 30);
            this.btnIngresarU.TabIndex = 4;
            this.btnIngresarU.Text = "INGRESAR OTRO USUARIO";
            this.btnIngresarU.UseVisualStyleBackColor = true;
            this.btnIngresarU.Click += new System.EventHandler(this.btnIngresarU_Click);
            // 
            // Menu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(858, 357);
            this.Controls.Add(this.btnRegistroF);
            this.Controls.Add(this.btnFacturacion);
            this.Controls.Add(this.btnIngresoP);
            this.Controls.Add(this.btnIngresarU);
            this.Controls.Add(this.btnSalir2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInicio);
            this.Name = "Menu_Principal";
            this.Text = "Menu_Principal";
            this.Load += new System.EventHandler(this.Menu_Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalir2;
        private System.Windows.Forms.Button btnIngresoP;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnRegistroF;
        private System.Windows.Forms.Button btnIngresarU;
    }
}