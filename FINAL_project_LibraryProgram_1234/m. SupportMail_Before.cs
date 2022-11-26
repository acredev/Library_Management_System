using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail; // email
using System.Net; // email
using CoolSms; // sms

namespace FINAL_project_LibraryProgram_1234
{
    public partial class SupportMail_Before : Form
    {
        public static bool telcheck = false;
        public static bool emailcheck = false;

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

        // SupportMail 폼으로 전화번호 또는 이메일 주소를 불러오기 위한 전역변수
        public static string user_tel;
        public static string user_email;
        public SupportMail_Before()
        {
            InitializeComponent();
        }

        private void rdobtn_telcheck_CheckedChanged(object sender, EventArgs e)
        {
            label_teloremail.Text = "전화번호";
            if (rdobtn_telcheck.Checked == true)
            {
                MessageBox.Show("전화번호 입력 시, - 없이 입력 바랍니다. \n\n ex) 01012341234");
            }
        }

        private void rdobtn_emailcheck_CheckedChanged(object sender, EventArgs e)
        {
            label_teloremail.Text = "이메일 주소";
            if (rdobtn_emailcheck.Checked == true)
            {
                MessageBox.Show("이메일 주소를 형식에 맞게 정확하게 입력해 주세요. \n\n ex) 1234@libary.com");
            }
        }

        private void btn_sendnum_Click(object sender, EventArgs e)
        {
            if (rdobtn_telcheck.Checked == true && rdobtn_emailcheck.Checked == false)
            {
                var body = smsapi.SendMessageAsync(txtbox_teloremail.Text, "일이삼사 도서관 본인인증 인증 번호입니다." + "[" + randomSMS_num.ToString() + "]");
                MessageBox.Show(txtbox_teloremail.Text + "번으로 인증번호가 발송되었습니다. 인증번호를 올바르게 입력해 주세요.");
                user_tel = txtbox_teloremail.Text;
            }
            else if (rdobtn_telcheck.Checked == false && rdobtn_emailcheck.Checked == true)
            {
                user_email = txtbox_teloremail.Text;
                // 구글 계정 아이디와 외부 접근 KEY
                string SystemMailId = "praticecoding.h@gmail.com";
                string SystemMailPwd = "cthoxecsadvgxoat";

                // SMTP 이메일 이용
                MailMessage mail = new MailMessage();
                mail.To.Add(txtbox_teloremail.Text);
                mail.From = new MailAddress(SystemMailId);
                mail.Subject = "일이삼사 도서관 본인인증 이메일 입니다.";
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

                    MessageBox.Show(txtbox_teloremail.Text + "이메일 주소로 인증번호가 발송되었습니다. 인증번호를 올바르게 입력해 주세요.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("이메일 발송 오류입니다. Google SMTP 서버 문제일 수 있습니다. 메인 화면의 '오류보고 / 개선요청' 항목에서 문의 접수 바랍니다. \n\n 오류 메시지 : " + ex.ToString(), "아이디 찾기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("본인인증 방식을 선택 후 시도해 주세요.");
            }
        }

        private void btn_checknum_Click(object sender, EventArgs e)
        {
            if (rdobtn_telcheck.Checked == true && rdobtn_emailcheck.Checked == false)
            {
                if (txtbox_checknum.Text == randomSMS_num.ToString())
                {
                    MessageBox.Show("휴대폰 인증이 완료되었습니다.", "인증 완료");
                    telcheck = true;
                    emailcheck = false;
                }
                else
                {
                    MessageBox.Show("휴대폰 인증이 실패했습니다. 인증번호 확인 후 재시도 바랍니다.", "인증 실패");
                    telcheck = false;
                    emailcheck = false;
                }
            }
            else if (rdobtn_telcheck.Checked == false && rdobtn_emailcheck.Checked == true)
            {
                if (txtbox_checknum.Text == randomEMail_num.ToString())
                {
                    MessageBox.Show("이메일 인증이 완료되었습니다.", "인증 완료");
                    telcheck = false;
                    emailcheck = true;
                }
                else
                {
                    MessageBox.Show("이메일 인증이 실패했습니다. 인증번호 확인 후 재시도 바랍니다.", "인증 실패");
                    telcheck = false;
                    emailcheck = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (telcheck == true && emailcheck == false)
            {
                MessageBox.Show(user_tel + "회원님으로 임시 로그인 되었습니다.");
                this.Visible = false;
                SupportMail showSupportMail = new SupportMail();
                showSupportMail.ShowDialog();
            }
            else if (telcheck == false && emailcheck == true)
            {
                MessageBox.Show(user_email + "회원님으로 임시 로그인 되었습니다.");
                this.Visible = false;
                SupportMail showSupportMail = new SupportMail();
                showSupportMail.ShowDialog();
            }
            else
            {
                MessageBox.Show("본인인증 후 시도 바랍니다.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SupportMail_Before_Load(object sender, EventArgs e)
        {
            MessageBox.Show("스팸 방지를 위해 비로그인 사용자는 본인인증 후 해당 메뉴에 접근이 가능합니다. \n\n 전화번호 또는 이메일 주소를 각 형식에 맞게 정확하게 입력해 주세요. \n\n 전화번호 ex) 01012341234 \n 이메일 ex) 1234@library.com");
        }
    }
}
