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

        private void Normal_loanBook_Load(object sender, EventArgs e)
        {
            string insertQuery = "SELECT 관리번호, 이름, 저자, 출판사, 대출여부 FROM library_project.book;";
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

        private void btn_main_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("이전 화면으로 돌아가시겠습니까?", "돌아가기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                Normal showNormal = new Normal();
                showNormal.Show();
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

        private void data_book_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_booknum.Text = data_book.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_title.Text = data_book.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtbox_writer.Text = data_book.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtbox_publisher.Text = data_book.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtbox_loanstatus.Text = data_book.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            string insertQuery = "SELECT 관리번호, 이름, 저자, 출판사, 대출여부 FROM library_project.book;";
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

            txtbox_booknum.Text = "";
            txtbox_title.Text = "";
            txtbox_writer.Text = "";
            txtbox_publisher.Text = "";
            txtbox_loanstatus.Text = "";
        }

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

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (combobox_search.Text != "")
                {
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

        private void btn_bookloan_Click(object sender, EventArgs e)
        {

        }

        private void btn_bookback_Click(object sender, EventArgs e)
        {

        }
    }
}
