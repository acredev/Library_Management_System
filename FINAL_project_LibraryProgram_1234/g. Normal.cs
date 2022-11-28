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
    public partial class Normal : Form
    {
        // <MySQL 연결 변수>
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");

        public Normal()
        {
            InitializeComponent();
        }

        private void Normal_Load(object sender, EventArgs e)
        {
            string insertQuery = "SELECT 제목, 내용 FROM library_project.board_notice;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_data_notice = new DataTable();
                adapter.Fill(load_data_notice);
                data_notice.DataSource = load_data_notice;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "로딩 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.Close();
                Main showMain = new Main();
                showMain.Show();
            }
        }

        private void btn_loanbook_Click(object sender, EventArgs e)
        {
            Normal_loanBook showLoan = new Normal_loanBook();
            showLoan.ShowDialog();
        }

        private void btn_searchbook_Click(object sender, EventArgs e)
        {
            Normal_SearchBook showSearch = new Normal_SearchBook();
            showSearch.ShowDialog();
        }

        private void btn_board_Click(object sender, EventArgs e)
        {
            Normal_Board showBoard = new Normal_Board();
            showBoard.ShowDialog();
        }

        private void btn_mypage_Click(object sender, EventArgs e)
        {
            Normal_Mypage showMypage = new Normal_Mypage();
            showMypage.ShowDialog();
        }

        private void btn_qna_Click(object sender, EventArgs e)
        {
            Normal_Qna showQna = new Normal_Qna();
            showQna.ShowDialog();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 도서관리 시스템을 종료하시겠습니까?", "종료하기", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
