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
    public partial class MainPlayer : UserControl
    {
        public int playerID { get; set; }
        public string image { get; set; }
        public MainPlayer()
        {
            InitializeComponent();
        }

        private void MainPlayer_Load(object sender, EventArgs e)
        {

        }

        private void btnPos_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
