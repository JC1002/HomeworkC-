
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
	public partial class frmListadoEntrada
	{
		public frmListadoEntrada()
		{
			InitializeComponent();
			
	
		}
		
#region Default Instance
		
		private static frmListadoEntrada defaultInstance;
		
		
		public static frmListadoEntrada Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmListadoEntrada();
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
		
		public void frmCheckinList_Load(System.Object sender, System.EventArgs e)
		{
			Modulo1.con.Open();
			DataTable Dt = new DataTable("tblTransaction");
			Modulo1.rs = new OleDbDataAdapter("Select * from tblTransaction, tblGuest, tblDiscount, tblRoom WHERE tblTransaction.GuestID = tblGuest.ID AND tblTransaction.DiscountID = tblDiscount.ID AND tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.Remarks = \'Checkin\' AND tblTransaction.Status = \'Activo\'", Modulo1.con);
			Modulo1.rs.Fill(Dt);
			
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
				total = (int) (Conversion.Val(subtotal.ToString()) - Conversion.Val(Dt.Rows[indx]["AdvancePayment"]));
				
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
			Modulo1.rs.Dispose();
			Modulo1.con.Close();
		}
		
		public void lvlcheckin_DoubleClick(object sender, System.EventArgs e)
		{
			
			dtIn.Value = DateTime.Parse(lvlcheckin.SelectedItems[0].SubItems[3].Text);
			dtOut.Value = DateTime.Now.Date;
			
			Modulo1.con.Open();
			DataTable dt = new DataTable("tblTransaction");
			Modulo1.rs = new OleDbDataAdapter("Select * from tblTransaction, tblRoom, tblDiscount WHERE tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.DiscountID = tblDiscount.ID", Modulo1.con);
			Modulo1.rs.Fill(dt);
			int indx = default(int);
			for (indx = 0; indx <= dt.Rows.Count - 1; indx++)
			{
				double value = Conversion.Val(dt.Rows[indx]["TransID"]);
				
				if (lvlcheckin.SelectedItems[0].Text == "TransID - " + value.ToString("0000"))
				{
					frmSalida.Default.txtTransID.Text = "TransID - " + value.ToString("0000");
					frmSalida.Default.lblTransID.Text = (dt.Rows[indx]["TransID"].ToString());
					frmSalida.Default.lblGuestID.Text = (dt.Rows[indx]["GuestID"].ToString());
					
					DateTime time = DateTime.Now;
					string format = "d/MM/yyyy";
					TimeSpan getdate = new TimeSpan();
					
					if (dtIn.Value == dtOut.Value)
					{
						frmSalida.Default.txtCheckout.Text = System.Convert.ToString(DateTime.Now.Date.AddDays(1));
						frmSalida.Default.txtDays.Text = "1";
						double subtotal = Conversion.Val(frmSalida.Default.txtDays.Text) * Conversion.Val(dt.Rows[indx]["RoomRate"]);
						subtotal = Conversion.Val(subtotal.ToString()) - Conversion.Val(System.Convert.ToString(System.Convert.ToDouble((dt.Rows[indx]["DiscountRate"])) * Conversion.Val(subtotal.ToString()) ));
						
						if (Conversion.Val(subtotal.ToString()) > Conversion.Val(dt.Rows[indx]["AdvancePayment"]))
						{
							double total = Conversion.Val(subtotal.ToString()) - System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"]));
							
							frmSalida.Default.txtSubTotal.Text = (string) (Conversion.Val(subtotal.ToString()).ToString("N"));
							frmSalida.Default.txtTotal.Text = (string) (Conversion.Val(total.ToString()).ToString("N"));
							frmSalida.Default.txtCash.Text = (string) (Conversion.Val(total.ToString()).ToString("N"));
							frmSalida.Default.txtChange.Text = "0.00";
						}
						else
						{
							double total = System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"])) - Conversion.Val(subtotal.ToString()) ;
							double change = Conversion.Val(total.ToString()) - System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"]));
							
							frmSalida.Default.txtSubTotal.Text = (string) (Conversion.Val(subtotal.ToString()).ToString("N"));
							frmSalida.Default.txtTotal.Text = "0.00";
							frmSalida.Default.txtCash.Text = "0.00";
							frmSalida.Default.txtChange.Text = (string) (Conversion.Val(total.ToString()).ToString("N"));
						}
						
					}
					else
					{
						frmSalida.Default.txtCheckout.Text = DateTime.Now.Date.ToString();
						
						getdate = (dtOut.Value) - (dtIn.Value);
						frmSalida.Default.txtDays.Text = getdate.Days.ToString();
						
						double subtotal = Conversion.Val(getdate.Days.ToString()) * Conversion.Val(dt.Rows[indx]["RoomRate"]);
						subtotal = Conversion.Val(subtotal.ToString()) - Conversion.Val(System.Convert.ToString(System.Convert.ToDouble((dt.Rows[indx]["DiscountRate"])) * Conversion.Val(subtotal.ToString()) ));
						
						if (Conversion.Val(subtotal.ToString()) > Conversion.Val(dt.Rows[indx]["AdvancePayment"]))
						{
							double total = Conversion.Val(subtotal.ToString()) - System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"]));
							
							frmSalida.Default.txtSubTotal.Text = (string) (Conversion.Val(subtotal.ToString()).ToString("N"));
							frmSalida.Default.txtTotal.Text = (string) (Conversion.Val(total.ToString()).ToString("N"));
							frmSalida.Default.txtCash.Text = (string) (Conversion.Val(total.ToString()).ToString("N"));
							frmSalida.Default.txtChange.Text = "0.00";
						}
						else
						{
							double total = System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"])) - Conversion.Val(subtotal.ToString()) ;
							double change = Conversion.Val(total.ToString()) - System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"]));
							
							frmSalida.Default.txtSubTotal.Text = (string) (Conversion.Val(subtotal.ToString()).ToString("N"));
							frmSalida.Default.txtTotal.Text = "0.00";
							frmSalida.Default.txtCash.Text = "0.00";
							frmSalida.Default.txtChange.Text = (string) (Conversion.Val(total.ToString()).ToString("N"));
						}
					}
					
					break;
					
				}
			}
			
			
			Modulo1.rs.Dispose();
			Modulo1.con.Close();
			
			//frmCheckout.txtTransID.Text = lvlcheckin.SelectedItems(0).Text
			frmSalida.Default.txtGuestName.Text = lvlcheckin.SelectedItems[0].SubItems[1].Text;
			frmSalida.Default.txtRoomNumber.Text = lvlcheckin.SelectedItems[0].SubItems[2].Text;
			frmSalida.Default.txtCheckin.Text = lvlcheckin.SelectedItems[0].SubItems[3].Text;
			//frmCheckout.txtCheckout.Text = lvlcheckin.SelectedItems(0).SubItems(4).Text
			//frmCheckout.txtDays.Text = lvlcheckin.SelectedItems(0).SubItems(5).Text
			frmSalida.Default.txtChildren.Text = lvlcheckin.SelectedItems[0].SubItems[6].Text;
			frmSalida.Default.txtAdult.Text = lvlcheckin.SelectedItems[0].SubItems[7].Text;
			frmSalida.Default.txtAdvance.Text = (string) (Conversion.Val(lvlcheckin.SelectedItems[0].SubItems[8].Text).ToString("N"));
			frmSalida.Default.txtDiscountType.Text = lvlcheckin.SelectedItems[0].SubItems[9].Text;
			
			this.Close();
		}
	}
}
