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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ProjectPRN_ManagerSoccer
{
    public partial class FrmManagePlayers : Form
    {
        Account account;
        Player player;
        public FrmManagePlayers(Account acc)
        {
            player = new Player();
            this.account = acc;
            InitializeComponent();
            AddButtonDetailColumn();
            LoadPlayers();

        }

        private void AddButtonDetailColumn()
        {
            DataGridViewButtonColumn colDetail = new DataGridViewButtonColumn();
            colDetail.Name = "Detail";
            colDetail.HeaderText = "Detail";
            colDetail.Text = "Detail";
            colDetail.UseColumnTextForButtonValue = true;
            dgPlayer.Columns.Add(colDetail);
        }

        private void FrmManagePlayers_Load(object sender, EventArgs e)
        {
            player.id = 0;
        }

        void LoadPlayers()
        {          
            dgPlayer.DataSource = (new BUSPlayer()).loadPlayer(account.TeamID);
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            FrmAddPlayer add = new FrmAddPlayer(account);
            add.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmHome fh = new FrmHome(account);
            fh.Show();
            this.Hide();
        }

        private void FrmManagePlayers_Activated(object sender, EventArgs e)
        {
            LoadPlayers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (player.id == 0)
            {
                MessageBox.Show("Hãy chọn 1 cầu thủ bạn muốn xóa!");
            }
            else
            {
                if ((new BUSPlayer()).CheckMain(player.id))
                {
                    MessageBox.Show("Không thể xóa cầu thủ chính!");
                }
                else
                {
                    if ((new BUSPlayer()).DeletePlayer(player.id))
                    {
                        MessageBox.Show("Xóa Player thành công!");
                        player.id = 0;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi xóa Player!");
                    }
                }
                
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (player.id == 0)
            {
                MessageBox.Show("Hãy chọn 1 cầu thủ bạn muốn sửa thông tin!");
            }
            else
            {
                FrmUpdatePlayer fu = new FrmUpdatePlayer(player, account);
                fu.Show();
                this.Hide();

            }
        }

        private void dgPlayer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == -1)
            {
                int numrow = e.RowIndex;
                DataGridViewRow dataGridViewRow = dgPlayer.Rows[numrow];
                string sPlayerID = dataGridViewRow.Cells[1].Value.ToString();
                player.id = Convert.ToInt32(dataGridViewRow.Cells[1].Value.ToString());
                player.name = dataGridViewRow.Cells[2].Value.ToString();
                player.region = dataGridViewRow.Cells[3].Value.ToString();
                player.dob = Convert.ToDateTime(dataGridViewRow.Cells[4].Value.ToString());
                player.teamID = account.TeamID;
                player.position = dataGridViewRow.Cells[6].Value.ToString();
                player.physical = Convert.ToInt32(dataGridViewRow.Cells[7].Value.ToString());
                player.attacking = Convert.ToInt32(dataGridViewRow.Cells[8].Value.ToString());
                player.defending = Convert.ToInt32(dataGridViewRow.Cells[9].Value.ToString());
                player.speed = Convert.ToInt32(dataGridViewRow.Cells[10].Value.ToString());
                player.image = dataGridViewRow.Cells[11].Value.ToString();
                player.isMain = Convert.ToBoolean(dataGridViewRow.Cells[12].Value.ToString());

            }
            else if(dgPlayer.Columns[e.ColumnIndex].Name == "Detail")
            {
                int numrow = e.RowIndex;
                DataGridViewRow dataGridViewRow = dgPlayer.Rows[numrow];
                string sPlayerID = dataGridViewRow.Cells[1].Value.ToString();
                player.id = Convert.ToInt32(dataGridViewRow.Cells[1].Value.ToString());
                player.name = dataGridViewRow.Cells[2].Value.ToString();
                player.region = dataGridViewRow.Cells[3].Value.ToString();
                player.dob = Convert.ToDateTime(dataGridViewRow.Cells[4].Value.ToString());
                player.teamID = account.TeamID;
                player.position = dataGridViewRow.Cells[6].Value.ToString();
                player.physical = Convert.ToInt32(dataGridViewRow.Cells[7].Value.ToString());
                player.attacking = Convert.ToInt32(dataGridViewRow.Cells[8].Value.ToString());
                player.defending = Convert.ToInt32(dataGridViewRow.Cells[9].Value.ToString());
                player.speed = Convert.ToInt32(dataGridViewRow.Cells[10].Value.ToString());
                player.image = dataGridViewRow.Cells[11].Value.ToString();
                player.isMain = Convert.ToBoolean(dataGridViewRow.Cells[12].Value.ToString());

                FrmDetailPlayer d = new FrmDetailPlayer(player, account);
                d.Show();
                this.Hide();
            }
            else
            {
                int numrow = e.RowIndex;
                DataGridViewRow dataGridViewRow = dgPlayer.Rows[numrow];
                string sPlayerID = dataGridViewRow.Cells[1].Value.ToString();
                player.id = Convert.ToInt32(dataGridViewRow.Cells[1].Value.ToString());
                player.name = dataGridViewRow.Cells[2].Value.ToString();
                player.region = dataGridViewRow.Cells[3].Value.ToString();
                player.dob = Convert.ToDateTime(dataGridViewRow.Cells[4].Value.ToString());
                player.teamID = account.TeamID;
                player.position = dataGridViewRow.Cells[6].Value.ToString();
                player.physical = Convert.ToInt32(dataGridViewRow.Cells[7].Value.ToString());
                player.attacking = Convert.ToInt32(dataGridViewRow.Cells[8].Value.ToString());
                player.defending = Convert.ToInt32(dataGridViewRow.Cells[9].Value.ToString());
                player.speed = Convert.ToInt32(dataGridViewRow.Cells[10].Value.ToString());
                player.image = dataGridViewRow.Cells[11].Value.ToString();
                player.isMain = Convert.ToBoolean(dataGridViewRow.Cells[12].Value.ToString());

            }

        }

        private void dgPlayer_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
