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
    public partial class NewMember : Form
    {
        //MySQL 연결 변수
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");
        //EMail 인증 난수
        public static Random randomNum = new Random();
        public static int emailcheck_num = randomNum.Next(10000000, 99999999);
        //전화번호 인증 난수
        public static Random randomNumTel = new Random();
        public static int telcheck_num = randomNumTel.Next(10000000, 99999999);

        //회원가입 진행 상태 bool형 변수
        public static bool id_check = false;
        public static bool pwd_check = false;
        public static bool gender_check = false;
        public static bool address_check = false;
        public static bool tel_check = false;
        public static bool birth_check = false;
        public static bool email_check = false;

        //CoolSMS API 사용
        SmsApi smsapi = new SmsApi(new SmsApiOptions
        {
            ApiKey = "NCSOPJRMYVLC9ZGS",
            ApiSecret = "RXWXXTZEUKGXX175IKXDB3BU43BWFPCE",
            DefaultSenderId = "01084295741"
        });

        public NewMember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void NewMember_Load(object sender, EventArgs e)
        {

        }

        // 아이디 중복 확인 버튼을 눌렀을 때
        private void btn_idcheck_Click(object sender, EventArgs e)
        {
            string insertQuery_idcheck = "SELECT *, COUNT(*) as cnt FROM library_project.member WHERE 아이디='" + txtbox_id.Text + "';";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery_idcheck, connection);
            MySqlDataReader reader = command.ExecuteReader();

            try
            {
                while(reader.Read() == true)
                {
                   string count_idcheck = reader["cnt"].ToString();
                    if (count_idcheck == "0")
                    {
                        MessageBox.Show("회원가입이 가능한 아이디입니다. 회원가입 절차를 계속 진행해 주세요.", "아이디 중복확인");
                        id_check = true;
                    }
                    else if (txtbox_id.Text == "")
                    {
                        MessageBox.Show("아이디 입력 후 버튼을 눌러주세요.", "아이디 중복확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("중복된 아이디로, 회원가입이 불가능합니다. 다른 아이디로 다시 시도해 주세요.", "아이디 중복확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "아이디 중복확인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        // 비밀번호 확인 (임시 보이기) 체크박스를 눌렀을 때
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtbox_pwd.UseSystemPasswordChar = false;
                txtbox_pwdcheck.UseSystemPasswordChar = false;
            }
            else
            {
                txtbox_pwd.UseSystemPasswordChar = true;
                txtbox_pwdcheck.UseSystemPasswordChar = true;
            }
        }

        // 비밀번호 텍스트 입력 부분에 입력값 변화가 생겼을 때
        private void txtbox_pwd_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_pwd.Text == txtbox_pwdcheck.Text)
            {
                label_pwdcheck.Text = "비밀번호 일치";
                label_pwdcheck.ForeColor = Color.Blue;
                pwd_check = true;
            }
            else if (txtbox_pwd.Text != txtbox_pwdcheck.Text)
            {
                label_pwdcheck.Text = "비밀번호 불일치";
                label_pwdcheck.ForeColor = Color.Red;
            }
            else if (txtbox_pwdcheck.Text != txtbox_pwd.Text)
            {
                label_pwdcheck.Text = "비밀번호 불일치";
                label_pwdcheck.ForeColor = Color.Red;
            }
            else
            {
                label_pwdcheck.Text = "";
            }
        }

        // 비밀번호 확인 텍스트 입력 부분에 입력값 변화가 생겼을 때
        private void txtbox_pwdcheck_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_pwd.Text == txtbox_pwdcheck.Text)
            {
                label_pwdcheck.Text = "비밀번호 일치";
                label_pwdcheck.ForeColor = Color.Blue;
                pwd_check = true;
            }
            else if (txtbox_pwd.Text != txtbox_pwdcheck.Text)
            {
                label_pwdcheck.Text = "비밀번호 불일치";
                label_pwdcheck.ForeColor = Color.Red;
            }
            else if (txtbox_pwdcheck.Text != txtbox_pwd.Text)
            {
                label_pwdcheck.Text = "비밀번호 불일치";
                label_pwdcheck.ForeColor = Color.Red;
            }
            else
            {
                label_pwdcheck.Text = "";
            }
        }

        // 전화번호 본인 인증 버튼을 눌렀을 때
        private void btn_telcheck_Click(object sender, EventArgs e)
        {
            if (comboBox_tel.Text == "" || maskedtxtBox_tel.Text == "")
            {
                MessageBox.Show("휴대폰 번호가 입력되지 않았습니다. 입력후 다시 시도해 주세요.");
            }
            else
            {
                var body = smsapi.SendMessageAsync(comboBox_tel.Text + maskedtxtBox_tel.Text, "일이삼사 도서관 본인인증 인증 번호입니다." + "[" + telcheck_num.ToString() + "]");
                MessageBox.Show("사용자의 휴대폰 번호 : " + comboBox_tel.Text + "-" + maskedtxtBox_tel.Text + "로 인증번호가 발송되었습니다. 인증번호를 올바르게 입력해 주세요.");
            }
        }

        // 전화번호 본인 인증 확인 버튼을 눌렀을 때
        private void btn_checktelnum_Click(object sender, EventArgs e)
        {
            if (txtbox_telchecknum.Text == telcheck_num.ToString())
            {
                MessageBox.Show("휴대폰 인증이 완료되었습니다. 회원가입을 진행해 주세요.", "인증 완료");
                tel_check = true;
            }
            else
            {
                MessageBox.Show("휴대폰 인증이 실패했습니다. 인증번호를 확인해 주세요.", "인증 실패");
            }
        }

        // EMail 인증 버튼을 눌렀을 때
        private void btn_emailcheck_Click(object sender, EventArgs e)
        {
            // 구글 계정 아이디와 외부 접근 KEY
            string SystemMailid = "praticecoding.h@gmail.com";
            string SystemMailPwd = "cthoxecsadvgxoat";

            // SMTP 이메일 이용
            MailMessage mail = new MailMessage();
            mail.To.Add(txtbox_email.Text + "@" + txtAddress.Text);
            mail.From = new MailAddress(SystemMailid);
            mail.Subject = "일이삼사 도서관 회원가입 본인인증 이메일 입니다.";
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

        // EMail 인증 확인 버튼을 눌렀을 때
        private void btn_emailchecknum_Click(object sender, EventArgs e)
        {
            if (txtbox_emailchecknum.Text == emailcheck_num.ToString())
            {
                MessageBox.Show("이메일 인증이 완료되었습니다. 회원가입을 진행해 주세요.", "인증 완료");
                email_check = true;
            }
            else
            {
                MessageBox.Show("이메일 인증이 실패했습니다. 인증번호를 확인해 주세요.", "인증 실패");
            }
        }

        // 회원가입 버튼을 눌렀을 때
        private void button2_Click(object sender, EventArgs e)
        {
            // 성별 정보 불러오기
            string gender = "";
            if (radiobtn_man.Checked)
            {
                gender = "남자";
            }
            else if (radiobtn_girl.Checked)
            {
                gender = "여자";
            }

            // 회원번호 생성
            string member_num = DateTime.Now.ToString("yyMMddhhmmss");

            // 회원가입일 생성
            string member_new_date = DateTime.Now.ToString("yyyy-MM-dd");

            // MySQL에 연결해서 정보 넘기기
            string insertQuery = "INSERT INTO library_project.member (회원번호, 이름, 아이디, 비밀번호, 성별, 주소, 연락처, 생년월일, 이메일, 가입일, 대출권수, 회원상태) VALUES ('" + member_num + "' ,'" + txtbox_name.Text + "' ,'" + txtbox_id.Text + "' ,'" + txtbox_pwd.Text + "' ,'" + gender + "' ,'" + txtbox_address.Text + "' ,'" + comboBox_tel.Text + "-" + maskedtxtBox_tel.Text + "' ,'" + maskedtxtbox_birth.Text + "' ,'" + txtbox_email.Text + "@" + txtAddress.Text + "' ,'" + member_new_date + "', '" + "0', '정상');";

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            try
            {
                if (id_check == true && pwd_check == true && tel_check == true && email_check == true)
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show(txtbox_name.Text + "회원님, 회원가입이 완료되었습니다.\n\n사용할 아이디 : " + txtbox_id.Text + "\n회원번호 : " + member_num + "입니다.\n\n확인 버튼을 누르시면 로그인 화면으로 돌아갑니다.", "회원가입 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else if (command.ExecuteNonQuery() != 1)
                    {
                        MessageBox.Show("비정상 입력 정보입니다. 재확인 바랍니다.", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("비정상 입력 정보입니다. 재확인 바랍니다.", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (txtbox_pwd.Text != txtbox_pwdcheck.Text)
                {
                    MessageBox.Show("비밀번호가 같지 않습니다. 재확인 바랍니다.", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (id_check == false && pwd_check == true && tel_check == true && email_check == true)
                {
                    MessageBox.Show("아이디 중복확인 후 회원가입 진행 바랍니다.", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (id_check == true && pwd_check == false && tel_check == true && email_check == true)
                {
                    MessageBox.Show("비밀번호 중복확인 후 회원가입 진행 바랍니다.", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (id_check == true && pwd_check == true && tel_check == false && email_check == true)
                {
                    MessageBox.Show("전화번호 본인인증 후 회원가입 진행 바랍니다.", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (id_check == true && pwd_check == true && tel_check == true && email_check == false)
                {
                    MessageBox.Show("이메일 본인인증 후 회원가입 진행 바랍니다.", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("모든 필드에 값이 입력되었는지 확인 후, 재 시도 바랍니다. (주소는 생략 가능합니다.).", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("빈 항목값 또는 형식에 맞지 않는 값이 있는지 확인 바랍니다. 오류가 지속될 경우, 하단의 '오류내용'을 토대로, 메인 화면의 '오류보고/개선요청' 으로 문의접수 바랍니다.\n\n오류내용 : " + ex.Message, "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        // 이전화면 돌아가기 버튼을 눌렀을 때
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}