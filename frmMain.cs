
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
using HotelParaiso;


using Microsoft.VisualBasic.CompilerServices;
using System.Data.OleDb;

namespace HBRS
{
	public partial class frmMain
	{
		public frmMain()
		{
			InitializeComponent();

		}
		
#region Default Instance
		
		private static frmMain defaultInstance;

		public static frmMain Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmMain();
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
		
		public void frmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
            string exit_app = System.Convert.ToString(Interaction.MsgBox("¿Salir de la aplicación?", (int)Constants.vbQuestion + Constants.vbYesNo, "Salir"));
			if (exit_app == Constants.vbNo.ToString())
			{
				e.Cancel = true;
			}
			else
			{
				ProjectData.EndApp();
			}
		}
		
		public void frmMain_Load(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void toolbarCheckIn_Click(System.Object sender, System.EventArgs e)
		{
			frmEntrada.Default.ShowDialog();
		}
		
		public void ToolStripButton13_Click(System.Object sender, System.EventArgs e)
		{
            string exit_app = System.Convert.ToString(Interaction.MsgBox("¿Salir de la aplicación?", (int)Constants.vbQuestion + Constants.vbYesNo, "Salir"));
			if (exit_app == Constants.vbYes.ToString())
			{
				ProjectData.EndApp();
			}
		}
		
		public void ToolStripButton12_Click(System.Object sender, System.EventArgs e)
		{
            string out_app = System.Convert.ToString(Interaction.MsgBox("¿Cerrar sesión de la aplicación?", (int)Constants.vbQuestion + Constants.vbYesNo, "Cerrar Sesión"));
			if (out_app == Constants.vbYes.ToString())
			{
				Modulo1.con.Close();
                this.Hide();
                frmLogin.Default.Show();
                
			}
		}
		
		public void ToolStripButton10_Click(System.Object sender, System.EventArgs e)
		{
			frmInvitado.Default.ShowDialog();
		}
		
		public void toolbarRoom_Click(System.Object sender, System.EventArgs e)
		{
			frmHabitacion.Default.ShowDialog();
		}
		
		public void toolbarReserve_Click(System.Object sender, System.EventArgs e)
		{
			frmReservar.Default.ShowDialog();
		}
		
		public void NewCheckInToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmEntrada.Default.ShowDialog();
		}
		
		public void NewReservationToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmReservar.Default.ShowDialog();
		}
		
		public void LogoutToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			string out_app = System.Convert.ToString(Interaction.MsgBox("¿Cerrar sesión de la aplicación?", (int) Constants.vbQuestion + Constants.vbYesNo, "Cerrar Sesión"));
			if (out_app == Constants.vbYes.ToString())
			{
				this.Hide();
				frmLogin.Default.Show();
			}
		}
		
		public void ExitToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		public void toolbarCheckOut_Click(System.Object sender, System.EventArgs e)
		{
			frmSalida.Default.ShowDialog();
		}
		
		public void CheckedInListToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmListadoEntradaMonitor.Default.ShowDialog();
		}
		
		public void RoomStatusToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmListadoHabitacionMonitor.Default.ShowDialog();
		}
		
		public void ReservedListToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmListadoReservacionesMonitor.Default.ShowDialog();
		}
		
		public void CheckedOutListToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmListadoSalida.Default.ShowDialog();
		}
		
		public void Timer1_Tick(System.Object sender, System.EventArgs e)
		{
			DateTime datenow = DateTime.Now;
            status.Items[2].Text = "Fecha y Hora : " + datenow.ToString();
		}
		
		public void DiscountToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmDescuento.Default.ShowDialog();
		}
		
		public void RoomToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmHabitacion.Default.ShowDialog();
			frmHabitacion.Default.TabPage2.Select();
		}
		
		public void GuestToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmInvitado.Default.ShowDialog();
		}

        private void cuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmAccesoAdministrativo abrir = new FrmAccesoAdministrativo();
            abrir.ShowDialog();

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            Process procStarter = new Process();
            procStarter.StartInfo.FileName = "Trialapp.exe";
            procStarter.Start();
        }

	}
	
}
