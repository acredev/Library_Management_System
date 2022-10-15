using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FINAL_project_LibraryProgram_1234
{
    public partial class Login_Normal : Form
    {
        public Login_Normal()
        {
            InitializeComponent();
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server = localhost;Database=member1;Uid=root;Pwd=root;");
                connection.Open();

                int login_status = 0;

                string loginform_id = txtbox_id.Text;
                string loginform_pwd = txtbox_pwd.Text;

                string selectQuery = "SELECT * FROM member WHERE 아이디=\'" + loginform_id + "\' ";
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

        private void button2_Click(object sender, EventArgs e)
        {
            NewMember showNewMember = new NewMember();
            showNewMember.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main showMain = new Main();
            showMain.Show();
            this.Visible = false; // 현재 창 종료하기
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 도서관리 시스템을 종료하시겠습니까?", "종료하기", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Normal_Find_ID shownormal_find_id = new Normal_Find_ID();
            shownormal_find_id.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Normal_Find_PW shownormal_find_pw = new Normal_Find_PW();
            shownormal_find_pw.Show();
        }
    }
}
