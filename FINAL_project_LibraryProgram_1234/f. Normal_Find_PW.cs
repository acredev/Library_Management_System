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
using CoolSms; // CoolSMS NuGET Package 사용 참조

namespace FINAL_project_LibraryProgram_1234
{
    public partial class Normal_Find_PW : Form
    {
        public static bool telcheck = false;
        public static bool emailcheck = false;

        //MySQL 연결 변수
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=member1;Uid=root;Pwd=root;");

        //CoolSMS API 사용
        SmsApi smsapi = new SmsApi(new SmsApiOptions
        {
            ApiKey = "NCSOPJRMYVLC9ZGS",
            ApiSecret = "RXWXXTZEUKGXX175IKXDB3BU43BWFPCE",
            DefaultSenderId = "01084295741"
        });

        // SMS 인증 난수
        public static Random randomSMS = new Random();
        public static int randomSMS_num = randomSMS.Next(10000000, 99999999);

        // EMail 인증 난수
        public static Random randomEMail = new Random();
        public static int randomEMail_num = randomEMail.Next(10000000, 99999999);

        // 개인정보 조회결과 변수
        public static string pwdfind_result_tel;
        public static string pwdfind_result_email;

        public Normal_Find_PW()
        {
            InitializeComponent();
        }

        // 폼 로드시
        private void Normal_Find_PW_Load(object sender, EventArgs e)
        {
            MessageBox.Show("아이디 조회 시, 회원정보에 입력된 전화번호와 이메일이 자동으로 입력됩니다.");
        }

        // 전화번호 인증 라디오 버튼 클릭시
        private void rdobtn_telcheck_CheckedChanged(object sender, EventArgs e)
        {
            label_teloremail.Text = "전화번호";
            if (rdobtn_telcheck.Checked == true)
            {
                MessageBox.Show("아이디 조회 시, 회원정보에 입력된 전화번호가 자동으로 입력됩니다.");
            }
        }

        // 이메일 인증 라디오 버튼 클릭시
        private void rdobtn_emailcheck_CheckedChanged(object sender, EventArgs e)
        {
            label_teloremail.Text = "이메일 주소";
            if (rdobtn_emailcheck.Checked == true)
            {
                MessageBox.Show("아이디 조회 시, 회원정보에 입력된 이메일이 자동으로 입력됩니다.", "비밀번호 찾기", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 아이디 조회 클릭시
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtbox_name.Text == "" || txtbox_id.Text == "")
            {
                MessageBox.Show("회원정보에 등록된 아이디와 이름을 정확하게 입력 후 진행해 주시기 바랍니다.", "비밀번호 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtbox_name.Text == "" && txtbox_id.Text == "")
            {
                MessageBox.Show("회원정보에 등록된 아이디와 이름을 정확하게 입력 후 진행해 주시기 바랍니다.", "비밀번호 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string insertQuery_pwdfind = "SELECT *, COUNT(*) as cnt FROM member1.member WHERE 이름 = '" + txtbox_name.Text + "' && 아이디 = '" + txtbox_id.Text + "';";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery_pwdfind, connection);
                MySqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read() == true)
                    {
                        string pwdfind_result_cnt = reader["cnt"].ToString();
                        pwdfind_result_tel = reader["연락처"].ToString();
                        pwdfind_result_email = reader["이메일"].ToString();
                        if (pwdfind_result_cnt == "0")
                        {
                            MessageBox.Show("회원가입되어 있지 않은 정보입니다.", "아이디 조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("아이디 조회가 완료 되었습니다. 다음 절차를 진행해 주세요.", "아이디 조회 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (rdobtn_telcheck.Checked == true && rdobtn_emailcheck.Checked == false)
                            {
                                label_teloremail.Text = "전화번호";

                                char[] pwdfind_result_tel_arr = pwdfind_result_tel.ToCharArray();
                                string pwdfind_result_tel_masked = "";
                                int i = 0;
                                foreach (char mask in pwdfind_result_tel_arr)
                                {
                                    if (i == 4)
                                    {
                                        pwdfind_result_tel_masked += "*";
                                    }
                                    else
                                    {
                                        pwdfind_result_tel_masked += mask;
                                    }
                                    i++;
                                }
                                txtbox_teloremail.Text = pwdfind_result_tel_masked;
                            }
                            else if (rdobtn_telcheck.Checked == false && rdobtn_emailcheck.Checked == true)
                            {
                                label_teloremail.Text = "이메일 주소";
                                char[] pwdfind_result_email_arr = pwdfind_result_email.ToCharArray();
                                string pwdfind_result_email_masked = "";
                                int i = 0;
                                foreach (char mask in pwdfind_result_email_arr)
                                {
                                    if (i == 4)
                                    {
                                        pwdfind_result_email_masked += "*";
                                    }
                                    else
                                    {
                                        pwdfind_result_email_masked += mask;
                                    }
                                    i++;
                                }
                                txtbox_teloremail.Text = pwdfind_result_email_masked;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB 연결 오류입니다. 메인 화면의 '오류보고 / 개선요청' 항목으로 진입해 오류를 보고해 주세요. 불편을 드려 죄송합니다. \n\n오류내용 : " + ex.Message, "비밀번호 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }

        // 인증번호 받기 클릭시
        private void btn_sendnum_Click(object sender, EventArgs e)
        {
            if (rdobtn_telcheck.Checked == true)
            {
                if (txtbox_teloremail.Text == "아이디 조회 후 자동 입력됩니다.")
                {
                    MessageBox.Show("아이디 조회 절차를 거친 후 재 시도 바랍니다.", "비밀번호 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var body = smsapi.SendMessageAsync(pwdfind_result_tel, "일이삼사 도서관 본인인증 인증 번호입니다." + "[" + randomSMS_num.ToString() + "]");
                    MessageBox.Show("회원정보에 등록된 사용자의 휴대폰 번호로 인증번호가 발송되었습니다. 인증번호를 올바르게 입력해 주세요.", "본인인증", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }   
            else if (rdobtn_emailcheck.Checked == true)
            {
                if (txtbox_teloremail.Text == "아이디 조회 후 자동 입력됩니다.")
                {
                    MessageBox.Show("아이디 조회 절차를 거친 후 재 시도 바랍니다.", "비밀번호 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // 구글 계정 아이디와 외부 접근 KEY
                    string SystemMailId = "praticecoding.h@gmail.com";
                    string SystemMailPwd = "cthoxecsadvgxoat";

                    // SMTP 이메일 이용
                    MailMessage mail = new MailMessage();
                    mail.To.Add(pwdfind_result_email);
                    mail.From = new MailAddress(SystemMailId);
                    mail.Subject = "일이삼사 도서관 비밀번호 찾기 본인인증 이메일 입니다.";
                    mail.Body = randomEMail_num.ToString();
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;
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
                    smtp.Credentials = new System.Net.NetworkCredential(SystemMailId, SystemMailPwd);

                    try
                    {
                        smtp.Send(mail);
                        smtp.Dispose();

                        MessageBox.Show("회원정보에 등록된 사용자의 이메일 주소로 인증번호가 발송되었습니다. 인증번호를 올바르게 입력해 주세요.", "본인인증", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("이메일 발송 오류입니다. Google SMTP 서버 문제일 수 있습니다. 메인 화면의 '오류보고 / 개선요청' 항목에서 문의 접수 바랍니다. 불편을 드려 죄송합니다.\n\n오류 메시지 : " + ex.ToString(), "비밀번호 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("알 수 없는 프로그램 오류입니다. 메인 화면의 '오류보고 / 개선요청' 항목으로 진입해 오류를 보고해 주세요. 불편을 드려 죄송합니다.", "비밀번호 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 인증하기 버튼 클릭시
        private void btn_checknum_Click(object sender, EventArgs e)
        {
            // SMS로 인증
            if (rdobtn_telcheck.Checked == true && rdobtn_emailcheck.Checked == false)
            {
                if (txtbox_checknum.Text == randomSMS_num.ToString())
                {
                    MessageBox.Show("휴대폰 인증이 완료되었습니다. 비밀번호 찾기 과정을 진행해 주세요.", "인증 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    telcheck = true;
                }
                else
                {
                    MessageBox.Show("휴대폰 인증이 실패했습니다. 인증번호 확인 후 재시도 바랍니다.", "인증 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    telcheck = false;
                }
            }

            // 이메일로 인증
            else if (rdobtn_telcheck.Checked == false && rdobtn_emailcheck.Checked == true)
            {
                if (txtbox_checknum.Text == randomEMail_num.ToString())
                {
                    MessageBox.Show("이메일 인증이 완료되었습니다. 비밀번호 찾기 과정을 진행해 주세요.", "인증 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    emailcheck = true;
                }
                else
                {
                    MessageBox.Show("이메일 인증이 실패했습니다. 인증번호 확인 후 재시도 바랍니다.", "인증 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // 비밀번호 찾기 클릭시
        private void button1_Click(object sender, EventArgs e)
        {
            const string randomchars = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder();
            Random randompwd = new Random();
            int length = 10;

            for (int i=0; i<length; i++)
            {
                int index = randompwd.Next(randomchars.Length);
                {
                    builder.Append(randomchars[index]);
                }
            }

            string randompwd_result = builder.ToString();
            if (telcheck == true || emailcheck == true)
            {
                string insertQuery_pwdfind = "UPDATE member1.member SET 비밀번호 = '" + randompwd_result + "' WHERE 아이디 = '" + txtbox_id.Text + "';";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery_pwdfind, connection);

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        if (rdobtn_telcheck.Checked == true && rdobtn_emailcheck.Checked == false)
                        {
                            var body = smsapi.SendMessageAsync(pwdfind_result_tel, "일이삼사 도서관 임시 비밀번호입니다." + "[" + randompwd_result.ToString() + "]");
                            MessageBox.Show("임시 비밀번호가 사용자의 전화번호로 발송되었습니다. 보안을 위해 임시 비밀번호로 로그인 후, 비밀번호 변경 절차를 거쳐 주세요.", "비밀번호 찾기", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else if (rdobtn_telcheck.Checked == false && rdobtn_emailcheck.Checked == true)
                        {
                            // 구글 계정 아이디와 외부 접근 KEY
                            string SystemMailid = "praticecoding.h@gmail.com";
                            string SystemMailPwd = "cthoxecsadvgxoat";

                            // SMTP 이메일 이용
                            MailMessage mail = new MailMessage();
                            mail.To.Add(pwdfind_result_email);
                            mail.From = new MailAddress(SystemMailid);
                            mail.Subject = "일이삼사 도서관 임시 비밀번호 안내 이메일 입니다.";
                            mail.Body = randompwd_result.ToString();
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

                                MessageBox.Show("임시 비밀번호가 사용자의 이메일로 발송되었습니다. 보안을 위해 임시 비밀번호로 로그인 후, 비밀번호 변경 절차를 거쳐 주세요.", "비밀번호 찾기", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("이메일 발송 오류입니다. 이메일 주소 또는 네트워크 상태를 확인해 주세요." + ex.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 프로그램 오류입니다. 메인 화면의 '오류보고 / 개선요청' 항목으로 진입해 오류를 보고해 주세요. 불편을 드려 죄송합니다.", "비밀번호 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("프로그램 오류입니다. 메인 화면의 '오류보고 / 개선요청' 항목으로 진입해 오류를 보고해 주세요. 불편을 드려 죄송합니다. \n\n오류내용 : " + ex.Message, "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("본인인증 절차를 거친 후 진행 바랍니다.", "비밀번호 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 아이디 찾기 클릭시
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Normal_Find_ID shownormal_Find_ID = new Normal_Find_ID();
            shownormal_Find_ID.Show();
        }
        // 로그인 화면 돌아가기 버튼 클릭 시
        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
