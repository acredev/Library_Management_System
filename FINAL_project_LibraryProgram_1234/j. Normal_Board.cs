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

        private void picture_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 후 메인화면으로 돌아가시겠습니까?", "로그아웃", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void data_notice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_notice_title.Text = data_notice.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_notice_body.Text = data_notice.Rows[e.RowIndex].Cells[1].Value.ToString();

                txtbox_free_who.Text = data_free.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_free_title.Text = data_free.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtbox_free_body.Text = data_free.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }
    }
}
