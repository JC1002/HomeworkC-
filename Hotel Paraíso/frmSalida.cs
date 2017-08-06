
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
	public partial class frmSalida
	{
		public frmSalida()
		{
			InitializeComponent();
			
			
		}
		
#region Default Instance
		
		private static frmSalida defaultInstance;
		
		public static frmSalida Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmSalida();
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
		
		public void bttnSearchGuest_Click(System.Object sender, System.EventArgs e)
		{
			frmListadoEntrada.Default.ShowDialog();
		}
		
		public void txtRoomNumber_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (txtRoomNumber.Text == null)
			{
			}
			else
			{
				Modulo1.con.Open();
				DataTable dt = new DataTable("tblRoom");
                Modulo1.rs = new OleDbDataAdapter("SELECT * FROM tblRoom WHERE RoomNumber = " + txtRoomNumber.Text, Modulo1.con);
				Modulo1.rs.Fill(dt);
				txtRoomType.Text = (dt.Rows[0]["RoomType"].ToString());
				txtRoomRate.Text = (Conversion.Val(dt.Rows[0]["RoomRate"].ToString()).ToString("N"));
				Modulo1.rs.Dispose();
				Modulo1.con.Close();
			}
			
		}
		
		public void txtCash_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0'|| e.KeyChar > '9') && e.KeyChar != ControlChars.Back && e.KeyChar != '.')
			{
				//cancel keys
				e.Handled = true;
			}
		}
		
		public void txtCash_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Conversion.Val(txtCash.Text) < Conversion.Val(txtTotal.Text))
			{
				txtChange.Text = "0.00";
			}
			else
			{
				txtChange.Text = System.Convert.ToString((Conversion.Val(txtCash.Text) - Conversion.Val(txtTotal.Text)).ToString("N"));
			}
		}
		
		public void bttnCheckout_Click(System.Object sender, System.EventArgs e)
		{

                if (txtTransID.Text == null)
                {
                    Interaction.MsgBox("Por favor seleccione una transacción para dar salida!", Constants.vbExclamation, "Nota");
                }
                else
                {
                    if (Conversion.Val(txtCash.Text) < Conversion.Val(txtTotal.Text))
                    {
                        Interaction.MsgBox("Efectivo Insuficiente!", Constants.vbExclamation, "Nota");
                    }
                    else
                    {
                        string @out = System.Convert.ToString(Interaction.MsgBox("Confirma dar Salida", (int)Constants.vbQuestion + Constants.vbYesNo, "Salida"));
                        if (@out == Constants.vbYes.ToString())
                        {
                            if (Modulo1.con.State == ConnectionState.Closed)
                            {
                                Modulo1.con.Open();
                            }

                            OleDbCommand update_trans = new OleDbCommand("UPDATE tblTransaction SET Remarks = \'Salida\' WHERE TransID = " + lblTransID.Text + "", Modulo1.con);
                            update_trans.ExecuteNonQuery();

                            OleDbCommand update_guest = new OleDbCommand("UPDATE tblGuest SET Remarks = \'Disponible\' WHERE ID = " + lblGuestID.Text + "", Modulo1.con);
                            update_guest.ExecuteNonQuery();

                            OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET Status = \'Disponible\' WHERE RoomNumber = " + txtRoomNumber.Text + "", Modulo1.con);
                            update_room.ExecuteNonQuery();
                            Interaction.MsgBox("Invitado Salió", Constants.vbInformation, "Salida");
                            Modulo1.con.Close();
                            clear_text();
                            this.Close();
                            frmSalida abrir = new frmSalida();
                            abrir.ShowDialog();
                        }
                    }
                }
		}
		
		public void clear_text()
		{
			txtTransID.Clear();
			txtGuestName.Clear();
			txtRoomRate.Clear();
			txtRoomType.Clear();
			txtCheckin.Clear();
			txtCheckout.Clear();
			txtChildren.Clear();
			txtAdult.Clear();
			txtAdvance.Clear();
			txtDiscountType.Clear();
			txtTotal.Clear();
			txtSubTotal.Clear();
			txtDays.Clear();
			txtCash.Clear();
			txtChange.Clear();
            //txtRoomNumber.Text = "";
		}
		
		public void lblTransID_TextChanged(object sender, System.EventArgs e)
		{
			
		}
		
		public void frmCheckout_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			clear_text();
		}
		
		public void frmCheckout_Load(System.Object sender, System.EventArgs e)
		{
			txtRoomNumber.Clear();
			dtOut.Value = DateTime.Now;
		}
		
		public void txtAdvance_TextChanged(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void txtTotal_TextChanged(System.Object sender, System.EventArgs e)
		{
			
		}
		
		
		public void txtDiscountType_TextChanged(System.Object sender, System.EventArgs e)
		{
			
		}
	}
}
