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
    public partial class Normal_Mypage : Form
    {
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database=library_project;Uid=root;Pwd=root;");
        public Normal_Mypage()
        {
            InitializeComponent();
        }

        private void Normal_Mypage_Load(object sender, EventArgs e)
        {
            string insertQuery = "SELECT * FROM library_project.member WHERE 회원번호 = '" + Normal.static_memnum + "';";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_my = new DataTable();
                adapter.Fill(load_my);
                data_my.DataSource = load_my;


            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Application.Restart();
            }
        }

        private void data_my_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtbox_memnum.Text = data_my.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtbox_name.Text = data_my.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtbox_id.Text = data_my.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtbox_pwd.Text = data_my.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtbox_gender.Text = data_my.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtbox_address.Text = data_my.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtbox_tel.Text = data_my.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtbox_birth.Text = data_my.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtbox_email.Text = data_my.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtbox_newdate.Text = data_my.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtbox_loanbook.Text = data_my.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtbox_status.Text = data_my.Rows[e.RowIndex].Cells[11].Value.ToString();
            }
            catch (Exception)
            {
                // 예외처리는 따로 안함, catch문을 써야 cellclick시 에러가 발생하지 않음
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            string insertQuery = "SELECT * FROM library_project.member WHERE 회원번호 = '" + Normal.static_memnum + "';";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable load_my = new DataTable();
                adapter.Fill(load_my);
                data_my.DataSource = load_my;


            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 오류입니다. 오류보고 / 문의사항 메뉴에서 문의 바랍니다. \n\n오류내용 : " + ex.Message, "조회 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void rdobtn_readonly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdobtn_modify_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_modifymeminfo_Click(object sender, EventArgs e)
        {

        }

        private void btn_deletemem_Click(object sender, EventArgs e)
        {

        }
    }
}
