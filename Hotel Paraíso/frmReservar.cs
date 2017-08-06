
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
	public partial class frmReservar
	{
		public frmReservar()
		{
			InitializeComponent();
			

		}
		
#region Default Instance
		
		private static frmReservar defaultInstance;
		

		public static frmReservar Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmReservar();
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
		string trans_id;
		int id;
		int guest_id;
		int room_num;
		
		public void dtCheckOutDate_ValueChanged(System.Object sender, System.EventArgs e)
		{
			TimeSpan T = dtCheckOutDate.Value - dtCheckInDate.Value;
			if (T.Days < 1)
			{
				dtCheckOutDate.Text = System.Convert.ToString(dtCheckInDate.Value.Date.AddDays(1));
				txtDaysNumber.Text = "1";
			}
			else
			{
				txtDaysNumber.Text = T.Days.ToString();
			}
			lblTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
			txtSubTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
			lblDateNow.Text = DateTime.Now.Date.ToString();
		}
		
		public void bttnSearchGuest_Click(System.Object sender, System.EventArgs e)
		{
			frmSeleccionarInvitado.Default.ShowDialog();
		}
		
		public void bttnSearchRoom_Click(System.Object sender, System.EventArgs e)
		{
			frmSeleccionarHabitacion.Default.ShowDialog();
		}
		
		public void bttnCancel_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		public void frmReserve_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
            string a = System.Convert.ToString(Interaction.MsgBox("¿Cancelar Transacción?", (int)Constants.vbQuestion + Constants.vbYesNo, "Cancelar"));
			if (a == Constants.vbNo.ToString())
			{
				e.Cancel = true;
			}
			else
			{
				clear_text();
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
			//dtCheckInDate.Text = time.ToString(format);
			dtCheckOutDate.Text = System.Convert.ToString(DateTime.Now.AddDays(1));

		}
		
		public void frmReserve_Load(object sender, System.EventArgs e)
		{
            // TODO: esta línea de código carga datos en la tabla 'bDHotelParaisoDataSet.tblTransaction' Puede moverla o quitarla según sea necesario.
            //this.tblTransactionTableAdapter.Fill(this.bDHotelParaisoDataSet.tblTransaction);
            // TODO: esta línea de código carga datos en la tabla 'bDHotelParaisoDataSet.tblDiscount' Puede moverla o quitarla según sea necesario.
            //this.tblDiscountTableAdapter.Fill(this.bDHotelParaisoDataSet.tblDiscount);
			clear_text();
			DateTime time = DateTime.Now;
			string format = "d/MM/yyyy";
			dtCheckInDate.Text = time.ToString(format);
			dtCheckOutDate.Text = System.Convert.ToString(dtCheckInDate.Value.Date.AddDays(1));
			lblDateNow.Text = DateTime.Now.Date.ToString();
			transID();
			pop_discount();
			display_reserve();
            cboDiscount.Text = "";
            
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
			}
			Modulo1.rs.Dispose();
			Modulo1.con.Close();
			
		}
		
		private void pop_discount()
		{
			
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
			
		}
		
		private void display_reserve()
		{
			
			DataTable Dt = new DataTable("tblGuest");
			OleDbDataAdapter rs = default(OleDbDataAdapter);
			
			rs = new OleDbDataAdapter("Select * from tblTransaction, tblGuest, tblDiscount, tblRoom WHERE tblTransaction.GuestID = tblGuest.ID AND tblTransaction.DiscountID = tblDiscount.ID AND tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.Remarks = \'Reserve\'", Modulo1.con);
			
			rs.Fill(Dt);
			int indx = default(int);
			lvlreserve.Items.Clear();
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
                total = (int) (Conversion.Val(subtotal.ToString()) - Conversion.Val(Dt.Rows[indx]["AdvancePayment"]));
				
				lv.SubItems.Add(System.Convert.ToString(Conversion.Val(total.ToString())));
				lvlreserve.Items.Add(lv);
			}
			rs.Dispose();
			
		}
		
		public void bttnReserve_Click(System.Object sender, System.EventArgs e)
		{
			int children = (int) (Conversion.Val(txtChildren.Text));
			int adult = (int) (Conversion.Val(txtAdults.Text));
			int advance = (int) (Conversion.Val(txtAdvance.Text));
			int discount = (int) (Conversion.Val(lblDiscountID.Text));
			string reserve = "0";
			string remarks = "Reserve";
			string stat = "Activo";
			
			if (lblGuestID.Text == "GuestID" || lblGuestID.Text == null || txtRoomNumber.Text == null || Conversion.Val(System.Convert.ToString(children + adult)) == null || advance == null || discount == null || cboDiscount.Text == "")
			{
				Interaction.MsgBox("Por Favor llene todos los campos", Constants.vbInformation, "Nota");
			}
			else
			{
                if (Conversion.Val(System.Convert.ToString(Conversion.Val(txtSubTotal.Text) * 0.5)) > Conversion.Val(txtAdvance.Text))
                {
                    MessageBox.Show("Falta cash, efectivo! :c $$$$", "Pago por adelantado faltante");
                    return;
                }

				string a = System.Convert.ToString(Interaction.MsgBox("¿Confirma la Reservación?", (int) Constants.vbQuestion + Constants.vbYesNo, "Reservación"));
				if (a == Constants.vbYes.ToString())
				{
					Modulo1.con.Open();
					OleDbCommand checkin = new OleDbCommand("INSERT INTO tblTransaction(GuestID,RoomNum,CheckInDate,CheckOutDate,ReservationDate,NoOfChild,NoOfAdult,AdvancePayment,DiscountID,Remarks,Status) values (\'" +
					lblGuestID.Text + "\',\'" +
					txtRoomNumber.Text + "\',\'" +
					dtCheckInDate.Text + "\',\'" +
					dtCheckOutDate.Text + "\',\'" +
					lblDateNow.Text + "\',\'" +
					txtChildren.Text + "\',\'" +
					txtAdults.Text + "\',\'" +
					txtAdvance.Text + "\',\'" +
					lblDiscountID.Text + "\',\'" +
					remarks + "\',\'" +
					stat + "\')", Modulo1.con);
					checkin.ExecuteNonQuery();
					
					OleDbCommand update_guest = new OleDbCommand("UPDATE tblGuest SET Remarks = \'Reserve\' WHERE ID = " + lblGuestID.Text + "", Modulo1.con);
					update_guest.ExecuteNonQuery();
					
					OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET Status = \'Reserve\' WHERE RoomNumber = " + txtRoomNumber.Text + "", Modulo1.con);
					update_room.ExecuteNonQuery();

                    Interaction.MsgBox("¡Invitado Reservado Exitosamente!", Constants.vbInformation, "Reservación");
					clear_text();
					Modulo1.con.Close();
					transID();
					display_reserve();
				}
			}
		}
		
		public void dtCheckInDate_ValueChanged(System.Object sender, System.EventArgs e)
		{
			DateTime t = dtCheckInDate.Value;
			if (t.Date < DateTime.Now.Date)
			{
				dtCheckInDate.Value = DateTime.Now.Date;
			}
			else
			{
				dtCheckOutDate.Value = dtCheckInDate.Value.Date.AddDays(1);
			}
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
		
		public void cboDiscount_TextChanged(object sender, System.EventArgs e)
		{
			Modulo1.con.Open();
			DataTable dt = new DataTable();
            Modulo1.rs = new OleDbDataAdapter("SELECT * FROM tblDiscount WHERE DiscountType = \'" + cboDiscount.Text + "\'", Modulo1.con);
			Modulo1.rs.Fill(dt);
			
			lblDiscountID.Text = (dt.Rows[0]["ID"].ToString());
			lblDiscountRate.Text = (dt.Rows[0]["DiscountRate"].ToString());
			
			//lblTotal.Text = Val(txtSubTotal.Text) - (Val(txtSubTotal.Text) * Val(lblDiscountRate.Text))
			txtSubTotal.Text = System.Convert.ToString((Conversion.Val(lblTotal.Text) - (Conversion.Val(lblTotal.Text) * Conversion.Val(lblDiscountRate.Text))).ToString("00.00"));
            lblAdvancePayment.Text = "Pago adelantado debe ser al menos " + (Conversion.Val(txtSubTotal.Text) * 0.5).ToString("00.00");
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
			txtTotal.Text = System.Convert.ToString(Conversion.Val(lblTotal.Text) - Conversion.Val(txtAdvance.Text));
		}
		
		public void txtRoomRate_TextChanged(System.Object sender, System.EventArgs e)
		{
			lblTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
			txtSubTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
		}
		
		public void lvlreserve_Click(object sender, System.EventArgs e)
		{
			trans_id = lvlreserve.SelectedItems[0].Text;
			Modulo1.con.Open();
			DataTable dt = new DataTable("tblTransaction");
			Modulo1.rs = new OleDbDataAdapter("SELECT * FROM tblTransaction", Modulo1.con);
			Modulo1.rs.Fill(dt);
			int indx = default(int);
			for (indx = 0; indx <= dt.Rows.Count - 1; indx++)
			{
				if (trans_id == "TransID - " + Conversion.Val(dt.Rows[indx]["TransID"]).ToString("0000"))
				{
					guest_id = System.Convert.ToInt32(dt.Rows[0]["GuestID"]);
					room_num = System.Convert.ToInt32(dt.Rows[0]["RoomNum"]);
					id = System.Convert.ToInt32(dt.Rows[indx]["TransID"]);
					break;
				}
			}
			Modulo1.rs.Dispose();
			Modulo1.con.Close();
		}
		
		public void bttnCheckin_Click(System.Object sender, System.EventArgs e)
		{
            string check_in = System.Convert.ToString(Interaction.MsgBox("¿Registrar Invitado?", (int)Constants.vbQuestion + Constants.vbYesNo, "Registrar"));
			if (check_in == Constants.vbYes.ToString())
			{
				Modulo1.con.Open();
				OleDbCommand update_trans = new OleDbCommand("UPDATE tblTransaction SET Remarks = \'Checkin\' WHERE TransID = " + id.ToString() + "", Modulo1.con);
				update_trans.ExecuteNonQuery();
				
				OleDbCommand update_guest = new OleDbCommand("UPDATE tblGuest SET Remarks = \'Checkin\' WHERE ID = " + guest_id.ToString() + "", Modulo1.con);
				update_guest.ExecuteNonQuery();
				
				OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET Status = \'Ocupado\' WHERE RoomNumber = " + room_num.ToString() + "", Modulo1.con);
				update_room.ExecuteNonQuery();
				Modulo1.con.Close();
				display_reserve();
				Interaction.MsgBox("Invitado Registrado!", Constants.vbInformation, "Reservación");
			}
		}
		
		public void bttnCancelReserve_Click(System.Object sender, System.EventArgs e)
		{
            string check_in = System.Convert.ToString(Interaction.MsgBox("¿Cancelar Reservación?", (int)Constants.vbQuestion + Constants.vbYesNo, "Cancelar"));
			if (check_in == Constants.vbYes.ToString())
			{
				Modulo1.con.Open();
				
				OleDbCommand update_trans = new OleDbCommand("UPDATE tblTransaction SET Remarks = \'Cancelado\' WHERE TransID = " + id.ToString() + "", Modulo1.con);
				update_trans.ExecuteNonQuery();
				
				OleDbCommand update_guest = new OleDbCommand("UPDATE tblGuest SET Remarks = \'Disponible\' WHERE ID = " + guest_id.ToString() + "", Modulo1.con);
				update_guest.ExecuteNonQuery();
				
				OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET Status = \'Disponible\' WHERE RoomNumber = " + room_num.ToString() + "", Modulo1.con);
				update_room.ExecuteNonQuery();
				
				Modulo1.con.Close();
				display_reserve();
				Interaction.MsgBox("Reservación Cancelada!", Constants.vbInformation, "Cancelar");
			}
		}
		
		public void lvlreserve_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			
		}

        private void txtRoomNumber_TextChanged(object sender, EventArgs e)
        {
            cboDiscount.Visible = false;
            cboDiscount.Visible = true;
            cboDiscount.Enabled = true;
        }

        private void frmReservar_Shown(object sender, EventArgs e)
        {

        }
	}
}
