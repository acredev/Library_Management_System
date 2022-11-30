
namespace FINAL_project_LibraryProgram_1234
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label_main = new System.Windows.Forms.Label();
            this.groupofbtn = new System.Windows.Forms.GroupBox();
            this.btn_support = new System.Windows.Forms.Button();
            this.btn_howtouse = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_login_master = new System.Windows.Forms.Button();
            this.btn_info = new System.Windows.Forms.Button();
            this.btn_login_normal = new System.Windows.Forms.Button();
            this.picturebox_main = new System.Windows.Forms.PictureBox();
            this.linklabel_gotofont = new System.Windows.Forms.LinkLabel();
            this.label_aboutfont = new System.Windows.Forms.Label();
            this.toolTip_InstallFont = new System.Windows.Forms.ToolTip(this.components);
            this.groupofbtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_main)).BeginInit();
            this.SuspendLayout();
            // 
            // label_main
            // 
            this.label_main.AutoSize = true;
            this.label_main.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_main.Location = new System.Drawing.Point(320, 45);
            this.label_main.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_main.Name = "label_main";
            this.label_main.Size = new System.Drawing.Size(452, 34);
            this.label_main.TabIndex = 0;
            this.label_main.Text = "일이삼사 도서관 도서 관리 프로그램";
            this.label_main.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupofbtn
            // 
            this.groupofbtn.Controls.Add(this.btn_support);
            this.groupofbtn.Controls.Add(this.btn_howtouse);
            this.groupofbtn.Controls.Add(this.btn_exit);
            this.groupofbtn.Controls.Add(this.btn_login_master);
            this.groupofbtn.Controls.Add(this.btn_info);
            this.groupofbtn.Controls.Add(this.btn_login_normal);
            this.groupofbtn.Location = new System.Drawing.Point(334, 86);
            this.groupofbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupofbtn.Name = "groupofbtn";
            this.groupofbtn.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupofbtn.Size = new System.Drawing.Size(415, 152);
            this.groupofbtn.TabIndex = 1;
            this.groupofbtn.TabStop = false;
            // 
            // btn_support
            // 
            this.btn_support.Cursor = System.Windows.Forms.Cursors.Help;
            this.btn_support.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_support.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_support.Location = new System.Drawing.Point(273, 78);
            this.btn_support.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_support.Name = "btn_support";
            this.btn_support.Size = new System.Drawing.Size(138, 34);
            this.btn_support.TabIndex = 5;
            this.btn_support.Text = "오류보고 / 개선요청";
            this.btn_support.UseVisualStyleBackColor = true;
            this.btn_support.Click += new System.EventHandler(this.btn_support_Click);
            // 
            // btn_howtouse
            // 
            this.btn_howtouse.Cursor = System.Windows.Forms.Cursors.Help;
            this.btn_howtouse.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_howtouse.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_howtouse.Location = new System.Drawing.Point(273, 45);
            this.btn_howtouse.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_howtouse.Name = "btn_howtouse";
            this.btn_howtouse.Size = new System.Drawing.Size(138, 34);
            this.btn_howtouse.TabIndex = 4;
            this.btn_howtouse.Text = "사용방법";
            this.btn_howtouse.UseVisualStyleBackColor = true;
            this.btn_howtouse.Click += new System.EventHandler(this.btn_howtouse_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_exit.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_exit.Location = new System.Drawing.Point(273, 112);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(138, 34);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "종료";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_login_master
            // 
            this.btn_login_master.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_login_master.Location = new System.Drawing.Point(139, 12);
            this.btn_login_master.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_login_master.Name = "btn_login_master";
            this.btn_login_master.Size = new System.Drawing.Size(134, 134);
            this.btn_login_master.TabIndex = 2;
            this.btn_login_master.Text = "도서관 관리자\r\n\r\n로그인";
            this.btn_login_master.UseVisualStyleBackColor = true;
            this.btn_login_master.Click += new System.EventHandler(this.btn_login_master_Click);
            // 
            // btn_info
            // 
            this.btn_info.Cursor = System.Windows.Forms.Cursors.Help;
            this.btn_info.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_info.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_info.Location = new System.Drawing.Point(273, 12);
            this.btn_info.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_info.Name = "btn_info";
            this.btn_info.Size = new System.Drawing.Size(138, 34);
            this.btn_info.TabIndex = 3;
            this.btn_info.Text = "정보";
            this.btn_info.UseVisualStyleBackColor = true;
            this.btn_info.Click += new System.EventHandler(this.btn_info_Click);
            // 
            // btn_login_normal
            // 
            this.btn_login_normal.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_login_normal.ImageKey = "(없음)";
            this.btn_login_normal.Location = new System.Drawing.Point(4, 12);
            this.btn_login_normal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_login_normal.Name = "btn_login_normal";
            this.btn_login_normal.Size = new System.Drawing.Size(134, 134);
            this.btn_login_normal.TabIndex = 1;
            this.btn_login_normal.Text = "개인 사용자\r\n\r\n로그인";
            this.btn_login_normal.UseVisualStyleBackColor = true;
            this.btn_login_normal.Click += new System.EventHandler(this.btn_login_normal_Click);
            // 
            // picturebox_main
            // 
            this.picturebox_main.Image = ((System.Drawing.Image)(resources.GetObject("picturebox_main.Image")));
            this.picturebox_main.Location = new System.Drawing.Point(34, 45);
            this.picturebox_main.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picturebox_main.Name = "picturebox_main";
            this.picturebox_main.Size = new System.Drawing.Size(275, 193);
            this.picturebox_main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox_main.TabIndex = 2;
            this.picturebox_main.TabStop = false;
            // 
            // linklabel_gotofont
            // 
            this.linklabel_gotofont.AutoSize = true;
            this.linklabel_gotofont.Font = new System.Drawing.Font("나눔고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.linklabel_gotofont.Location = new System.Drawing.Point(626, 250);
            this.linklabel_gotofont.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linklabel_gotofont.Name = "linklabel_gotofont";
            this.linklabel_gotofont.Size = new System.Drawing.Size(123, 14);
            this.linklabel_gotofont.TabIndex = 10;
            this.linklabel_gotofont.TabStop = true;
            this.linklabel_gotofont.Text = "나눔고딕 설치 바로가기";
            this.linklabel_gotofont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabel_gotofont_LinkClicked);
            this.linklabel_gotofont.MouseHover += new System.EventHandler(this.linklabel_gotofont_MouseHover);
            // 
            // label_aboutfont
            // 
            this.label_aboutfont.AutoSize = true;
            this.label_aboutfont.Font = new System.Drawing.Font("나눔고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_aboutfont.Location = new System.Drawing.Point(31, 250);
            this.label_aboutfont.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_aboutfont.Name = "label_aboutfont";
            this.label_aboutfont.Size = new System.Drawing.Size(563, 14);
            this.label_aboutfont.TabIndex = 11;
            this.label_aboutfont.Text = "※ 가독성을 위해 \'나눔 고딕\' 폰트를 사용했으며, 미 설치된 컴퓨터에서는 의도한 바와 다르게 표시될 수 있습니다.";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(783, 279);
            this.Controls.Add(this.label_aboutfont);
            this.Controls.Add(this.linklabel_gotofont);
            this.Controls.Add(this.picturebox_main);
            this.Controls.Add(this.groupofbtn);
            this.Controls.Add(this.label_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "일이삼사 도서관 메인";
            this.groupofbtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_main;
        private System.Windows.Forms.GroupBox groupofbtn;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_login_master;
        private System.Windows.Forms.Button btn_info;
        private System.Windows.Forms.Button btn_login_normal;
        private System.Windows.Forms.PictureBox picturebox_main;
        private System.Windows.Forms.Button btn_support;
        private System.Windows.Forms.Button btn_howtouse;
        private System.Windows.Forms.LinkLabel linklabel_gotofont;
        private System.Windows.Forms.Label label_aboutfont;
        private System.Windows.Forms.ToolTip toolTip_InstallFont;
    }
}

