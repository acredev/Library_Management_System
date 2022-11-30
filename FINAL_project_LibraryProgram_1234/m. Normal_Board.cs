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
    public partial class Normal_Board : Form
    {
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");
        public Normal_Board()
        {
            InitializeComponent();
        }

        // 폼 로드시 게시판 정보들을 모두 불러옴
        private void Normal_Board_Load(object sender, EventArgs e)
        {
            string insertQuery_loadNotice = "SELECT 제목, 내용 FROM library_project.board_notice;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery_loadNotice, connection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_data_notice = new DataTable();
                adapter.Fill(load_data_notice);
                data_notice.DataSource = load_data_notice;

                string insertQuery_loadFree = "SELECT 작성자, 제목, 내용 FROM library_project.board_free";
                MySqlCommand command2 = new MySqlCommand(insertQuery_loadFree, connection);
                MySqlDataAdapter adapter2 = new MySqlDataAdapter(command2);
                DataTable load_data_free = new DataTable();
                adapter2.Fill(load_data_free);
                data_free.DataSource = load_data_free;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        // 돌아가기 버튼 클릭시
        private void btn_main_click_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("이전 화면으로 돌아가시겠습니까?", "돌아가기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                Normal showNormal = new Normal();
                showNormal.Show();
            }
        }

        // 문의하기/개선요청 버튼 클릭시
        private void picture_support_Click(object sender, EventArgs e)
        {
            SupportMail showSupportMail = new SupportMail();
            showSupportMail.ShowDialog();
        }

        // 로그아웃 버튼 클릭 시
        private void picture_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 후 메인화면으로 돌아가시겠습니까?", "로그아웃", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        // 공지사항 data 클릭 시 각 정보들을 txtview에 뿌려줌
        private void data_notice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_notice_title.Text = data_notice.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_notice_body.Text = data_notice.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }

        // 자유 게시판 data 클릭 시 각 정보들을 txtview에 뿌려줌
        private void data_free_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_free_title.Text = data_free.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_free_who.Text = data_free.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtbox_free_body.Text = data_free.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }

        // 자유게시판 열람모드를 읽기전용으로 체크시
        private void rdobtn_free_readonly_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtn_free_readonly.Checked == true)
            {
                txtbox_free_who.ReadOnly = true;
                txtbox_free_title.ReadOnly = true;
                txtbox_free_body.ReadOnly = true;

                txtbox_free_who.Text = "";
                txtbox_free_title.Text = "";
                txtbox_free_body.Text = "";
            }
            
        }

        private void rdobtn_free_new_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtn_free_new.Checked == true)
            {
                txtbox_free_who.ReadOnly = true;
                txtbox_free_title.ReadOnly = false;
                txtbox_free_body.ReadOnly = false;

                txtbox_free_who.Text = "자동 입력되며, 수정할 수 없습니다.";
                txtbox_free_title.Text = "";
                txtbox_free_body.Text = "";
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (rdobtn_free_readonly.Checked == true)
            {
                MessageBox.Show("신규 작성 모드에서만 게시글 작성이 가능합니다. 모드를 변경 후 진행 바랍니다.");
            }
            else if (rdobtn_free_new.Checked == true)
            {
                string insertQuery = "INSERT INTO library_project.board_free (작성자, 회원번호, 제목, 내용) VALUES ('" + Normal.static_memname + "', '" + Normal.static_memnum + "', '" + txtbox_free_title.Text + "', '" + txtbox_free_body.Text + "');";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    if (command.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("신규등록 요청하신 공지사항 제목 : " + txtbox_free_title.Text + " 게시글이 데이터베이스에 등록되었습니다. 조회 버튼을 눌러, 게시판 목록을 다시 재 조회 바랍니다.");

                        // 텍스트박스 화면 초기화
                        txtbox_free_body.Text = "";
                        txtbox_free_title.Text = "";
                        txtbox_free_who.Text = "";
                        txtbox_notice_body.Text = "";
                        txtbox_notice_title.Text = "";

                        // 데이터 조회 화면 초기화
                        data_notice.DataSource = "";
                        data_free.DataSource = "";
                    }
                    else
                    {
                        MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "게시글 등록 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "게시글 등록 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("글 모드를 선택 후 진행 바랍니다.");
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            string insertQuery_loadNotice = "SELECT 제목, 내용 FROM library_project.board_notice;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery_loadNotice, connection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_data_notice = new DataTable();
                adapter.Fill(load_data_notice);
                data_notice.DataSource = load_data_notice;

                string insertQuery_loadFree = "SELECT 작성자, 제목, 내용 FROM library_project.board_free";
                MySqlCommand command2 = new MySqlCommand(insertQuery_loadFree, connection);
                MySqlDataAdapter adapter2 = new MySqlDataAdapter(command2);
                DataTable load_data_free = new DataTable();
                adapter2.Fill(load_data_free);
                data_free.DataSource = load_data_free;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

            // 텍스트박스 화면 초기화
            txtbox_free_body.Text = "";
            txtbox_free_title.Text = "";
            txtbox_free_who.Text = "";
            txtbox_notice_body.Text = "";
            txtbox_notice_title.Text = "";

            // 라디오 버튼 다시 열람모드로 변경
            rdobtn_free_readonly.Checked = true;
        }
    }
}
