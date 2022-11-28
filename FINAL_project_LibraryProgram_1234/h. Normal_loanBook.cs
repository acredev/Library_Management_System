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
    public partial class Normal_loanBook : Form
    {
        public static bool searchByName = true;
        public static bool searchByWriter = false;
        public static bool searchByPublisher = false;
        public static bool searchByStatus = false;

        // <MySQL 연결 변수>
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");
        public Normal_loanBook()
        {
            InitializeComponent();
        }

        // 창 로드시 데이터그리드뷰 바로 출력
        private void Normal_loanBook_Load(object sender, EventArgs e)
        {
            string insertQuery = "SELECT 관리번호, 이름, 저자, 출판사, 대출여부, 대출한_회원번호 FROM library_project.book;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_book = new DataTable();
                adapter.Fill(load_book);
                data_book.DataSource = load_book;

                // 사용자에게 불필요한 정보인 관리번호와 대출한 회원번호 칼럼은 숨긴다.
                this.data_book.Columns[0].Visible = false;
                this.data_book.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "로딩 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        // 이전화면 돌아가기 버튼 클릭시
        private void btn_main_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("이전 화면으로 돌아가시겠습니까?", "돌아가기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                Normal showNormal = new Normal();
                showNormal.Show();
            }
        }

        // 프로그램 문의접수 버튼 클릭시

        private void picture_support_Click(object sender, EventArgs e)
        {
            SupportMail showSupportMail = new SupportMail();
            showSupportMail.ShowDialog();
        }

        // 로그아웃 버튼 클릭시
        private void picture_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 후 메인화면으로 돌아가시겠습니까?", "로그아웃", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        // 셀 클릭시 정보들을 텍스트박스로 자세히 볼 수 있도록 뿌려줌
        private void data_book_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_booknum.Text = data_book.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_title.Text = data_book.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtbox_writer.Text = data_book.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtbox_publisher.Text = data_book.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtbox_loanstatus.Text = data_book.Rows[e.RowIndex].Cells[4].Value.ToString();

                // 셀 클릭 시 마다 회원정보를 계속 갱신해서 현재 회원이 대출가능한 상태인지 여부를 판단하는 알고리즘
                string cnt_loan = "SELECT 대출권수, 회원상태 FROM library_project.member WHERE 회원번호 = '" + Normal.static_memnum + "';";
                connection.Open();
                MySqlCommand cnt_loan_cmd = new MySqlCommand(cnt_loan, connection);
                MySqlDataReader cnt_loan_read = cnt_loan_cmd.ExecuteReader();

                while (cnt_loan_read.Read())
                {
                    txtbox_loancnt.Text = cnt_loan_read["대출권수"].ToString();
                    txtbox_status.Text = cnt_loan_read["회원상태"].ToString();
                }
            }

            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
            connection.Close();
        }

        // 재조회 버튼 클릭시
        private void btn_load_Click(object sender, EventArgs e)
        {
            string insertQuery = "SELECT 관리번호, 이름, 저자, 출판사, 대출여부, 대출한_회원번호 FROM library_project.book;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_book = new DataTable();
                adapter.Fill(load_book);
                data_book.DataSource = load_book;

                // 사용자에게 불필요한 정보인 관리번호와 대출한 회원번호 칼럼은 숨긴다.
                this.data_book.Columns[0].Visible = false;
                this.data_book.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "로딩 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

            // 텍스트박스의 모든내용 초기화
            txtbox_booknum.Text = "";
            txtbox_title.Text = "";
            txtbox_writer.Text = "";
            txtbox_publisher.Text = "";
            txtbox_loanstatus.Text = "";
        }

        // 검색범주 선택시
        private void combobox_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_search.SelectedItem.ToString() == "제목")
            {
                searchByName = true;
                searchByWriter = false;
                searchByPublisher = false;
                searchByStatus = false;

                combobox_searchbystatus.Visible = false;

                txtbox_search.Text = "";
            }
            else if (combobox_search.SelectedItem.ToString() == "저자")
            {
                searchByName = false;
                searchByWriter = true;
                searchByPublisher = false;
                searchByStatus = false;

                combobox_searchbystatus.Visible = false;

                txtbox_search.Text = "";
            }
            else if (combobox_search.SelectedItem.ToString() == "출판사")
            {
                searchByName = false;
                searchByWriter = false;
                searchByPublisher = true;
                searchByStatus = false;

                combobox_searchbystatus.Visible = false;

                txtbox_search.Text = "";
            }
            else if (combobox_search.SelectedItem.ToString() == "대출여부")
            {
                searchByName = false;
                searchByWriter = false;
                searchByPublisher = false;
                searchByStatus = true;

                combobox_searchbystatus.Visible = true;

                txtbox_search.Text = "";
            }
        }

        // 검색 버튼 클릭시
        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (combobox_search.Text != "")
                {
                    // 책 제목으로 검색한다면
                    if (searchByName == true)
                    {
                        string insertQuery = "SELECT 관리번호, 이름, 저자, 출판사, 대출여부 FROM library_project.book WHERE 이름 = '" + txtbox_search.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data = new DataTable();
                        adapter.Fill(load_data);
                        data_book.DataSource = load_data;
                        connection.Close();

                        txtbox_booknum.Text = "";
                        txtbox_title.Text = "";
                        txtbox_writer.Text = "";
                        txtbox_publisher.Text = "";
                        txtbox_loanstatus.Text = "";
                    }
                    // 저자로 검색한다면
                    else if (searchByWriter == true)
                    {
                        string insertQuery = "SELECT 관리번호, 이름, 저자, 출판사, 대출여부 FROM library_project.book WHERE 저자 = '" + txtbox_search.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data = new DataTable();
                        adapter.Fill(load_data);
                        data_book.DataSource = load_data;
                        connection.Close();

                        txtbox_booknum.Text = "";
                        txtbox_title.Text = "";
                        txtbox_writer.Text = "";
                        txtbox_publisher.Text = "";
                        txtbox_loanstatus.Text = "";
                    }
                    // 책 출판사로 검색한다면
                    else if (searchByPublisher == true)
                    {
                        string insertQuery = "SELECT 관리번호, 이름, 저자, 출판사, 대출여부 FROM library_project.book WHERE 출판사 = '" + txtbox_search.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data = new DataTable();
                        adapter.Fill(load_data);
                        data_book.DataSource = load_data;
                        connection.Close();

                        txtbox_booknum.Text = "";
                        txtbox_title.Text = "";
                        txtbox_writer.Text = "";
                        txtbox_publisher.Text = "";
                        txtbox_loanstatus.Text = "";
                    }
                    // 대출 가능여부인 책을 보려면
                    else if (searchByStatus == true)
                    {
                        string insertQuery = "SELECT 관리번호, 이름, 저자, 출판사, 대출여부 FROM library_project.book WHERE 대출여부 = '" + combobox_searchbystatus.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data = new DataTable();
                        adapter.Fill(load_data);
                        data_book.DataSource = load_data;
                        connection.Close();

                        txtbox_booknum.Text = "";
                        txtbox_title.Text = "";
                        txtbox_writer.Text = "";
                        txtbox_publisher.Text = "";
                        txtbox_loanstatus.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("검색 범주 선택 후 검색 바랍니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "로딩 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 대출 버튼을 누른다면
        private void btn_bookloan_Click(object sender, EventArgs e)
        {
            bool isCanLoan = false;
            bool isCanStatus = false;

            if (txtbox_title.Text == "")
            {
                MessageBox.Show("도서 정보를 불러온 후, 도서를 선택해 이용 바랍니다.");
            }
            else
            {
                // 사용자 대출권수가 0~9권이면 대출가능
                if (txtbox_loancnt.Text == "0" || txtbox_loancnt.Text == "1" || txtbox_loancnt.Text == "2" || txtbox_loancnt.Text == "3" || txtbox_loancnt.Text == "4" || txtbox_loancnt.Text == "5" || txtbox_loancnt.Text == "6" || txtbox_loancnt.Text == "7" || txtbox_loancnt.Text == "8" || txtbox_loancnt.Text == "9" || txtbox_loancnt.Text == "10")
                {
                    isCanLoan = true;
                }
                else { isCanLoan = false; }

                if (txtbox_status.Text != "정상" && txtbox_loanstatus.Text != "대출 중") { isCanStatus = false; }
                else { isCanStatus = true; }

                if (isCanLoan == true && isCanStatus == true && txtbox_loanstatus.Text != "대출 중")
                {
                    string insertQuery = "UPDATE library_project.member SET 대출권수 = 대출권수 + 1 WHERE 회원번호 ='" + Normal.static_memnum + "'; " + "UPDATE library_project.book SET 대출여부 = '대출 중' WHERE 관리번호 = '" + txtbox_booknum.Text + "'; " + "UPDATE library_project.book SET 대출한_회원번호 = '" + Normal.static_memnum + "' WHERE 관리번호 = '" + txtbox_booknum.Text + "';";
                    connection.Open();
                    MySqlCommand insertBook_cmd = new MySqlCommand(insertQuery, connection);
                    try
                    {
                        if (insertBook_cmd.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show(txtbox_title.Text + " 도서 대출이 완료되었습니다. 재조회 버튼을 눌러 화면을 갱신해 주세요.");

                            txtbox_booknum.Text = "";
                            txtbox_title.Text = "";
                            txtbox_writer.Text = "";
                            txtbox_publisher.Text = "";
                            txtbox_loanstatus.Text = "";
                            data_book.DataSource = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "도서대출 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (isCanLoan == true && isCanStatus == false)
                {
                    MessageBox.Show("회원 상태가 대출 불가능한 상태입니다. 대출 불가능합니다.", "도서대출 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (isCanLoan == false && isCanStatus == true)
                {
                    MessageBox.Show("최대 10권까지 대출 가능합니다. 대출 불가능합니다.", "도서대출 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (isCanLoan == false && isCanStatus == false)
                {
                    MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다.", "도서대출 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtbox_loanstatus.Text == "대출 중")
                {
                    MessageBox.Show("타 사용자 또는 본인이 대출중인 도서입니다. 대출할 수 없습니다.", "도서대출 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            connection.Close();
        }

        private void btn_bookback_Click(object sender, EventArgs e)
        {
            bool isBookLoanYou = false;
        }
    }
}
