namespace HotelParaiso
{
    partial class FrmAccesoAdministrativo
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuarioAdm = new System.Windows.Forms.TextBox();
            this.txtContraAdm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAccesar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(59, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // txtUsuarioAdm
            // 
            this.txtUsuarioAdm.BackColor = System.Drawing.Color.Black;
            this.txtUsuarioAdm.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioAdm.ForeColor = System.Drawing.Color.White;
            this.txtUsuarioAdm.Location = new System.Drawing.Point(173, 70);
            this.txtUsuarioAdm.Name = "txtUsuarioAdm";
            this.txtUsuarioAdm.Size = new System.Drawing.Size(100, 23);
            this.txtUsuarioAdm.TabIndex = 2;
            // 
            // txtContraAdm
            // 
            this.txtContraAdm.BackColor = System.Drawing.Color.Black;
            this.txtContraAdm.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraAdm.ForeColor = System.Drawing.Color.White;
            this.txtContraAdm.Location = new System.Drawing.Point(173, 113);
            this.txtContraAdm.Name = "txtContraAdm";
            this.txtContraAdm.PasswordChar = '•';
            this.txtContraAdm.Size = new System.Drawing.Size(100, 23);
            this.txtContraAdm.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(49, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Acceso Administrativo";
            // 
            // btnAccesar
            // 
            this.btnAccesar.BackgroundImage = global::My.Resources.Resources.boton1blue;
            this.btnAccesar.FlatAppearance.BorderSize = 0;
            this.btnAccesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccesar.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccesar.ForeColor = System.Drawing.Color.White;
            this.btnAccesar.Location = new System.Drawing.Point(134, 167);
            this.btnAccesar.Name = "btnAccesar";
            this.btnAccesar.Size = new System.Drawing.Size(86, 34);
            this.btnAccesar.TabIndex = 5;
            this.btnAccesar.Text = "Accesar";
            this.btnAccesar.UseVisualStyleBackColor = true;
            this.btnAccesar.Click += new System.EventHandler(this.btnAccesar_Click);
            // 
            // FrmAccesoAdministrativo
            // 
            this.AcceptButton = this.btnAccesar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(347, 223);
            this.Controls.Add(this.btnAccesar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContraAdm);
            this.Controls.Add(this.txtUsuarioAdm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAccesoAdministrativo";
            this.Text = "Hotel Paraíso - Acceso Administrativo";
            this.Load += new System.EventHandler(this.FrmAccesoAdministrativo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuarioAdm;
        private System.Windows.Forms.TextBox txtContraAdm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAccesar;
    }
}