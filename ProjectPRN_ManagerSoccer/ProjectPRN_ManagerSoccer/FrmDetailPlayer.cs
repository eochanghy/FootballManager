using BUS;
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
using DTO;
namespace ProjectPRN_ManagerSoccer
{
    public partial class FrmDetailPlayer : Form
    {
        Account account;
        Player player;
        bool fromSearch;
        public FrmDetailPlayer(Player p, Account acc)
        {
            this.fromSearch = false;
            this.account = acc;
            this.player = p;
            InitializeComponent();
            LoadDataPlayer();
        }
        public FrmDetailPlayer(Player p, Account acc, bool fr)
        {
            this.fromSearch = fr;
            this.account = acc;
            this.player = p;
            InitializeComponent();
            LoadDataPlayer();
        }

        void LoadDataPlayer()
        {
            try
            {
                txtName.Text = player.name;
                txtDob.Text = player.dob.ToString();
                txtCountry.Text = player.region;
                txtPos.Text = player.position;
                rdMain.Checked = player.isMain;
                txtPhy.Text = player.physical.ToString();
                txtAtt.Text = player.attacking.ToString();
                txtSpeed.Text = player.speed.ToString();
                txtDef.Text = player.defending.ToString();
                string url = "/Resources/" + player.image;
                string path = url.Replace('/', '\\');
                picbImage.Image = Image.FromFile(getProjectPath() + path);
            }
            catch (Exception)
            {

                MessageBox.Show("Not found image..");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!fromSearch)
            {
                FrmManagePlayers fm = new FrmManagePlayers(account);
                fm.Show();
                this.Hide();
            }
            else
            {
                FrmSearch f = new FrmSearch(account);
                f.Show();
                this.Hide();
            }
            
        }

        private void FrmDetailPlayer_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
