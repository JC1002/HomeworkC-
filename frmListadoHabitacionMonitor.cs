
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
	public partial class frmListadoHabitacionMonitor
	{
		public frmListadoHabitacionMonitor()
		{
			InitializeComponent();

		}
		
#region Default Instance
		
		private static frmListadoHabitacionMonitor defaultInstance;
		
		public static frmListadoHabitacionMonitor Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmListadoHabitacionMonitor();
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
		
		public void frmRoomListMonitor_Load(System.Object sender, System.EventArgs e)
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
				lv.Text = (Dt.Rows[indx]["RoomNumber"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["RoomType"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["RoomRate"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["NoOfOccupancy"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["Status"].ToString());
				lvRoom.Items.Add(lv);
			}
			rs.Dispose();
			Modulo1.con.Close();
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
                        int jj = lvRoom.Columns.Count;
                        for (int rr = 0; rr < jj; rr++)
                        {
                            ws.Cells[i, j] = lvRoom.Columns[rr].Text;
                            j = j + 1;
                        }
                        i = 2;
                        j = 1;
                        foreach (ListViewItem lista in lvRoom.Items)
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
                        foreach (ColumnHeader ch in lvRoom.Columns)
                        {
                            sb.Append(ch.Text + ",");
                        }
                        sb.AppendLine();
                        foreach (ListViewItem lvi in lvRoom.Items)
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
