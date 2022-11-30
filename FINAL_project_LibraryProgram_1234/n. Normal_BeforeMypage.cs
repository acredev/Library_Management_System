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
    public partial class Normal_BeforeMypage : Form
    {
        // <MySQL 연결 변수>
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");

        // 폼 로드시 비밀번호를 불러와 해당 변수에 저장
        private static string static_mempwd = string.Empty;

        public Normal_BeforeMypage()
        {
            InitializeComponent();
        }

        private void Normal_BeforeMypage_Load(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "SELECT 비밀번호 FROM library_project.member WHERE 회원번호 = '" + Normal.static_memnum + "';";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read() == true)
                {
                    static_mempwd = reader["비밀번호"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("비정상 접근입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "로딩 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            if (static_mempwd == txtbox_pwd.Text)
            {
                MessageBox.Show("비밀번호 확인이 완료되었습니다.");
                this.Close();

                Normal_Mypage showMyPage = new Normal_Mypage();
                showMyPage.ShowDialog();

            }
            else
            {
                MessageBox.Show("회원정보에 등록된 비밀번호와 일치하지 않습니다. 다시 시도해 주세요.", "비밀번호 확인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
