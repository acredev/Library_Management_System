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

namespace FINAL_project_LibraryProgram_1234
{
    public partial class Master : Form
    {
        // <MySQL 연결 변수>
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");
        public Master()
        {
            InitializeComponent();
        }

        // <문의하기 픽쳐박스 클릭시>
        private void picture_support_Click(object sender, EventArgs e)
        {
            SupportMail showSupportMail = new SupportMail();
            showSupportMail.ShowDialog();
        }

        // 로그아웃 픽쳐박스 클릭시
        private void picture_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 후 메인화면으로 돌아가시겠습니까?", "로그아웃", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        // <프로그램 종료 픽쳐박스 클릭시>
        private void picture_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("일이삼사 도서관리 프로그램을 정말 종료하시곘습니까?", "프로그램 종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // <Master.cs 전체에서 사용할 변수들>
        public static bool tab2_isBookModify = false;
        public static bool tab2_isBookNew = false;
        public static bool tab2_isBookReadOnly = true;

        public static bool tab3_isMemModify = false;
        public static bool tab3_isMemReadOnly = true;

        public static bool tab4_isNoticeModify = false;
        public static bool tab4_isNoticeReadOnly = true;
        public static bool tab4_isNoticeNew = false;

        public static bool tab4_isFreeModify = false;
        public static bool tab4_isFreeReadOnly = true;

        public static bool tab5_isModify = false;
        public static bool tab5_isReadOnly = true;
        public static bool tab5_emailsend = false;

        // <탭 1에서, 조회/재조회 버튼 클릭시>
        private void btn_tab1_load_Click(object sender, EventArgs e)
        {
            string insertQuery_loadMember = "SELECT 회원번호, 이름, 아이디, 대출권수, 회원상태, 성별, 생년월일, 연락처, 주소 FROM library_project.member;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery_loadMember, connection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_data_tab1_member = new DataTable();
                adapter.Fill(load_data_tab1_member);
                data_tab1_member.DataSource = load_data_tab1_member;

                string insertQuery_loadBook = "SELECT * FROM library_project.book";
                MySqlCommand command2 = new MySqlCommand(insertQuery_loadBook, connection);
                MySqlDataAdapter adapter2 = new MySqlDataAdapter(command2);
                DataTable load_data_tab1_book = new DataTable();
                adapter2.Fill(load_data_tab1_book);
                data_tab1_book.DataSource = load_data_tab1_book;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        // <탭 1에서, 회원목록 셀 클릭 시>
        private void data_tab1_member_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_tab1_membernum.Text = data_tab1_member.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_tab1_name.Text = data_tab1_member.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtbox_tab1_id.Text = data_tab1_member.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtbox_tab1_loannum.Text = data_tab1_member.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtbox_tab1_memberstauts.Text = data_tab1_member.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtbox_tab1_gender.Text = data_tab1_member.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtbox_tab1_membirth.Text = data_tab1_member.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtbox_tab1_tel.Text = data_tab1_member.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtbox_tab1_address.Text = data_tab1_member.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }

        // <탭 1에서, 도서목록 셀 클릭 시>
        private void data_tab1_book_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_tab1_booknum.Text = data_tab1_book.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_tab1_bookname.Text = data_tab1_book.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtbox_tab1_bookisbn.Text = data_tab1_book.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtbox_tab1_writer.Text = data_tab1_book.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtbox_tab1_date.Text = data_tab1_book.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtbox_tab1_publisher.Text = data_tab1_book.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtbox_tab1_bookstatus.Text = data_tab1_book.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtbox_tab1_loan.Text = data_tab1_book.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtbox_tab1_price.Text = data_tab1_book.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtbox_tab1_pages.Text = data_tab1_book.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtbox_tab1_bookinfo.Text = data_tab1_book.Rows[e.RowIndex].Cells[10].Value.ToString();

                string wholoanbook = data_tab1_book.Rows[e.RowIndex].Cells[11].Value.ToString();
                if (wholoanbook == "")
                {
                    txtbox_tab1_wholoanbook.Text = "대출 가능 도서입니다.";
                }
                else
                {
                    txtbox_tab1_wholoanbook.Text = wholoanbook;
                }
            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }

        // <탭 1에서, 회원검색 (분류) 선택 시, 회원번호/연락처/생년월일을 선택한다면 양식에 맞게 작성하도록 maskedtxtbox와 연결해줌>
        private void combobox_tab1_searchmem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_tab1_searchmem.SelectedItem.ToString() == "회원번호")
            {
                txtbox_tab1_searchmem.Visible = false;
                txtbox_tab1_searchmem.Text = "";

                maskedtxtBox_tab1_searchmem.Visible = true;
                maskedtxtBox_tab1_searchmem.Mask = "000000000000";
            }
            else if (combobox_tab1_searchmem.SelectedItem.ToString() == "연락처")
            {
                txtbox_tab1_searchmem.Visible = false;
                txtbox_tab1_searchmem.Text = "";

                maskedtxtBox_tab1_searchmem.Visible = true;
                maskedtxtBox_tab1_searchmem.Mask = "000-0000-0000";
            }
            else if (combobox_tab1_searchmem.SelectedItem.ToString() == "생년월일")
            {
                txtbox_tab1_searchmem.Visible = false;
                txtbox_tab1_searchmem.Text = "";

                maskedtxtBox_tab1_searchmem.Visible = true;
                maskedtxtBox_tab1_searchmem.Mask = "0000-00-00";
            }
            else
            {
                maskedtxtBox_tab1_searchmem.Visible = false;
                maskedtxtBox_tab1_searchmem.Text = "";

                txtbox_tab1_searchmem.Visible = true;
            }
        }

        // <탭 1에서, 회원검색 버튼 클릭시>
        private void btn_tab1_memsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_tab1_searchmem.Text == "" && maskedtxtBox_tab1_searchmem.Text == "")
                {
                    MessageBox.Show("검색명 입력 후 시도 바랍니다.");
                }
                else
                {
                    if (combobox_tab1_searchmem.Text =="회원번호")
                    {
                        string insertQuery = "SELECT 회원번호, 이름, 아이디, 대출권수, 회원상태, 성별, 생년월일, 연락처, 주소 FROM library_project.member WHERE 회원번호 = '" + maskedtxtBox_tab1_searchmem.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_tab1_member = new DataTable();
                        adapter.Fill(load_data_tab1_member);
                        data_tab1_member.DataSource = load_data_tab1_member;
                        connection.Close();
                    }
                    else if (combobox_tab1_searchmem.Text == "이름")
                    {
                        string insertQuery = "SELECT 회원번호, 이름, 아이디, 대출권수, 회원상태, 성별, 생년월일, 연락처, 주소 FROM library_project.member WHERE 이름 = '" + txtbox_tab1_searchmem.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_tab1_member = new DataTable();
                        adapter.Fill(load_data_tab1_member);
                        data_tab1_member.DataSource = load_data_tab1_member;
                        connection.Close();
                    }
                    else if (combobox_tab1_searchmem.Text == "아이디")
                    {
                        string insertQuery = "SELECT 회원번호, 이름, 아이디, 대출권수, 회원상태, 성별, 생년월일, 연락처, 주소 FROM library_project.member WHERE 아이디 = '" + txtbox_tab1_searchmem.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_tab1_member = new DataTable();
                        adapter.Fill(load_data_tab1_member);
                        data_tab1_member.DataSource = load_data_tab1_member;
                        connection.Close();
                    }
                    else if (combobox_tab1_searchmem.Text == "연락처")
                    {
                        string insertQuery = "SELECT 회원번호, 이름, 아이디, 대출권수, 회원상태, 성별, 생년월일, 연락처, 주소 FROM library_project.member WHERE 연락처 = '" + maskedtxtBox_tab1_searchmem.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_tab1_member = new DataTable();
                        adapter.Fill(load_data_tab1_member);
                        data_tab1_member.DataSource = load_data_tab1_member;
                        connection.Close();
                    }
                    else if (combobox_tab1_searchmem.Text == "생년월일")
                    {
                        string insertQuery = "SELECT 회원번호, 이름, 아이디, 대출권수, 회원상태, 성별, 생년월일, 연락처, 주소 FROM library_project.member WHERE 생년월일 = '" + maskedtxtBox_tab1_searchmem.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_tab1_member = new DataTable();
                        adapter.Fill(load_data_tab1_member);
                        data_tab1_member.DataSource = load_data_tab1_member;
                        connection.Close();
                    }
                    else if (combobox_tab1_searchmem.Text == "이메일")
                    {
                        string insertQuery = "SELECT 회원번호, 이름, 아이디, 대출권수, 회원상태, 성별, 생년월일, 연락처, 주소 FROM library_project.member WHERE 이메일 = '" + txtbox_tab1_searchmem.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_tab1_member = new DataTable();
                        adapter.Fill(load_data_tab1_member);
                        data_tab1_member.DataSource = load_data_tab1_member;
                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }

        // <탭 1에서, 도서검색 (분류) 선택 시, 관리번호를 선택한다면 양식에 맞게 작성하도록 maskedtxtbox와 연결해주고,>
        // <                                 대출여부를 선택한다면 양식에 맞게 선택하도록 combobox와 연결해줌.>
        private void combobox_tab1_searchbook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_tab1_searchbook.SelectedItem.ToString() == "관리번호")
            {
                txtbox_tab1_searchbook.Visible = false;
                txtbox_tab1_searchbook.Text = "";

                combobox_tab1_searchbookbystatus.Visible = false;
                combobox_tab1_searchbookbystatus.SelectedItem = "";

                masktxtbox_tab1_searchbook.Visible = true;
                masktxtbox_tab1_searchbook.Mask = "000000000000";
            }
            else if (combobox_tab1_searchbook.SelectedItem.ToString() == "대출여부")
            {
                txtbox_tab1_searchbook.Visible = false;
                txtbox_tab1_searchbook.Text = "";

                combobox_tab1_searchbookbystatus.Visible = true;
                combobox_tab1_searchbookbystatus.SelectedItem = "";

                masktxtbox_tab1_searchbook.Visible = false;
                masktxtbox_tab1_searchbook.Text = "";
            }
            else
            {
                txtbox_tab1_searchbook.Visible = true;
                txtbox_tab1_searchbook.Text = "";

                combobox_tab1_searchbookbystatus.Visible = false;
                combobox_tab1_searchbookbystatus.SelectedItem = "";

                masktxtbox_tab1_searchbook.Visible = false;
                masktxtbox_tab1_searchbook.Text = "";
            }
        }

        // <탭 1에서, 도서검색 버튼 클릭시>
        private void btn_tab1_booksearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_tab1_searchbook.Text == "" && combobox_tab1_searchbookbystatus.SelectedItem.ToString() == "" && maskedtxtBox_tab1_searchmem.Text == "")
                {
                    MessageBox.Show("검색명 입력 후 시도 바랍니다.");
                }
                else
                {
                    if (combobox_tab1_searchbook.Text == "관리번호")
                    {
                        string insertQuery = "SELECT * FROM library_project.book WHERE 관리번호 = '" + masktxtbox_tab1_searchbook.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_tab1_book = new DataTable();
                        adapter.Fill(load_data_tab1_book);
                        data_tab1_book.DataSource = load_data_tab1_book;
                        connection.Close();
                    }
                    else if (combobox_tab1_searchbook.Text == "도서명")
                    {
                        string insertQuery = "SELECT * FROM library_project.book WHERE 이름 = '" + txtbox_tab1_searchbook.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_tab1_book = new DataTable();
                        adapter.Fill(load_data_tab1_book);
                        data_tab1_book.DataSource = load_data_tab1_book;
                        connection.Close();
                    }
                    else if (combobox_tab1_searchbook.Text == "ISBN")
                    {
                        string insertQuery = "SELECT * FROM library_project.book WHERE ISBN = '" + txtbox_tab1_searchbook.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_tab1_book = new DataTable();
                        adapter.Fill(load_data_tab1_book);
                        data_tab1_book.DataSource = load_data_tab1_book;
                        connection.Close();
                    }
                    else if (combobox_tab1_searchbook.Text == "대출여부")
                    {
                        string insertQuery = "SELECT * FROM library_project.book WHERE 대출여부 = '" + combobox_tab1_searchbookbystatus.SelectedItem.ToString() + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_tab1_book = new DataTable();
                        adapter.Fill(load_data_tab1_book);
                        data_tab1_book.DataSource = load_data_tab1_book;
                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }

        // 탭 1에서, 대출 처리 버튼 클릭 시
        private void btn_tab1_bookloan_Click(object sender, EventArgs e)
        {
            bool isMemberCanLoanStatus = true;
            bool isMemberCanStatus = false;
            bool isBookCanStatus = false;

            if (txtbox_tab1_membernum.Text == "" && txtbox_tab1_booknum.Text == "")
            {
                MessageBox.Show("회원 정보와 도서 정보를 불러온 후, 대출 대상 회원과 도서를 선택해 이용 바랍니다.");
            }
            else if (txtbox_tab1_membernum.Text == "" && txtbox_tab1_booknum.Text != "")
            {
                MessageBox.Show("대출 대상 회원을 선택 바랍니다.");
            }
            else if (txtbox_tab1_membernum.Text != "" && txtbox_tab1_booknum.Text == "")
            {
                MessageBox.Show("대출 대상 도서를 선택 바랍니다.");
            }
            else
            {
                if (txtbox_tab1_loannum.Text == "0" || txtbox_tab1_loannum.Text == "1" || txtbox_tab1_loannum.Text == "2" || txtbox_tab1_loannum.Text == "3" || txtbox_tab1_loannum.Text == "4" || txtbox_tab1_loannum.Text == "5" || txtbox_tab1_loannum.Text == "6" || txtbox_tab1_loannum.Text == "7" || txtbox_tab1_loannum.Text == "8" || txtbox_tab1_loannum.Text == "9")
                {
                    isMemberCanLoanStatus = true;
                }
                else { isMemberCanLoanStatus = false; }

                if (txtbox_tab1_memberstauts.Text != "정상") { isMemberCanStatus = false; }
                else { isMemberCanStatus = true; }

                if (txtbox_tab1_loan.Text != "대출 가능") { isBookCanStatus = false; }
                else { isBookCanStatus = true; }

                if (isMemberCanLoanStatus == true && isMemberCanStatus == true && isBookCanStatus == true)
                {
                    string insertQuery = "UPDATE library_project.member SET 대출권수 = 대출권수 + 1 WHERE 회원번호 = '" + txtbox_tab1_membernum.Text + "'; " + "UPDATE library_project.book SET 대출여부 = '대출 중' WHERE 관리번호 = '" + txtbox_tab1_booknum.Text + "'; " + "UPDATE library_project.book SET 대출한_회원번호 = '" + txtbox_tab1_membernum.Text + "' WHERE 관리번호 = '" + txtbox_tab1_booknum.Text + "';";
                    connection.Open();
                    MySqlCommand command_loan = new MySqlCommand(insertQuery, connection);
                    try
                    {
                        if (command_loan.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show(txtbox_tab1_name.Text + "회원님의 " + txtbox_tab1_bookname.Text + " 도서 대출이 완료되었습니다. 재조회 버튼을 눌러 화면을 갱신해 주세요.");

                            // 회원 정보 텍스트박스 초기화
                            txtbox_tab1_membernum.Text = "";
                            txtbox_tab1_name.Text = "";
                            txtbox_tab1_id.Text = "";
                            txtbox_tab1_loannum.Text = "";
                            txtbox_tab1_memberstauts.Text = "";
                            txtbox_tab1_gender.Text = "";
                            txtbox_tab1_membirth.Text = "";
                            txtbox_tab1_tel.Text = "";
                            txtbox_tab1_address.Text = "";

                            // 도서 정보 텍스트박스 초기화
                            txtbox_tab1_booknum.Text = "";
                            txtbox_tab1_bookname.Text = "";
                            txtbox_tab1_bookisbn.Text = "";
                            txtbox_tab1_writer.Text = "";
                            txtbox_tab1_date.Text = "";
                            txtbox_tab1_publisher.Text = "";
                            txtbox_tab1_bookstatus.Text = "";
                            txtbox_tab1_loan.Text = "";
                            txtbox_tab1_price.Text = "";
                            txtbox_tab1_pages.Text = "";
                            txtbox_tab1_bookinfo.Text = "";
                            txtbox_tab1_wholoanbook.Text = "";

                            // 데이터 조회 화면 초기화
                            data_tab1_member.DataSource = "";
                            data_tab1_book.DataSource = "";
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "도서대출 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "도서대출 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
                else if (isBookCanStatus == false)
                {
                    if (txtbox_tab1_membernum.Text == txtbox_tab1_wholoanbook.Text)
                    {
                        MessageBox.Show("본 도서는 회원님께서 대출하신 도서입니다.");
                    }
                    else
                    {
                        MessageBox.Show("현재 " + txtbox_tab1_bookname.Text + "도서는 타 회원이 대출 중인 도서로, 대출이 불가능합니다.");
                    }
                }
                else if (isMemberCanLoanStatus == false && isMemberCanStatus == true && isBookCanStatus == true)
                {
                    MessageBox.Show("최대 대출 권수는 10권으로, 현재 " + txtbox_tab1_name.Text + " 회원님 께서는 " + txtbox_tab1_loannum.Text + "권을 대출하셨습니다. 대출이 불가능합니다.", "대출불가");
                }
                else if (isMemberCanLoanStatus == true && isMemberCanStatus == false && isBookCanStatus == true)
                {
                    MessageBox.Show("현재 회원 상태가 " + txtbox_tab1_memberstauts.Text + "으로, 대출이 불가능한 상태입니다.");
                }
                else
                {
                    MessageBox.Show(txtbox_tab1_name.Text + "회원님은 대출이 불가능한 회원입니다.");
                }
            }
        }

        // 탭 1에서, 반납 처리 버튼 클릭 시
        private void btn_tab1_bookback_Click(object sender, EventArgs e)
        {
            bool isBookLoanYou = false;

            if (txtbox_tab1_membernum.Text == txtbox_tab1_wholoanbook.Text)
            {
                isBookLoanYou = true;
            }
            else
            {
                isBookLoanYou = false;
            }

            if (txtbox_tab1_membernum.Text == "" && txtbox_tab1_booknum.Text == "")
            {
                MessageBox.Show("회원 정보와 도서 정보를 불러온 후, 반납 대상 회원과 도서를 선택해 이용 바랍니다.");
            }
            else if (txtbox_tab1_membernum.Text == "" && txtbox_tab1_booknum.Text != "")
            {
                MessageBox.Show("반납 대상 회원을 선택 바랍니다.");
            }
            else if (txtbox_tab1_membernum.Text != "" && txtbox_tab1_booknum.Text == "")
            {
                MessageBox.Show("반납 대상 도서를 선택 바랍니다.");
            }
            else
            {
                if (isBookLoanYou == true)
                {
                    string insertQuery = "UPDATE library_project.member SET 대출권수 = 대출권수 - 1 WHERE 회원번호 = '" + txtbox_tab1_membernum.Text + "'; " + "UPDATE library_project.book SET 대출여부 = '대출 가능' WHERE 관리번호 = '" + txtbox_tab1_booknum.Text + "'; " + "UPDATE library_project.book SET 대출한_회원번호 = '' WHERE 관리번호 = '" + txtbox_tab1_booknum.Text + "';";
                    connection.Open();
                    MySqlCommand command_bookback = new MySqlCommand(insertQuery, connection);
                    try
                    {
                        if (command_bookback.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show(txtbox_tab1_name.Text + "회원님의" + txtbox_tab1_bookname.Text + "도서 반납이 완료되었습니다. 재조회 버튼을 눌러 화면을 갱신해 주세요.");

                            // 회원 정보 텍스트박스 초기화
                            txtbox_tab1_membernum.Text = "";
                            txtbox_tab1_name.Text = "";
                            txtbox_tab1_id.Text = "";
                            txtbox_tab1_loannum.Text = "";
                            txtbox_tab1_memberstauts.Text = "";
                            txtbox_tab1_gender.Text = "";
                            txtbox_tab1_membirth.Text = "";
                            txtbox_tab1_tel.Text = "";
                            txtbox_tab1_address.Text = "";

                            // 도서 정보 텍스트박스 초기화
                            txtbox_tab1_booknum.Text = "";
                            txtbox_tab1_bookname.Text = "";
                            txtbox_tab1_bookisbn.Text = "";
                            txtbox_tab1_writer.Text = "";
                            txtbox_tab1_date.Text = "";
                            txtbox_tab1_publisher.Text = "";
                            txtbox_tab1_bookstatus.Text = "";
                            txtbox_tab1_loan.Text = "";
                            txtbox_tab1_price.Text = "";
                            txtbox_tab1_pages.Text = "";
                            txtbox_tab1_bookinfo.Text = "";
                            txtbox_tab1_wholoanbook.Text = "";

                            // 데이터 조회 화면 초기화
                            data_tab1_member.DataSource = "";
                            data_tab1_book.DataSource = "";
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다.", "도서반납 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "도서반납 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("본 도서는 해당 회원이 대출한 도서가 아니라 반납처리가 불가능 합니다. 강제 반납 처리가 불가합니다. 대출한 회원을 검색해서 처리 바랍니다.");
                }
            }
        }

        // <탭 2에서, 조회/재조회 버튼 클릭시>
        private void btn_tab2_loadbook_Click(object sender, EventArgs e)
        {
            txtbox_tab2_booknum.ReadOnly = true;
            string insertQuery_loadBook = "SELECT * FROM library_project.book;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery_loadBook, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable load_data_book = new DataTable();
            adapter.Fill(load_data_book);

            data_tab2_book.DataSource = load_data_book;
            connection.Close();
        }

        // <탭 2에서, 도서목록 셀 클릭 시>
        private void data_tab2_book_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rdobtn_tab2_newmode.Checked == true)
            {
                MessageBox.Show("신규 도서 등록 모드입니다. 관리모드 변경 후 이용 바랍니다.");
            }
            else
            {
                try
                {
                    txtbox_tab2_booknum.Text = data_tab2_book.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtbox_tab2_bookname.Text = data_tab2_book.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtbox_tab2_isbn.Text = data_tab2_book.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtbox_tab2_bookwrite.Text = data_tab2_book.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtbox_tab2_bookdate.Text = data_tab2_book.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtbox_tab2_bookpublisher.Text = data_tab2_book.Rows[e.RowIndex].Cells[5].Value.ToString();
                    combobox_tab2_bookstatus.Text = data_tab2_book.Rows[e.RowIndex].Cells[6].Value.ToString();
                    combobox_tab2_bookloanstatus.Text = data_tab2_book.Rows[e.RowIndex].Cells[7].Value.ToString();
                    txtbox_tab2_bookprice.Text = data_tab2_book.Rows[e.RowIndex].Cells[8].Value.ToString();
                    txtbox_tab2_bookpages.Text = data_tab2_book.Rows[e.RowIndex].Cells[9].Value.ToString();
                    txtbox_tab2_bookabout.Text = data_tab2_book.Rows[e.RowIndex].Cells[10].Value.ToString();
                    txtbox_tab2_loannum.Text = data_tab2_book.Rows[e.RowIndex].Cells[11].Value.ToString();
                }
                catch (Exception)
                {
                    // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
                }
            }
        }

        // <탭 2에서, 도서검색 (분류) 선택 시, 관리번호를 선택한다면 양식에 맞게 작성하도록 maskedtxtbox와 연결해주고,>
        // <                                 대출여부를 선택한다면 양식에 맞게 선택하도록 combobox와 연결해줌.>
        private void combobox_tab2_searchbook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_tab2_searchbook.SelectedItem.ToString() == "관리번호")
            {
                txtbox_tab2_searchbook.Visible = false;
                txtbox_tab1_searchbook.Text = "";

                combobox_tab2_searchbybookstatus.Visible = false;
                combobox_tab2_searchbybookstatus.SelectedItem = "";

                maskedtextbox_tab2_searchbookbynum.Visible = true;
                maskedtextbox_tab2_searchbookbynum.Mask = "000000000000";
            }
            else if (combobox_tab2_searchbook.SelectedItem.ToString() == "대출여부")
            {
                txtbox_tab2_searchbook.Visible = false;
                txtbox_tab1_searchbook.Text = "";

                combobox_tab2_searchbybookstatus.Visible = true;
                combobox_tab2_searchbybookstatus.SelectedItem = "";

                maskedtextbox_tab2_searchbookbynum.Visible = false;
                maskedtextbox_tab2_searchbookbynum.Mask = "";
            }
            else
            {
                txtbox_tab2_searchbook.Visible = true;
                txtbox_tab1_searchbook.Text = "";

                combobox_tab2_searchbybookstatus.Visible = false;
                combobox_tab2_searchbybookstatus.SelectedItem = "";

                maskedtextbox_tab2_searchbookbynum.Visible = false;
                maskedtextbox_tab2_searchbookbynum.Mask = "";
            }
        }

        // <탭 2에서, 검색하기 버튼 클릭 시>
        private void btn_tab2_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_tab2_searchbook.Text == "" && maskedtextbox_tab2_searchbookbynum.Text == "" && combobox_tab2_searchbybookstatus.Text == "")
                {
                    MessageBox.Show("검색명 입력 후 시도 바랍니다.");
                }
                else
                {
                    if (combobox_tab2_searchbook.Text == "관리번호")
                    {
                        string insertQuery_searchBook_byNum = "SELECT * FROM library_project.book WHERE 관리번호 = '" + maskedtextbox_tab2_searchbookbynum.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery_searchBook_byNum, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_book = new DataTable();
                        adapter.Fill(load_data_book);

                        data_tab2_book.DataSource = load_data_book;
                        connection.Close();
                    }
                    else if (combobox_tab2_searchbook.Text == "도서명")
                    {
                        string insertQuery_searchBook_byName = "SELECT * FROM library_project.book WHERE 이름 = '" + txtbox_tab2_searchbook.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery_searchBook_byName, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_book = new DataTable();
                        adapter.Fill(load_data_book);

                        data_tab2_book.DataSource = load_data_book;
                        connection.Close();
                    }
                    else if (combobox_tab2_searchbook.Text == "ISBN")
                    {
                        string insertQuery_searchBook_byISBN = "SELECT * FROM library_project.book WHERE ISBN = '" + txtbox_tab2_searchbook.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery_searchBook_byISBN, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_book = new DataTable();
                        adapter.Fill(load_data_book);

                        data_tab2_book.DataSource = load_data_book;
                        connection.Close();
                    }
                    else if (combobox_tab2_searchbook.Text == "저자")
                    {
                        string insertQuery_searchBook_byWriter = "SELECT * FROM library_project.book WHERE 저자 = '" + txtbox_tab2_searchbook.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery_searchBook_byWriter, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_book = new DataTable();
                        adapter.Fill(load_data_book);

                        data_tab2_book.DataSource = load_data_book;
                        connection.Close();
                    }
                    else if (combobox_tab2_searchbook.Text == "출판사")
                    {
                        string insertQuery_searchBook_byPublisher = "SELECT * FROM library_project.book WHERE 출판사 = '" + txtbox_tab2_searchbook.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery_searchBook_byPublisher, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_book = new DataTable();
                        adapter.Fill(load_data_book);

                        data_tab2_book.DataSource = load_data_book;
                        connection.Close();
                    }
                    else if (combobox_tab2_searchbook.Text == "대출여부")
                    {
                        string insertQuery_searchBook_byLoan = "SELECT * FROM library_project.book WHERE 대출여부 = '" + combobox_tab2_searchbybookstatus.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery_searchBook_byLoan, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_data_book = new DataTable();
                        adapter.Fill(load_data_book);

                        data_tab2_book.DataSource = load_data_book;
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("범주 선택 후 검색 바랍니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "도서검색 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // <탭 2에서, 관리모드가 열람모드로 변경 시>
        private void rdobtn_tab2_seemode_CheckedChanged(object sender, EventArgs e)
        {
            tab2_isBookReadOnly = true;
            tab2_isBookModify = false;
            tab2_isBookNew = false;

            txtbox_tab2_booknum.ReadOnly = true;
            txtbox_tab2_bookname.ReadOnly = true;
            txtbox_tab2_isbn.ReadOnly = true;
            txtbox_tab2_bookwrite.ReadOnly = true;
            txtbox_tab2_bookpublisher.ReadOnly = true;
            txtbox_tab2_bookdate.ReadOnly = true;
            txtbox_tab2_bookprice.ReadOnly = true;
            txtbox_tab2_bookpages.ReadOnly = true;
            txtbox_tab2_bookabout.ReadOnly = true;
        }

        // <탭 2에서, 관리모드가 수정모드로 변경 시>

        private void rdobtn_tab2_editmode_CheckedChanged(object sender, EventArgs e)
        {
            tab2_isBookReadOnly = false;
            tab2_isBookModify = true;
            tab2_isBookNew = false;

            txtbox_tab2_booknum.ReadOnly = true;
            txtbox_tab2_bookname.ReadOnly = false;
            txtbox_tab2_isbn.ReadOnly = false;
            txtbox_tab2_bookwrite.ReadOnly = false;
            txtbox_tab2_bookpublisher.ReadOnly = false;
            txtbox_tab2_bookdate.ReadOnly = false;
            txtbox_tab2_bookprice.ReadOnly = false;
            txtbox_tab2_bookpages.ReadOnly = false;
            txtbox_tab2_bookabout.ReadOnly = false;
        }

        // <탭 2에서, 관리모드가 신규등록모드로 변경 시>
        private void rdobtn_tab2_newmode_CheckedChanged(object sender, EventArgs e)
        {
            tab2_isBookReadOnly = false;
            tab2_isBookModify = false;
            tab2_isBookNew = true;

            txtbox_tab2_booknum.ReadOnly = true;
            txtbox_tab2_bookname.ReadOnly = false;
            txtbox_tab2_isbn.ReadOnly = false;
            txtbox_tab2_bookwrite.ReadOnly = false;
            txtbox_tab2_bookpublisher.ReadOnly = false;
            txtbox_tab2_bookdate.ReadOnly = false;
            txtbox_tab2_bookprice.ReadOnly = false;
            txtbox_tab2_bookpages.ReadOnly = false;
            txtbox_tab2_bookabout.ReadOnly = false;

            txtbox_tab2_booknum.Text = "시스템에서 자동 입력되며, 보안을 위해 수정할 수 없습니다.";
            txtbox_tab2_bookname.Text = "";
            txtbox_tab2_isbn.Text = "";
            txtbox_tab2_bookwrite.Text = "";
            txtbox_tab2_bookpublisher.Text = "";
            txtbox_tab2_bookdate.Text = "";
            txtbox_tab2_bookprice.Text = "";
            txtbox_tab2_bookpages.Text = "";
            txtbox_tab2_bookabout.Text = "";
        }

        // <탭 2에서, 저장버튼 클릭 시>

        private void btn_tab2_save_Click(object sender, EventArgs e)
        {
            if (tab2_isBookReadOnly == true)
            {
                MessageBox.Show("신규 도서 등록시에만 사용 가능한 버튼입니다.");
            }
            else if (tab2_isBookModify == true)
            {
                if (txtbox_tab2_bookname.Text != "" && combobox_tab2_bookstatus.Text != "")
                {
                    string modifybook_insertQuery = "UPDATE library_project.book SET 이름 = '" + txtbox_tab2_bookname.Text + "', ISBN = '" + txtbox_tab2_isbn.Text + "', 저자 = '" + txtbox_tab2_bookwrite.Text + "', 출판일자 = '" + txtbox_tab2_bookdate.Text + "', 출판사 = '" + txtbox_tab2_bookpublisher.Text + "', 도서상태 = '" + combobox_tab2_bookstatus.Text + "', 대출여부 = '" + combobox_tab2_bookloanstatus.Text + "', 도서가격 = '" + txtbox_tab2_bookprice.Text + "', 페이지수 = '" + txtbox_tab2_bookpages.Text + "', 도서소개 = '" + txtbox_tab2_bookabout.Text + "' WHERE 관리번호 = '" + txtbox_tab2_booknum.Text + "';";
                    connection.Open();
                    MySqlCommand modi1fy_command = new MySqlCommand(modifybook_insertQuery, connection);

                    try
                    {
                        if (modi1fy_command.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("수정 요청하신 도서 관리번호 " + txtbox_tab2_booknum.Text + " 도서가 데이터베이스에 수정되었습니다. 조회 버튼을 눌러, 도서 목록을 다시 재 조회 바랍니다.");
                            // 도서 정보 텍스트박스 초기화
                            txtbox_tab2_bookname.Text = "";
                            txtbox_tab2_isbn.Text = "";
                            txtbox_tab2_bookwrite.Text = "";
                            txtbox_tab2_bookpublisher.Text = "";
                            txtbox_tab2_bookdate.Text = "";
                            txtbox_tab2_bookprice.Text = "";
                            txtbox_tab2_bookpages.Text = "";
                            txtbox_tab2_bookabout.Text = "";

                            // 데이터 조회 화면 초기화
                            data_tab2_book.DataSource = "";
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "도서수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "도서수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            else if (tab2_isBookNew == true)
            {
                if (txtbox_tab2_bookname.Text != "" && combobox_tab2_bookstatus.Text != "")
                {
                    string book_num = DateTime.Now.ToString("ssmmhhddMMyy");

                    string newbook_insertQuery = "INSERT INTO library_project.book (관리번호, 이름, ISBN, 저자, 출판일자, 출판사, 도서상태, 대출여부, 도서가격, 페이지수, 도서소개) VALUES ('" + book_num + "', '" + txtbox_tab2_bookname.Text + "', '" + txtbox_tab2_isbn.Text + "', '" + txtbox_tab2_bookwrite.Text + "', '" + txtbox_tab2_bookdate.Text + "', '" + txtbox_tab2_bookpublisher.Text + "', '" + combobox_tab2_bookstatus.Text + "', '" + combobox_tab2_bookloanstatus.Text + "', '" + txtbox_tab2_bookprice.Text + "', '" + txtbox_tab2_bookpages.Text + "', '" + txtbox_tab2_bookabout.Text + "');";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(newbook_insertQuery, connection);

                    try
                    {
                        if (command.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("신규 등록하신 " + txtbox_tab2_bookname.Text + " 도서가 데이터베이스에 등록되었습니다. 본 도서의 관리 번호는 " + book_num + "입니다. 조회 버튼을 눌러, 도서 목록을 다시 재 조회 바랍니다.");

                            // 도서 정보 텍스트박스 초기화
                            txtbox_tab2_bookname.Text = "";
                            txtbox_tab2_isbn.Text = "";
                            txtbox_tab2_bookwrite.Text = "";
                            txtbox_tab2_bookpublisher.Text = "";
                            txtbox_tab2_bookdate.Text = "";
                            txtbox_tab2_bookprice.Text = "";
                            txtbox_tab2_bookpages.Text = "";
                            txtbox_tab2_bookabout.Text = "";

                            // 데이터 조회 화면 초기화
                            data_tab2_book.DataSource = "";
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "도서등록 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "도서등록 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("도서 이름과 도서 상태 항목은 필수 입력 항목입니다. 필수 입력 항목을 입력 후, 다시 시도해 주세요.");
                }
            }
            else
            {
                MessageBox.Show("도서 수정 모드 또는 신규 등록 모드에서만 작동 가능한 버튼입니다.");
            }
        }

        // <탭 2에서, 도서정보 강제삭제 클릭 시>
        private void btn_tab2_delete_Click(object sender, EventArgs e)
        {
            if (tab2_isBookModify == true)
            {
                if (MessageBox.Show("정말 " + txtbox_tab2_bookname.Text + "도서의 정보를 삭제하시겠습니까? 처리 이후에는 복구할 수 없습니다.", "도서정보 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string delBook_insertQuery = "DELETE FROM library_project.book WHERE 관리번호 = '" + txtbox_tab2_booknum.Text + "';";
                    connection.Open();
                    MySqlCommand delBook_command = new MySqlCommand(delBook_insertQuery, connection);

                    try
                    {
                        if (delBook_command.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("삭제 요청하신 관리번호 " + txtbox_tab2_booknum.Text + " 도서의 정보가 데이터베이스에서 삭제되었습니다. 조회 버튼을 눌러, 도서 목록을 다시 재 조회 바랍니다.");
                            // 도서 정보 텍스트박스 초기화
                            txtbox_tab2_booknum.Text = "";
                            txtbox_tab2_bookname.Text = "";
                            txtbox_tab2_isbn.Text = "";
                            txtbox_tab2_bookwrite.Text = "";
                            txtbox_tab2_bookpublisher.Text = "";
                            txtbox_tab2_bookdate.Text = "";
                            txtbox_tab2_bookprice.Text = "";
                            txtbox_tab2_bookpages.Text = "";
                            txtbox_tab2_bookabout.Text = "";

                            // 데이터 조회 화면 초기화
                            data_tab2_book.DataSource = "";
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "회원정보 수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "회원정보 수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("도서정보 수정 모드에서만 강제 삭제 처리가 가능합니다. 도서 관리 모드를 변경 후 진행 바랍니다.");
            }
        }

        // <탭 2에서, 입력내용 초기화 버튼 클릭 시>
        private void btn_tab2_reset_Click(object sender, EventArgs e)
        {
            txtbox_tab2_booknum.Text = "";
                txtbox_tab2_bookname.Text = "";
                txtbox_tab2_isbn.Text = "";
                txtbox_tab2_bookwrite.Text = "";
                txtbox_tab2_bookpublisher.Text = "";
                txtbox_tab2_bookdate.Text = "";
                txtbox_tab2_bookprice.Text = "";
                txtbox_tab2_bookpages.Text = "";
                txtbox_tab2_bookabout.Text = "";
        }

        // <탭 3에서, 조회/재조회 버튼 클릭시>
        private void btn_tab3_loadmem_Click(object sender, EventArgs e)
        {
            string insertQuery_loadMember = "SELECT 회원번호, 이름, 아이디, 성별, 주소, 연락처, 생년월일, 이메일, 가입일, 대출권수, 회원상태 FROM library_project.member;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery_loadMember, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable load_data_tab3_member = new DataTable();
            adapter.Fill(load_data_tab3_member);
            data_tab3_member.DataSource = load_data_tab3_member;
            connection.Close();
        }

        // <탭 3에서, 회원목록 셀 클릭 시>
        private void data_tab3_member_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_tab3_membernum.Text = data_tab3_member.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_tab3_membername.Text = data_tab3_member.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtbox_tab3_memberid.Text = data_tab3_member.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtbox_tab3_membergender.Text = data_tab3_member.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtbox_tab3_address.Text = data_tab3_member.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtbox_tab3_membertel.Text = data_tab3_member.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtbox_tab3_memberbirth.Text = data_tab3_member.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtbox_tab3_memberemail.Text = data_tab3_member.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtbox_tab3_membernewdate.Text = data_tab3_member.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtbox_tab3_loan.Text = data_tab3_member.Rows[e.RowIndex].Cells[9].Value.ToString();
                combobox_tab3_memberstatus.Text = data_tab3_member.Rows[e.RowIndex].Cells[10].Value.ToString();

            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }

        // <탭 3에서, 회원관리모드 변경 시 - 열람모드>
        private void rdobtn_tab3_seemode_CheckedChanged(object sender, EventArgs e)
        {
            tab3_isMemModify = false;
            tab3_isMemReadOnly = true;

            txtbox_tab3_membername.ReadOnly = true;
            txtbox_tab3_memberid.ReadOnly = true;
            txtbox_tab3_membergender.ReadOnly = true;
            txtbox_tab3_membernewdate.ReadOnly = true;
            txtbox_tab3_memberbirth.ReadOnly = true;
            txtbox_tab3_membertel.ReadOnly = true;
            txtbox_tab3_memberemail.ReadOnly = true;
            txtbox_tab3_loan.ReadOnly = true;
            txtbox_tab3_address.ReadOnly = true;
        }

        // <탭 3에서, 회원관리모드 변경 시 - 수정모드>

        private void rdobtn_tab3_modifymode_CheckedChanged(object sender, EventArgs e)
        {
            tab3_isMemModify = true;
            tab3_isMemReadOnly = false;

            txtbox_tab3_membername.ReadOnly = false;
            txtbox_tab3_memberid.ReadOnly = true;
            txtbox_tab3_membergender.ReadOnly = false;
            txtbox_tab3_membernewdate.ReadOnly = false;
            txtbox_tab3_memberbirth.ReadOnly = false;
            txtbox_tab3_membertel.ReadOnly = false;
            txtbox_tab3_memberemail.ReadOnly = false;
            txtbox_tab3_loan.ReadOnly = true;
            txtbox_tab3_address.ReadOnly = false;
        }

        // <탭 3에서, 회원검색 범주 선택시>
        private void combobox_tab3_searchmem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_tab3_searchmem.SelectedItem.ToString() == "회원번호")
            {
                txtbox_tab3_searchmem.Visible = false;
                txtbox_tab3_searchmem.Text = "";

                maskedtxtbox_tab3_search.Visible = true;
                maskedtxtbox_tab3_search.Text = "";
                maskedtxtbox_tab3_search.Mask = "000000000000";

                combobox_tab3_searchmembystatus.Visible = false;
            }
            else if (combobox_tab3_searchmem.SelectedItem.ToString() == "회원상태")
            {
                txtbox_tab3_searchmem.Visible = false;
                txtbox_tab3_searchmem.Text = "";

                maskedtxtbox_tab3_search.Visible = false;
                maskedtxtbox_tab3_search.Text = "";
                maskedtxtbox_tab3_search.Mask = "000000000000";

                combobox_tab3_searchmembystatus.Visible = true;
            }
            else if (combobox_tab3_searchmem.SelectedItem.ToString() == "이름")
            {
                txtbox_tab3_searchmem.Visible = true;
                txtbox_tab3_searchmem.Text = "";

                maskedtxtbox_tab3_search.Visible = false;
                maskedtxtbox_tab3_search.Text = "";
                maskedtxtbox_tab3_search.Mask = "000000000000";

                combobox_tab3_searchmembystatus.Visible = false;
            }
            else if (combobox_tab3_searchmem.SelectedItem.ToString() == "아이디")
            {
                txtbox_tab3_searchmem.Visible = true;
                txtbox_tab3_searchmem.Text = "";

                maskedtxtbox_tab3_search.Visible = false;
                maskedtxtbox_tab3_search.Text = "";
                maskedtxtbox_tab3_search.Mask = "000000000000";

                combobox_tab3_searchmembystatus.Visible = false;
            }
            else if (combobox_tab3_searchmem.SelectedItem.ToString() == "연락처")
            {
                txtbox_tab3_searchmem.Visible = false;
                txtbox_tab3_searchmem.Text = "";

                maskedtxtbox_tab3_search.Visible = true;
                maskedtxtbox_tab3_search.Text = "";
                maskedtxtbox_tab3_search.Mask = "000-0000-0000";

                combobox_tab3_searchmembystatus.Visible = false;
            }
            else if (combobox_tab3_searchmem.SelectedItem.ToString() == "생년월일")
            {
                txtbox_tab3_searchmem.Visible = false;
                txtbox_tab3_searchmem.Text = "";

                maskedtxtbox_tab3_search.Visible = true;
                maskedtxtbox_tab3_search.Text = "";
                maskedtxtbox_tab3_search.Mask = "0000-00-00";

                combobox_tab3_searchmembystatus.Visible = false;
            }
            else if (combobox_tab3_searchmem.SelectedItem.ToString() == "이메일")
            {
                txtbox_tab3_searchmem.Visible = true;
                txtbox_tab3_searchmem.Text = "";

                maskedtxtbox_tab3_search.Visible = false;
                maskedtxtbox_tab3_search.Text = "";
                maskedtxtbox_tab3_search.Mask = "000000000000";

                combobox_tab3_searchmembystatus.Visible = false;
            }
        }

        // <탭 3에서, 회원 검색 버튼 클릭 시>
        private void btn_tab3_searchmem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_tab3_searchmem.Text == "" && maskedtxtbox_tab3_search.Text == "" && combobox_tab3_searchmembystatus.Text == "")
                {
                    MessageBox.Show("검색명 입력 후 시도 바랍니다.");
                }
                else
                {
                    if (combobox_tab3_searchmem.Text == "회원번호")
                    {
                        string searchMemNum_insertQuery = "SELECT * FROM library_project.member WHERE 회원번호 ='" + maskedtxtbox_tab3_search.Text + "';";
                        connection.Open();
                        MySqlCommand searchMem_command = new MySqlCommand(searchMemNum_insertQuery, connection);
                        MySqlDataAdapter result_searchMem = new MySqlDataAdapter(searchMem_command);

                        DataTable load_mem_search = new DataTable();
                        result_searchMem.Fill(load_mem_search);

                        data_tab3_member.DataSource = load_mem_search;
                        connection.Close();
                    }
                    else if (combobox_tab3_searchmem.Text == "회원상태")
                    {
                        string searchMemStatus_insertQuery = "SELECT * FROM library_project.member WHERE 회원상태 ='" + combobox_tab3_searchmembystatus.Text + "';";
                        connection.Open();
                        MySqlCommand searchMem_command = new MySqlCommand(searchMemStatus_insertQuery, connection);
                        MySqlDataAdapter result_searchMem = new MySqlDataAdapter(searchMem_command);

                        DataTable load_mem_search = new DataTable();
                        result_searchMem.Fill(load_mem_search);

                        data_tab3_member.DataSource = load_mem_search;
                        connection.Close();
                    }
                    else if (combobox_tab3_searchmem.Text == "이름")
                    {
                        string searchMemName_insertQuery = "SELECT * FROM library_project.member WHERE 이름 ='" + txtbox_tab3_searchmem.Text + "';";
                        connection.Open();
                        MySqlCommand searchMem_command = new MySqlCommand(searchMemName_insertQuery, connection);
                        MySqlDataAdapter result_searchMem = new MySqlDataAdapter(searchMem_command);

                        DataTable load_mem_search = new DataTable();
                        result_searchMem.Fill(load_mem_search);

                        data_tab3_member.DataSource = load_mem_search;
                        connection.Close();
                    }
                    else if (combobox_tab3_searchmem.Text == "아이디")
                    {
                        string searchMemId_insertQuery = "SELECT * FROM library_project.member WHERE 아이디 ='" + txtbox_tab3_memberid.Text + "';";
                        connection.Open();
                        MySqlCommand searchMem_command = new MySqlCommand(searchMemId_insertQuery, connection);
                        MySqlDataAdapter result_searchMem = new MySqlDataAdapter(searchMem_command);

                        DataTable load_mem_search = new DataTable();
                        result_searchMem.Fill(load_mem_search);

                        data_tab3_member.DataSource = load_mem_search;
                        connection.Close();
                    }
                    else if (combobox_tab3_searchmem.Text == "연락처")
                    {
                        string searchMemTel_insertQuery = "SELECT * FROM library_project.member WHERE 연락처 ='" + maskedtxtbox_tab3_search.Text + "';";
                        connection.Open();
                        MySqlCommand searchMem_command = new MySqlCommand(searchMemTel_insertQuery, connection);
                        MySqlDataAdapter result_searchMem = new MySqlDataAdapter(searchMem_command);

                        DataTable load_mem_search = new DataTable();
                        result_searchMem.Fill(load_mem_search);

                        data_tab3_member.DataSource = load_mem_search;
                        connection.Close();
                    }
                    else if (combobox_tab3_searchmem.Text == "생년월일")
                    {
                        string searchMembirth_insertQuery = "SELECT * FROM library_project.member WHERE 생년월일 ='" + maskedtxtbox_tab3_search.Text + "';";
                        connection.Open();
                        MySqlCommand searchMem_command = new MySqlCommand(searchMembirth_insertQuery, connection);
                        MySqlDataAdapter result_searchMem = new MySqlDataAdapter(searchMem_command);

                        DataTable load_mem_search = new DataTable();
                        result_searchMem.Fill(load_mem_search);

                        data_tab3_member.DataSource = load_mem_search;
                        connection.Close();
                    }
                    else if (combobox_tab3_searchmem.Text == "이메일")
                    {
                        string searchMemEmail_insertQuery = "SELECT * FROM library_project.member WHERE 이메일 ='" + txtbox_tab3_memberemail.Text + "';";
                        connection.Open();
                        MySqlCommand searchMem_command = new MySqlCommand(searchMemEmail_insertQuery, connection);
                        MySqlDataAdapter result_searchMem = new MySqlDataAdapter(searchMem_command);

                        DataTable load_mem_search = new DataTable();
                        result_searchMem.Fill(load_mem_search);

                        data_tab3_member.DataSource = load_mem_search;
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("범주 선택 후 검색 바랍니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "회원검색 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // <탭 3에서, 회원정보 저장 버튼 클릭 시>
        private void btn_tab3_save_Click(object sender, EventArgs e)
        {
            if (tab3_isMemReadOnly == true)
            {
                MessageBox.Show("신규 멤버 등록시에만 사용 가능한 버튼입니다. 회원 관리 모드를 변경 후 진행 바랍니다.");
            }
            else if (tab3_isMemModify == true)
            {
                if (txtbox_tab3_membername.Text != "" && txtbox_tab3_membername.Text != "")
                {
                    string modifymem_insertQuery = "UPDATE library_project.member SET 이름 = '" + txtbox_tab3_membername.Text + "', 성별 = '" + txtbox_tab3_membergender.Text + "', 주소 = '" + txtbox_tab3_address.Text + "', 연락처 = '" + txtbox_tab3_membertel.Text + "', 생년월일 = '" + txtbox_tab3_memberbirth.Text + "', 이메일 = '" + txtbox_tab3_memberemail.Text + "', 가입일 = '" + txtbox_tab3_membernewdate.Text + "', 회원상태 = '" + combobox_tab3_memberstatus.Text + "' WHERE 회원번호 = '" + txtbox_tab3_membernum.Text + "';";
                    connection.Open();
                    MySqlCommand modifymem_command = new MySqlCommand(modifymem_insertQuery, connection);

                    try
                    {
                        if (modifymem_command.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("수정 요청하신 회원번호 " + txtbox_tab3_membernum.Text + " 회원의 정보가 데이터베이스에 수정되었습니다. 조회 버튼을 눌러, 회원 목록을 다시 재 조회 바랍니다.");
                            // 회원 정보 텍스트박스 초기화
                            txtbox_tab3_membername.Text = "";
                            txtbox_tab3_memberid.Text = "";
                            txtbox_tab3_membergender.Text = "";
                            txtbox_tab3_membernewdate.Text = "";
                            txtbox_tab3_memberbirth.Text = "";
                            txtbox_tab3_membertel.Text = "";
                            txtbox_tab3_memberemail.Text = "";
                            txtbox_tab3_loan.Text = "";
                            txtbox_tab3_address.Text = "";

                            // 데이터 조회 화면 초기화
                            data_tab3_member.DataSource = "";
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "회원정보 수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "회원정보 수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("도서 관리 모드를 우선 선택 후 진행 바랍니다.");
                }
            }
        }

        // <탭 3에서, 입력내용 초기화 클릭 시>

        private void btn_tab3_reset_Click(object sender, EventArgs e)
        {
            // 회원 정보 텍스트박스 초기화
            txtbox_tab3_membernum.Text = "";
            txtbox_tab3_membername.Text = "";
            txtbox_tab3_memberid.Text = "";
            txtbox_tab3_membergender.Text = "";
            txtbox_tab3_membernewdate.Text = "";
            txtbox_tab3_memberbirth.Text = "";
            txtbox_tab3_membertel.Text = "";
            txtbox_tab3_memberemail.Text = "";
            txtbox_tab3_loan.Text = "";
            txtbox_tab3_address.Text = "";
        }

        // <탭 3에서, 회원 강제탈퇴 클릭 시>
        private void btn_tab3_delete_Click(object sender, EventArgs e)
        {
            if (tab3_isMemModify == true)
            {
                if (MessageBox.Show("정말 " + txtbox_tab3_membername.Text + "회원을 강제 탈퇴 처리하시겠습니까? 처리 이후에는 복구할 수 없습니다.", "회원정보 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string delMem_insertQuery = "DELETE FROM library_project.member WHERE 회원번호 = '" + txtbox_tab3_membernum.Text + "';";
                    connection.Open();
                    MySqlCommand delMem_command = new MySqlCommand(delMem_insertQuery, connection);

                    try
                    {
                        if (delMem_command.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("삭제 요청하신 회원번호 " + txtbox_tab3_membernum.Text + " 회원의 정보가 데이터베이스에서 삭제되었습니다. 조회 버튼을 눌러, 회원 목록을 다시 재 조회 바랍니다.");
                            // 회원 정보 텍스트박스 초기화
                            txtbox_tab3_membername.Text = "";
                            txtbox_tab3_memberid.Text = "";
                            txtbox_tab3_membergender.Text = "";
                            txtbox_tab3_membernewdate.Text = "";
                            txtbox_tab3_memberbirth.Text = "";
                            txtbox_tab3_membertel.Text = "";
                            txtbox_tab3_memberemail.Text = "";
                            txtbox_tab3_loan.Text = "";
                            txtbox_tab3_address.Text = "";

                            // 데이터 조회 화면 초기화
                            data_tab3_member.DataSource = "";
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "강제 회원탈퇴 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "강제 회원탈퇴 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("회원정보 수정 모드에서만 강제 탈퇴 처리가 가능합니다. 회원 관리 모드를 변경 후 진행 바랍니다.");
            }
        }

        // <탭 4에서, 조회 / 재조회 버튼 클릭시>
        private void btn_tab4_load_Click(object sender, EventArgs e)
        {
            string loadfree_insertQuery = "SELECT * FROM library_project.board_free;";
            connection.Open();
            MySqlCommand loadfree_command = new MySqlCommand(loadfree_insertQuery, connection);

            try
            {
                MySqlDataAdapter result_loadfree = new MySqlDataAdapter(loadfree_command);

                DataTable data_load_free = new DataTable();
                result_loadfree.Fill(data_load_free);

                data_tab4_free.DataSource = data_load_free;

                string loadnotice_insertQuery = "SELECT * FROM library_project.board_notice;";
                MySqlCommand loadnotice_command = new MySqlCommand(loadnotice_insertQuery, connection);
                MySqlDataAdapter result_loadnotice = new MySqlDataAdapter(loadnotice_command);

                DataTable data_load_notice = new DataTable();
                result_loadnotice.Fill(data_load_notice);

                data_tab4_notice.DataSource = data_load_notice;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "게시판 조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        // <탭 4에서, 공지사항 클릭 시 txtbox로 내용전달>
        private void data_tab4_notice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_tab4_notice_title.Text = data_tab4_notice.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_tab4_notice_body.Text = data_tab4_notice.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }

        // <탭 4에서, 공지 관리모드를 열람모드로 변경 시>
        private void rdobtn_tab4_seeNotice_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtn_tab4_seeNotice.Checked == true)
            {
                tab4_isNoticeReadOnly = true;
                tab4_isNoticeModify = false;
                tab4_isNoticeNew = false;

                txtbox_tab4_notice_title.ReadOnly = true;
                txtbox_tab4_notice_body.ReadOnly = true;
            }
        }

        // <탭 4에서, 공지 관리모드를 수정모드로 변경 시>
        private void rdobtn_tab4_modifyNotice_CheckedChanged(object sender, EventArgs e)
        {
            tab4_isNoticeReadOnly = false;
            tab4_isNoticeModify = true;
            tab4_isNoticeNew = false;

            txtbox_tab4_notice_title.ReadOnly = true;
            txtbox_tab4_notice_body.ReadOnly = false;
        }

        // <탭 4에서, 공지 관리모드를 신규모드로 변경 시>
        private void rdobtn_tab4_newNotice_CheckedChanged(object sender, EventArgs e)
        {
            tab4_isNoticeReadOnly = false;
            tab4_isNoticeModify = false;
            tab4_isNoticeNew = true;

            txtbox_tab4_notice_title.ReadOnly = false;
            txtbox_tab4_notice_body.ReadOnly = false;

            txtbox_tab4_notice_title.Text = "";
            txtbox_tab4_notice_body.Text = "";
        }

        // <탭 4에서, 공지 검색 버튼 클릭 시>
        private void btn_tab4_searchNotice_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_tab4_searchNotice.Text == "")
                {
                    MessageBox.Show("검색명 입력 후 시도 바랍니다.");
                }
                else
                {
                    if (combobox_tab4_notice_search.Text == "제목")
                    {
                        string insertQuery_searchtitle = "SELECT * FROM library_project.board_notice WHERE 제목 = '" + txtbox_tab4_searchNotice.Text + "';";
                        connection.Open();
                        MySqlCommand searchCommand = new MySqlCommand(insertQuery_searchtitle, connection);
                        MySqlDataAdapter searchAdapter = new MySqlDataAdapter(searchCommand);

                        DataTable load_data_notice = new DataTable();
                        searchAdapter.Fill(load_data_notice);

                        data_tab4_notice.DataSource = load_data_notice;
                        connection.Close();
                    }
                    else if (combobox_tab4_notice_search.Text == "내용")
                    {
                        string insertQuery_searchbody = "SELECT * FROM library_project.board_notice WHERE 내용 = '" + txtbox_tab4_searchNotice.Text + "';";
                        connection.Open();
                        MySqlCommand searchCommand = new MySqlCommand(insertQuery_searchbody, connection);
                        MySqlDataAdapter searchAdapter = new MySqlDataAdapter(searchCommand);

                        DataTable load_data_notice = new DataTable();
                        searchAdapter.Fill(load_data_notice);

                        data_tab4_notice.DataSource = load_data_notice;
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("범주 선택 후 검색 바랍니다.");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "게시판 검색 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // <탭 4에서, 공지 저장 버튼 클릭 시>
        private void btn_tab4_notice_save_Click(object sender, EventArgs e)
        {
            if (tab4_isNoticeReadOnly == true)
            {
                MessageBox.Show("수정 모드에서만 사용 가능한 버튼입니다. 회원 관리 모드를 변경 후 진행 바랍니다.");
            }
            else if (tab4_isNoticeModify == true)
            {
                if (txtbox_tab4_notice_title.Text != "" && txtbox_tab4_notice_body.Text != "")
                {
                    string modifyNotice_insertQuery = "UPDATE library_project.board_notice SET 내용 = '" + txtbox_tab4_notice_body.Text + "' WHERE 제목 = '" + txtbox_tab4_notice_title.Text + "';";
                    connection.Open();
                    MySqlCommand modifyNotice_command = new MySqlCommand(modifyNotice_insertQuery, connection);

                    try
                    {
                        if (modifyNotice_command.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("수정 요청하신 공지사항 제목 : " + txtbox_tab4_notice_title.Text + " 공지의 내용 수정이 완료되었습니다. 조회 버튼을 눌러, 공지사항 목록을 다시 재 조회 바랍니다.");

                            // 공지사항 텍스트박스 초기화
                            txtbox_tab4_notice_title.Text = "";
                            txtbox_tab4_notice_body.Text = "";

                            // 데이터 조회 화면 초기화
                            data_tab4_notice.DataSource = "";
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "공지사항 수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "공지사항 수정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            else if (tab4_isNoticeNew == true)
            {
                if (txtbox_tab4_notice_title.Text != "" && txtbox_tab4_notice_body.Text != "")
                {
                    string newNotice_insertQuery = "INSERT INTO library_project.board_notice (제목, 내용) VALUES ('" + txtbox_tab4_notice_title.Text + "', '" + txtbox_tab4_notice_body.Text + "');";
                    connection.Open();
                    MySqlCommand newNotice_command = new MySqlCommand(newNotice_insertQuery, connection);

                    try
                    {
                        if (newNotice_command.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("신규등록 요청하신 공지사항 제목 : " + txtbox_tab4_notice_title.Text + " 공지사항 게시글이 데이터베이스에 등록되었습니다. 조회 버튼을 눌러, 공지사항 목록을 다시 재 조회 바랍니다.");

                            // 공지사항 텍스트박스 초기화
                            txtbox_tab4_notice_title.Text = "";
                            txtbox_tab4_notice_body.Text = "";

                            // 데이터 조회 화면 초기화
                            data_tab4_notice.DataSource = "";
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "공지사항 등록 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "공지사항 등록 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("게시판 관리 모드를 우선 선택 후 진행 바랍니다.");
            }
        }

        // <탭 4에서, 공지 삭제 버튼 클릭 시>
        private void btn_tab4_notice_delete_Click(object sender, EventArgs e)
        {
            if (tab4_isNoticeReadOnly == true)
            {
                MessageBox.Show("수정 모드에서만 사용 가능한 버튼입니다. 게시판 관리 모드를 변경 후 진행 바랍니다.");
            }
            else if (tab4_isNoticeModify == true)
            {
                txtbox_tab4_notice_title.ReadOnly = false;
                txtbox_tab4_notice_body.ReadOnly = false;
                if (txtbox_tab4_notice_title.Text == "")
                {
                    MessageBox.Show("삭제할 공지사항이 선택되지 않았습니다. 공지사항 선택 후 처리 바랍니다.");
                }
                else
                {
                    if (MessageBox.Show("정말 " + txtbox_tab4_notice_title.Text + " 공지사항을 삭제하시겠습니까? 처리 이후에는 복구할 수 없습니다.", "공지사항 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string delNotice_insertQuery = "DELETE FROM library_project.board_notice WHERE 제목 = '" + txtbox_tab4_notice_title.Text + "';";
                        connection.Open();
                        MySqlCommand delNotice_command = new MySqlCommand(delNotice_insertQuery, connection);

                        try
                        {
                            if (delNotice_command.ExecuteNonQuery() != 0)
                            {
                                MessageBox.Show("삭제 요청하신 공지사항 " + txtbox_tab4_notice_title.Text + " 게시글이 데이터베이스에서 삭제되었습니다. 조회 버튼을 눌러, 공지사항 목록을 다시 재 조회 바랍니다.");

                                // 공지사항 텍스트박스 초기화
                                txtbox_tab4_notice_title.Text = "";
                                txtbox_tab4_notice_title.Text = "";

                                // 데이터 조회 화면 초기화
                                data_tab4_notice.DataSource = "";
                            }
                            else
                            {
                                MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "공지사항 삭제 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "공지사항 삭제 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        connection.Close();
                    }
                    else
                    {
                        // 메시지박스 닫힘.
                    }
                }
            }
            else if (tab4_isNoticeNew == true)
            {
                txtbox_tab4_notice_title.ReadOnly = true;
                txtbox_tab4_notice_body.ReadOnly = true;

                MessageBox.Show("수정 모드에서만 사용 가능한 버튼입니다. 게시판 관리 모드를 변경 후 진행 바랍니다.");
            }
            else
            {
                MessageBox.Show("게시판 관리 모드를 우선 선택 후 진행 바랍니다.");
            }
        }

        // <탭 4에서, 입력 내용 초기화 버튼 클릭 시>
        private void btn_tab4_notice_reset_Click(object sender, EventArgs e)
        {
            if (tab4_isNoticeReadOnly)
            {
                MessageBox.Show("수정 모드에서만 사용 가능한 버튼입니다. 게시판 관리 모드를 변경 후 진행 바랍니다.");
            }
            else if (tab4_isNoticeModify)
            {
                txtbox_tab4_notice_title.ReadOnly = false;
                txtbox_tab4_notice_body.ReadOnly = false;
            }
            else if (tab4_isNoticeNew)
            {
                txtbox_tab4_notice_title.ReadOnly = false;
                txtbox_tab4_notice_body.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("게시판 관리 모드를 우선 선택 후 진행 바랍니다.");
            }
        }

        // <탭 4에서, 자유게시판 글 클릭 시 txtbox로 내용전달>
        private void data_tab4_free_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_tab4_free_writer.Text = data_tab4_free.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_tab4_free_writernum.Text = data_tab4_free.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtbox_tab4_free_name.Text = data_tab4_free.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtbox_tab4_free_body.Text = data_tab4_free.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }


        // <탭 4에서, 자유 검색 버튼 클릭 시>
        private void btn_tab4_searchFree_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_tab4_searchFree.Text == "")
                {
                    MessageBox.Show("검색명 입력 후 시도 바랍니다.");
                }
                else
                {
                    if (combobox_tab4_searchFree.Text == "제목")
                    {
                        string insertQuery_searchtitle = "SELECT * FROM library_project.board_free WHERE 제목 = '" + txtbox_tab4_searchFree.Text + "';";
                        connection.Open();
                        MySqlCommand searchCommand = new MySqlCommand(insertQuery_searchtitle, connection);
                        MySqlDataAdapter searchAdapter = new MySqlDataAdapter(searchCommand);

                        DataTable load_data_free = new DataTable();
                        searchAdapter.Fill(load_data_free);

                        data_tab4_free.DataSource = load_data_free;
                        connection.Close();
                    }
                    else if (combobox_tab4_notice_search.Text == "내용")
                    {
                        string insertQuery_searchbody = "SELECT * FROM library_project.board_free WHERE 내용 = '%" + txtbox_tab4_searchFree.Text + "%';";
                        connection.Open();
                        MySqlCommand searchCommand = new MySqlCommand(insertQuery_searchbody, connection);
                        MySqlDataAdapter searchAdapter = new MySqlDataAdapter(searchCommand);

                        DataTable load_data_free = new DataTable();
                        searchAdapter.Fill(load_data_free);

                        data_tab4_notice.DataSource = load_data_free;
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("범주 선택 후 검색 바랍니다.");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "게시판 검색 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // <탭 4에서, 자유 관리모드를 열람모드로 변경 시>
        private void rdobtn_tab4_seeFree_CheckedChanged(object sender, EventArgs e)
        {
            tab4_isFreeReadOnly = true;
            tab4_isFreeModify = true;

            txtbox_tab4_free_name.ReadOnly = true;
            txtbox_tab4_free_body.ReadOnly = true;
            txtbox_tab4_free_writer.ReadOnly = true;
            txtbox_tab4_free_writernum.ReadOnly = true;
        }

        // <탭 4에서, 자유 관리모드를 삭제모드로 변경 시>
        private void rdobtn_tab4_deleteFree_CheckedChanged(object sender, EventArgs e)
        {
            tab4_isFreeReadOnly = false;
            tab4_isFreeModify = true;

            txtbox_tab4_free_name.ReadOnly = true;
            txtbox_tab4_free_body.ReadOnly = true;
            txtbox_tab4_free_writer.ReadOnly = true;
            txtbox_tab4_free_writernum.ReadOnly = true;
        }

        // <탭 4에서, 자유게시판 삭제 버튼 클릭 시>
        private void btn_tab4_free_delete_Click(object sender, EventArgs e)
        {
            if (tab4_isFreeModify == true)
            {
                if (MessageBox.Show("정말 자유게시판 " + txtbox_tab4_free_name.Text + " 글을 삭제 처리하시겠습니까? 처리 이후에는 복구할 수 없습니다.", "자유게시판 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string delFree_insertQuery = "DELETE FROM library_project.board_free WHERE 제목 = '" + txtbox_tab4_free_name.Text + "';";
                    connection.Open();
                    MySqlCommand delFree_command = new MySqlCommand(delFree_insertQuery, connection);

                    try
                    {
                        if (delFree_command.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("삭제 요청하신 게시글 " + txtbox_tab4_free_name.Text + " 글이 데이터베이스에서 삭제되었습니다. 조회 버튼을 눌러, 게시글 목록을 다시 재 조회 바랍니다.");

                            // 게시글 정보 텍스트박스 초기화
                            txtbox_tab4_free_name.Text = "";
                            txtbox_tab4_free_body.Text = "";
                            txtbox_tab4_free_writer.Text = "";
                            txtbox_tab4_free_writernum.Text = "";

                            // 데이터 조회 화면 초기화
                            data_tab4_free.DataSource = "";
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "게시글 삭제 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "게시글 삭제 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("삭제 모드에서만 강제 삭제가 가능합니다. 모드를 변경해 주세요.");
                }
            }
            else
            {
                MessageBox.Show("삭제 모드에서만 강제 삭제가 가능합니다. 모드를 변경해 주세요.");
            }
        }

        // <탭 4에서, 자유게시판 내용 초기화 버튼 클릭 시>
        private void btn_tab4_free_reset_Click(object sender, EventArgs e)
        {
            txtbox_tab4_free_name.Text = "";
            txtbox_tab4_free_body.Text = "";
            txtbox_tab4_free_writer.Text = "";
            txtbox_tab4_free_writernum.Text = "";
        }

        // <탭 5에서, 문의내역 불러오기 버튼 클릭 시>
        private void btn_tab5_load_Click(object sender, EventArgs e)
        {
            string loadqna_insertQuery = "SELECT * FROM library_project.board_qna;";
            connection.Open();
            MySqlCommand loadqna_command = new MySqlCommand(loadqna_insertQuery, connection);

            try
            {
                MySqlDataAdapter result_qna = new MySqlDataAdapter(loadqna_command);

                DataTable data_load_qna = new DataTable();
                result_qna.Fill(data_load_qna);

                data_tab5_qna.DataSource = data_load_qna;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "문의사항 조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        // <탭 5에서, 데이터그리드에 있는 항목을 선택하면 텍스트뷰로 뿌려줌>
        private void data_tab5_qna_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_tab5_memnum.Text = data_tab5_qna.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_tab5_memname.Text = data_tab5_qna.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtbox_tab5_mememail.Text = data_tab5_qna.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtbox_tab5_title.Text = data_tab5_qna.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtbox_tab5_body.Text = data_tab5_qna.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtbox_tab5_answer.Text = data_tab5_qna.Rows[e.RowIndex].Cells[5].Value.ToString();

            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }

        // <탭 5에서, 라디오 버튼을 선택해 모드 변경 시>
        private void rdobtn_tab5_see_CheckedChanged(object sender, EventArgs e)
        {
            tab5_isReadOnly = true;
            tab5_isModify = false;

            txtbox_tab5_memname.ReadOnly = true;
            txtbox_tab5_memnum.ReadOnly = true;
            txtbox_tab5_title.ReadOnly = true;
            txtbox_tab5_body.ReadOnly = true;
            txtbox_tab5_answer.ReadOnly = true;
        }

        private void rdo_btn5_set_CheckedChanged(object sender, EventArgs e)
        {
            tab5_isReadOnly = false;
            tab5_isModify = true;

            txtbox_tab5_memname.ReadOnly = true;
            txtbox_tab5_memnum.ReadOnly = true;
            txtbox_tab5_title.ReadOnly = true;
            txtbox_tab5_body.ReadOnly = true;
            txtbox_tab5_answer.ReadOnly = false;
        }

        private void btn_tab5_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_tab5_search.Text == "")
                {
                    MessageBox.Show("검색명 입력 후 시도 바랍니다.");
                }
                else
                {
                    if (combobox_tab5_search.Text == "제목")
                    {
                        string insertQuery_searchqnabyTitle = "SELECT * FROM library_project.board_qna WHERE 제목 = '" + txtbox_tab5_search.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery_searchqnabyTitle, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_qna = new DataTable();
                        adapter.Fill(load_qna);

                        data_tab5_qna.DataSource = load_qna;
                        connection.Close();
                    }
                    else if (combobox_tab5_search.Text == "내용")
                    {
                        string insertQuery_searchqnabyTitle = "SELECT * FROM library_project.board_qna WHERE 내용 = '" + txtbox_tab5_search.Text + "';";
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(insertQuery_searchqnabyTitle, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        DataTable load_qna = new DataTable();
                        adapter.Fill(load_qna);

                        data_tab5_qna.DataSource = load_qna;
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("범주 선택 후 검색 바랍니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "문의 게시글 검색 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkbox_tab5_emailsend_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_tab5_emailsend.Checked == true)
            {
                tab5_emailsend = true;
            }
            else if (chkbox_tab5_emailsend.Checked == false)
            {
                tab5_emailsend = false;
            }
        }

        private void btn_tab5_save_Click(object sender, EventArgs e)
        {
            if (tab5_isReadOnly == true)
            {
                MessageBox.Show("문의내용 삭제 / 답변 모드에서만 강제 삭제가 가능합니다. 모드를 변경해 주세요.");
            }
            else if (tab5_isModify == true)
            {
                if (txtbox_tab5_answer.Text != "")
                {
                    string insertQuery_qnaanswer = "UPDATE library_project.board_qna SET 답변 = '" + txtbox_tab5_answer.Text + "'WHERE 회원번호 = '" + txtbox_tab5_memnum.Text + "';";
                    connection.Open();
                    MySqlCommand qnaanswer_command = new MySqlCommand(insertQuery_qnaanswer, connection);

                    try
                    {
                        if (qnaanswer_command.ExecuteNonQuery() != 0)
                        {
                            if (tab5_emailsend == true)
                            {
                                MailMessage mail = new MailMessage();
                                mail.From = new MailAddress("praticecoding.h@gmail.com", "[일이삼사 도서관] 문의하신 내용에 대한 답변이 달렸습니다.", System.Text.Encoding.UTF8);
                                mail.To.Add(txtbox_tab5_mememail.Text);
                                mail.Subject = "[일이삼사 도서관] 문의하신 내용에 대한 답변이 달렸습니다.";
                                mail.Body = txtbox_tab5_memname.Text + " 회원님께서 작성하신 " + txtbox_tab5_title.Text + " 문의에 대한 답변입니다.\n\n" + "-------------------------------------------------------\n" + "답변 : " + txtbox_tab5_body.Text;

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

                                    MessageBox.Show(txtbox_tab5_memname.Text + " 회원에게 정상적으로 답변 안내 이메일을 전송하고, 문의 게시글에 대한 답변을 등록했습니다. 조회 버튼을 눌러, 게시글 목록을 다시 재 조회 바랍니다.");

                                    txtbox_tab5_title.Text = "";
                                    txtbox_tab5_body.Text = "";
                                    txtbox_tab5_memname.Text = "";
                                    txtbox_tab5_memnum.Text = "";
                                    txtbox_tab5_mememail.Text = "";
                                    txtbox_tab5_answer.Text = "";

                                    data_tab5_qna.DataSource = "";
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                            else if (tab5_emailsend == false)
                            {
                                MessageBox.Show(txtbox_tab5_memname.Text + " 회원님이 작성하신 " + txtbox_tab5_title.Text + " 문의 게시글에 대한 답변이 등록되었습니다. 조회 버튼을 눌러, 게시글 목록을 다시 재 조회 바랍니다.");

                                txtbox_tab5_title.Text = "";
                                txtbox_tab5_body.Text = "";
                                txtbox_tab5_memname.Text = "";
                                txtbox_tab5_memnum.Text = "";
                                txtbox_tab5_mememail.Text = "";
                                txtbox_tab5_answer.Text = "";

                                data_tab5_qna.DataSource = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("알 수 없는 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : ", "문의내용 답변 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "문의내용 답변 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("답변 내용 작성 후 진행 바랍니다.");
                }
            }
        }

        private void btn_tab5_delete_Click(object sender, EventArgs e)
        {
            if (tab5_isReadOnly == true)
            {
                MessageBox.Show("문의내용 삭제 / 답변 모드에서만 강제 삭제가 가능합니다. 모드를 변경해 주세요.");
            }
            else if (tab5_isModify == true)
            {
                if (MessageBox.Show("정말 " + txtbox_tab5_title.Text + " 문의 게시글을 삭제 처리하시겠습니까? 처리 이후에는 복구할 수 없습니다.", "문의 게시글 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string delqna_insertQuery = "DELETE FROM library_project.board_qna WHERE 회원번호 = '" + txtbox_tab5_memnum.Text + "';";
                    connection.Open();
                    MySqlCommand delqna_command = new MySqlCommand(delqna_insertQuery, connection);

                    try
                    {
                        if (delqna_command.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("삭제 요청하신 게시글 " + txtbox_tab5_title.Text + " 글이 데이터베이스에서 삭제되었습니다. 조회 버튼을 눌러, 게시글 목록을 다시 재 조회 바랍니다.");

                            txtbox_tab5_title.Text = "";
                            txtbox_tab5_body.Text = "";
                            txtbox_tab5_memname.Text = "";
                            txtbox_tab5_memnum.Text = "";
                            txtbox_tab5_mememail.Text = "";
                            txtbox_tab5_answer.Text = "";

                            data_tab5_qna.DataSource = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "게시글 삭제 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("삭제/답변 모드에서만 삭제가 가능합니다. 모드를 변경해 주세요.");
                }
            }
            else
            {
                //없음
            }
        }
    }
}
