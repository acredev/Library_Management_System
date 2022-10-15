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
using System.Net.Mail;
using System.Net;

namespace FINAL_project_LibraryProgram_1234
{
    public partial class NewMember : Form
    {
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=member1;Uid=root;Pwd=root;");
        public static Random randomNum = new Random();
        public static int emailcheck_num = randomNum.Next(10000000, 99999999);
        public static int idcheck_status = 0;
        public static int pwdcheck_status = 0;
        public static int emailcheck_status = 0;
        public static int telcheck_status = 0;

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

        private void button2_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (radiobtn_man.Checked)
            {
                gender = "남자";
            }
            else if (radiobtn_girl.Checked)
            {
                gender = "여자";
            }

            string insertQuery = "INSERT INTO member (이름, 아이디, 비밀번호, 성별, 주소, 연락처, 생년월일, 이메일) VALUES ('" + txtbox_name.Text + "' ,'" + txtbox_id.Text + "' ,'" + txtbox_pwd.Text + "' ,'" + gender + "' ,'" + txtbox_address.Text + "' ,'" + comboBox_tel.Text + "-" + maskedtxtBox_tel.Text + "' ,'" + maskedtxtbox_birth.Text + "' ,'" + txtbox_email.Text + "@" + txtAddress.Text + "');";

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            try
            {
                if (txtbox_pwd.Text == txtbox_pwdcheck.Text)
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show(txtbox_name.Text + "회원님, 회원가입이 완료되었습니다.\n\n사용하실 아이디는 " + txtbox_id.Text + "입니다.\n\n확인 버튼을 누르시면 로그인 화면으로 돌아갑니다.", "회원가입 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            catch(Exception ex)
            {
                MessageBox.Show("모든 항목은 필수 입력 항목입니다. 빈 항목값 또는 형식에 맞지 않는 값이 있는지 확인 바랍니다. \n\n오류내용 : " + ex.Message, "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

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

        private void txtbox_pwdcheck_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_pwd.Text == txtbox_pwdcheck.Text)
            {
                label_pwdcheck.Text = "비밀번호 일치";
                label_pwdcheck.ForeColor = Color.Blue;
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

        private void txtbox_pwd_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_pwd.Text == txtbox_pwdcheck.Text)
            {
                label_pwdcheck.Text = "비밀번호 일치";
                label_pwdcheck.ForeColor = Color.Blue;
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

        private void btn_emailcheck_Click(object sender, EventArgs e)
        {
            string SystemMailid = "praticecoding.h@gmail.com";
            string SystemMailPwd = "cthoxecsadvgxoat";

            MailMessage mail = new MailMessage();
            mail.To.Add(txtbox_email.Text + "@" + txtAddress.Text);
            mail.From = new MailAddress(SystemMailid);
            mail.Subject = "일이삼사 도서관 회원가입 본인인증 이메일 입니다.";
            mail.Body = emailcheck_num.ToString();

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

        private void btn_emailchecknum_Click(object sender, EventArgs e)
        {
            if(txtbox_emailchecknum.Text == emailcheck_num.ToString())
            {
                MessageBox.Show("이메일 인증이 완료되었습니다. 회원가입을 진행해 주세요.", "인증 완료");
                emailcheck_status = 1;
            }
            else
            {
                MessageBox.Show("이메일 인증이 실패했습니다. 인증번호를 확인해 주세요.", "인증 실패");
            }
        }

        private void btn_idcheck_Click(object sender, EventArgs e)
        {

        }

        private void btn_telcheck_Click(object sender, EventArgs e)
        {

        }
    }
}
