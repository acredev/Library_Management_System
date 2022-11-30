using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_project_LibraryProgram_1234
{
    public partial class NewMember_PersonalInformation : Form
    {
        public static bool chk1 = false;
        public static bool chk2 = false;

        public NewMember_PersonalInformation()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkbox_1_agree_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_1_agree.Checked == true)
            {
                chkbox_1_agree.Checked = true;
                chkbox_1_disagree.Checked = false;
                chk1 = true;
            }
            else
            {
                chk1 = false;
            }
        }

        private void chkbox_1_disagree_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_1_disagree.Checked == true)
            {
                chkbox_1_disagree.Checked = true;
                chkbox_1_agree.Checked = false;
                chk1 = false;
            }
            else
            {
                chk1 = true;
            }
        }

        private void btn_moveto_newmember_Click(object sender, EventArgs e)
        {
            if (chk1 == true && chk2 == true)
            {
                this.Visible = false;
                NewMember showNewMember_Normal = new NewMember();
                showNewMember_Normal.ShowDialog();
            }
            else if (chk1 == false && chk2 == true)
            {
                MessageBox.Show("이용약관에 미동의시 일이삼사 도서관리 프로그램을 정상적으로 이용하실 수 없습니다.", "이용약관 동의 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (chk1 == true && chk2 == false)
            {
                MessageBox.Show("개인정보 수집 및 이용동의 약관에 미동의시 일이삼사 도서관리 프로그램을 정상적으로 이용하실 수 없습니다.", "이용약관 동의 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("이용약관과 개인정보 수집 및 이용동의 약관에 미동의시 일이삼사 도서관리 프로그램을 정상적으로 이용하실 수 없습니다.", "이용약관 동의 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkbox2_agree_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox2_agree.Checked == true)
            {
                chkbox2_agree.Checked = true;
                chkbox_2_disagree.Checked = false;
                chk2 = true;
            }
            else
            {
                chk2 = false;
            }
        }

        private void chkbox_2_disagree_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_2_disagree.Checked == true)
            {
                chkbox_2_disagree.Checked = true;
                chkbox2_agree.Checked = false;
                chk2 = false;
            }
            else
            {
                chk2 = true;
            }
        }
    }
}
