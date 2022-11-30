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
using MySql.Data.MySqlClient; // MySQL 연동

namespace FINAL_project_LibraryProgram_1234
{
    public partial class Login_Master : Form
    {
        private static bool isMasterLogin = false;

        // MySQL 연결
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");
        public Login_Master()
        {
            InitializeComponent();
        }

        // 로그인 버튼 클릭시
        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "SELECT * FROM library_project.master WHERE 아이디 = '" + txtbox_id.Text + "';";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (txtbox_id.Text == reader["아이디"].ToString() && txtbox_pwd.Text == reader["비밀번호"].ToString())
                    {
                        isMasterLogin = true;
                    }

                    if (isMasterLogin == true)
                    {
                        MessageBox.Show(txtbox_id.Text + " 관리자님, 환영합니다.", "로그인 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Master showMaster = new Master();
                        showMaster.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("회원 정보를 확인해 주세요.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isMasterLogin = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
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
            if (MessageBox.Show("정말 도서관리 시스템을 종료하시겠습니까?", "종료하기", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
