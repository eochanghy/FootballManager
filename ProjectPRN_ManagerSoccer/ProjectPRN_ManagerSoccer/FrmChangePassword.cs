using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace ProjectPRN_ManagerSoccer
{
    public partial class FrmChangePassword : Form
    {
        String userName;
        public FrmChangePassword(string un)
        {
            this.userName = un;
            InitializeComponent();
        }
        public bool checkInput()
        { 
            if(txtNewPass.Text == "" || txtRePass.Text == "")
            {
                MessageBox.Show("Please enter password..");
                return false;
            }
            if (!txtNewPass.Text.Equals(txtRePass.Text))
            {
                MessageBox.Show("Wrong re-pass..");
                return false;
            }
            return true;
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                if((new BUSForgot()).updatePassword(userName, txtNewPass.Text))
                {
                    MessageBox.Show("Update password success..");
                    FrmLogin f = new FrmLogin();
                    f.Show();
                    this.Hide();
                }
            }
        }
    }

}

