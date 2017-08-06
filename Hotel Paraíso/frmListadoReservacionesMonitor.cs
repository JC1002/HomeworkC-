
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
using System.IO;

namespace HBRS
{
	public partial class frmListadoReservacionesMonitor
	{
		public frmListadoReservacionesMonitor()
		{
			InitializeComponent();
			
		}
		
#region Default Instance
		
		private static frmListadoReservacionesMonitor defaultInstance;

		public static frmListadoReservacionesMonitor Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmListadoReservacionesMonitor();
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
		
		public void frmReserveListMonitor_Load(System.Object sender, System.EventArgs e)
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
				int rate = default(int);
				double discount = default(double);
				double subtotal = default(double);
				double total = default(double);
				double advance = default(double);
				
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
				advance = System.Convert.ToDouble(Dt.Rows[indx]["AdvancePayment"]);
				lv.SubItems.Add(Conversion.Val(advance.ToString()).ToString("N"));
				lv.SubItems.Add(Dt.Rows[indx]["DiscountType"].ToString());
				
				discount = Conversion.Val(Dt.Rows[indx]["DiscountRate"]);
				
				subtotal = (days * rate) - ((days * rate) * discount);
				
				total = Conversion.Val(subtotal.ToString()) - Conversion.Val(Dt.Rows[indx]["AdvancePayment"]);
				
				lv.SubItems.Add(Conversion.Val(total.ToString()).ToString("N"));
				lvlreserve.Items.Add(lv);
			}
			rs.Dispose();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Libro de Excel (*.xlsx)|*.xlsx | Libro de Excel 97-2003 (*.xls)|*.xls | Archivo csv (*.csv)|*.csv";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FilterIndex == 1)
                    {


                        Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
                        xla.Visible = true;
                        Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                        Microsoft.Office.Interop.Excel.Worksheet ws = ((Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet);
                        int i = 1;
                        int j = 1;
                        int jj = lvlreserve.Columns.Count;
                        for (int rr = 0; rr < jj; rr++)
                        {
                            ws.Cells[i, j] = lvlreserve.Columns[rr].Text;
                            j = j + 1;
                        }
                        i = 2;
                        j = 1;
                        foreach (ListViewItem lista in lvlreserve.Items)
                        {
                            ws.Cells[i, j] = lista.Text.ToString();
                            foreach (ListViewItem.ListViewSubItem drv in lista.SubItems)
                            {
                                ws.Cells[i, j] = drv.Text.ToString();
                                j += 1;
                            }
                            j = 1;
                            i += 1;
                        }

                        wb.SaveAs(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);
                        wb.Close(false, Type.Missing, Type.Missing);
                        xla.Quit();
                    }
                    else if (saveFileDialog1.FilterIndex == 2)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        foreach (ColumnHeader ch in lvlreserve.Columns)
                        {
                            sb.Append(ch.Text + ",");
                        }
                        sb.AppendLine();
                        foreach (ListViewItem lvi in lvlreserve.Items)
                        {
                            foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                            {
                                if (lvs.Text.Trim() == string.Empty)
                                    sb.Append(" ,");
                                else
                                    sb.Append(lvs.Text + ",");
                            }
                            sb.AppendLine();
                        }
                        StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                        sw.Write(sb.ToString());
                        sw.Close();
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
	}
}
