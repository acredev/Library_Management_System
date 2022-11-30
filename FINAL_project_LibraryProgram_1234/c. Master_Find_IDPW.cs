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
    public partial class Master_Find_IDPW : Form
    {
        public Master_Find_IDPW()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login_Master showLogin_Master = new Login_Master();
            showLogin_Master.Show();
            this.Close();
        }
    }
}
