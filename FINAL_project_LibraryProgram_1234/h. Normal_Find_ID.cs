using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_project_LibraryProgram_1234
{
    public partial class Normal_Find_ID : Form
    {
        public Normal_Find_ID()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Normal_Find_PW shownormal_Find_PW = new Normal_Find_PW();
            shownormal_Find_PW.Show();
        }

        private void _8_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
