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
using System.IO;

namespace ProjectPRN_ManagerSoccer
{
    public partial class FrmUpdatePlayer : Form
    {
        Account account;
        Player player;
        public FrmUpdatePlayer(Player player, Account acc)
        {
            this.account = acc;
            this.player = player;
            InitializeComponent();
            LoadDataPlayer();
            LoadDataComboBox();
        }
        void LoadDataPlayer()
        {
            txtName.Text = player.name;
            cbCountry.SelectedValue = player.region;
            cbPosition.SelectedValue = player.position;
            dtDateOfBirth.Value = player.dob;
            numPhysical.Value = (decimal)player.physical;
            numAttacking.Value = (decimal)player.attacking;
            numDefeding.Value = (decimal)player.defending;
            numSpeed.Value = (decimal)player.speed;
            tbAddURL.Text = player.image;
            string url = "/Resources/" + player.image;
            string path = url.Replace('/', '\\');
            picbImage.Image = Image.FromFile(getProjectPath() + path);

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int TeamID = account.TeamID;
            string name = txtName.Text;
            DateTime DOB = dtDateOfBirth.Value;
            string Region = cbCountry.Text;
            string Position = cbPosition.Text;
            string isMain = player.isMain.ToString();
            int numPhi = (int)numPhysical.Value;
            int numSp = (int)numSpeed.Value;
            int numAtk = (int)numAttacking.Value;
            int numDef = (int)numDefeding.Value;
            string img = tbAddURL.Text;

            if (txtName.Text == "")
            {
                MessageBox.Show("Fill all information!");
            }

            else
            {
                if ((new BUSPlayer()).EditPlayer(player.id, name, Region, DOB, TeamID, Position, numPhi, numAtk, numDef, numSp, img, isMain))
                {
                    MessageBox.Show("Edit Player thành công!");
                    FrmManagePlayers fm = new FrmManagePlayers(account);
                    fm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi!");
                }
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
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = getProjectPath() + "\\Resources\\",
                Title = "Select image file",
                Filter = "Gif files (*.gif)|*.gif| Png files (*.png)|*.png",
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

        private void FrmUpdatePlayer_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmManagePlayers fm = new FrmManagePlayers(account);
            fm.Show();
            this.Hide();
        }
    }
}
