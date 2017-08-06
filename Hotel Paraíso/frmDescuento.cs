
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


using System.Data.OleDb;

namespace HBRS
{
	public partial class frmDescuento
	{
		public frmDescuento()
		{
			InitializeComponent();
			
		}
		
#region Default Instance
		
		private static frmDescuento defaultInstance;

		public static frmDescuento Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmDescuento();
					defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
#endregion
		bool update_discount = false;
		int id;
		public void bttnCancel_Click(System.Object sender, System.EventArgs e)
		{
			clear_txt();
			update_discount = false;
		}
		
		public void frmDiscount_Load(System.Object sender, System.EventArgs e)
		{
			display_discount();
			clear_txt();
		}
		
		private void display_discount()
		{
			Modulo1.con.Open();
			DataTable dt = new DataTable("tblDiscount");
			Modulo1.rs = new OleDbDataAdapter("SELECT * FROM tblDiscount", Modulo1.con);
			Modulo1.rs.Fill(dt);
			
			lvlDiscount.Items.Clear();
			
			int indx = default(int);
			for (indx = 0; indx <= dt.Rows.Count - 1; indx++)
			{
				ListViewItem lv = new ListViewItem();
				lv.Text = (dt.Rows[indx]["ID"].ToString());
				lv.SubItems.Add(dt.Rows[indx]["DiscountType"].ToString());
				lv.SubItems.Add(dt.Rows[indx]["DiscountRate"].ToString());
				lvlDiscount.Items.Add(lv);
			}
			Modulo1.rs.Dispose();
			Modulo1.con.Close();
		}
		
		public void TextBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0'|| e.KeyChar > '9') && e.KeyChar != ControlChars.Back && e.KeyChar != '.')
			{
				//cancel keys
				e.Handled = true;
			}
		}
		
		public void bttnSave_Click(System.Object sender, System.EventArgs e)
		{
			if (txtType.Text.Trim() == null | bool.Parse(txtRate.Text.Trim()))
			{
				Interaction.MsgBox("Llene todos los campos!", Constants.vbInformation, "Nota");
				return;
			}
			string a = System.Convert.ToString(Interaction.MsgBox("¿Guardar Información de Descuento?", (int) Constants.vbQuestion + Constants.vbYesNo, "Guardar"));
			if (a == Constants.vbYes.ToString())
			{
				if (update_discount == false)
				{
					Modulo1.con.Open();
					OleDbCommand save = new OleDbCommand("INSERT INTO tblDiscount(DiscountType,DiscountRate,Status) values (\'" + txtType.Text.Trim() + "\',\'" + txtRate.Text.Trim() + "\',\'Activo\')", Modulo1.con);
					save.ExecuteNonQuery();
					Modulo1.con.Close();
				}
				else
				{
					Modulo1.con.Open();
					OleDbCommand update = new OleDbCommand("UPDATE tblDiscount SET DiscountType = \'" + txtType.Text.Trim() + "\',DiscountRate = \'" + Conversion.Val(txtRate.Text.Trim()) / 100 + "\' WHERE ID = \'" + id.ToString() + "\'", Modulo1.con);
					update.ExecuteNonQuery();
					Modulo1.con.Close();
				}
				Interaction.MsgBox("Datos guardados exitosamente!", Constants.vbInformation, "Descuento");
				display_discount();
				clear_txt();
			}
			
		}
		
		private void clear_txt()
		{
			txtType.Clear();
			txtRate.Clear();
			update_discount = false;
		}
		
		public void lvlDiscount_DoubleClick(object sender, System.EventArgs e)
		{
			string a = System.Convert.ToString(Interaction.MsgBox("Actualizar Objeto seleccionado?", (int) Constants.vbQuestion + Constants.vbYesNo, "Actualizar Descuento"));
			if (a == Constants.vbYes.ToString())
			{
				id = int.Parse(lvlDiscount.SelectedItems[0].Text);
				txtType.Text = lvlDiscount.SelectedItems[0].SubItems[1].Text;
				txtRate.Text = System.Convert.ToString(Conversion.Val(lvlDiscount.SelectedItems[0].SubItems[2].Text) * 100);
				update_discount = true;
				bttnSave.Text = "&Actualizar";
			}
		}
	}
}
