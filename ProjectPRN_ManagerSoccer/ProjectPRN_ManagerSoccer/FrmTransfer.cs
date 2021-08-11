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
    
    public partial class FrmTransfer : Form
    {
        Account account;
        public FrmTransfer(Account acc)
        {
            this.account = acc;
            InitializeComponent();
        }
        List<Player> listP = new List<Player>();
        
        private void loadGrid()
        {
            DataTable dt = new DataTable();
            dt = (new BUSTransfer()).getTransferPlayer(account);
            dgTeam.DataSource = dt;
            dgListTransfer.DataSource = (new BUSTransfer()).getTransferMark();
            foreach (DataRow dr in dt.Rows)
            {
                listP.Add(new Player(Convert.ToInt32(dr["PlayerID"].ToString()),
                    dr["PlayerName"].ToString(),
                    dr["Region"].ToString(),
                    Convert.ToDateTime(dr["DateOfBirth"].ToString()),
                    Convert.ToInt32(dr["TeamID"].ToString()),
                    dr["Position"].ToString(),
                    Convert.ToDouble(dr["Physical"].ToString()),
                    Convert.ToDouble(dr["Attacking"].ToString()),
                    Convert.ToDouble(dr["Defending"].ToString()),
                    Convert.ToDouble(dr["Speed"].ToString()),
                    dr["Image"].ToString(),
                    Convert.ToBoolean(dr["isMain"].ToString())
                    ));
            }
        }
        private void FrmTransfer_Load(object sender, EventArgs e)
        {
            btnRemove.Visible = false;
            lblMoney.Text = (new BUSTransfer()).getMoney(account.TeamID);
            loadGrid();
            txtPrice.Text = "0";
            

        }
        private void dgTeam_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            txtID.Text = dgTeam.Rows[e.RowIndex].Cells["PlayerID"].FormattedValue.ToString();
            txtName.Text = dgTeam.Rows[e.RowIndex].Cells["PlayerName"].FormattedValue.ToString();
            
        }

        private void txtSell_Click(object sender, EventArgs e)
        {
            Player a = new Player();
            foreach (Player i in listP)
            {
                
                if (Convert.ToInt32(txtID.Text) == i.id)
                {
                    a = i;
                }
            }
            try
            {
                if((new BUSTransfer()).addTransfer(a, Convert.ToDouble(txtPrice.Text))&& (new BUSTransfer()).updateAfterSell(a.id))
                {
                    MessageBox.Show("Sell complete..");
                    refresh();
                }
                               
                

            }
            catch (Exception)
            {
                MessageBox.Show("Sell that bai..");
                return;
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
        public void refresh()
        {
            cbxMyPlayer.Checked = false;
            lblMoney.Text = (new BUSTransfer()).getMoney(account.TeamID);
            loadGrid();
            txtPrice.Text = "0";
            txtID.Text = "";
            txtPrice.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmHome f = new FrmHome(account);
            f.Show();
            this.Hide();
        }

        private void cbxMyPlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMyPlayer.Checked)
            {
                btnRemove.Visible = true;
                btnBuy.Visible = false;
                DataTable myP = (new BUSTransfer()).getMyPlayer(account.TeamID);
                dgListTransfer.DataSource = myP;
            }
            else
            {
                btnBuy.Visible = true;
                btnRemove.Visible = false;
                dgListTransfer.DataSource = (new BUSTransfer()).getTransferMark();
            }
        }
        string pID;
        private void dgListTransfer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pID = dgListTransfer.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if((new BUSTransfer()).removeFromTransfer(pID, account.TeamID))
            {
                MessageBox.Show("Remove success..");
                refresh();
            }
        }
        private void btnBuy_Click(object sender, EventArgs e)
        {
            int tID = Convert.ToInt32(dgListTransfer.SelectedRows[0].Cells["TeamID"].FormattedValue.ToString());
            if(tID == account.TeamID)
            {
                MessageBox.Show("This player in your team..");
            }
            else
            {
                double tMoney = Convert.ToDouble(dgListTransfer.SelectedRows[0].Cells["Price"].FormattedValue.ToString());
                if (Convert.ToDouble(lblMoney.Text) < tMoney)
                {
                    MessageBox.Show("Not enough money...");
                }
                else
                {
                    double newMoney = Convert.ToDouble(lblMoney.Text) - tMoney;
                    int sellTeamID = Convert.ToInt32(dgListTransfer.SelectedRows[0].Cells["TeamID"].FormattedValue.ToString());
                    double sellTeamMoney = Convert.ToDouble((new BUSTransfer()).getMoney(sellTeamID));
                    double newMoneyForSell = sellTeamMoney + tMoney;
                    if ((new BUSTransfer()).removeFromTransfer(pID, account.TeamID)&&(new BUSTransfer()).updateMoney(newMoney, account.TeamID)
                        &&(new BUSTransfer()).updateMoney(newMoneyForSell, sellTeamID))
                    {
                        MessageBox.Show("Buy success..");
                        refresh();
                    }
                }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtPrice.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmNegotiate fn = new FrmNegotiate(account);
            fn.Show();
            this.Hide();
        }
    }
}
