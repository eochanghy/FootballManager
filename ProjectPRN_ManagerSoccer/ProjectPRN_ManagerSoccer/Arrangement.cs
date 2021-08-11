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
    public partial class Arrangement : Form
    {
        Account account;
        public Arrangement(Account acc)
        {
            this.account = acc;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        MainPlayer topPlayer = new MainPlayer();
        private void Arrangement_Load(object sender, EventArgs e)
        {
            loadMainPlayer();
            loadSubPlayer();
        }
        public void loadMainPlayer()
        {
            List<MPlayer> mPlayer = (new BUSArrangement()).getAllPlayerLocation(account.TeamID);
            if(mPlayer.Count != 0)
            {
                foreach (MPlayer mp in mPlayer)
                {
                    MainPlayer playerUC = new MainPlayer();
                    playerUC.playerID = mp.playerID;
                    playerUC.image = mp.image;
                    playerUC.Location = new Point(mp.playerX, mp.playerY);
                    playerUC.lblName.Text = mp.playerName;
                    string tPath = "/Resources/" + mp.image;
                    string path = tPath.Replace('/', '\\');
                    playerUC.BackgroundImage = Image.FromFile(getProjectPath() + path);
                    ControlExtension.Draggable(playerUC, true);
                    playerUC.MouseUp += PlayerUC_MouseUp;
                    playerUC.MouseDown += PlayerUC_MouseDown;
                    playerUC.LocationChanged += PlayerUC_LocationChanged;
                    playerUC.DoubleClick += PlayerUC_DoubleClick;
                    panel1.Controls.Add(playerUC);
                }
            }
            else
            {
                Console.WriteLine("asdasdasd");
                Random r = new Random();
                List<Player> listP = (new BUSArrangement()).getIsMainPlayer(account.TeamID);
                foreach (Player p in listP)
                {
                    MainPlayer playerUC = new MainPlayer();
                    playerUC.playerID = p.id;
                    playerUC.image = p.image;
                    playerUC.Location = new Point(r.Next(1, 800), r.Next(1, 500));
                    playerUC.lblName.Text = p.name;
                    string tPath = "/Resources/" + p.image;
                    string path = tPath.Replace('/', '\\');
                    playerUC.BackgroundImage = Image.FromFile(getProjectPath() + path);
                    ControlExtension.Draggable(playerUC, true);
                    playerUC.MouseUp += PlayerUC_MouseUp;
                    playerUC.MouseDown += PlayerUC_MouseDown;
                    playerUC.LocationChanged += PlayerUC_LocationChanged;
                    playerUC.DoubleClick += PlayerUC_DoubleClick;
                    panel1.Controls.Add(playerUC);
                }
            }
            
        }
        public void loadSubPlayer()
        {
            List<SPlayer> listS = (new BUSArrangement()).getSubPlayer(account.TeamID);
            foreach (SPlayer sp in listS)
            {
                SubPlayer subPlayer = new SubPlayer();
                subPlayer.playerID = sp.playerId;
                subPlayer.image = sp.image;
                string tPath = "/Resources/" + sp.image;
                string path = tPath.Replace('/', '\\');
                subPlayer.ptImage.Image = Image.FromFile(getProjectPath() + path);
                subPlayer.txtName.Text = sp.playerName;
                subPlayer.btnCancel.Click += BtnCancel_Click;
                subPlayer.btnSwap.Click += BtnSwap_Click;
                panelSub.Controls.Add(subPlayer);
            }
        }

        private void BtnSwap_Click(object sender, EventArgs e)
        {
            spSwap = (SubPlayer)((Button)sender).Parent;
            foreach (SubPlayer item in panelSub.Controls)
            {
                item.btnSwap.Visible = false;
                item.btnCancel.Visible = false;

            }
            mpSwap.lblName.ForeColor = Color.Black;
            swapCheck = false;

            int spIDSwap = spSwap.playerID;
            string spNameSwap = spSwap.txtName.Text;
            string spImageSwap = spSwap.image;
            //set for spSwap
            spSwap.playerID = mpSwap.playerID;
            spSwap.txtName.Text = mpSwap.lblName.Text;
            spSwap.image = mpSwap.image;
            string tPath = "/Resources/" + spSwap.image;
            string path = tPath.Replace('/', '\\');
            spSwap.ptImage.Image = Image.FromFile(getProjectPath() + path);
            //set for mpSwap
            mpSwap.playerID = spIDSwap;
            mpSwap.lblName.Text = spNameSwap;
            mpSwap.image = spImageSwap;
            string prePath = "/Resources/" + mpSwap.image;
            string mPath = prePath.Replace('/', '\\');
            mpSwap.BackgroundImage = Image.FromFile(getProjectPath() + mPath);

            mpSwap = null;
            spSwap = null;


        }

        bool swapCheck = false;
        MainPlayer mpSwap;
        SubPlayer spSwap;
        private void BtnCancel_Click(object sender, EventArgs e)
        {     
                mpSwap.lblName.ForeColor = Color.Black;
                foreach (SubPlayer item in panelSub.Controls)
                {
                    item.btnSwap.Visible = false;
                    item.btnCancel.Visible = false;

                }
                swapCheck = false;
            mpSwap = null;
            
        }
        
        private void PlayerUC_DoubleClick(object sender, EventArgs e)
        {
            
            if (!swapCheck)
            {
                mpSwap = (MainPlayer)sender;
                mpSwap.lblName.ForeColor = Color.Red;
                foreach (SubPlayer item in panelSub.Controls)
                {
                    item.btnSwap.Visible = true;
                    item.btnCancel.Visible = true;

                }
                swapCheck = true;
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

        private void PlayerUC_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void PlayerUC_LocationChanged(object sender, EventArgs e)
        {
            MainPlayer playerUC = (MainPlayer)sender;
            if(playerUC.Left < 0)
            {
                playerUC.Left = 0;
            }
            if(playerUC.Top < 0)
            {
                playerUC.Top = 0;
            }
            if(playerUC.Bottom > panel1.Height)
            {
                playerUC.Top = panel1.Height - playerUC.Height;
            }
            if(playerUC.Right > panel1.Width)
            {
                playerUC.Left = panel1.Width - playerUC.Width;
            }
        }

        private void PlayerUC_MouseUp(object sender, MouseEventArgs e)
        {
            MainPlayer uc = (MainPlayer)sender;
            //insert new location to database
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BUSArrangement ba = new BUSArrangement();
                ba.deletePostion(account.TeamID);
                foreach (MainPlayer mp in panel1.Controls)
                {
                    ba.updateIsMain(mp.playerID, 1);               
                    ba.insertLocation(mp.playerID, mp.Location.X, mp.Location.Y, 1);
                }
                foreach (SubPlayer sp in panelSub.Controls)
                {
                    ba.updateIsMain(sp.playerID, 0);
                }
                MessageBox.Show("Save success...");
            }
            catch (Exception)
            {

                MessageBox.Show("Save loi..");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHome f = new FrmHome(account);
            f.Show();
            this.Hide();
        }
    }
}
