// 프로그램 메인

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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        // 일반 사용자 로그인 버튼 클릭시
        private void btn_login_normal_Click(object sender, EventArgs e)
        {
            Login_Normal showFormLoginNormal = new Login_Normal();
            showFormLoginNormal.Show();
            this.Visible = false; // 메인 창 종료하기
        }

        // 관리자 사용자 로그인 버튼 클릭시
        private void btn_login_master_Click(object sender, EventArgs e)
        {
            Login_Master showFormLoginMaster = new Login_Master();
            showFormLoginMaster.Show();
            this.Visible = false; // 메인 창 종료하기
        }

        // 정보 버튼 클릭시
        private void btn_info_Click(object sender, EventArgs e)
        {
            info showForminfo = new info();
            showForminfo.ShowDialog();
        }

        // 사용방법 버튼 클릭시
        private void btn_howtouse_Click(object sender, EventArgs e)
        {

        }

        // 오류보고 / 개선요청 버튼 클릭시
        private void btn_support_Click(object sender, EventArgs e)
        {
            SupportMail_Before showSupportMail_Before = new SupportMail_Before();
            showSupportMail_Before.ShowDialog();
        }

        // 프로그램 종료 버튼 클릭시
        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 도서관리 시스템을 종료하시겠습니까?", "종료하기", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // 나눔고딕 설치 바로가기 링크라벨 클릭시
        private void linklabel_gotofont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://hangeul.naver.com/font");
        }

        // 나눔고딕 설치 바로가기 링크라벨에 마우스를 올려두었을 경우
        private void linklabel_gotofont_MouseHover(object sender, EventArgs e)
        {
            toolTip_InstallFont.ToolTipTitle = "폰트 설치";
            toolTip_InstallFont.IsBalloon = true;
            toolTip_InstallFont.SetToolTip(linklabel_gotofont, "나눔고딕 설치 바로가기");
        }
    }
}
