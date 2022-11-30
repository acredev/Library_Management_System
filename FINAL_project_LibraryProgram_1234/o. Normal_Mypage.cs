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
using CoolSms;

namespace FINAL_project_LibraryProgram_1234
{
    public partial class Normal_Mypage : Form
    {
        //MySQL 연결 변수
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");

        //EMail 인증 난수
        public static Random randomNum = new Random();
        public static int emailcheck_num = randomNum.Next(10000000, 99999999);

        //전화번호 인증 난수
        public static Random randomNumTel = new Random();
        public static int telcheck_num = randomNumTel.Next(00000001, 99999999);

        //회원정보 변경 상태 bool형 변수
        public static bool isPwdCheck = false;
        public static bool isTelCheck = false;
        public static bool isEMailCheck = false;

        //CoolSMS API 사용
        SmsApi smsapi = new SmsApi(new SmsApiOptions
        {
            ApiKey = "NCSOPJRMYVLC9ZGS",
            ApiSecret = "RXWXXTZEUKGXX175IKXDB3BU43BWFPCE",
            DefaultSenderId = "01084295741"
        });

        public Normal_Mypage()
        {
            InitializeComponent();
        }

        // 폼 로드시 로그인한 회원정보를 바로 불러와 각 textbox에 뿌려줌
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

        // 이전화면 버튼 클릭 시
        private void btn_main_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("이전 화면으로 돌아가시겠습니까?", "돌아가기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                Normal showNormal = new Normal();
                showNormal.Show();
            }
        }

        // 오류보고 / 개선요청 버튼 클릭시
        private void picture_support_Click(object sender, EventArgs e)
        {
            SupportMail showSupportMail = new SupportMail();
            showSupportMail.ShowDialog();
        }

        // 로그아웃 버튼 클릭시
        private void picture_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 후 메인화면으로 돌아가시겠습니까?", "로그아웃", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        // 회원정보 열람 모드로 변경시
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
                txtbox_email.ReadOnly = true;
                txtbox_newdate.ReadOnly = true;
                txtbox_loanbook.ReadOnly = true;
                txtbox_status.ReadOnly = true;
                txtbox_address.ReadOnly = true;
                maskedtxtbox_tel.ReadOnly = true;
                maskedtxtbox_birth.ReadOnly = true;
                combobox_gender.Enabled = true;

                chkbox_seepwd.Visible = false;
                label_check_email.Visible = false;
                label_isPwdSame.Visible = false;
                label_check_tel.Visible = false;
                txtbox_check_tel.Visible = false;
                txtbox_check_email.Visible = false;
                btn_checknum_tel.Visible = false;
                btn_checknum_email.Visible = false;
                btn_check_tel.Visible = false;
                btn_check_email.Visible = false;

                label_isPwdSame.Text = "";
                txtbox_pwd.Text = "";
                txtbox_pwdcheck.Text = "";

                txtbox_pwd.Text = "";
                txtbox_pwdcheck.Text = "";

                chkbox_seepwd.Checked = false;
            }
        }

        //회원정보 수정 모드로 변경시
        private void rdobtn_modify_CheckedChanged(object sender, EventArgs e)
        {
            txtbox_memnum.ReadOnly = true;
            txtbox_name.ReadOnly = true;
            txtbox_id.ReadOnly = true;
            txtbox_pwd.ReadOnly = false;
            txtbox_pwdcheck.ReadOnly = false;
            txtbox_email.ReadOnly = false;
            txtbox_newdate.ReadOnly = true;
            txtbox_loanbook.ReadOnly = true;
            txtbox_status.ReadOnly = true;
            txtbox_address.ReadOnly = false;
            txtbox_check_tel.ReadOnly = false;
            txtbox_check_email.ReadOnly = false;
            maskedtxtbox_tel.ReadOnly = false;
            maskedtxtbox_birth.ReadOnly = false;
            combobox_gender.Enabled = true;

            chkbox_seepwd.Visible = true;
            label_check_email.Visible = true;
            label_isPwdSame.Visible = true;
            label_check_tel.Visible = true;
            txtbox_check_tel.Visible = true;
            txtbox_check_email.Visible = true;
            btn_checknum_tel.Visible = true;
            btn_checknum_email.Visible = true;
            btn_check_tel.Visible = true;
            btn_check_email.Visible = true;
            
            label_isPwdSame.Text = "";
            txtbox_pwd.Text = "";
            txtbox_pwdcheck.Text = "";
            txtbox_check_tel.Text = "";
            txtbox_check_email.Text = "";

            chkbox_seepwd.Checked = false;
        }

        // 개명을 하셨나요? 버튼 클릭 시
        private void label_isYouChangeName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("메인 화면의 '도서관 문의' 화면에서, 제목과 내용이 '개명 요청' 이라는 게시글을 남겨주세요. 변경 절차를 도서관에서 유선상 안내할 예정입니다.");
        }

        // 비밀번호와 비밀번호 확인 텍스트가 같은지 여부를 확인해 label_isPwdSame 에 표시함, 평소에는 사라짐
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

        // 비밀번호와 비밀번호 확인 텍스트가 같은지 여부를 확인해 label_isPwdSame 에 표시함, 평소에는 사라짐
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

        // 비밀번호 보기 버튼 클릭시
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
        //전화번호 본인인증 버튼 클릭시
        private void btn_check_tel_Click(object sender, EventArgs e)
        {
            if (maskedtxtbox_tel.Text == "")
            {
                MessageBox.Show("휴대폰 번호가 입력되지 않았습니다. 입력후 다시 시도해 주세요.");
            }
            else
            {
                var body = smsapi.SendMessageAsync(maskedtxtbox_tel.Text, "일이삼사 도서관 본인인증 인증 번호입니다." + "[" + telcheck_num.ToString() + "]");
                MessageBox.Show("사용자의 휴대폰 번호 : " + maskedtxtbox_tel.Text + "로 인증번호가 발송되었습니다. 인증번호를 올바르게 입력해 주세요.");
            }
        }

        //전화번호 인증확인 버튼 클릭시
        private void btn_checknum_tel_Click(object sender, EventArgs e)
        {
            if (txtbox_check_tel.Text == telcheck_num.ToString())
            {
                MessageBox.Show("휴대폰 인증이 완료되었습니다. 회원가입을 진행해 주세요.", "인증 완료");
                isTelCheck = true;
            }
            else
            {
                MessageBox.Show("휴대폰 인증이 실패했습니다. 인증번호를 확인해 주세요.", "인증 실패");
            }
        }


        //이메일 본인확인 버튼 클릭시
        private void btn_check_email_Click(object sender, EventArgs e)
        {
            // 구글 계정 아이디와 외부 접근 KEY
            string SystemMailid = "praticecoding.h@gmail.com";
            string SystemMailPwd = "cthoxecsadvgxoat";

            // SMTP 이메일 이용
            MailMessage mail = new MailMessage();
            mail.To.Add(txtbox_email.Text);
            mail.From = new MailAddress(SystemMailid);
            mail.Subject = "일이삼사 도서관 회원정보 변경 본인인증 이메일 입니다.";
            mail.Body = emailcheck_num.ToString();
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High; // 중요도 높음
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.BodyEncoding = Encoding.UTF8;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Timeout = 100000;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential(SystemMailid, SystemMailPwd);

            try
            {
                smtp.Send(mail);
                smtp.Dispose();

                MessageBox.Show("이메일 인증번호가 전송되었습니다. 인증번호 입력 후 인증확인 버튼을 눌러주세요.", "전송 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show("이메일 발송 오류입니다. 이메일 주소 또는 네트워크 상태를 확인해 주세요." + ex.ToString());
            }
        }

        // 이메일 인증확인 버튼 클릭시
        private void btn_checknum_email_Click(object sender, EventArgs e)
        {
            if (txtbox_check_email.Text == emailcheck_num.ToString())
            {
                MessageBox.Show("이메일 인증이 완료되었습니다. 회원가입을 진행해 주세요.", "인증 완료");
                isEMailCheck = true;
            }
            else
            {
                MessageBox.Show("이메일 인증이 실패했습니다. 인증번호를 확인해 주세요.", "인증 실패");
            }
        }
        // 회원정보 수정 버튼 클릭시
        private void btn_modifymeminfo_Click(object sender, EventArgs e)
        {
            if (isEMailCheck == true && isPwdCheck == true && isTelCheck == true)
            {
                string insertQuery = "UPDATE library_project.member SET 비밀번호 = '" + txtbox_pwd.Text + "', 성별 = '" + combobox_gender.Text + "', 주소 = '" + txtbox_address.Text + "', 연락처 = '" + maskedtxtbox_tel.Text + "', 생년월일 = '" + maskedtxtbox_birth.Text + "', 이메일 = '" + txtbox_email.Text + "' WHERE 회원번호 = '" + txtbox_memnum.Text + "';";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    if (command.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show(txtbox_name.Text + " 회원님의 개인 정보가 수정되었습니다. 재조회 버튼을 눌러 화면을 갱신해 주세요.");

                        rdobtn_readonly.Checked = true;

                        txtbox_name.Text = "";
                        txtbox_memnum.Text = "";
                        txtbox_id.Text = "";
                        txtbox_status.Text = "";
                        txtbox_loanbook.Text = "";
                        txtbox_newdate.Text = "";
                        txtbox_pwd.Text = "";
                        txtbox_pwdcheck.Text = "";
                        maskedtxtbox_birth.Text = "";
                        combobox_gender.SelectedItem = "";
                        txtbox_address.Text = "";
                        maskedtxtbox_tel.Text = "";
                        txtbox_check_tel.Text = "";
                        txtbox_email.Text = "";
                        txtbox_check_email.Text = "";

                        txtbox_memnum.ReadOnly = true;
                        txtbox_name.ReadOnly = true;
                        txtbox_id.ReadOnly = true;
                        txtbox_pwd.ReadOnly = true;
                        txtbox_pwdcheck.ReadOnly = true;
                        txtbox_email.ReadOnly = true;
                        txtbox_newdate.ReadOnly = true;
                        txtbox_loanbook.ReadOnly = true;
                        txtbox_status.ReadOnly = true;
                        txtbox_address.ReadOnly = true;
                        maskedtxtbox_tel.ReadOnly = true;
                        maskedtxtbox_birth.ReadOnly = true;
                        combobox_gender.Enabled = true;

                        chkbox_seepwd.Visible = false;
                        label_check_email.Visible = false;
                        label_isPwdSame.Visible = false;
                        label_check_tel.Visible = false;
                        txtbox_check_tel.Visible = false;
                        txtbox_check_email.Visible = false;
                        btn_checknum_tel.Visible = false;
                        btn_checknum_email.Visible = false;
                        btn_check_tel.Visible = false;
                        btn_check_email.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "회원정보 수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("본인인증 절차를 진행 후 회원정보 수정을 요청해 주세요.");
            }
        }

        // 회원정보 탈퇴 버튼 클릭시
        private void btn_deletemem_Click(object sender, EventArgs e)
        {
            if (rdobtn_readonly.Checked == true)
            {
                MessageBox.Show("회원정보 수정 모드에서만 가능합니다. 모드 변경 후 이용 바랍니다.");
            }
            else if (rdobtn_modify.Checked == true)
            {
                if (txtbox_loanbook.Text != "0")
                {
                    if (MessageBox.Show(txtbox_name.Text + " 회원님, 정말 탈퇴 하시겠습니까? 처리 이후에는 복구할 수 없습니다.", "회원정보 탈퇴", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string insertQuery = "DELETE FROM library_project.member WHERE 회원번호 = '" + txtbox_memnum.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);

                        try
                        {
                            if (command.ExecuteNonQuery() != 0)
                            {
                                MessageBox.Show(txtbox_name.Text + " 회원님의 정보가 정상 탈퇴 처리 되었습니다. 확인 버튼을 누르시면 로그아웃 되며, 다시 회원가입 후 도서관리 시스템을 이용할 수 있습니다.");
                                Application.Restart();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "회원탈퇴 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("대출한 도서가 존재합니다. 반납 처리 후 회원 탈퇴가 가능합니다.");
                }
            }
        }

        // 재조회 버튼 클릭시
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
    }        
}
