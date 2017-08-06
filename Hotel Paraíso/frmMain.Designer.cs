// VBConversions Note: VB project level imports
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
// End of VB project level imports


namespace HBRS
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class frmMain : System.Windows.Forms.Form
	{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

        //Required by the Windows Form Designer
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbarCheckIn = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbarCheckOut = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbarReserve = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbarRoom = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.status = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButton5 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.NewCheckInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.LogoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckedInListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReservedListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckedOutListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.RoomStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DiscountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GuestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.cuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ToolStrip1.SuspendLayout();
            this.status.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbarCheckIn,
            this.ToolStripButton11,
            this.toolbarCheckOut,
            this.ToolStripSeparator6,
            this.toolbarReserve,
            this.ToolStripSeparator7,
            this.toolbarRoom,
            this.ToolStripSeparator8,
            this.ToolStripButton10,
            this.ToolStripSeparator9,
            this.ToolStripButton12,
            this.ToolStripSeparator10,
            this.ToolStripButton13});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 24);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(974, 39);
            this.ToolStrip1.TabIndex = 14;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // toolbarCheckIn
            // 
            this.toolbarCheckIn.Image = ((System.Drawing.Image)(resources.GetObject("toolbarCheckIn.Image")));
            this.toolbarCheckIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarCheckIn.Name = "toolbarCheckIn";
            this.toolbarCheckIn.Size = new System.Drawing.Size(86, 36);
            this.toolbarCheckIn.Text = "Registro";
            this.toolbarCheckIn.ToolTipText = "Registro y listado de Entrada (Checkin)";
            this.toolbarCheckIn.Click += new System.EventHandler(this.toolbarCheckIn_Click);
            // 
            // ToolStripButton11
            // 
            this.ToolStripButton11.Name = "ToolStripButton11";
            this.ToolStripButton11.Size = new System.Drawing.Size(6, 39);
            // 
            // toolbarCheckOut
            // 
            this.toolbarCheckOut.Image = ((System.Drawing.Image)(resources.GetObject("toolbarCheckOut.Image")));
            this.toolbarCheckOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarCheckOut.Name = "toolbarCheckOut";
            this.toolbarCheckOut.Size = new System.Drawing.Size(74, 36);
            this.toolbarCheckOut.Text = "Salida";
            this.toolbarCheckOut.ToolTipText = "Registro de Salida (Checkout)";
            this.toolbarCheckOut.Click += new System.EventHandler(this.toolbarCheckOut_Click);
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // toolbarReserve
            // 
            this.toolbarReserve.Image = ((System.Drawing.Image)(resources.GetObject("toolbarReserve.Image")));
            this.toolbarReserve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarReserve.Name = "toolbarReserve";
            this.toolbarReserve.Size = new System.Drawing.Size(106, 36);
            this.toolbarReserve.Text = "Reservaci�n";
            this.toolbarReserve.ToolTipText = "Registro y listado de Reservaciones";
            this.toolbarReserve.Click += new System.EventHandler(this.toolbarReserve_Click);
            // 
            // ToolStripSeparator7
            // 
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // toolbarRoom
            // 
            this.toolbarRoom.Image = ((System.Drawing.Image)(resources.GetObject("toolbarRoom.Image")));
            this.toolbarRoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarRoom.Name = "toolbarRoom";
            this.toolbarRoom.Size = new System.Drawing.Size(112, 36);
            this.toolbarRoom.Text = "Habitaciones";
            this.toolbarRoom.ToolTipText = "Registro y listado de Habitaciones";
            this.toolbarRoom.Click += new System.EventHandler(this.toolbarRoom_Click);
            // 
            // ToolStripSeparator8
            // 
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            this.ToolStripSeparator8.Size = new System.Drawing.Size(6, 39);
            // 
            // ToolStripButton10
            // 
            this.ToolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton10.Image")));
            this.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton10.Name = "ToolStripButton10";
            this.ToolStripButton10.Size = new System.Drawing.Size(91, 36);
            this.ToolStripButton10.Text = "Invitados";
            this.ToolStripButton10.ToolTipText = "Registro y listado de Invitados";
            this.ToolStripButton10.Click += new System.EventHandler(this.ToolStripButton10_Click);
            // 
            // ToolStripSeparator9
            // 
            this.ToolStripSeparator9.Name = "ToolStripSeparator9";
            this.ToolStripSeparator9.Size = new System.Drawing.Size(6, 39);
            // 
            // ToolStripButton12
            // 
            this.ToolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton12.Image")));
            this.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton12.Name = "ToolStripButton12";
            this.ToolStripButton12.Size = new System.Drawing.Size(111, 36);
            this.ToolStripButton12.Text = "Cerrar sesi�n";
            this.ToolStripButton12.ToolTipText = "Cerrar la sesi�n actual";
            this.ToolStripButton12.Click += new System.EventHandler(this.ToolStripButton12_Click);
            // 
            // ToolStripSeparator10
            // 
            this.ToolStripSeparator10.Name = "ToolStripSeparator10";
            this.ToolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // ToolStripButton13
            // 
            this.ToolStripButton13.Image = global::My.Resources.Resources.exit_icon_3;
            this.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton13.Name = "ToolStripButton13";
            this.ToolStripButton13.Size = new System.Drawing.Size(65, 36);
            this.ToolStripButton13.Text = "Salir";
            this.ToolStripButton13.ToolTipText = "Salir del Sistema Hotel Para�so";
            this.ToolStripButton13.Click += new System.EventHandler(this.ToolStripButton13_Click);
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel4,
            this.ToolStripStatusLabel5,
            this.ToolStripStatusLabel6});
            this.status.Location = new System.Drawing.Point(0, 616);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(974, 24);
            this.status.TabIndex = 15;
            this.status.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel4
            // 
            this.ToolStripStatusLabel4.AutoSize = false;
            this.ToolStripStatusLabel4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ToolStripStatusLabel4.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            this.ToolStripStatusLabel4.Size = new System.Drawing.Size(319, 19);
            this.ToolStripStatusLabel4.Spring = true;
            this.ToolStripStatusLabel4.Text = "Logueado como  :";
            // 
            // ToolStripStatusLabel5
            // 
            this.ToolStripStatusLabel5.AutoSize = false;
            this.ToolStripStatusLabel5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
            this.ToolStripStatusLabel5.Size = new System.Drawing.Size(319, 19);
            this.ToolStripStatusLabel5.Spring = true;
            this.ToolStripStatusLabel5.Text = "Sistema Hotel Para�so";
            // 
            // ToolStripStatusLabel6
            // 
            this.ToolStripStatusLabel6.AutoSize = false;
            this.ToolStripStatusLabel6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ToolStripStatusLabel6.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6";
            this.ToolStripStatusLabel6.Size = new System.Drawing.Size(319, 19);
            this.ToolStripStatusLabel6.Spring = true;
            this.ToolStripStatusLabel6.Text = "Fecha y Hora :";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(331, 19);
            this.ToolStripStatusLabel1.Spring = true;
            this.ToolStripStatusLabel1.Text = "Login as";
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(331, 19);
            this.ToolStripStatusLabel2.Spring = true;
            this.ToolStripStatusLabel2.Text = "Hotel Billing and Reservation System v. 1";
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(331, 19);
            this.ToolStripStatusLabel3.Spring = true;
            this.ToolStripStatusLabel3.Text = "Today is: ";
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripButton5
            // 
            this.ToolStripButton5.Name = "ToolStripButton5";
            this.ToolStripButton5.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem1,
            this.SettingsToolStripMenuItem,
            this.SettingsToolStripMenuItem1});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(974, 24);
            this.MenuStrip1.TabIndex = 16;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem1
            // 
            this.FileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewCheckInToolStripMenuItem,
            this.NewReservationToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.LogoutToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1";
            this.FileToolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.FileToolStripMenuItem1.Text = "&Archivo";
            // 
            // NewCheckInToolStripMenuItem
            // 
            this.NewCheckInToolStripMenuItem.Name = "NewCheckInToolStripMenuItem";
            this.NewCheckInToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.NewCheckInToolStripMenuItem.Text = "Nuevo Registro";
            this.NewCheckInToolStripMenuItem.Click += new System.EventHandler(this.NewCheckInToolStripMenuItem_Click);
            // 
            // NewReservationToolStripMenuItem
            // 
            this.NewReservationToolStripMenuItem.Name = "NewReservationToolStripMenuItem";
            this.NewReservationToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.NewReservationToolStripMenuItem.Text = "Nueva Reservaci�n";
            this.NewReservationToolStripMenuItem.Click += new System.EventHandler(this.NewReservationToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(171, 6);
            // 
            // LogoutToolStripMenuItem
            // 
            this.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem";
            this.LogoutToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.LogoutToolStripMenuItem.Text = "Cerrar Sesi�n";
            this.LogoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ExitToolStripMenuItem.Text = "Salir";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckedInListToolStripMenuItem,
            this.ReservedListToolStripMenuItem,
            this.CheckedOutListToolStripMenuItem,
            this.ToolStripMenuItem2,
            this.RoomStatusToolStripMenuItem});
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.SettingsToolStripMenuItem.Text = "&Monitoreo";
            // 
            // CheckedInListToolStripMenuItem
            // 
            this.CheckedInListToolStripMenuItem.Name = "CheckedInListToolStripMenuItem";
            this.CheckedInListToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.CheckedInListToolStripMenuItem.Text = "Lista de Re&gistrados";
            this.CheckedInListToolStripMenuItem.Click += new System.EventHandler(this.CheckedInListToolStripMenuItem_Click);
            // 
            // ReservedListToolStripMenuItem
            // 
            this.ReservedListToolStripMenuItem.Name = "ReservedListToolStripMenuItem";
            this.ReservedListToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.ReservedListToolStripMenuItem.Text = "Lista de &Reservados";
            this.ReservedListToolStripMenuItem.Click += new System.EventHandler(this.ReservedListToolStripMenuItem_Click);
            // 
            // CheckedOutListToolStripMenuItem
            // 
            this.CheckedOutListToolStripMenuItem.Name = "CheckedOutListToolStripMenuItem";
            this.CheckedOutListToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.CheckedOutListToolStripMenuItem.Text = "Lista de &Salidas";
            this.CheckedOutListToolStripMenuItem.Click += new System.EventHandler(this.CheckedOutListToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(211, 6);
            // 
            // RoomStatusToolStripMenuItem
            // 
            this.RoomStatusToolStripMenuItem.Name = "RoomStatusToolStripMenuItem";
            this.RoomStatusToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.RoomStatusToolStripMenuItem.Text = "&Estado de las &Habitaciones";
            this.RoomStatusToolStripMenuItem.Click += new System.EventHandler(this.RoomStatusToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem1
            // 
            this.SettingsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DiscountToolStripMenuItem,
            this.RoomToolStripMenuItem,
            this.GuestToolStripMenuItem,
            this.toolStripSeparator11,
            this.cuentasToolStripMenuItem});
            this.SettingsToolStripMenuItem1.Name = "SettingsToolStripMenuItem1";
            this.SettingsToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.SettingsToolStripMenuItem1.Text = "&Ajustes";
            // 
            // DiscountToolStripMenuItem
            // 
            this.DiscountToolStripMenuItem.Name = "DiscountToolStripMenuItem";
            this.DiscountToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.DiscountToolStripMenuItem.Text = "&Descuentos";
            this.DiscountToolStripMenuItem.Click += new System.EventHandler(this.DiscountToolStripMenuItem_Click);
            // 
            // RoomToolStripMenuItem
            // 
            this.RoomToolStripMenuItem.Name = "RoomToolStripMenuItem";
            this.RoomToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.RoomToolStripMenuItem.Text = "&Habitaciones";
            this.RoomToolStripMenuItem.Click += new System.EventHandler(this.RoomToolStripMenuItem_Click);
            // 
            // GuestToolStripMenuItem
            // 
            this.GuestToolStripMenuItem.Name = "GuestToolStripMenuItem";
            this.GuestToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.GuestToolStripMenuItem.Text = "&Invitados";
            this.GuestToolStripMenuItem.Click += new System.EventHandler(this.GuestToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(173, 6);
            // 
            // cuentasToolStripMenuItem
            // 
            this.cuentasToolStripMenuItem.Name = "cuentasToolStripMenuItem";
            this.cuentasToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.cuentasToolStripMenuItem.Text = "Cuentas de Usuario";
            this.cuentasToolStripMenuItem.Click += new System.EventHandler(this.cuentasToolStripMenuItem_Click);
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 86);
            this.label1.TabIndex = 17;
            this.label1.Text = "Hotel Para�so";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 48);
            this.label2.TabIndex = 18;
            this.label2.Text = "�Para usted, se hizo!";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = global::My.Resources.Resources.FreeVector_Seaside_Hotel_Vector;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(974, 640);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.MenuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Hotel Para�so - Pantalla Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		internal System.Windows.Forms.ToolStrip ToolStrip1;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
		internal System.Windows.Forms.StatusStrip status;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel2;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
		internal System.Windows.Forms.ToolStripSeparator ToolStripButton5;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
		internal System.Windows.Forms.ToolStripButton toolbarCheckIn;
		internal System.Windows.Forms.ToolStripSeparator ToolStripButton11;
		internal System.Windows.Forms.ToolStripButton toolbarCheckOut;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
		internal System.Windows.Forms.ToolStripButton toolbarReserve;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator7;
		internal System.Windows.Forms.ToolStripButton toolbarRoom;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator8;
		internal System.Windows.Forms.ToolStripButton ToolStripButton10;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator9;
		internal System.Windows.Forms.ToolStripButton ToolStripButton12;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator10;
		internal System.Windows.Forms.ToolStripButton ToolStripButton13;
		internal System.Windows.Forms.MenuStrip MenuStrip1;
		internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem NewCheckInToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem NewReservationToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem LogoutToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
		internal System.Windows.Forms.Timer Timer1;
		internal System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem CheckedInListToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem ReservedListToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem CheckedOutListToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
		internal System.Windows.Forms.ToolStripMenuItem RoomStatusToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem DiscountToolStripMenuItem;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel4;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel5;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel6;
		internal System.Windows.Forms.ToolStripMenuItem RoomToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem GuestToolStripMenuItem;
        private System.ComponentModel.IContainer components;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem cuentasToolStripMenuItem;
        private Label label1;
        private Label label2;
		
	}
	
}
