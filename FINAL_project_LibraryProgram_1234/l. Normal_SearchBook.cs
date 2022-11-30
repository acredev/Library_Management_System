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
    public partial class Normal_SearchBook : Form
    {
        // <MySQL 연결 변수>
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");
        public Normal_SearchBook()
        {
            InitializeComponent();
        }

        // 폼 로드 시 책 정보 자동 불러옴
        private void Normal_SearchBook_Load(object sender, EventArgs e)
        {
            string insertQuery = "SELECT 이름, ISBN, 저자, 출판일자, 출판사, 도서상태, 대출여부, 페이지수, 도서소개 FROM library_project.book;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_book = new DataTable();
                adapter.Fill(load_book);
                data_book.DataSource = load_book;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "로딩 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        // 오류보고 / 개선요청 클릭시
        private void picture_support_Click(object sender, EventArgs e)
        {
            SupportMail showSupportMail = new SupportMail();
            showSupportMail.ShowDialog();
        }

        // 로그아웃 클릭시
        private void picture_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 후 메인화면으로 돌아가시겠습니까?", "로그아웃", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        // 돌아가기 클릭시
        private void btn_main_click_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("이전 화면으로 돌아가시겠습니까?", "돌아가기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                Normal showNormal = new Normal();
                showNormal.Show();
            }
        }

        // DataGridView 셀 클릭시 관련 정보들을 각 textbox에 뿌려줌
        private void data_book_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_title.Text = data_book.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_isbn.Text = data_book.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtbox_writer.Text = data_book.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtbox_date.Text = data_book.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtbox_publisher.Text = data_book.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtbox_status.Text = data_book.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtbox_loanstatus.Text = data_book.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtbox_pages.Text = data_book.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtbox_about.Text = data_book.Rows[e.RowIndex].Cells[8].Value.ToString();
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
            string insertQuery = "SELECT 이름, ISBN, 저자, 출판일자, 출판사, 도서상태, 대출여부, 페이지수, 도서소개 FROM library_project.book;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_book = new DataTable();
                adapter.Fill(load_book);
                data_book.DataSource = load_book;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "로딩 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

            txtbox_title.Text = "";
            txtbox_isbn.Text = "";
            txtbox_writer.Text = "";
            txtbox_date.Text = "";
            txtbox_publisher.Text = "";
            txtbox_status.Text = "";
            txtbox_loanstatus.Text = "";
            txtbox_pages.Text = "";
            txtbox_about.Text = "";
        }

        // 검색 범주 선택시
        private void combobox_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_search.SelectedItem.ToString() == "제목")
            {
                txtbox_search.Visible = true;
                combobox_searchbyloanstatus.Visible = false;

                txtbox_search.Text = "";
            }
            else if (combobox_search.SelectedItem.ToString() == "저자")
            {
                txtbox_search.Visible = true;
                combobox_searchbyloanstatus.Visible = false;

                txtbox_search.Text = "";
            }
            else if (combobox_search.SelectedItem.ToString() == "출판사")
            {
                txtbox_search.Visible = true;
                combobox_searchbyloanstatus.Visible = false;

                txtbox_search.Text = "";
            }
            else if (combobox_search.SelectedItem.ToString() == "대출여부")
            {
                txtbox_search.Visible = false;
                combobox_searchbyloanstatus.Visible = true;

                txtbox_search.Text = "";
            }
            else if (combobox_search.SelectedItem.ToString() == "ISBN")
            {
                txtbox_search.Visible = true;
                combobox_searchbyloanstatus.Visible = false;

                txtbox_search.Text = "";
            }
        }

        // 도서 검색 클릭시
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (combobox_search.Text == "")
            {
                MessageBox.Show("검색범주 선택 후 시도 바랍니다.");
            }
            else if (txtbox_search.Text == "" && combobox_search.Text == "")
            {
                MessageBox.Show("검색명 입력 후 시도 바랍니다.");
            }
            else
            {
                if (combobox_search.Text == "제목")
                {
                    string insertQuery = "SELECT 이름, ISBN, 저자, 출판일자, 출판사, 도서상태, 대출여부, 페이지수 FROM library_project.book WHERE 이름 = '" + txtbox_search.Text + "';";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    DataTable load_data_book = new DataTable();
                    adapter.Fill(load_data_book);
                    data_book.DataSource = load_data_book;
                    connection.Close();
                }
                else if (combobox_search.Text == "저자")
                {
                    string insertQuery = "SELECT 이름, ISBN, 저자, 출판일자, 출판사, 도서상태, 대출여부, 페이지수 FROM library_project.book WHERE 저자 = '" + txtbox_search.Text + "';";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    DataTable load_data_book = new DataTable();
                    adapter.Fill(load_data_book);
                    data_book.DataSource = load_data_book;
                    connection.Close();
                }
                else if (combobox_search.Text == "출판사")
                {
                    string insertQuery = "SELECT 이름, ISBN, 저자, 출판일자, 출판사, 도서상태, 대출여부, 페이지수 FROM library_project.book WHERE 출판사 = '" + txtbox_search.Text + "';";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    DataTable load_data_book = new DataTable();
                    adapter.Fill(load_data_book);
                    data_book.DataSource = load_data_book;
                    connection.Close();
                }
                else if (combobox_search.Text == "대출여부")
                {
                    string insertQuery = "SELECT 이름, ISBN, 저자, 출판일자, 출판사, 도서상태, 대출여부, 페이지수 FROM library_project.book WHERE 대출여부 = '" + combobox_searchbyloanstatus.Text + "';";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    DataTable load_data_book = new DataTable();
                    adapter.Fill(load_data_book);
                    data_book.DataSource = load_data_book;
                    connection.Close();
                }
                else if (combobox_search.Text == "ISBN")
                {
                    string insertQuery = "SELECT 이름, ISBN, 저자, 출판일자, 출판사, 도서상태, 대출여부, 페이지수 FROM library_project.book WHERE ISBN = '" + txtbox_search.Text + "';";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    DataTable load_data_book = new DataTable();
                    adapter.Fill(load_data_book);
                    data_book.DataSource = load_data_book;
                    connection.Close();
                }
            }
        } 
    }
}
