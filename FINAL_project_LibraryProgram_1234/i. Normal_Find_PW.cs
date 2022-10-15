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
    public partial class Normal_Find_PW : Form
    {
        public Normal_Find_PW()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Normal_Find_ID showNormal_Find_id = new Normal_Find_ID();
            showNormal_Find_id.Show();
            Close();
        }
    }
}
