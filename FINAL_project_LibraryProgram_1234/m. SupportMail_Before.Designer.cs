
namespace FINAL_project_LibraryProgram_1234
{
    partial class SupportMail_Before
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupportMail_Before));
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdobtn_emailcheck = new System.Windows.Forms.RadioButton();
            this.rdobtn_telcheck = new System.Windows.Forms.RadioButton();
            this.btn_checknum = new System.Windows.Forms.Button();
            this.txtbox_checknum = new System.Windows.Forms.TextBox();
            this.label_checknum = new System.Windows.Forms.Label();
            this.btn_sendnum = new System.Windows.Forms.Button();
            this.txtbox_teloremail = new System.Windows.Forms.TextBox();
            this.label_teloremail = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(177, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(680, 60);
            this.label1.TabIndex = 2;
            this.label1.Text = "비로그인 사용자 대상 ────────────────────────────────\r\n프로그램 실행 시, DB 연결 오류 또는 프로그램 문제로 인해," +
    " 일이삼사 도서관리 프로그램에\r\n접속이 불가능한 비로그인 사용자 분께서는 본인인증 후 이메일 문의접수 바랍니다.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(173, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(687, 46);
            this.label4.TabIndex = 1;
            this.label4.Text = "비로그인 오류보고 / 개선요청 본인인증";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdobtn_emailcheck);
            this.groupBox1.Controls.Add(this.rdobtn_telcheck);
            this.groupBox1.Location = new System.Drawing.Point(219, 173);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(456, 96);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rdobtn_emailcheck
            // 
            this.rdobtn_emailcheck.AutoSize = true;
            this.rdobtn_emailcheck.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdobtn_emailcheck.ForeColor = System.Drawing.Color.Black;
            this.rdobtn_emailcheck.Location = new System.Drawing.Point(140, 57);
            this.rdobtn_emailcheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rdobtn_emailcheck.Name = "rdobtn_emailcheck";
            this.rdobtn_emailcheck.Size = new System.Drawing.Size(163, 24);
            this.rdobtn_emailcheck.TabIndex = 5;
            this.rdobtn_emailcheck.Text = "이메일로 본인인증";
            this.rdobtn_emailcheck.UseVisualStyleBackColor = true;
            this.rdobtn_emailcheck.CheckedChanged += new System.EventHandler(this.rdobtn_emailcheck_CheckedChanged);
            // 
            // rdobtn_telcheck
            // 
            this.rdobtn_telcheck.AutoSize = true;
            this.rdobtn_telcheck.Checked = true;
            this.rdobtn_telcheck.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdobtn_telcheck.ForeColor = System.Drawing.Color.Black;
            this.rdobtn_telcheck.Location = new System.Drawing.Point(140, 28);
            this.rdobtn_telcheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rdobtn_telcheck.Name = "rdobtn_telcheck";
            this.rdobtn_telcheck.Size = new System.Drawing.Size(179, 24);
            this.rdobtn_telcheck.TabIndex = 4;
            this.rdobtn_telcheck.TabStop = true;
            this.rdobtn_telcheck.Text = "휴대전화로 본인인증";
            this.rdobtn_telcheck.UseVisualStyleBackColor = true;
            this.rdobtn_telcheck.CheckedChanged += new System.EventHandler(this.rdobtn_telcheck_CheckedChanged);
            // 
            // btn_checknum
            // 
            this.btn_checknum.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_checknum.ForeColor = System.Drawing.Color.Black;
            this.btn_checknum.Location = new System.Drawing.Point(551, 322);
            this.btn_checknum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_checknum.Name = "btn_checknum";
            this.btn_checknum.Size = new System.Drawing.Size(124, 26);
            this.btn_checknum.TabIndex = 11;
            this.btn_checknum.Text = "본인인증";
            this.btn_checknum.UseVisualStyleBackColor = true;
            this.btn_checknum.Click += new System.EventHandler(this.btn_checknum_Click);
            // 
            // txtbox_checknum
            // 
            this.txtbox_checknum.ForeColor = System.Drawing.Color.Black;
            this.txtbox_checknum.Location = new System.Drawing.Point(312, 322);
            this.txtbox_checknum.MaxLength = 8;
            this.txtbox_checknum.Name = "txtbox_checknum";
            this.txtbox_checknum.Size = new System.Drawing.Size(231, 27);
            this.txtbox_checknum.TabIndex = 10;
            // 
            // label_checknum
            // 
            this.label_checknum.AutoSize = true;
            this.label_checknum.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_checknum.ForeColor = System.Drawing.Color.Black;
            this.label_checknum.Location = new System.Drawing.Point(215, 324);
            this.label_checknum.Name = "label_checknum";
            this.label_checknum.Size = new System.Drawing.Size(73, 20);
            this.label_checknum.TabIndex = 9;
            this.label_checknum.Text = "인증번호";
            // 
            // btn_sendnum
            // 
            this.btn_sendnum.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_sendnum.ForeColor = System.Drawing.Color.Black;
            this.btn_sendnum.Location = new System.Drawing.Point(551, 289);
            this.btn_sendnum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_sendnum.Name = "btn_sendnum";
            this.btn_sendnum.Size = new System.Drawing.Size(124, 26);
            this.btn_sendnum.TabIndex = 8;
            this.btn_sendnum.Text = "인증번호 받기";
            this.btn_sendnum.UseVisualStyleBackColor = true;
            this.btn_sendnum.Click += new System.EventHandler(this.btn_sendnum_Click);
            // 
            // txtbox_teloremail
            // 
            this.txtbox_teloremail.Cursor = System.Windows.Forms.Cursors.No;
            this.txtbox_teloremail.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtbox_teloremail.ForeColor = System.Drawing.Color.Black;
            this.txtbox_teloremail.Location = new System.Drawing.Point(312, 289);
            this.txtbox_teloremail.MaxLength = 13;
            this.txtbox_teloremail.Name = "txtbox_teloremail";
            this.txtbox_teloremail.Size = new System.Drawing.Size(231, 25);
            this.txtbox_teloremail.TabIndex = 7;
            // 
            // label_teloremail
            // 
            this.label_teloremail.AutoSize = true;
            this.label_teloremail.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_teloremail.ForeColor = System.Drawing.Color.Black;
            this.label_teloremail.Location = new System.Drawing.Point(215, 291);
            this.label_teloremail.Name = "label_teloremail";
            this.label_teloremail.Size = new System.Drawing.Size(73, 20);
            this.label_teloremail.TabIndex = 6;
            this.label_teloremail.Text = "전화번호";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(219, 422);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(456, 35);
            this.button2.TabIndex = 13;
            this.button2.Text = "돌아가기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(219, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(456, 49);
            this.button1.TabIndex = 12;
            this.button1.Text = "인증완료";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SupportMail_Before
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(895, 479);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_checknum);
            this.Controls.Add(this.txtbox_checknum);
            this.Controls.Add(this.label_checknum);
            this.Controls.Add(this.btn_sendnum);
            this.Controls.Add(this.txtbox_teloremail);
            this.Controls.Add(this.label_teloremail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SupportMail_Before";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SupportMail_Before";
            this.Load += new System.EventHandler(this.SupportMail_Before_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdobtn_emailcheck;
        private System.Windows.Forms.RadioButton rdobtn_telcheck;
        private System.Windows.Forms.Button btn_checknum;
        private System.Windows.Forms.TextBox txtbox_checknum;
        private System.Windows.Forms.Label label_checknum;
        private System.Windows.Forms.Button btn_sendnum;
        private System.Windows.Forms.TextBox txtbox_teloremail;
        private System.Windows.Forms.Label label_teloremail;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}