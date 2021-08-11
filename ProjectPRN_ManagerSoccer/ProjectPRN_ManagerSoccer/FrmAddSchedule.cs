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
    public partial class FrmAddSchedule : Form
    {
        Account account;
        int ScheduleID;
        public FrmAddSchedule(Account acc)
        {
            InitializeComponent();
            label1.Text = "Add schedule";
            btnSave.Visible = false;
            btnAdd.Visible = true;
            this.account = acc;
        }
        public FrmAddSchedule(Account acc, int sch)
        {
            InitializeComponent();
            label1.Text = "Edit schedule";
            btnSave.Visible = true;
            btnAdd.Visible = false;
            this.ScheduleID = sch;
            this.account = acc;
            LoadData(ScheduleID);
        }

        void LoadData(int id)
        {
            DataTable data = (new BUSPlayer()).loadDataSchedult(id);
            DataRow row = data.Rows[0];
            textBox1.Text = row[1].ToString();
            dateTimePicker1.Value = (DateTime)row[4];
            string[] arrListStr = row[2].ToString().Split(':');
            num1.Value = int.Parse(arrListStr[0]);
            num2.Value = int.Parse(arrListStr[1]);
            string[] arrListStr1 = row[3].ToString().Split(':');
            num3.Value = int.Parse(arrListStr1[0]);
            num4.Value = int.Parse(arrListStr1[1]);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                bool checkTime = true;
                string s = textBox1.Text;
                string TimeStart = num1.Value.ToString() + ":" + num2.Value.ToString();
                string TimeEnd = num3.Value.ToString() + ":" + num4.Value.ToString();
                DateTime date = dateTimePicker1.Value;
                if (num1.Value == num3.Value)
                {
                    if (num2.Value >= num4.Value)
                    {
                        checkTime = false;
                        MessageBox.Show("Time start must be < time End..");

                    }
                }
                else
                {
                    if (num1.Value > num3.Value)
                    {
                        checkTime = false;
                        MessageBox.Show("Time start must be < time End..");
                    }
                }
                if (checkTime)
                {
                    if ((new BUSPlayer()).AddSchedule(s, TimeStart, TimeEnd, date, account.TeamID))
                    {
                        MessageBox.Show("Add Schedule thành công!");
                        FrmSchedule fs = new FrmSchedule(account);
                        fs.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Content must not empty..");
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                bool checkTime = true;
                string s = textBox1.Text;
                string TimeStart = num1.Value.ToString() + ":" + num2.Value.ToString();
                string TimeEnd = num3.Value.ToString() + ":" + num4.Value.ToString();
                DateTime date = dateTimePicker1.Value;
                if (num1.Value == num3.Value)
                {
                    if (num2.Value >= num4.Value)
                    {
                        checkTime = false;
                        MessageBox.Show("Time start must be < time End..");

                    }
                }
                else
                {
                    if (num1.Value > num3.Value)
                    {
                        checkTime = false;
                        MessageBox.Show("Time start must be < time End..");
                    }
                }
                if (checkTime)
                {
                    if ((new BUSPlayer()).EditSchedule(ScheduleID, s, TimeStart, TimeEnd, date, account.TeamID))
                    {
                        MessageBox.Show("Edit Schedule thành công!");
                        FrmSchedule fs = new FrmSchedule(account);
                        fs.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Content must not empty..");
            }


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmSchedule fs = new FrmSchedule(account);
            fs.Show();
            this.Hide();
        }
    }
}
