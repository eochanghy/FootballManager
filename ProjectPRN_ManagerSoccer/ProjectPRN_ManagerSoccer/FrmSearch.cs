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
    public partial class FrmSearch : Form
    {
        Account account;
        Player p;
        Team t;
        public FrmSearch(Account acc)
        {
            p = new Player();
            t = new Team();
            this.account = acc;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbSearch.SelectedItem == "Team"){
                (new BUSSearch()).SearchTeam(cbSearch.Text, tbSearch.Text);
                dataGridView1.DataSource = (new BUSSearch()).loadDataT(cbSearch.Text, tbSearch.Text);
            }
            if (cbSearch.SelectedItem == "Player")
            {
                (new BUSSearch()).SearchPlayer(cbSearch.Text, tbSearch.Text);
                string region = cbxRegion.SelectedItem.ToString();
                if (cbxRegion.SelectedIndex == 0) region = "";
                string pos = cbPosition.SelectedItem.ToString();
                if (cbPosition.SelectedIndex == 0) pos = "";
                dataGridView1.DataSource = (new BUSSearch()).loadDataP(region, cbSearch.Text, pos, tbSearch.Text);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbSearch.SelectedItem = null;
            tbSearch.Text = "";
            dataGridView1.DataSource = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmHome fh = new FrmHome(account);
            fh.Show();
            this.Hide();
        }


        private void FrmSearch_Load(object sender, EventArgs e)
        {
            cbSearch.SelectedIndex = 0;
            cbPosition.SelectedIndex = 0;
            cbxRegion.SelectedIndex = 0;
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbSearch.SelectedIndex == 1)
            {
                cbxRegion.Visible = true;
                cbPosition.Visible = true;
                Rigion.Visible = true;
                label2.Visible = true;
                dataGridView1.DataSource = null;
            }
            if(cbSearch.SelectedIndex == 0)
            {
                Rigion.Visible = false;
                label2.Visible = false;
                cbxRegion.Visible = false;
                cbPosition.Visible = false;
                dataGridView1.DataSource = null;
            }
        }
        
        private void btnView_Click(object sender, EventArgs e)
        {

            if (cbSearch.SelectedIndex == 1)
            {
                FrmDetailPlayer f = new FrmDetailPlayer(p, account, true);
                f.Show();
                this.Hide();
            }
            else
            {
                FrmDetailTeam Team = new FrmDetailTeam(t, account, true);
                Team.Show();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(cbSearch.SelectedIndex == 1)
            {
                p.id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PlayerID"].FormattedValue.ToString());
                p.name = dataGridView1.Rows[e.RowIndex].Cells["PlayerName"].FormattedValue.ToString();
                p.region = dataGridView1.Rows[e.RowIndex].Cells["Region"].FormattedValue.ToString();
                p.dob = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["DateOfBirth"].FormattedValue.ToString());
                p.teamID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TeamID"].FormattedValue.ToString());
                p.physical = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Physical"].FormattedValue.ToString());
                p.attacking = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Attacking"].FormattedValue.ToString());
                p.defending = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Defending"].FormattedValue.ToString());
                p.speed = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Speed"].FormattedValue.ToString());
                p.image = dataGridView1.Rows[e.RowIndex].Cells["Image"].FormattedValue.ToString();
                p.isMain = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["isMain"].FormattedValue.ToString());
                p.position= dataGridView1.Rows[e.RowIndex].Cells["Position"].FormattedValue.ToString();
            }
            if (cbSearch.SelectedIndex == 0)
            {
                t.id= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TeamID"].FormattedValue.ToString());
                t.name= dataGridView1.Rows[e.RowIndex].Cells["TeamName"].FormattedValue.ToString();
                t.region= dataGridView1.Rows[e.RowIndex].Cells["Region"].FormattedValue.ToString();
                t.logo= dataGridView1.Rows[e.RowIndex].Cells["Logo"].FormattedValue.ToString();
                t.monney= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Money"].FormattedValue.ToString());
            }
        }
    }
}
