using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HBRS;

namespace HotelParaiso
{
    public partial class FrmAccesoAdministrativo : Form
    {
        public FrmAccesoAdministrativo()
        {
            InitializeComponent();
        }

        private void btnAccesar_Click(object sender, EventArgs e)
        {
            if (txtUsuarioAdm.Text == "admin" && txtContraAdm.Text == "admin")
            {
                this.Hide();
                this.Close();
                FrmUsuarios abrir = new FrmUsuarios();
                abrir.ShowDialog();
            }
        }

        private void FrmAccesoAdministrativo_Load(object sender, EventArgs e)
        {
            btnAccesar.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //borde transparente del botón
        }
    }
}
