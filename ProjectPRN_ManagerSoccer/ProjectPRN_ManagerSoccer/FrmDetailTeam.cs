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
    public partial class FrmDetailTeam : Form
    {
        Account account;
        Team team;
        bool fromSearch;
        public FrmDetailTeam(Team t,Account acc)
        {
            this.account = acc;
            this.team = t;
            InitializeComponent();
            LoadDataTeam();
        }
        public FrmDetailTeam(Team t,Account acc,bool se)
        {
            this.account = acc;
            this.team = t;
            this.fromSearch = se;
            InitializeComponent();
            LoadDataTeam();
        }

        private void LoadDataTeam()
        {
            try
            {
                txtName.Text = team.name;              
                txtCountry.Text = team.region;
                txtMoney.Text=team.monney.ToString();
                string url = "/Resources/" + team.logo;
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

        private void FrmDetailTeam_Load(object sender, EventArgs e)
        {

        }
    }
}
