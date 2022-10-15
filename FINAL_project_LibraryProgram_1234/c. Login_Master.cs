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
    public partial class Login_Master : Form
    {
        public Login_Master()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main showMain = new Main();
            showMain.Show();
            this.Visible = false; // 현재 창 종료하기
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 도서관리 시스템을 종료하시겠습니까?", "종료하기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Master showMaster = new Master();
            if (textBox1.Text == "1234" && textBox2.Text == "1234pwd")
            {
                showMaster.Show();
                this.Visible = false;
            }

            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 틀렸습니다.", "로그인 오류");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Master_Find_IDPW showMaster_Find_IDPW = new Master_Find_IDPW();
            showMaster_Find_IDPW.ShowDialog();
            this.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void Login_Master_Load(object sender, EventArgs e)
        {

        }
    }
}
