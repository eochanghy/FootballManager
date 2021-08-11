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
namespace ProjectPRN_ManagerSoccer
{
    public partial class FrmNegotiate : Form
    {
        Account account;
        List<Player> listP = new List<Player>();
        Player player;
        int requestID = 0;
        int teamIDSend = 0;
        public FrmNegotiate(Account acc)
        {
            this.account = acc;
            InitializeComponent();
        }
        public void loadTransfer()
        {
            DataTable dt = new DataTable();
            dt = (new BUSTransfer()).getTransferMark();
            dgDisplay.DataSource = dt;         
        }
        public void loadRequestForMe()
        {
            DataTable dt = (new BUSRequest()).getRequestForME(account.TeamID);
            dgDisplay.DataSource = dt;
        }
        public void loadRequestFromME()
        {
            DataTable dt = (new BUSRequest()).getRequestFromME(account.TeamID);
            dgDisplay.DataSource = dt;
        }
        private void FrmNegotiate_Load(object sender, EventArgs e)
        {
            cbxOption.SelectedIndex = 0;
            btnAccept.Visible = false;
            btnRemove.Visible = false;
            lblMoney.Text = (new BUSTransfer()).getMoney(account.TeamID);
            loadTransfer();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmTransfer ft = new FrmTransfer(account);
            ft.Show();
            this.Hide();
        }

        private void dgDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPlayerID.Text = dgDisplay.Rows[e.RowIndex].Cells["PlayerID"].FormattedValue.ToString();
            txtPlayerName.Text = dgDisplay.Rows[e.RowIndex].Cells["PlayerName"].FormattedValue.ToString();
            txtPrice.Text = dgDisplay.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
            if (cbxOption.SelectedIndex == 0)
            {
                int teamID = Convert.ToInt32(dgDisplay.Rows[e.RowIndex].Cells["TeamID"].FormattedValue.ToString());
                player = new Player(Convert.ToInt32(txtPlayerID.Text), txtPlayerName.Text, teamID);
            }
            else
            {
                if (cbxOption.SelectedIndex == 1)
                {
                    int teamID = Convert.ToInt32(dgDisplay.Rows[e.RowIndex].Cells["TeamIDReceive"].FormattedValue.ToString());
                    player = new Player(Convert.ToInt32(txtPlayerID.Text), txtPlayerName.Text, teamID);
                    txtMessage.Text = dgDisplay.Rows[e.RowIndex].Cells["Message"].FormattedValue.ToString();
                    requestID = Convert.ToInt32(dgDisplay.Rows[e.RowIndex].Cells["RequestID"].FormattedValue.ToString());
                    teamIDSend = Convert.ToInt32(dgDisplay.Rows[e.RowIndex].Cells["TeamIDSend"].FormattedValue.ToString());
                }
                else
                {
                    int teamID = Convert.ToInt32(dgDisplay.Rows[e.RowIndex].Cells["TeamIDReceive"].FormattedValue.ToString());
                    player = new Player(Convert.ToInt32(txtPlayerID.Text), txtPlayerName.Text, teamID);
                    txtMessage.Text = dgDisplay.Rows[e.RowIndex].Cells["Message"].FormattedValue.ToString();
                    requestID = Convert.ToInt32(dgDisplay.Rows[e.RowIndex].Cells["RequestID"].FormattedValue.ToString());
                    teamIDSend = Convert.ToInt32(dgDisplay.Rows[e.RowIndex].Cells["TeamIDSend"].FormattedValue.ToString());
                    txtMessage.Text = dgDisplay.Rows[e.RowIndex].Cells["Message"].FormattedValue.ToString();
                }
            }
        }
        private bool checkInput()
        {
            if(txtPlayerID.Text == "")
            {
                MessageBox.Show("Please select player...");
                return false;
            }
            if(txtPrice.Text == "")
            {
                MessageBox.Show("Please enter price...");
                return false;
            }
            if(txtMessage.Text == "")
            {
                MessageBox.Show("Please enter message...");
                return false;
            }
            return true;
        }
        public void reset()
        {
            cbxOption.SelectedIndex = 0;
            txtPlayerID.Text = "";
            txtPlayerName.Text = "";
            txtPrice.Text = "";
            txtMessage.Text = "";
            lblMoney.Text = (new BUSTransfer()).getMoney(account.TeamID);
            player = new Player();
            requestID = 0;
            teamIDSend = 0;
        }
        
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                if(player.teamID != account.TeamID)
                {
                    double teamMoney = Convert.ToDouble(lblMoney.Text);
                    double playerPrice = Convert.ToDouble(txtPrice.Text);
                    if(teamMoney >= playerPrice)
                    {
                        if ((new BUSRequest()).insertRequest(txtPlayerID.Text, txtPlayerName.Text, txtPrice.Text, txtMessage.Text, account.TeamID, player.teamID) && (new BUSTransfer()).updateMoney(teamMoney - playerPrice, account.TeamID))
                        {
                            MessageBox.Show("Send request success..");
                            reset();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not enough money");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Can not request buy player in your team..");
                }
                
            }
        }

        private void cbxOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxOption.SelectedIndex == 0)
            {
                btnAccept.Visible = false;
                btnRemove.Visible = false;
                btnSend.Visible = true;
                txtPrice.ReadOnly = false;
                txtMessage.ReadOnly = false;
                loadTransfer();
                
            }
            else
            {
                if (cbxOption.SelectedIndex == 1)
                {
                    btnAccept.Visible = true;
                    btnRemove.Visible = true;
                    btnSend.Visible = false;
                    txtPrice.ReadOnly = true;
                    txtMessage.ReadOnly = true;
                    loadRequestForMe();
                }
                else
                {
                    if (cbxOption.SelectedIndex == 2)
                    {
                        btnAccept.Visible = false;
                        btnRemove.Visible = true;
                        btnSend.Visible = false;
                        txtPrice.ReadOnly = true;
                        txtMessage.ReadOnly = true;
                        loadRequestFromME();
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(requestID == 0)
            {
                MessageBox.Show("Please select request..");
            }
            else
            {
                double teamSendMoney = Convert.ToDouble((new BUSTransfer()).getMoney(teamIDSend));
                double playerPrice = Convert.ToDouble(txtPrice.Text);
                if((new BUSRequest()).removeRequest(requestID) && (new BUSTransfer()).updateMoney(teamSendMoney+playerPrice, teamIDSend))
                {
                    MessageBox.Show("Remove success..");
                    reset();
                }
            }
            
        }
        private void removeRequest(int teamIDSend, int requestID, double moneyReturn)
        {
            double teamSendMoney = Convert.ToDouble((new BUSTransfer()).getMoney(teamIDSend));
            if ((new BUSRequest()).removeRequest(requestID) && (new BUSTransfer()).updateMoney(teamSendMoney + moneyReturn, teamIDSend))
            {
                bool run = true;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (requestID == 0)
            {
                MessageBox.Show("Please select request..");
            }
            else
            {

                //change teamid of player, update money
                double teamMoney = Convert.ToDouble(lblMoney.Text);
                double playerPrice = Convert.ToDouble(txtPrice.Text);
                DataTable dt = (new BUSRequest()).getAnotherRequest(txtPlayerID.Text, requestID);
                foreach (DataRow dr in dt.Rows)
                {
                    int teamIDS = Convert.ToInt32(dr["TeamIDSend"].ToString());
                    double moneyReturn = Convert.ToDouble(dr["Price"].ToString());
                    removeRequest(teamIDS, requestID, moneyReturn);
                }
                if ((new BUSTransfer()).removeFromTransfer(txtPlayerID.Text, teamIDSend)
                    && (new BUSTransfer()).updateMoney(teamMoney+playerPrice, account.TeamID)
                    && (new BUSRequest()).removeAllRequestbyPlayerID(txtPlayerID.Text))
                {
                    MessageBox.Show("Accept success..");
                    reset();
                }
            }
        }
    }
}
