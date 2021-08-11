using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;

namespace ProjectPRN_ManagerSoccer
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Account acc = (new BUSUser()).checkUser(txtAccount.Text, txtPass.Text);
            if (acc != null)
            {
                MessageBox.Show("Login success..");
                FrmHome f = new FrmHome(acc);
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login fail..");
                txtAccount.Text = "";
                txtPass.Text = "";
            }
        }

        private void lbCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegister obj = new FrmRegister();
            obj.Show();
            this.Hide();
        }

        
        private void btnContact_Click(object sender, EventArgs e)
        {
            FrmContact f = new FrmContact();
            f.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("do you want to exit?", "Aleart", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmForgot fg = new FrmForgot();
            fg.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }
    }
}
