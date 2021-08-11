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
using DAO;

namespace ProjectPRN_ManagerSoccer
{
    public partial class FrmAddPlayer : Form
    {
        Account account;
        bool afterRegis;
        int count = 0;
        public FrmAddPlayer(Account acc)
        {
            this.afterRegis = false;
            this.account = acc;
            InitializeComponent();
            LoadDataComboBox();
        }
        public FrmAddPlayer(Account acc, bool ar)
        {
            this.account = acc;
            this.afterRegis = ar;
            InitializeComponent();
            LoadDataComboBox();
        }
        private bool addPlayer(string isMain)
        {
            string name = txtName.Text;
            DateTime DOB = dtDateOfBirth.Value;
            string Region = cbCountry.Text;
            string Position = cbPosition.Text;
            int numPhi = (int)numPhysical.Value;
            int numSp = (int)numSpeed.Value;
            int numAtk = (int)numAttacking.Value;
            int numDef = (int)numDefeding.Value;
            string img = tbAddURL.Text;
            if (txtName.Text == "")
            {
                MessageBox.Show("Fill all information!");
                return false;
            }
            else
            {
                if ((new BUSPlayer()).AddPlayer(name, Region, DOB, account.TeamID, Position, numPhi, numAtk, numDef, numSp, img, isMain))
                {
                    return true;
                    
                }
                else
                {
                    MessageBox.Show("Error..");
                    return false;
                }
            }
        }
        public void reset()
        {
            txtName.Text = "";
            cbCountry.SelectedIndex = 0;
            cbPosition.SelectedIndex = 0;
            numPhysical.Value = 1;
            numAttacking.Value = 1;
            numDefeding.Value = 1;
            numSpeed.Value = 1; 

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!afterRegis)
            {
                if (addPlayer("False"))
                {
                    MessageBox.Show("Add Player sucess!");
                    FrmManagePlayers fm = new FrmManagePlayers(account);
                    fm.Show();
                    this.Hide();
                }

            }
            else
            {
                if (count <= 11)
                {
                    if (addPlayer("True"))
                    {
                        count++;
                        MessageBox.Show("Add success " + count + " player.");
                        reset();
                    }
                }
                else
                {
                    if (addPlayer("False"))
                    {
                        count++;
                        MessageBox.Show("Add success " + count + " player.");
                        reset();
                    }
                    if (count >= 15)
                    {
                        MessageBox.Show("Add complete, you can continue add or click exit to return home...");
                        btnExit.Visible = true;
                    }
                }
            }

        }

        private void picbImage_Click(object sender, EventArgs e)
        {

        }

        private void btnChooseImage_Click(object sender, EventArgs e)
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
                tbAddURL.Text = filename;
                string url = "/Resources/" + filename;
                string path = url.Replace('/', '\\');
                picbImage.Image = Image.FromFile(getProjectPath() + path);
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

        private void FrmAddPlayer_Load(object sender, EventArgs e)
        {
            btnExit.Visible = false;
            if (afterRegis)
            {
                btnBack.Visible = false;
            }
            else
            {
                
                btnBack.Visible = true;
            }
        }

        void LoadDataComboBox()
        {
            //cbCountry.DataSource = (new BUSPlayer()).loadRegion();
            //cbCountry.DisplayMember = "Region";
            //cbCountry.ValueMember = "Region";
            //cbPosition.DataSource = (new BUSPlayer()).loadPositon();
            //cbPosition.DisplayMember = "Position";
            //cbPosition.ValueMember = "Position";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmManagePlayers fm = new FrmManagePlayers(account);
            fm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmHome f = new FrmHome(account);
            f.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
