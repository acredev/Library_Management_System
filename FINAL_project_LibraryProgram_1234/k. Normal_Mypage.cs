using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySQL 사용 참조
using System.Net.Mail; // EMail 클라이언트 사용 참조
using System.Net; // EMail SMTP 사용 참조

namespace FINAL_project_LibraryProgram_1234
{
    public partial class Normal_Mypage : Form
    {
        public static bool isPwdCheck = false;
        public static bool isTelCheck = false;
        public static bool isEMailCheck = false;

        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");
        public Normal_Mypage()
        {
            InitializeComponent();
        }

        
        private void Normal_Mypage_Load(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "SELECT * FROM library_project.member WHERE 회원번호 = '" + Normal.static_memnum + "';";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read() == true)
                {
                    txtbox_memnum.Text = reader["회원번호"].ToString();
                    txtbox_name.Text = reader["이름"].ToString();
                    txtbox_id.Text = reader["아이디"].ToString();
                    //txtbox_pwd.Text = reader["비밀번호"].ToString();
                    combobox_gender.Text = reader["성별"].ToString();
                    txtbox_address.Text = reader["주소"].ToString();
                    maskedtxtbox_tel.Text = reader["연락처"].ToString();
                    maskedtxtbox_birth.Text = reader["생년월일"].ToString();
                    txtbox_email.Text = reader["이메일"].ToString();
                    txtbox_newdate.Text = reader["가입일"].ToString();
                    txtbox_loanbook.Text = reader["대출권수"].ToString();
                    txtbox_status.Text = reader["회원상태"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void btn_main_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("이전 화면으로 돌아가시겠습니까?", "돌아가기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                Normal showNormal = new Normal();
                showNormal.Show();
            }
        }

        private void picture_support_Click(object sender, EventArgs e)
        {
            SupportMail showSupportMail = new SupportMail();
            showSupportMail.ShowDialog();
        }

        private void picture_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 후 메인화면으로 돌아가시겠습니까?", "로그아웃", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void rdobtn_readonly_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "SELECT * FROM library_project.member WHERE 회원번호 = '" + Normal.static_memnum + "';";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read() == true)
                {
                    txtbox_memnum.Text = reader["회원번호"].ToString();
                    txtbox_name.Text = reader["이름"].ToString();
                    txtbox_id.Text = reader["아이디"].ToString();
                    //txtbox_pwd.Text = reader["비밀번호"].ToString();
                    combobox_gender.Text = reader["성별"].ToString();
                    txtbox_address.Text = reader["주소"].ToString();
                    maskedtxtbox_tel.Text = reader["연락처"].ToString();
                    maskedtxtbox_birth.Text = reader["생년월일"].ToString();
                    txtbox_email.Text = reader["이메일"].ToString();
                    txtbox_newdate.Text = reader["가입일"].ToString();
                    txtbox_loanbook.Text = reader["대출권수"].ToString();
                    txtbox_status.Text = reader["회원상태"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

            if (rdobtn_readonly.Checked == true)
            {
                txtbox_memnum.ReadOnly = true;
                txtbox_name.ReadOnly = true;
                txtbox_id.ReadOnly = true;
                txtbox_pwd.ReadOnly = true;
                txtbox_pwdcheck.ReadOnly = true;
                combobox_gender.Enabled = false;
                txtbox_address.ReadOnly = true;
                maskedtxtbox_tel.ReadOnly = true;
                maskedtxtbox_birth.ReadOnly = true;
                txtbox_email.ReadOnly = true;
                txtbox_newdate.ReadOnly = true;
                txtbox_loanbook.ReadOnly = true;
                txtbox_status.ReadOnly = true;

                chkbox_seepwd.Visible = false;
                label_isPwdSame.Visible = false;
                label_check_tel.Visible = false;
                txtbox_check_tel.Visible = false;
                btn_checknum_tel.Visible = false;
                label_check_email.Visible = false;
                txtbox_check_email.Visible = false;
                btn_checknum_email.Visible = false;

                label_isPwdSame.Text = "";
                txtbox_pwd.Text = "";
                txtbox_pwdcheck.Text = "";

                txtbox_pwd.Text = "";
                txtbox_pwdcheck.Text = "";

                chkbox_seepwd.Checked = false;
            }
        }

        private void rdobtn_modify_CheckedChanged(object sender, EventArgs e)
        {
            txtbox_memnum.ReadOnly = true;
            txtbox_name.ReadOnly = true;
            txtbox_id.ReadOnly = true;
            txtbox_pwd.ReadOnly = false;
            txtbox_pwdcheck.ReadOnly = false;
            combobox_gender.Enabled = true;
            txtbox_address.ReadOnly = false;
            maskedtxtbox_tel.ReadOnly = false;
            maskedtxtbox_birth.ReadOnly = false;
            txtbox_email.ReadOnly = false;
            txtbox_newdate.ReadOnly = true;
            txtbox_loanbook.ReadOnly = true;
            txtbox_status.ReadOnly = true;

            chkbox_seepwd.Visible = true;
            label_isPwdSame.Visible = true;
            label_check_tel.Visible = true;
            txtbox_check_tel.Visible = true;
            btn_checknum_tel.Visible = true;
            label_check_email.Visible = true;
            txtbox_check_email.Visible = true;
            btn_checknum_email.Visible = true;

            label_isPwdSame.Text = "";
            txtbox_pwd.Text = "";
            txtbox_pwdcheck.Text = "";
            txtbox_check_tel.Text = "";
            txtbox_check_email.Text = "";

            chkbox_seepwd.Checked = false;
        }

        private void label_isYouChangeName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("메인 화면의 '도서관 문의' 화면에서, 간단한 관련 정보를 남겨주세요. 변경 절차를 도서관에서 유선상 안내할 예정입니다.");
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "SELECT * FROM library_project.member WHERE 회원번호 = '" + Normal.static_memnum + "';";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read() == true)
                {
                    txtbox_memnum.Text = reader["회원번호"].ToString();
                    txtbox_name.Text = reader["이름"].ToString();
                    txtbox_id.Text = reader["아이디"].ToString();
                    //txtbox_pwd.Text = reader["비밀번호"].ToString();
                    combobox_gender.Text = reader["성별"].ToString();
                    txtbox_address.Text = reader["주소"].ToString();
                    maskedtxtbox_tel.Text = reader["연락처"].ToString();
                    maskedtxtbox_birth.Text = reader["생년월일"].ToString();
                    txtbox_email.Text = reader["이메일"].ToString();
                    txtbox_newdate.Text = reader["가입일"].ToString();
                    txtbox_loanbook.Text = reader["대출권수"].ToString();
                    txtbox_status.Text = reader["회원상태"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        

        private void chkbox_seepwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_seepwd.Checked == true)
            {
                txtbox_pwd.UseSystemPasswordChar = false;
                txtbox_pwdcheck.UseSystemPasswordChar = false;
            }
            else if (chkbox_seepwd.Checked == false)
            {
                txtbox_pwd.UseSystemPasswordChar = true;
                txtbox_pwdcheck.UseSystemPasswordChar = true;
            }
        }

        private void btn_modifymeminfo_Click(object sender, EventArgs e)
        {

        }

        private void btn_deletemem_Click(object sender, EventArgs e)
        {

        }

        private void txtbox_pwd_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_pwd.Text == txtbox_pwdcheck.Text)
            {
                label_isPwdSame.Text = "비밀번호 일치";
                label_isPwdSame.ForeColor = Color.Blue;
                isPwdCheck = true;
            }
            else if (txtbox_pwd.Text != txtbox_pwdcheck.Text)
            {
                label_isPwdSame.Text = "비밀번호 불일치";
                label_isPwdSame.ForeColor = Color.Red;
                isPwdCheck = false;
            }
            else if (txtbox_pwdcheck.Text != txtbox_pwd.Text)
            {
                label_isPwdSame.Text = "비밀번호 불일치";
                label_isPwdSame.ForeColor = Color.Red;
                isPwdCheck = false;
            }
            else
            {
                label_isPwdSame.Text = "";
            }
        }

        private void txtbox_pwdcheck_TextChanged(object sender, EventArgs e)
        {
            label_isPwdSame.Visible = true;

            if (txtbox_pwd.Text == txtbox_pwdcheck.Text)
            {
                label_isPwdSame.Text = "비밀번호 일치";
                label_isPwdSame.ForeColor = Color.Blue;
                isPwdCheck = true;
            }
            else if (txtbox_pwd.Text != txtbox_pwdcheck.Text)
            {
                label_isPwdSame.Text = "비밀번호 불일치";
                label_isPwdSame.ForeColor = Color.Red;
                isPwdCheck = false;
            }
            else if (txtbox_pwdcheck.Text != txtbox_pwd.Text)
            {
                label_isPwdSame.Text = "비밀번호 불일치";
                label_isPwdSame.ForeColor = Color.Red;
                isPwdCheck = false;
            }
            else
            {
                label_isPwdSame.Text = "";
            }
        }
    }        
}
