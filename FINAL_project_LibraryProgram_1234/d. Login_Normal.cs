// 일반 사용자 로그인

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySQL 연동

namespace FINAL_project_LibraryProgram_1234
{
    public partial class Login_Normal : Form
    {
        public Login_Normal()
        {
            InitializeComponent();
        }

        // 로그인 버튼 클릭시
        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");
                connection.Open();

                int login_status = 0;

                string loginform_id = txtbox_id.Text;
                string loginform_pwd = txtbox_pwd.Text;

                string selectQuery = "SELECT * FROM library_project.member WHERE 아이디=\'" + loginform_id + "\' ";
                MySqlCommand Selectcommand = new MySqlCommand(selectQuery, connection);


                MySqlDataReader myAccount = Selectcommand.ExecuteReader();

                while (myAccount.Read())
                {

                    if (loginform_id == (string)myAccount["아이디"] && loginform_pwd == (string)myAccount["비밀번호"])
                    {
                        //MessageBox.Show("로그인 완료");
                        login_status = 1;
                    }
                }
                connection.Close();

                if (login_status == 1)
                {
                    MessageBox.Show("로그인 완료");
                    Normal showNormal = new Normal();
                    showNormal.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("회원 정보를 확인해 주세요.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // 회원가입 버튼 클릭시
        private void btn_new_Click(object sender, EventArgs e)
        {
            NewMember_PersonalInformation show_newMember_PersonalInformation = new NewMember_PersonalInformation();
            show_newMember_PersonalInformation.ShowDialog();
        }

        // 비밀번호 보기 체크박스 체크시

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
            if (MessageBox.Show("정말 도서관리 시스템을 종료하시겠습니까?", "종료하기", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        // 아이디 찾기 링크라벨 클릭시

        private void linklabel_findid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Normal_Find_ID shownormal_find_id = new Normal_Find_ID();
            shownormal_find_id.ShowDialog();
        }

        // 비밀번호 찾기 링크라벨 클릭시
        private void linklabel_findpwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Normal_Find_PW shownormal_find_pw = new Normal_Find_PW();
            shownormal_find_pw.ShowDialog();
        }
    }
}
