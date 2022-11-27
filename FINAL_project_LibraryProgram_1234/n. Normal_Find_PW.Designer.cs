
namespace FINAL_project_LibraryProgram_1234
{
    partial class Normal_Find_PW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Normal_Find_PW));
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_checknum = new System.Windows.Forms.Button();
            this.txtbox_checknum = new System.Windows.Forms.TextBox();
            this.label_checknum = new System.Windows.Forms.Label();
            this.btn_sendnum = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdobtn_emailcheck = new System.Windows.Forms.RadioButton();
            this.rdobtn_telcheck = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtbox_teloremail = new System.Windows.Forms.TextBox();
            this.txtbox_name = new System.Windows.Forms.TextBox();
            this.label_teloremail = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.txtbox_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(264, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 100);
            this.label4.TabIndex = 0;
            this.label4.Text = "개인 사용자\r\n비밀번호 찾기";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(124, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // btn_checknum
            // 
            this.btn_checknum.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_checknum.Location = new System.Drawing.Point(444, 366);
            this.btn_checknum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_checknum.Name = "btn_checknum";
            this.btn_checknum.Size = new System.Drawing.Size(124, 26);
            this.btn_checknum.TabIndex = 13;
            this.btn_checknum.Text = "본인인증";
            this.btn_checknum.UseVisualStyleBackColor = true;
            this.btn_checknum.Click += new System.EventHandler(this.btn_checknum_Click);
            // 
            // txtbox_checknum
            // 
            this.txtbox_checknum.Location = new System.Drawing.Point(205, 366);
            this.txtbox_checknum.MaxLength = 8;
            this.txtbox_checknum.Name = "txtbox_checknum";
            this.txtbox_checknum.Size = new System.Drawing.Size(231, 27);
            this.txtbox_checknum.TabIndex = 12;
            // 
            // label_checknum
            // 
            this.label_checknum.AutoSize = true;
            this.label_checknum.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_checknum.Location = new System.Drawing.Point(108, 368);
            this.label_checknum.Name = "label_checknum";
            this.label_checknum.Size = new System.Drawing.Size(73, 20);
            this.label_checknum.TabIndex = 11;
            this.label_checknum.Text = "인증번호";
            // 
            // btn_sendnum
            // 
            this.btn_sendnum.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_sendnum.Location = new System.Drawing.Point(444, 333);
            this.btn_sendnum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_sendnum.Name = "btn_sendnum";
            this.btn_sendnum.Size = new System.Drawing.Size(124, 26);
            this.btn_sendnum.TabIndex = 10;
            this.btn_sendnum.Text = "인증번호 받기";
            this.btn_sendnum.UseVisualStyleBackColor = true;
            this.btn_sendnum.Click += new System.EventHandler(this.btn_sendnum_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdobtn_emailcheck);
            this.groupBox1.Controls.Add(this.rdobtn_telcheck);
            this.groupBox1.Location = new System.Drawing.Point(112, 161);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(456, 96);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // rdobtn_emailcheck
            // 
            this.rdobtn_emailcheck.AutoSize = true;
            this.rdobtn_emailcheck.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdobtn_emailcheck.Location = new System.Drawing.Point(59, 56);
            this.rdobtn_emailcheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rdobtn_emailcheck.Name = "rdobtn_emailcheck";
            this.rdobtn_emailcheck.Size = new System.Drawing.Size(274, 24);
            this.rdobtn_emailcheck.TabIndex = 2;
            this.rdobtn_emailcheck.Text = "회원 정보에 등록된 이메일로 인증";
            this.rdobtn_emailcheck.UseVisualStyleBackColor = true;
            this.rdobtn_emailcheck.CheckedChanged += new System.EventHandler(this.rdobtn_emailcheck_CheckedChanged);
            // 
            // rdobtn_telcheck
            // 
            this.rdobtn_telcheck.AutoSize = true;
            this.rdobtn_telcheck.Checked = true;
            this.rdobtn_telcheck.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdobtn_telcheck.Location = new System.Drawing.Point(59, 27);
            this.rdobtn_telcheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rdobtn_telcheck.Name = "rdobtn_telcheck";
            this.rdobtn_telcheck.Size = new System.Drawing.Size(290, 24);
            this.rdobtn_telcheck.TabIndex = 1;
            this.rdobtn_telcheck.TabStop = true;
            this.rdobtn_telcheck.Text = "회원 정보에 등록된 휴대전화로 인증";
            this.rdobtn_telcheck.UseVisualStyleBackColor = true;
            this.rdobtn_telcheck.CheckedChanged += new System.EventHandler(this.rdobtn_telcheck_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(88, 476);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(480, 35);
            this.button2.TabIndex = 16;
            this.button2.Text = "돌아가기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.linkLabel1.Location = new System.Drawing.Point(473, 399);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(94, 20);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "아이디 찾기";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(88, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(480, 49);
            this.button1.TabIndex = 14;
            this.button1.Text = "비밀번호 찾기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtbox_teloremail
            // 
            this.txtbox_teloremail.Cursor = System.Windows.Forms.Cursors.No;
            this.txtbox_teloremail.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtbox_teloremail.Location = new System.Drawing.Point(205, 333);
            this.txtbox_teloremail.Name = "txtbox_teloremail";
            this.txtbox_teloremail.ReadOnly = true;
            this.txtbox_teloremail.Size = new System.Drawing.Size(231, 25);
            this.txtbox_teloremail.TabIndex = 9;
            this.txtbox_teloremail.Text = "아이디 조회 후 자동 입력됩니다.";
            // 
            // txtbox_name
            // 
            this.txtbox_name.Location = new System.Drawing.Point(205, 269);
            this.txtbox_name.MaxLength = 5;
            this.txtbox_name.Name = "txtbox_name";
            this.txtbox_name.Size = new System.Drawing.Size(231, 27);
            this.txtbox_name.TabIndex = 4;
            // 
            // label_teloremail
            // 
            this.label_teloremail.AutoSize = true;
            this.label_teloremail.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_teloremail.Location = new System.Drawing.Point(108, 335);
            this.label_teloremail.Name = "label_teloremail";
            this.label_teloremail.Size = new System.Drawing.Size(73, 20);
            this.label_teloremail.TabIndex = 8;
            this.label_teloremail.Text = "전화번호";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_name.Location = new System.Drawing.Point(108, 271);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(41, 20);
            this.label_name.TabIndex = 3;
            this.label_name.Text = "이름";
            // 
            // txtbox_id
            // 
            this.txtbox_id.Location = new System.Drawing.Point(205, 301);
            this.txtbox_id.MaxLength = 10;
            this.txtbox_id.Name = "txtbox_id";
            this.txtbox_id.Size = new System.Drawing.Size(231, 27);
            this.txtbox_id.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(108, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "아이디";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(444, 300);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 26);
            this.button3.TabIndex = 7;
            this.button3.Text = "아이디 조회";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Normal_Find_PW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(656, 532);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtbox_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_checknum);
            this.Controls.Add(this.txtbox_checknum);
            this.Controls.Add(this.label_checknum);
            this.Controls.Add(this.btn_sendnum);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtbox_teloremail);
            this.Controls.Add(this.txtbox_name);
            this.Controls.Add(this.label_teloremail);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Normal_Find_PW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "개인 사용자 비밀번호 찾기 (일이삼사 도서관)";
            this.Load += new System.EventHandler(this.Normal_Find_PW_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_checknum;
        private System.Windows.Forms.TextBox txtbox_checknum;
        private System.Windows.Forms.Label label_checknum;
        private System.Windows.Forms.Button btn_sendnum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdobtn_emailcheck;
        private System.Windows.Forms.RadioButton rdobtn_telcheck;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtbox_teloremail;
        private System.Windows.Forms.TextBox txtbox_name;
        private System.Windows.Forms.Label label_teloremail;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox txtbox_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
    }
}