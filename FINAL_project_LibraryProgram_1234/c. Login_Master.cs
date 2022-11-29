// 관리자 로그인

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

        // 로그인 버튼 클릭시
        private void btn_login_Click(object sender, EventArgs e)
        {
            Master showMaster = new Master();
            if (txtbox_id.Text == "1234" && txtbox_pwd.Text == "1234pwd")
            {
                showMaster.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 틀렸습니다.", "로그인 오류");
            }
        }

        // 비밀번호 보기 체크박스 클릭시
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtbox_pwd.UseSystemPasswordChar = false;
            }
            else
            {
                txtbox_pwd.UseSystemPasswordChar = true;
            }
        }

        // 나눔고딕 설치 링크라벨 클릭시
        private void linklabel_findid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Master_Find_IDPW showMaster_Find_IDPW = new Master_Find_IDPW();
            showMaster_Find_IDPW.ShowDialog();
            this.Visible = false;
        }

        // 초기 화면으로 버튼 클릭시
        private void btn_gotomain_Click(object sender, EventArgs e)
        {
            Main showMain = new Main();
            showMain.Show();
            this.Visible = false; // 현재 창 종료하기
        }

        // 프로그램 종료 버튼 클릭시
        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 도서관리 시스템을 종료하시겠습니까?", "종료하기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
