using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace FINAL_project_LibraryProgram_1234
{
    public partial class SupportMail : Form
    {
        public SupportMail()
        {
            InitializeComponent();
			txtBody.Text = "<<< 시스템 기본정보 >>> " + "\r\n";
			txtBody.Text += "※ 정확한 오류 문의를 위해 아래의 내용을 지우지 마세요." + "\r\n";
			txtBody.Text += "1. NetBIOS 이름 : " + Environment.MachineName.ToString() + "\r\n";
			txtBody.Text += "2. 윈도우 OS 버전 : " + Environment.OSVersion.ToString() + "\r\n";
			txtBody.Text += "3. 윈도우 상세버전 : " + Environment.Version.ToString() + "\r\n";
			txtBody.Text += "-------------------------------------------------------" + "\r\n";
			txtBody.Text += "-------------------------------------------------------" + "\r\n";
			txtBody.Text += "● 문의 내용 : "+ "\r\n";
			txtBody.Text += "● 개선 요구사항 : " + "\r\n";

			DateTime nowDate = DateTime.Now;
			txtSubject.Text = "[" + nowDate.Year + "-" + nowDate.Month + "-" + nowDate.Day + "] " + "일이삼사 도서관 오류버그 / 개선요청";
		}

        private void btnSendMail_Click(object sender, EventArgs e)
        {
			MailMessage mail = new MailMessage();
			if (txtFrom.Text == "")
            {
				MessageBox.Show("회신 받을 메일 주소를 입력 바랍니다.", "오류");
            }
			mail.From = new MailAddress(txtFrom.Text + "@" + txtAddress.Text, "일이삼사 도서관 문의접수", System.Text.Encoding.UTF8);
			mail.To.Add(txtTo.Text);
			mail.Subject = txtSubject.Text;
			mail.Body = txtBody.Text + "\r\n" + "-------------------------------------------------------" + "\r\n" + "★ 문의자 : " + txtFrom.Text + "@" + txtAddress.Text;

			mail.IsBodyHtml = false;
			mail.Priority = MailPriority.High;
			mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

			mail.SubjectEncoding = Encoding.UTF8;
			mail.BodyEncoding = Encoding.UTF8;

			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.Port = 587;
			smtp.Timeout = 10000;
			smtp.UseDefaultCredentials = true;
			smtp.EnableSsl = true;
			smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtp.Credentials = new System.Net.NetworkCredential("praticecoding.h@gmail.com", "cthoxecsadvgxoat");

			try
			{
				smtp.Send(mail);
				mail.Dispose();

				MessageBox.Show("문의 메일이 정상적으로 전송 완료 되었습니다. 감사합니다." + "\r\n\r\n" + "입력해주신 " + txtFrom.Text + "@" + txtAddress.Text + " 주소로 답변 드리겠습니다.", "문의 메일 정상 전송 완료");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

        private void txtBody_TextChanged(object sender, EventArgs e)
        {

		}

        private void button2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("문의 내용을 전부 폐기하고 이전 화면으로 돌아가시겠습니까?", "종료하기", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.Close();
			}
		}

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {

        }

        private void SupportMail_Load(object sender, EventArgs e)
        {

        }
    }
}
