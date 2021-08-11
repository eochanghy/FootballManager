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
    public partial class SubPlayer : UserControl
    {
        public int playerID { get; set; }
        public string image { get; set; }
        public SubPlayer()
        {
            InitializeComponent();
        }

        private void SubPlayer_Load(object sender, EventArgs e)
        {
            btnSwap.Visible = false;
            btnCancel.Visible = false;
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {

        }
    }
}
