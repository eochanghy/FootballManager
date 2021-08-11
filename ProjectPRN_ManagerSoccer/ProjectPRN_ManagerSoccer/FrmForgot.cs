using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using DAO;

namespace ProjectPRN_ManagerSoccer
{
    public partial class FrmForgot : Form
    {
        public FrmForgot()
        {
            InitializeComponent();
            
        }
        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                if (checkCorrect())
                {
                    MessageBox.Show("All information is correct, you can change password..");
                    FrmChangePassword f = new FrmChangePassword(txtUser.Text);
                    f.Show();
                    this.Hide();
                }
            }
        }
        public bool checkInput()
        {
            if(txtUser.Text == "")
            {
                MessageBox.Show("Please enter user name..");
                return false;
            }
            if(!(new BUSForgot()).checkExistUSerName(txtUser.Text))
            {
                MessageBox.Show("This user name is not exist..");
                return false;
            }
            if(txtAns.Text == "")
            {
                MessageBox.Show("Please enter Answer..");
                return false;
            }
            if(txtPhone.Text == "")
            {
                MessageBox.Show("Please enter Phone..");
                return false;
            }
            if(txtEmail.Text == "")
            {
                MessageBox.Show("Please enter Email..");
                return false;
            }
            return true;
        }
        public bool checkCorrect()
        {
            Account acc = (new BUSForgot()).getAccByUserName(txtUser.Text);
            if (!cbQues.SelectedItem.ToString().Equals(acc.PrivateQuesion))
            {
                MessageBox.Show("Wrong question..");
                return false;
            }
            if (!txtAns.Text.Equals(acc.Answer))
            {
                MessageBox.Show("Wrong answer..");
                return false;
            }
            if (!txtPhone.Text.Equals(acc.Phone))
            {
                MessageBox.Show("Wrong phone..");
                return false;
            }
            if (!txtEmail.Text.Equals(acc.Email))
            {
                MessageBox.Show("Wrong email..");
                return false;
            }
            return true;
        }

   



        private void txtAns_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void FrmForgot_Load(object sender, EventArgs e)
        {
            cbQues.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmLogin f = new FrmLogin();
            f.Show();
            this.Hide();
        }
    }
}
