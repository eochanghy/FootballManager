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
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            if (checkInput())
            {
                if((new BUSUser()).checkExistedAcc(txtUser.Text))
                {
                    if((new BUSRegister()).Register(txtUser.Text, txtPass.Text, ttxPhone.Text, txtEmail.Text, cbQues.SelectedItem.ToString(), txtAs.Text))
                    {
                        Account account = new Account(txtUser.Text, txtPass.Text, ttxPhone.Text, txtEmail.Text, cbQues.SelectedItem.ToString(), txtAs.Text);
                        MessageBox.Show("Register success..");
                        MessageBox.Show("Please insert Football Team..");
                        FrmTeam t = new FrmTeam(account);
                        
                        t.Show();
                        this.Hide();
                    }
                    
                }
                else
                {
                    MessageBox.Show("This user name is existed..");
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
            if (txtPass.Text == "")
            {
                MessageBox.Show("Please enter password..");
                return false;
            }
            if (txtAs.Text == "")
            {
                MessageBox.Show("Please enter answer..");
                return false;
            }
            if (ttxPhone.Text == "")
            {
                MessageBox.Show("Please enter phone..");
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please enter email..");
                return false;
            }
            return true;

        }
        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmLogin f = new FrmLogin();
            f.Show();
            this.Close();
        }

        private void txtAs_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            cbQues.SelectedIndex = 0;
        }

        private void ttxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }
    }
}
