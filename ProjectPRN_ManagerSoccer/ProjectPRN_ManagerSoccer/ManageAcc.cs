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
    public partial class ManageAcc : Form
    {
        Account account;
        public ManageAcc(Account acc)
        {
            this.account = (new BUSUser()).checkUser(acc.UserName, acc.Password);
            InitializeComponent();
            
        }
        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (txtAns.Text == "")
            {
                MessageBox.Show("Please input Answers");
            }
            else
            {
                if (txtPhone.Text == "")
                {
                    MessageBox.Show("Please input phone..");
                }
                else
                {
                    if (txtEmail.Text == "")
                    {
                        MessageBox.Show("Please input email..");
                    }
                    else
                    {
                        if((new BUSManageAcc()).updateAcc(txtPassword.Text, txtPhone.Text, txtEmail.Text, cbQues.SelectedItem.ToString(), txtAns.Text, account.UserID))
                        {
                            account.Password = txtPassword.Text;
                            account.Phone = txtPhone.Text;
                            account.Email = txtEmail.Text;
                            account.PrivateQuesion = cbQues.Text;
                            account.Answer = txtAns.Text;
                            MessageBox.Show("Update success..");
                            FrmHome f = new FrmHome(account);
                            f.Show();
                            this.Hide();
                        }
                    }
                }
            }
            
            

        }


        

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmHome f = new FrmHome(account);
            f.Show();
            this.Hide();
        }

        private void ManageAcc_Load(object sender, EventArgs e)
        {
            txtPassword.Text = account.Password;
            cbQues.SelectedItem = account.PrivateQuesion;
            txtAns.Text = account.Answer;
            txtPhone.Text = account.Phone;
            txtEmail.Text = account.Email;
        }
    }
}
