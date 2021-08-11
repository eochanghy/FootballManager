using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace ProjectPRN_ManagerSoccer
{
    public partial class FrmTeam : Form
    {
        Account account;
        public FrmTeam(Account acc)
        {
            this.account = acc;
            InitializeComponent();
        }

        private void FrmTeam_Load(object sender, EventArgs e)
        {
            Account acc2 = (new BUSUser()).getAccwithouTeamID(account.UserName, account.Password);
            Console.WriteLine("id cua acc2: "+acc2.UserID);
            account.UserID = acc2.UserID;
            account.TeamID = acc2.UserID;
        }
        private bool checkInput()
        {
            if(txtName.Text.Trim()=="")
            {
                MessageBox.Show("Please enter team name..");
                return false;
            }
            if (txtMoney.Text.Trim() == "")
            {
                MessageBox.Show("Please enter team money..");
                return false;
            }
            if (txtImage.Text.Trim() == "")
            {
                MessageBox.Show("Please upload image..");
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                if((new BUSRegister()).updateTeamID(account)&& (new BUSRegister()).CreateTeam(txtName.Text, cbxRegion.SelectedItem.ToString(), txtImage.Text, txtMoney.Text))
                {    
                        MessageBox.Show("Create team succes, let's add player..");
                        FrmAddPlayer add = new FrmAddPlayer(account, true);
                        add.Show();
                        this.Hide();
                }
                else
                {
                    MessageBox.Show("Khong thanh cong");
                }
                
            }
        }
        private string getProjectPath()
        {
            string path = Application.StartupPath;
            DirectoryInfo di = new DirectoryInfo(path);
            for (int i = 0; i < 2; i++)
            {
                di = Directory.GetParent(di.FullName);
            }
            return di.FullName;
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = getProjectPath() + "\\Resources\\",
                Title = "Select image file",
                Filter = "Jpg files (*.jpg)|*.jpg| Gif files (*.gif)|*.gif| Png files (*.png)|*.png",
                FilterIndex = 1,
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string ext = openFileDialog.FileName.Substring(openFileDialog.FileName.IndexOf('.'));
                string filename = Guid.NewGuid().ToString() + ext;
                string fileDest = getProjectPath() + "\\Resources\\" + filename;
                File.Copy(openFileDialog.FileName, fileDest);
                txtImage.Text = filename;
                string url = "/Resources/" + filename;
                string path = url.Replace('/', '\\');
                ptImage.Image = Image.FromFile(getProjectPath() + path);
            }
        }

        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtMoney.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 45)
            {
                e.Handled = true;
            }
        }
    }
}
