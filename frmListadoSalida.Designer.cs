// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Linq;
using System;
using System.Collections;
using System.Xml.Linq;
using System.Windows.Forms;
// End of VB project level imports


namespace HBRS
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class frmListadoSalida : System.Windows.Forms.Form
	{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            this.dtOut = new System.Windows.Forms.DateTimePicker();
            this.dtIn = new System.Windows.Forms.DateTimePicker();
            this.lvlcheckin = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtOut
            // 
            this.dtOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOut.Location = new System.Drawing.Point(123, 479);
            this.dtOut.Name = "dtOut";
            this.dtOut.Size = new System.Drawing.Size(104, 20);
            this.dtOut.TabIndex = 45;
            // 
            // dtIn
            // 
            this.dtIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtIn.Location = new System.Drawing.Point(23, 479);
            this.dtIn.Name = "dtIn";
            this.dtIn.Size = new System.Drawing.Size(94, 20);
            this.dtIn.TabIndex = 44;
            // 
            // lvlcheckin
            // 
            this.lvlcheckin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8,
            this.ColumnHeader9,
            this.ColumnHeader10,
            this.ColumnHeader11});
            this.lvlcheckin.FullRowSelect = true;
            this.lvlcheckin.GridLines = true;
            this.lvlcheckin.Location = new System.Drawing.Point(12, 21);
            this.lvlcheckin.Name = "lvlcheckin";
            this.lvlcheckin.Size = new System.Drawing.Size(801, 349);
            this.lvlcheckin.TabIndex = 46;
            this.lvlcheckin.UseCompatibleStateImageBehavior = false;
            this.lvlcheckin.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "TransID";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Nombre del Invitado";
            this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader2.Width = 200;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "# Hab.";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Fecha de Ingreso";
            this.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader4.Width = 100;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Fecha de Salida";
            this.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader5.Width = 100;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "No. de D�as";
            this.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader6.Width = 80;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Ni�os";
            this.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Adultos";
            this.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Pago por Adelantado";
            this.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader9.Width = 120;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Descuento";
            this.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader10.Width = 80;
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Total";
            this.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader11.Width = 80;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::My.Resources.Resources.w8boton1verdeoscuro;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(301, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 29);
            this.button1.TabIndex = 47;
            this.button1.Text = "Exportar informe a Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmListadoSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 419);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvlcheckin);
            this.Controls.Add(this.dtOut);
            this.Controls.Add(this.dtIn);
            this.Name = "frmListadoSalida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Salidas";
            this.Load += new System.EventHandler(this.frmCheckOutList_Load);
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.DateTimePicker dtOut;
		internal System.Windows.Forms.DateTimePicker dtIn;
		internal System.Windows.Forms.ListView lvlcheckin;
		internal System.Windows.Forms.ColumnHeader ColumnHeader1;
		internal System.Windows.Forms.ColumnHeader ColumnHeader2;
		internal System.Windows.Forms.ColumnHeader ColumnHeader3;
		internal System.Windows.Forms.ColumnHeader ColumnHeader4;
		internal System.Windows.Forms.ColumnHeader ColumnHeader5;
		internal System.Windows.Forms.ColumnHeader ColumnHeader6;
		internal System.Windows.Forms.ColumnHeader ColumnHeader7;
		internal System.Windows.Forms.ColumnHeader ColumnHeader8;
		internal System.Windows.Forms.ColumnHeader ColumnHeader9;
		internal System.Windows.Forms.ColumnHeader ColumnHeader10;
		internal System.Windows.Forms.ColumnHeader ColumnHeader11;
        private SaveFileDialog saveFileDialog1;
        private Button button1;
	}
	
}
