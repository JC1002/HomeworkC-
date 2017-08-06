
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
	public partial class frmHabitacion
	{
		public frmHabitacion()
		{
			InitializeComponent();
			

		}
		
#region Default Instance
		
		private static frmHabitacion defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static frmHabitacion Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmHabitacion();
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
		int id;
		public void frmRoom_Load(System.Object sender, System.EventArgs e)
		{
			TabControl1.SelectTab(0);
			display_room();
		}
		private void display_room()
		{
			Modulo1.con.Open();
			DataTable Dt = new DataTable("tblRoom");
			OleDbDataAdapter rs = default(OleDbDataAdapter);
			
			rs = new OleDbDataAdapter("Select * from tblRoom", Modulo1.con);
			
			rs.Fill(Dt);
			int indx = default(int);
			lvRoom.Items.Clear();
			for (indx = 0; indx <= Dt.Rows.Count - 1; indx++)
			{
				ListViewItem lv = new ListViewItem();
				lv.Text = (Dt.Rows[indx]["ID"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["RoomNumber"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["RoomType"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["RoomRate"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["NoOfOccupancy"].ToString());
				lvRoom.Items.Add(lv);
			}
			rs.Dispose();
			Modulo1.con.Close();
		}
		
		public void bttnCancel_Click(System.Object sender, System.EventArgs e)
		{
			txtID.Clear();
			txtRoomType.Clear();
			txtRoomRate.Clear();
			txtNoOfOccupancy.Clear();
			bttnSave.Text = "&Guardar";
		}
		
		public void bttnSave_Click(System.Object sender, System.EventArgs e)
		{
			Modulo1.con.Open();
			string num = txtID.Text.Trim();
			string type = txtRoomType.Text.Trim();
			string rate = txtRoomRate.Text.Trim();
			string occupancy = txtNoOfOccupancy.Text.Trim();
			string stat = "Disponible";
			if (type == null || rate == null || occupancy == null)
			{
				Interaction.MsgBox("Por favor llene todos los campos", Constants.vbInformation, "Nota");
			}
			else
			{
				if (bttnSave.Text == "&Guardar")
				{
					var sql = "SELECT * FROM tblRoom WHERE RoomNumber = " + Modulo1.SafeSqlLiteral(num, 2) + "";
					
					var cmd = new OleDbCommand(sql, Modulo1.con);
					OleDbDataReader dr = cmd.ExecuteReader();
					
					try
					{
						if (dr.Read() == false)
						{
							OleDbCommand add_room = new OleDbCommand("INSERT INTO tblRoom(RoomNumber,RoomType,RoomRate,NoOfOccupancy,Status) values (\'" +
							Modulo1.SafeSqlLiteral(num, 2) + "\',\'" +
							Modulo1.SafeSqlLiteral(type, 2) + "\',\'" +
							Modulo1.SafeSqlLiteral(rate, 2) + "\',\'" +
							Modulo1.SafeSqlLiteral(occupancy, 2) + "\',\'" +
							stat + "\')", Modulo1.con);
							add_room.ExecuteNonQuery();
							add_room.Dispose();
							Interaction.MsgBox("Habitación Agregada!", Constants.vbInformation, "Nota");
							txtID.Clear();
							txtRoomType.Clear();
							txtRoomRate.Clear();
							txtNoOfOccupancy.Clear();
						}
						else
						{
							Interaction.MsgBox("Número de Habitación Existente!", Constants.vbExclamation, "Nota");
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				else
				{
					OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET RoomNumber= \'" + Modulo1.SafeSqlLiteral(num, 2) + "\',RoomType = \'" + Modulo1.SafeSqlLiteral(type, 2) + "\',RoomRate = \'" + Modulo1.SafeSqlLiteral(rate, 2) + "\',NoOfOccupancy = \'" + Modulo1.SafeSqlLiteral(occupancy, 2) + "\' WHERE ID = " + id.ToString() + "", Modulo1.con);
					update_room.ExecuteNonQuery();
					update_room.Dispose();
					Interaction.MsgBox("Habitación Guardada!", Constants.vbInformation, "Nota");
					bttnSave.Text = "&Guardar";
					txtID.Clear();
					txtRoomType.Clear();
					txtRoomRate.Clear();
					txtNoOfOccupancy.Clear();
				}
			}
			Modulo1.con.Close();
			display_room();
		}
		
		public void lvRoom_DoubleClick(object sender, System.EventArgs e)
		{
			string a = System.Convert.ToString(Interaction.MsgBox("¿Actualizar Objeto seleccionado?", (int) Constants.vbQuestion + Constants.vbYesNo, "Actualizar Habitación"));
			if (a == Constants.vbYes.ToString())
			{
				id = int.Parse(lvRoom.SelectedItems[0].Text);
				txtID.Text = lvRoom.SelectedItems[0].SubItems[1].Text;
				txtRoomType.Text = lvRoom.SelectedItems[0].SubItems[2].Text;
				txtRoomRate.Text = lvRoom.SelectedItems[0].SubItems[3].Text;
				txtNoOfOccupancy.Text = lvRoom.SelectedItems[0].SubItems[4].Text;
				
				TabControl1.SelectTab(0);
				bttnSave.Text = "&Actualizar";
			}
		}
		
		public void lvRoom_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			
		}
	}
}
