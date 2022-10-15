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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("시스템 관리자에게 문의 바랍니다. (발표용 비밀번호 : 1234pwd)", "관리자 비밀번호 분실");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "일이삼사" && textBox2.Text == "19831049")
            {
                MessageBox.Show("사서번호 19831049 회원님의 관리자 아이디는 1234 입니다.", "관리자 아이디 찾기");
            }
            else if (textBox1.Text == "일이삼사" && textBox2.Text == "21831001")
            {
                MessageBox.Show("사서번호 21831001 회원님의 관리자 아이디는 1234 입니다.", "관리자 아이디 찾기");
            }
            else if (textBox1.Text == "일이삼사" && textBox2.Text == "21831011")
            {
                MessageBox.Show("사서번호 21831011 회원님의 관리자 아이디는 1234 입니다.", "관리자 아이디 찾기");
            }
            else if (textBox1.Text == "일이삼사" && textBox2.Text == "21831045")
            {
                MessageBox.Show("사서번호 21831045 회원님의 관리자 아이디는 1234 입니다.", "관리자 아이디 찾기");
            }
            else if (textBox1.Text != "일이삼사" || textBox2.Text != "19831049" || textBox2.Text != "21831001" || textBox2.Text != "21831011" || textBox2.Text != "21831045")
            {
                MessageBox.Show("도서관명 또는 사서번호 오류입니다. 확인 후 재시도 바랍니다.", "관리자 아이디 찾기 오류");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login_Master showLogin_Master = new Login_Master();
            showLogin_Master.Show();
            this.Close();
        }

        private void Master_Find_IDPW_Load(object sender, EventArgs e)
        {

        }
    }
}
