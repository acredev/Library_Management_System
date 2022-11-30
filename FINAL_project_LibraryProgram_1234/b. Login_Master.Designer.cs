
namespace FINAL_project_LibraryProgram_1234
{
    partial class Login_Master
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Master));
            this.linklabel_findid = new System.Windows.Forms.LinkLabel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_gotomain = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.txtbox_pwd = new System.Windows.Forms.TextBox();
            this.txtbox_id = new System.Windows.Forms.TextBox();
            this.label_pwd = new System.Windows.Forms.Label();
            this.label_id = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.picture_masterlogin = new System.Windows.Forms.PictureBox();
            this.label_main = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture_masterlogin)).BeginInit();
            this.SuspendLayout();
            // 
            // linklabel_findid
            // 
            this.linklabel_findid.AutoSize = true;
            this.linklabel_findid.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.linklabel_findid.Location = new System.Drawing.Point(343, 255);
            this.linklabel_findid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linklabel_findid.Name = "linklabel_findid";
            this.linklabel_findid.Size = new System.Drawing.Size(65, 14);
            this.linklabel_findid.TabIndex = 8;
            this.linklabel_findid.TabStop = true;
            this.linklabel_findid.Text = "아이디 찾기";
            this.linklabel_findid.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabel_findid_LinkClicked);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_exit.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_exit.Location = new System.Drawing.Point(81, 311);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(327, 31);
            this.btn_exit.TabIndex = 10;
            this.btn_exit.Text = "프로그램 종료";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_gotomain
            // 
            this.btn_gotomain.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_gotomain.Location = new System.Drawing.Point(81, 280);
            this.btn_gotomain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_gotomain.Name = "btn_gotomain";
            this.btn_gotomain.Size = new System.Drawing.Size(327, 31);
            this.btn_gotomain.TabIndex = 9;
            this.btn_gotomain.Text = "초기 화면으로";
            this.btn_gotomain.UseVisualStyleBackColor = true;
            this.btn_gotomain.Click += new System.EventHandler(this.btn_gotomain_Click);
            // 
            // btn_login
            // 
            this.btn_login.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_login.Location = new System.Drawing.Point(352, 191);
            this.btn_login.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(56, 58);
            this.btn_login.TabIndex = 6;
            this.btn_login.Text = "로그인";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // txtbox_pwd
            // 
            this.txtbox_pwd.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtbox_pwd.Location = new System.Drawing.Point(138, 225);
            this.txtbox_pwd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtbox_pwd.MaxLength = 20;
            this.txtbox_pwd.Name = "txtbox_pwd";
            this.txtbox_pwd.Size = new System.Drawing.Size(210, 22);
            this.txtbox_pwd.TabIndex = 5;
            this.txtbox_pwd.UseSystemPasswordChar = true;
            // 
            // txtbox_id
            // 
            this.txtbox_id.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtbox_id.Location = new System.Drawing.Point(138, 193);
            this.txtbox_id.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtbox_id.MaxLength = 10;
            this.txtbox_id.Name = "txtbox_id";
            this.txtbox_id.Size = new System.Drawing.Size(210, 22);
            this.txtbox_id.TabIndex = 3;
            // 
            // label_pwd
            // 
            this.label_pwd.AutoSize = true;
            this.label_pwd.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_pwd.Location = new System.Drawing.Point(77, 228);
            this.label_pwd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_pwd.Name = "label_pwd";
            this.label_pwd.Size = new System.Drawing.Size(64, 17);
            this.label_pwd.TabIndex = 4;
            this.label_pwd.Text = "비밀번호";
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_id.Location = new System.Drawing.Point(78, 198);
            this.label_id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(50, 17);
            this.label_id.TabIndex = 2;
            this.label_id.Text = "아이디";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox1.Location = new System.Drawing.Point(138, 253);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 18);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "비밀번호 보이기";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // picture_masterlogin
            // 
            this.picture_masterlogin.Image = ((System.Drawing.Image)(resources.GetObject("picture_masterlogin.Image")));
            this.picture_masterlogin.Location = new System.Drawing.Point(200, 29);
            this.picture_masterlogin.Name = "picture_masterlogin";
            this.picture_masterlogin.Size = new System.Drawing.Size(92, 100);
            this.picture_masterlogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_masterlogin.TabIndex = 35;
            this.picture_masterlogin.TabStop = false;
            // 
            // label_main
            // 
            this.label_main.AutoSize = true;
            this.label_main.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_main.Location = new System.Drawing.Point(87, 140);
            this.label_main.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_main.Name = "label_main";
            this.label_main.Size = new System.Drawing.Size(334, 40);
            this.label_main.TabIndex = 1;
            this.label_main.Text = "도서관 관리자 로그인";
            this.label_main.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(206)))), ((int)(((byte)(172)))));
            this.ClientSize = new System.Drawing.Size(491, 357);
            this.Controls.Add(this.picture_masterlogin);
            this.Controls.Add(this.label_main);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.linklabel_findid);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_gotomain);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txtbox_pwd);
            this.Controls.Add(this.txtbox_id);
            this.Controls.Add(this.label_pwd);
            this.Controls.Add(this.label_id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "Login_Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "도서관 관리자 로그인 (일이삼사 도서관)";
            ((System.ComponentModel.ISupportInitialize)(this.picture_masterlogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linklabel_findid;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_gotomain;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox txtbox_pwd;
        private System.Windows.Forms.TextBox txtbox_id;
        private System.Windows.Forms.Label label_pwd;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox picture_masterlogin;
        private System.Windows.Forms.Label label_main;
    }
}