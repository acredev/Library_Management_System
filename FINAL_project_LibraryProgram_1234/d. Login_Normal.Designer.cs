
namespace FINAL_project_LibraryProgram_1234
{
    partial class Login_Normal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Normal));
            this.label_id = new System.Windows.Forms.Label();
            this.label_normallogin = new System.Windows.Forms.Label();
            this.label_pwd = new System.Windows.Forms.Label();
            this.txtbox_id = new System.Windows.Forms.TextBox();
            this.txtbox_pwd = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.linklabel_findid = new System.Windows.Forms.LinkLabel();
            this.linklabel_findpwd = new System.Windows.Forms.LinkLabel();
            this.picture_normallogin = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_gotomain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picture_normallogin)).BeginInit();
            this.SuspendLayout();
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_id.Location = new System.Drawing.Point(84, 221);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(57, 20);
            this.label_id.TabIndex = 2;
            this.label_id.Text = "아이디";
            // 
            // label_normallogin
            // 
            this.label_normallogin.AutoSize = true;
            this.label_normallogin.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_normallogin.Location = new System.Drawing.Point(137, 158);
            this.label_normallogin.Name = "label_normallogin";
            this.label_normallogin.Size = new System.Drawing.Size(374, 50);
            this.label_normallogin.TabIndex = 1;
            this.label_normallogin.Text = "개인 사용자 로그인";
            this.label_normallogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_pwd
            // 
            this.label_pwd.AutoSize = true;
            this.label_pwd.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_pwd.Location = new System.Drawing.Point(84, 256);
            this.label_pwd.Name = "label_pwd";
            this.label_pwd.Size = new System.Drawing.Size(73, 20);
            this.label_pwd.TabIndex = 4;
            this.label_pwd.Text = "비밀번호";
            // 
            // txtbox_id
            // 
            this.txtbox_id.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtbox_id.Location = new System.Drawing.Point(163, 215);
            this.txtbox_id.MaxLength = 10;
            this.txtbox_id.Name = "txtbox_id";
            this.txtbox_id.Size = new System.Drawing.Size(243, 26);
            this.txtbox_id.TabIndex = 3;
            // 
            // txtbox_pwd
            // 
            this.txtbox_pwd.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtbox_pwd.Location = new System.Drawing.Point(163, 252);
            this.txtbox_pwd.MaxLength = 20;
            this.txtbox_pwd.Name = "txtbox_pwd";
            this.txtbox_pwd.Size = new System.Drawing.Size(243, 26);
            this.txtbox_pwd.TabIndex = 5;
            this.txtbox_pwd.UseSystemPasswordChar = true;
            // 
            // btn_login
            // 
            this.btn_login.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_login.Location = new System.Drawing.Point(413, 215);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 63);
            this.btn_login.TabIndex = 6;
            this.btn_login.Text = "로그인";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_new
            // 
            this.btn_new.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_new.Location = new System.Drawing.Point(493, 215);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 63);
            this.btn_new.TabIndex = 7;
            this.btn_new.Text = "회원\r\n가입\r\n";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // linklabel_findid
            // 
            this.linklabel_findid.AutoSize = true;
            this.linklabel_findid.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.linklabel_findid.Location = new System.Drawing.Point(359, 286);
            this.linklabel_findid.Name = "linklabel_findid";
            this.linklabel_findid.Size = new System.Drawing.Size(94, 20);
            this.linklabel_findid.TabIndex = 9;
            this.linklabel_findid.TabStop = true;
            this.linklabel_findid.Text = "아이디 찾기";
            this.linklabel_findid.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabel_findid_LinkClicked);
            // 
            // linklabel_findpwd
            // 
            this.linklabel_findpwd.AutoSize = true;
            this.linklabel_findpwd.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.linklabel_findpwd.Location = new System.Drawing.Point(459, 286);
            this.linklabel_findpwd.Name = "linklabel_findpwd";
            this.linklabel_findpwd.Size = new System.Drawing.Size(110, 20);
            this.linklabel_findpwd.TabIndex = 10;
            this.linklabel_findpwd.TabStop = true;
            this.linklabel_findpwd.Text = "비밀번호 찾기";
            this.linklabel_findpwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabel_findpwd_LinkClicked);
            // 
            // picture_normallogin
            // 
            this.picture_normallogin.Image = ((System.Drawing.Image)(resources.GetObject("picture_normallogin.Image")));
            this.picture_normallogin.Location = new System.Drawing.Point(267, 34);
            this.picture_normallogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picture_normallogin.Name = "picture_normallogin";
            this.picture_normallogin.Size = new System.Drawing.Size(133, 113);
            this.picture_normallogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_normallogin.TabIndex = 12;
            this.picture_normallogin.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox1.Location = new System.Drawing.Point(163, 283);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 21);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "비밀번호 보이기";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_exit.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_exit.Location = new System.Drawing.Point(88, 356);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(480, 35);
            this.btn_exit.TabIndex = 12;
            this.btn_exit.Text = "프로그램 종료";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_gotomain
            // 
            this.btn_gotomain.Font = new System.Drawing.Font("나눔고딕", 9.75F);
            this.btn_gotomain.Location = new System.Drawing.Point(88, 315);
            this.btn_gotomain.Name = "btn_gotomain";
            this.btn_gotomain.Size = new System.Drawing.Size(481, 35);
            this.btn_gotomain.TabIndex = 11;
            this.btn_gotomain.Text = "초기 화면으로";
            this.btn_gotomain.UseVisualStyleBackColor = true;
            this.btn_gotomain.Click += new System.EventHandler(this.btn_gotomain_Click);
            // 
            // Login_Normal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(655, 405);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_gotomain);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.picture_normallogin);
            this.Controls.Add(this.linklabel_findpwd);
            this.Controls.Add(this.linklabel_findid);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txtbox_pwd);
            this.Controls.Add(this.txtbox_id);
            this.Controls.Add(this.label_pwd);
            this.Controls.Add(this.label_normallogin);
            this.Controls.Add(this.label_id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login_Normal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "개인 사용자 로그인 (일이삼사 도서관)";
            ((System.ComponentModel.ISupportInitialize)(this.picture_normallogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label_normallogin;
        private System.Windows.Forms.Label label_pwd;
        private System.Windows.Forms.TextBox txtbox_id;
        private System.Windows.Forms.TextBox txtbox_pwd;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.LinkLabel linklabel_findid;
        private System.Windows.Forms.LinkLabel linklabel_findpwd;
        private System.Windows.Forms.PictureBox picture_normallogin;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_gotomain;
    }
}