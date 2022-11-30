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

namespace FINAL_project_LibraryProgram_1234
{
    public partial class Normal_Qna : Form
    {
        //MySQL 연결 변수
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");

        //회원정보 저장변수
        private static string memNum = string.Empty;
        private static string memName = string.Empty;
        private static string memEMail = string.Empty;

        public Normal_Qna()
        {
            InitializeComponent();
        }

        // 폼 로드시 QnA DB 정보를 DataGridView에 띄워주고,
        // 동시에 회원정보를 가져와 private static 변수에 저장함
        private void Normal_Qna_Load(object sender, EventArgs e)
        {
            string insertQuery = "SELECT 제목, 내용 FROM library_project.board_qna;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_data_qna = new DataTable();
                adapter.Fill(load_data_qna);
                data_qna.DataSource = load_data_qna;

                string insertQuery_mem = "SELECT 회원번호, 이름, 이메일 FROM library_project.member WHERE 회원번호 = '" + Normal.static_memnum + "';";
                MySqlCommand command_mem = new MySqlCommand(insertQuery_mem, connection);
                MySqlDataReader reader = command_mem.ExecuteReader();
                while (reader.Read() == true)
                {
                    memNum = reader["회원번호"].ToString();
                    memName = reader["이름"].ToString();
                    memEMail = reader["이메일"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }
    
        //이전화면 돌아가기 버튼 클릭 시
        private void btn_main_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("이전 화면으로 돌아가시겠습니까?", "돌아가기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                Normal showNormal = new Normal();
                showNormal.Show();
            }
        }

        //개선요청 버튼 클릭시
        private void picture_support_Click(object sender, EventArgs e)
        {
            SupportMail showSupportMail = new SupportMail();
            showSupportMail.ShowDialog();
        }
    
        //로그아웃 버튼 클릭시
        private void picture_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 후 메인화면으로 돌아가시겠습니까?", "로그아웃", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        //재조회 버튼 클릭시
        private void btn_load_Click(object sender, EventArgs e)
        {
            txtbox_title.Text = "";
            txtbox_body.Text = "";

            rdobtn_see.Checked = true;

            string insertQuery = "SELECT 제목, 내용 FROM library_project.board_qna;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_data_qna = new DataTable();
                adapter.Fill(load_data_qna);
                data_qna.DataSource = load_data_qna;

                string insertQuery_mem = "SELECT 회원번호, 이름, 이메일 FROM library_project.member WHERE 회원번호 = '" + Normal.static_memnum + "';";
                MySqlCommand command_mem = new MySqlCommand(insertQuery_mem, connection);
                MySqlDataReader reader = command_mem.ExecuteReader();
                while (reader.Read() == true)
                {
                    memNum = reader["회원번호"].ToString();
                    memName = reader["이름"].ToString();
                    memEMail = reader["이메일"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        //열람모드 라디오버튼 클릭시
        private void rdobtn_see_CheckedChanged(object sender, EventArgs e)
        {
            txtbox_title.Text = "";
            txtbox_body.Text = "";

            txtbox_title.ReadOnly = true;
            txtbox_body.ReadOnly = true;
        }

        //신규 작성모드 라디오버튼 클릭시
        private void rdobtn_new_CheckedChanged(object sender, EventArgs e)
        {
            txtbox_title.Text = "";
            txtbox_body.Text = "";

            txtbox_title.ReadOnly = false;
            txtbox_body.ReadOnly = false;
        }

        //문의접수 버튼 클릭시
        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (rdobtn_see.Checked == true)
            {
                MessageBox.Show("열람 모드에서는 사용할 수 없는 기능입니다. 모드 변경 후 이용해 주세요.");
            }
            else if (rdobtn_new.Checked == true)
            {
                string insertQuery = "INSERT INTO library_project.board_qna (회원번호, 작성자, 회원EMail, 제목, 내용) VALUES ('" + memNum + "', '" + memName + "', '" + memEMail + "', '" + txtbox_title.Text + "', '" + txtbox_body.Text + "');";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                try
                {
                    if (command.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("신규등록 요청하신 문의사항 제목 : " + txtbox_title.Text + " 게시글이 데이터베이스에 등록되었습니다. 도서관 관리자가 확인 후, 빠른 시일내에 답변 작성이 이루어질 예정입니다. 답변은 사용자의 이메일로도 발송됩니다. 조회 버튼을 눌러, 목록을 다시 재 조회 바랍니다.");

                        txtbox_title.Text = "";
                        txtbox_body.Text = "";

                        data_qna.DataSource = "";
                    }
                    else
                    {
                        MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "문의사항 등록 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "문의사항 등록 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("모드 선택 후 이용 바랍니다.");
            }
        }

        //입력내용 초기화 버튼 클릭시
        private void btn_reset_Click(object sender, EventArgs e)
        {
            if (rdobtn_see.Checked == true)
            {
                MessageBox.Show("열람 모드에서는 사용할 수 없는 기능입니다. 모드 변경 후 이용해 주세요.");
            }
            else if (rdobtn_new.Checked == true)
            {
                txtbox_title.Text = "";
                txtbox_body.Text = "";
            }
        }

        private void data_qna_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_title.Text = data_qna.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_body.Text = data_qna.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }
    }
}
