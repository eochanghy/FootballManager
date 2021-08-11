using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPRN_ManagerSoccer
{
    public partial class FrmSchedule : Form
    {
        Account account;
        int ScheduleID = 0;
        public FrmSchedule(Account acc)
        {
            this.account = acc;
            InitializeComponent();
            LoadSchedule();
        }

        void LoadSchedule()
        {
            dgSchedule.DataSource = (new BUSPlayer()).loadSchedule(account.TeamID);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmHome fh = new FrmHome(account);
            fh.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddSchedule f = new FrmAddSchedule(account);
            f.Show();
            this.Hide();
        }

        private void FrmSchedule_Activated(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ScheduleID == 0)
            {
                MessageBox.Show("Hãy chọn 1 lịch tập bạn muốn xóa!");
            }
            else
            {
                if ((new BUSPlayer()).DeleteSchedule(ScheduleID))
                {
                    MessageBox.Show("Xóa lịch tập thành công!");
                    ScheduleID = 0;
                }
                else
                {
                    MessageBox.Show("Lỗi xóa!");
                }
            }
        }

        private void dgSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            DataGridViewRow dataGridViewRow = dgSchedule.Rows[numrow];
            string sScheduleID = dataGridViewRow.Cells[0].Value.ToString();
            ScheduleID = int.Parse(sScheduleID);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ScheduleID == 0)
            {
                MessageBox.Show("Hãy chọn 1 lịch tập bạn muốn sửa thông tin!");
            }
            else
            {
                FrmAddSchedule add = new FrmAddSchedule(account, ScheduleID);
                add.ShowDialog();
                ScheduleID = 0;
            }
        }

        private void FrmSchedule_Load(object sender, EventArgs e)
        {

        }

        private void dgSchedule_SelectionChanged(object sender, EventArgs e)
        {           
        }
    }
}
