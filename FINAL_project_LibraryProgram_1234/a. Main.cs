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


        private void button1_Click(object sender, EventArgs e)
        {
            Login_Normal showFormLoginNormal = new Login_Normal();
            showFormLoginNormal.Show();
            this.Visible = false; // 메인 창 종료하기
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login_Master showFormLoginMaster = new Login_Master();
            showFormLoginMaster.Show();
            this.Visible = false; // 메인 창 종료하기
        }

        private void button3_Click(object sender, EventArgs e)
        {
            info showForminfo = new info();
            showForminfo.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 도서관리 시스템을 종료하시겠습니까?", "종료하기", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SupportMail showFormSupportMail = new SupportMail();
            showFormSupportMail.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://hangeul.naver.com/font");
        }

        private void linkLabel2_MouseHover(object sender, EventArgs e)
        {
            toolTip_InstallFont.ToolTipTitle = "폰트 설치";
            toolTip_InstallFont.IsBalloon = true;
            toolTip_InstallFont.SetToolTip(linkLabel2, "나눔고딕 설치 바로가기");
        }
    }
}
