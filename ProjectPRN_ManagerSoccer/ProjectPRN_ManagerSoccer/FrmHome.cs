using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPRN_ManagerSoccer
{
    public partial class FrmHome : Form
    {
        Account account;
        public FrmHome(Account acc)
        {
            InitializeComponent();
            this.account = acc;
            
        }
        public FrmHome()
        {
            InitializeComponent();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmSearch f = new FrmSearch(account);
            f.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin fLogin = new FrmLogin();
            fLogin.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmManagePlayers f = new FrmManagePlayers(account);
            f.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmSchedule f = new FrmSchedule(account);
            f.Show();
            this.Hide();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmTransfer f = new FrmTransfer(account);
            f.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Arrangement fa = new Arrangement(account);
            fa.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ManageAcc m = new ManageAcc(account);
            m.Show();
            this.Hide();
        }
    }
}
