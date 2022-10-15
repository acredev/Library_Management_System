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
    public partial class info : Form
    {
        public info()
        {
            InitializeComponent();
        }

        private void info_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://hangeul.naver.com/font");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:m_file@naver.com");
        }

        private void linkLabel2_MouseHover(object sender, EventArgs e)
        {
            toolTip_info.ToolTipTitle = "폰트 설치";
            toolTip_info.IsBalloon = true;
            toolTip_info.SetToolTip(linkLabel2, "나눔고딕 설치 바로가기");
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            toolTip_info.ToolTipTitle = "개발자 문의";
            toolTip_info.IsBalloon = true;
            toolTip_info.SetToolTip(linkLabel1, "개발자 문의 바로가기");
        }
    }
}
