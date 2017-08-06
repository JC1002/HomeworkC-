using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data.OleDb;


namespace HBRS
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bDHotelParaisoDataSet.tblUser' Puede moverla o quitarla según sea necesario.
            this.tblUserTableAdapter.Fill(this.bDHotelParaisoDataSet.tblUser);

        }

        private void tblUserBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text != "" || passwordTextBox.Text != "")
            {
                this.Validate();
                this.tblUserBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.bDHotelParaisoDataSet);
                usernameTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
                passwordTextBox.PasswordChar = '•';
            }

            else
            {
                MessageBox.Show("Debe llenar ambos campos", "Algun campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            toolStripButton1.PerformClick();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (usernameTextBox.Enabled == false && passwordTextBox.Enabled == false)
            {
                usernameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                passwordTextBox.PasswordChar = '\0';
            }

            else
            {
                usernameTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
                passwordTextBox.PasswordChar = '•';
            }

            }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {

        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
