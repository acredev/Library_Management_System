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
    public partial class Normal_Find_ID : Form
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

        public Normal_Find_ID()
        {
            InitializeComponent();
        }

        // 폼 로드시
        private void _8_Load(object sender, EventArgs e)
        {
            MessageBox.Show("전화번호 입력시 - 를 제외하고 입력 바랍니다. \n\n 예시 : 01012341234");
        }

        // 전화번호로 찾기 버튼 클릭시
        private void rdobtn_telcheck_CheckedChanged(object sender, EventArgs e)
        {
            label_teloremail.Text = "전화번호";
            if (rdobtn_telcheck.Checked == true)
            {
                MessageBox.Show("전화번호 입력시 - 없이 입력 바랍니다. \n\n 예시 : 01012341234");
            }
        }

        // 이메일로 찾기 버튼 클릭시
        private void rdobtn_emailcheck_CheckedChanged(object sender, EventArgs e)
        {
            label_teloremail.Text = "이메일 주소";
        }

        // 인증번호 발송 클릭시
        private void btn_sendnum_Click(object sender, EventArgs e)
        {
            // SMS로 인증번호 발송
            if (rdobtn_telcheck.Checked == true && rdobtn_emailcheck.Checked == false)
            {
                if (txtbox_teloremail.Text == "")
                {
                    MessageBox.Show("전화번호 입력 후 재 시도 바랍니다.", "아이디 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var body = smsapi.SendMessageAsync(txtbox_teloremail.Text, "일이삼사 도서관 본인인증 인증 번호입니다." + "[" + randomSMS_num.ToString() + "]");
                    MessageBox.Show("사용자의 휴대폰 번호 : " + txtbox_teloremail.Text + "로 인증번호가 발송되었습니다. 인증번호를 올바르게 입력해 주세요.");
                }
            }
            // 이메일로 인증번호 발송
            else if (rdobtn_telcheck.Checked == false && rdobtn_emailcheck.Checked == true)
            {
                if (txtbox_teloremail.Text == "")
                {
                    MessageBox.Show("이메일 주소 입력 후 재 시도 바랍니다.", "아이디 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // 구글 계정 아이디와 외부 접근 KEY
                    string SystemMailId = "praticecoding.h@gmail.com";
                    string SystemMailPwd = "cthoxecsadvgxoat";

                    // SMTP 이메일 이용
                    MailMessage mail = new MailMessage();
                    mail.To.Add(txtbox_teloremail.Text);
                    mail.From = new MailAddress(SystemMailId);
                    mail.Subject = "일이삼사 도서관 아이디 찾기 본인인증 이메일 입니다.";
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

                        MessageBox.Show("사용자의 이메일 주소 : " + txtbox_teloremail.Text + "로 인증번호가 발송되었습니다. 인증번호를 올바르게 입력해 주세요.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("이메일 발송 오류입니다. Google SMTP 서버 문제일 수 있습니다. 메인 화면의 '오류보고 / 개선요청' 항목에서 문의 접수 바랍니다. \n\n 오류 메시지 : " + ex.ToString(), "아이디 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 인증하기 클릭시
        private void btn_checknum_Click(object sender, EventArgs e)
        {
            // SMS로 인증
            if (rdobtn_telcheck.Checked == true && rdobtn_emailcheck.Checked == false)
            {
                if (txtbox_checknum.Text == randomSMS_num.ToString())
                {
                    MessageBox.Show("휴대폰 인증이 완료되었습니다. 아이디 찾기 과정을 진행해 주세요.", "인증 완료");
                    telcheck = true;
                }
                else
                {
                    MessageBox.Show("휴대폰 인증이 실패했습니다. 인증번호 확인 후 재시도 바랍니다.", "인증 실패");
                    telcheck = false;
                }
            }

            // 이메일로 인증
            else if (rdobtn_telcheck.Checked == false && rdobtn_telcheck.Checked == true)
            {
                if (txtbox_checknum.Text == randomEMail_num.ToString())
                {
                    MessageBox.Show("이메일 인증이 완료되었습니다. 아이디 찾기 과정을 진행해 주세요.", "인증 완료");
                    emailcheck = true;
                }
                else
                {
                    MessageBox.Show("이메일 인증이 실패했습니다. 인증번호 확인 후 재시도 바랍니다.", "인증 실패");
                }
            }
        }

        // 아이디 찾기 클릭시
        private void button1_Click(object sender, EventArgs e)
        {
            if (telcheck == true && emailcheck == false)
            {
                string insertQuery_idfind = "SELECT *, COUNT(*) as cnt FROM member1.member WHERE 이름 = '" + txtbox_name.Text + "' && 연락처 = '" + txtbox_teloremail.Text + "';";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery_idfind, connection);
                MySqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read() == true)
                    {
                        string idfind_result_cnt = reader["cnt"].ToString();
                        string idfind_result = reader["아이디"].ToString();
                        if (idfind_result_cnt == "0")
                        {
                            MessageBox.Show("회원가입되어 있지 않은 정보입니다.");
                        }
                        else
                        {
                            MessageBox.Show("요청하신 아이디는 " + idfind_result + "입니다.");
                            Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB 연결 오류입니다. 메인 화면의 '오류보고 / 개선요청' 항목으로 진입해 오류를 보고해 주세요. 불편을 드려 죄송합니다. \n\n오류내용 : " + ex.Message, "아이디 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }

            else if (telcheck == false && emailcheck == true)
            {
                string insertQuery_idfind = "SELECT *, COUNT(*) as cnt FROM member1.member WHERE 이름 = '" + txtbox_name.Text + "' && 이메일 = '" + txtbox_teloremail.Text + "';";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery_idfind, connection);
                MySqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read() == true)
                    {
                        string idfind_result_cnt = reader["cnt"].ToString();
                        string idfind_result = reader["아이디"].ToString();
                        if (idfind_result_cnt == "0")
                        {
                            MessageBox.Show("회원가입되어 있지 않은 정보입니다.");
                        }
                        else
                        {
                            MessageBox.Show("요청하신 아이디는 " + idfind_result + "입니다.");
                            Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB 연결 오류입니다. 메인 화면의 '오류보고 / 개선요청' 항목으로 진입해 오류를 보고해 주세요. 불편을 드려 죄송합니다. \n\n오류내용 : " + ex.Message, "아이디 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
            else if (telcheck == false && emailcheck == false)
            {
                MessageBox.Show("회원정보에 등록된 전화번호, 또는 이메일 주소로 본인인증 후 아이디 찾기를 진행해 주시기 바랍니다.", "아이디 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 비밀번호 찾기 클릭시
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Normal_Find_PW shownormal_Find_PW = new Normal_Find_PW();
            shownormal_Find_PW.Show();
        }

        // 이전화면 돌아가기 클릭시
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
