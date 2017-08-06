
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
	public partial class frmEntrada
	{
		public frmEntrada()
		{
			InitializeComponent();
		}
		
#region Default Instance
		
		private static frmEntrada defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static frmEntrada Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmEntrada();
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
		int guestID;
		int roomID;
		int trans_ID;
		
		public void frmCheckin_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			string a = System.Convert.ToString(Interaction.MsgBox("¿Cancelar Transacción?", (int) Constants.vbQuestion + Constants.vbYesNo, "Cancelar"));
			if (a == Constants.vbNo.ToString())
			{
				e.Cancel = true;
			}
			else
			{
				clear_text();
			}
		}
		public void frmCheckin_Load(System.Object sender, System.EventArgs e)
		{
            if (cboDiscount.Text == "" && txtTotal.Text == "")
            { bttnCheckIn.Enabled = false; }
			clear_text();
			DateTime time = DateTime.Now;
			string format = "d/MM/yyyy";
			txtCheckInDate.Text = time.ToString(format);
			dtCheckOutDate.Text = System.Convert.ToString(DateTime.Now.AddDays(1));
			transID();
			pop_discount();
			display_checkin();
		}
		
		public void transID()
		{
			Modulo1.con.Open();
			DataTable dt = new DataTable("tblTransaction");
			Modulo1.rs = new OleDbDataAdapter("SELECT * FROM tblTransaction ORDER BY TransID DESC", Modulo1.con);
			Modulo1.rs.Fill(dt);
			
			if (dt.Rows.Count == 0)
			{
				txtTransID.Text = "TransID - 0001";
			}
			else
			{
				int value = (int) (Conversion.Val(dt.Rows[0]["TransID"]));
				value++;
				txtTransID.Text = "TransID - " + value.ToString("0000");
				trans_ID = value;
			}
			Modulo1.rs.Dispose();
			Modulo1.con.Close();
		}
		
		public void bttnCheckIn_Click_1(System.Object sender, System.EventArgs e)
		{
			int children = (int) (Conversion.Val(txtChildren.Text));
			int adult = (int) (Conversion.Val(txtAdults.Text));
			int advance = (int) (Conversion.Val(txtAdvance.Text));
			int discount = (int) (Conversion.Val(lblDiscountID.Text));
			string reserve = "0";
			string remarks = "Checkin";
			string stat = "Activo";
			
			if (lblGuestID.Text == "GuestID" || lblGuestID.Text == null || txtRoomNumber.Text == null || Conversion.Val(System.Convert.ToString(txtAdults.Text + txtChildren.Text)) == null || advance == null || discount == null)
			{
				Interaction.MsgBox("Por favor llene todos los campos", Constants.vbInformation, "Nota");
			}
			else
			{
				if (Conversion.Val(System.Convert.ToString(Conversion.Val(txtSubTotal.Text) * 0.5)) > Conversion.Val(txtAdvance.Text))
				{
					MessageBox.Show("Falta cash, efectivo! :c $$$$", "Pago por adelantado faltante");
					return;
				}
				string a = System.Convert.ToString(Interaction.MsgBox("¿Confirma Transacción de Entrada?", (int) Constants.vbQuestion + Constants.vbYesNo, "Entrada"));
				if (a == Constants.vbYes.ToString())
				{
					Modulo1.con.Open();
					OleDbCommand checkin = new OleDbCommand("INSERT INTO tblTransaction(GuestID,RoomNum,CheckInDate,CheckOutDate,NoOfChild,NoOfAdult,AdvancePayment,DiscountID,Remarks,Status) values (\'" +
					lblGuestID.Text + "\',\'" +
					txtRoomNumber.Text + "\',\'" +
					txtCheckInDate.Text + "\',\'" +
					dtCheckOutDate.Text + "\',\'" +
					txtChildren.Text + "\',\'" +
					txtAdults.Text + "\',\'" +
					txtAdvance.Text + "\',\'" +
					lblDiscountID.Text + "\',\'" +
					remarks + "\',\'" +
					stat + "\')", Modulo1.con);
					checkin.ExecuteNonQuery();
					
					OleDbCommand update_guest = new OleDbCommand("UPDATE tblGuest SET Remarks = \'Checkin\' WHERE ID = " + lblGuestID.Text + "", Modulo1.con);
					update_guest.ExecuteNonQuery();
					
					OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET Status = \'Ocupado\' WHERE RoomNumber = " + txtRoomNumber.Text + "", Modulo1.con);
					update_room.ExecuteNonQuery();
					
					if (Conversion.Val(txtSubTotal.Text) < Conversion.Val(txtAdvance.Text) || Conversion.Val(txtSubTotal.Text) == Conversion.Val(txtAdvance.Text))
					{
                        Interaction.MsgBox("Invitado eixtosamente ingresado! " + "Change: " + Conversion.Val(System.Convert.ToString(Conversion.Val(txtAdvance.Text) - Conversion.Val(txtSubTotal.Text))).ToString("00.00"), Constants.vbInformation, "Entrada");
						string change = System.Convert.ToString(Interaction.MsgBox("¿Devolver el cambio al cliente?", (int) Constants.vbQuestion + Constants.vbYesNo, "Cambiar"));
						if (change == Constants.vbYes.ToString())
						{
							OleDbCommand update_trans = new OleDbCommand("UPDATE tblTransaction SET AdvancePayment = " + Conversion.Val(txtSubTotal.Text) + " WHERE TransID = " + trans_ID.ToString() + "", Modulo1.con);
							update_trans.ExecuteNonQuery();
						}
					}
					else
					{
						Interaction.MsgBox("Invitado eixtosamente ingresado!", Constants.vbInformation, "Entrada");
					}
					
					clear_text();
					Modulo1.con.Close();
					transID();
					display_checkin();
				}
			}
		}
		
		public void bttnCancel_Click(System.Object sender, System.EventArgs e)
		{
			clear_text();
		}
		
		public void dtCheckOutDate_ValueChanged_1(System.Object sender, System.EventArgs e)
		{
			TimeSpan T = dtCheckOutDate.Value - DateTime.Now;
			if (T.Days < 1)
			{
				dtCheckOutDate.Text = System.Convert.ToString(DateTime.Now.AddDays(1));
				txtDaysNumber.Text = "1";
			}
			else
			{
				txtDaysNumber.Text = System.Convert.ToString(T.Days + 1);
			}
			lblTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
			txtSubTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
		}
		
		public void bttnSearchGuest_Click(System.Object sender, System.EventArgs e)
		{
			frmSeleccionarInvitado.Default.ShowDialog();
		}
		
		public void bttnSearchRoom_Click(System.Object sender, System.EventArgs e)
		{
			frmSeleccionarHabitacion.Default.ShowDialog();
		}
		
		public void txtRoomRate_TextChanged(System.Object sender, System.EventArgs e)
		{
			lblTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
			txtSubTotal.Text = System.Convert.ToString((Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text)).ToString("00.00"));
		}
		
		public void bttnAddAdult_Click(System.Object sender, System.EventArgs e)
		{
			int tao;
			tao = (int) (Conversion.Val(txtAdults.Text) + Conversion.Val(txtChildren.Text));
			if (tao == Conversion.Val(lblNoOfOccupancy.Text))
			{
				
			}
			else
			{
				txtAdults.Text = System.Convert.ToString(Conversion.Val(txtAdults.Text) + 1);
			}
		}
		
		public void bttnAddChildren_Click(System.Object sender, System.EventArgs e)
		{
			int tao;
			tao = (int) (Conversion.Val(txtAdults.Text) + Conversion.Val(txtChildren.Text));
			if (tao == Conversion.Val(lblNoOfOccupancy.Text))
			{
				
			}
			else
			{
				txtChildren.Text = System.Convert.ToString(Conversion.Val(txtChildren.Text) + 1);
			}
		}
		
		public void bttnSubAdult_Click(System.Object sender, System.EventArgs e)
		{
			if (Conversion.Val(txtAdults.Text) == 0)
			{
				txtAdults.Text = System.Convert.ToString(Conversion.Val(txtAdults.Text));
			}
			else
			{
				txtAdults.Text = System.Convert.ToString(Conversion.Val(txtAdults.Text) - 1);
			}
		}
		
		public void bttnSubChildren_Click(System.Object sender, System.EventArgs e)
		{
			if (Conversion.Val(txtChildren.Text) == 0)
			{
				txtChildren.Text = System.Convert.ToString(Conversion.Val(txtChildren.Text));
			}
			else
			{
				txtChildren.Text = System.Convert.ToString(Conversion.Val(txtChildren.Text) - 1);
			}
		}
		
		private void pop_discount()
		{
			Modulo1.con.Open();
			DataTable dt = new DataTable();
			Modulo1.rs = new OleDbDataAdapter("SELECT * FROM tblDiscount", Modulo1.con);
			Modulo1.rs.Fill(dt);
			
			cboDiscount.Items.Clear();
			int i = default(int);
			for (i = 0; i <= dt.Rows.Count - 1; i++)
			{
				cboDiscount.Items.Add(dt.Rows[i]["DiscountType"]);
			}
			Modulo1.rs.Dispose();
			Modulo1.con.Close();
		}
		
		public void cboDiscount_TextChanged(object sender, System.EventArgs e)
		{
			Modulo1.con.Open();
			DataTable dt = new DataTable();
			Modulo1.rs = new OleDbDataAdapter("SELECT * FROM tblDiscount WHERE DiscountType = \'" + cboDiscount.Text + "\'", Modulo1.con);
			Modulo1.rs.Fill(dt);
			
			lblDiscountID.Text = (dt.Rows[0]["ID"].ToString());
			lblDiscountRate.Text =(dt.Rows[0]["DiscountRate"].ToString());
			
			//lblTotal.Text = Val(txtSubTotal.Text) - (Val(txtSubTotal.Text) * Val(lblDiscountRate.Text))
			txtSubTotal.Text = System.Convert.ToString((Conversion.Val(lblTotal.Text) - (Conversion.Val(lblTotal.Text) * Conversion.Val(lblDiscountRate.Text))).ToString("00.00"));
			lblAdvancePayment.Text = "Pago por Adelantado debe ser al menos " + (Conversion.Val(txtSubTotal.Text) * 0.5).ToString("00.00");
			Modulo1.rs.Dispose();
			Modulo1.con.Close();
		}
		
		public void txtAdvance_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0'|| e.KeyChar > '9') && e.KeyChar != ControlChars.Back && e.KeyChar != '.')
			{
				//cancel keys
				e.Handled = true;
			}
		}
		
		public void txtAdvance_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Conversion.Val(txtSubTotal.Text) < Conversion.Val(txtAdvance.Text) || Conversion.Val(txtSubTotal.Text) == Conversion.Val(txtAdvance.Text))
			{
				txtTotal.Text = "0.00";
			}
			else
			{
				txtTotal.Text = System.Convert.ToString((Conversion.Val(txtSubTotal.Text) - Conversion.Val(txtAdvance.Text)).ToString("00.00"));
			}
		}
		
		private void clear_text()
		{
			txtGuestName.Clear();
			txtRoomNumber.Clear();
			txtRoomType.Clear();
			txtRoomRate.Clear();
			txtChildren.Text = "0";
			txtAdults.Text = "0";
			cboDiscount.Refresh();
			txtAdvance.Clear();
			txtSubTotal.Clear();
			txtTotal.Clear();
			lblDiscountID.Text = "";
			lblDiscountRate.Text = "";
			lblGuestID.Text = "";
			lblAdvancePayment.Text = "";
			lblNoOfOccupancy.Text = "0";
			
			DateTime time = DateTime.Now;
			string format = "MM/d/yyyy";
			txtCheckInDate.Text = time.ToString(format);
			dtCheckOutDate.Text = System.Convert.ToString(DateTime.Now.AddDays(1));
		}
		
		private void display_checkin()
		{
			Modulo1.con.Open();
			DataTable Dt = new DataTable("tblGuest");
			OleDbDataAdapter rs = default(OleDbDataAdapter);
			
			rs = new OleDbDataAdapter("Select * from tblTransaction, tblGuest, tblDiscount, tblRoom WHERE tblTransaction.GuestID = tblGuest.ID AND tblTransaction.DiscountID = tblDiscount.ID AND tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.Remarks = \'Checkin\' AND tblTransaction.Status = \'Activo\'", Modulo1.con);
			
			rs.Fill(Dt);
			int indx = default(int);
			lvlcheckin.Items.Clear();
			for (indx = 0; indx <= Dt.Rows.Count - 1; indx++)
			{
				ListViewItem lv = new ListViewItem();
				TimeSpan getdate = new TimeSpan();
				int days = default(int);
				int subtotal = default(int);
				int total = default(int);
				int rate = default(int);
				double discount = default(double);
				
				int value = (int) (Conversion.Val(Dt.Rows[indx]["TransID"]));
				
				lv.Text = "TransID - " + value.ToString("0000");
				lv.SubItems.Add(Dt.Rows[indx]["GuestFName"] + " " + Dt.Rows[indx]["GuestLName"]);
				lv.SubItems.Add(Dt.Rows[indx]["RoomNum"].ToString());
				
				rate = System.Convert.ToInt32(Dt.Rows[indx]["RoomRate"]);
				
				lv.SubItems.Add(Dt.Rows[indx]["CheckInDate"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["CheckOutDate"].ToString());
				
				dtIn.Value = System.Convert.ToDateTime(Dt.Rows[indx]["CheckOutDate"]);
				dtOut.Value = System.Convert.ToDateTime(Dt.Rows[indx]["CheckInDate"]);
				
				getdate = dtIn.Value - dtOut.Value;
				days = getdate.Days;
				
				lv.SubItems.Add(days.ToString());
				lv.SubItems.Add(Dt.Rows[indx]["NoOfChild"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["NoOfAdult"].ToString());
                lv.SubItems.Add(Dt.Rows[indx]["AdvancePayment"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["DiscountType"].ToString());
				
				discount = Conversion.Val(Dt.Rows[indx]["DiscountRate"]);
				
				subtotal = (int) ((days * rate) - ((days * rate) * discount));
				total = (int) ((Conversion.Val(subtotal.ToString()) - Conversion.Val(Dt.Rows[indx]["AdvancePayment"])));
				
				if (Conversion.Val(subtotal.ToString()) > Conversion.Val(Dt.Rows[indx]["AdvancePayment"]))
				{
					lv.SubItems.Add(System.Convert.ToString(Conversion.Val(total.ToString())));
				}
				else
				{
					lv.SubItems.Add("0");
				}
				
				lvlcheckin.Items.Add(lv);
			}
			rs.Dispose();
			Modulo1.con.Close();
		}
		
		public void cboDiscount_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
            bttnCheckIn.Enabled = true;
		}
	}
}
