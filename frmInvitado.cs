
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
	public partial class frmInvitado
	{
		public frmInvitado()
		{
			InitializeComponent();
			
			
		}
		
#region Default Instance
		
		private static frmInvitado defaultInstance;

		public static frmInvitado Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmInvitado();
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
		
		public void bttnSave_Click(System.Object sender, System.EventArgs e)
		{
			Modulo1.con.Open();
			string fname = txtFName.Text.Trim();
			string mname = txtMName.Text.Trim();
			string lname = txtLName.Text.Trim();
			string add = txtAddress.Text.Trim();
			string num = txtNumber.Text.Trim();
			string email = txtEmail.Text.Trim();
			string stat = "Activo";
			string remark = "Disponible";
			
			if (fname == null || mname == null || lname == null || add == null || num == null)
			{
				Interaction.MsgBox("Por favor llene todos los campos", Constants.vbInformation, "Nota");
			}
			else
			{
				OleDbCommand add_guest = new OleDbCommand("INSERT INTO tblGuest(GuestFName,GuestMName,GuestLName,GuestAddress,GuestContactNumber,GuestGender,GuestEmail,Status,Remarks) values (\'" +
				fname + "\',\'" +
				mname + "\',\'" +
				lname + "\',\'" +
				add + "\',\'" +
				num + "\',\'" +
				cboGender.Text + "\',\'" +
				email + "\',\'" +
				stat + "\',\'" +
				remark + "\')", Modulo1.con);
				add_guest.ExecuteNonQuery();
				add_guest.Dispose();
				Interaction.MsgBox("Invitado Agregado!", Constants.vbInformation, "Nota");
				txtFName.Clear();
				txtMName.Clear();
				txtLName.Clear();
				txtAddress.Clear();
				txtNumber.Clear();
				txtEmail.Clear();
			}
			Modulo1.con.Close();
			display_guest();
		}
		
		public void frmGuest_Load(System.Object sender, System.EventArgs e)
		{
			display_guest();
			TabControl1.SelectTab(0);
		}
		
		private void display_guest()
		{
			Modulo1.con.Open();
			DataTable Dt = new DataTable("tblGuest");
			OleDbDataAdapter rs = default(OleDbDataAdapter);
			
			rs = new OleDbDataAdapter("Select * from tblGuest", Modulo1.con);
			
			rs.Fill(Dt);
			int indx = default(int);
			lvGuest.Items.Clear();
			for (indx = 0; indx <= Dt.Rows.Count - 1; indx++)
			{
				ListViewItem lv = new ListViewItem();
				lv.Text = (Dt.Rows[indx]["ID"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["GuestFName"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["GuestMName"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["GuestLName"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["GuestAddress"].ToString());
                lv.SubItems.Add(Dt.Rows[indx]["GuestContactNumber"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["Status"].ToString());
				lvGuest.Items.Add(lv);
			}
			rs.Dispose();
			Modulo1.con.Close();
		}
		
		public void bttnCancel_Click(System.Object sender, System.EventArgs e)
		{
			txtFName.Clear();
			txtMName.Clear();
			txtLName.Clear();
			txtAddress.Clear();
			txtNumber.Clear();
			txtEmail.Clear();
		}
	}
}
