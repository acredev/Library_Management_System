
namespace FINAL_project_LibraryProgram_1234
{
    partial class Normal_loanBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Normal_loanBook));
            this.btn_main = new System.Windows.Forms.Button();
            this.picture_support = new System.Windows.Forms.PictureBox();
            this.picture_logout = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtbox_loannum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtbox_status = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtbox_loancnt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtbox_booknum = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_bookback = new System.Windows.Forms.Button();
            this.btn_bookloan = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.combobox_searchbystatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.combobox_search = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbox_search = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbox_title = new System.Windows.Forms.TextBox();
            this.txtbox_publisher = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbox_loanstatus = new System.Windows.Forms.TextBox();
            this.txtbox_writer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.data_book = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.picture_support)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_logout)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_book)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_main
            // 
            this.btn_main.ForeColor = System.Drawing.Color.Green;
            this.btn_main.Location = new System.Drawing.Point(18, 6);
            this.btn_main.Name = "btn_main";
            this.btn_main.Size = new System.Drawing.Size(112, 59);
            this.btn_main.TabIndex = 47;
            this.btn_main.Text = "이전화면";
            this.btn_main.UseVisualStyleBackColor = true;
            this.btn_main.Click += new System.EventHandler(this.btn_main_Click);
            // 
            // picture_support
            // 
            this.picture_support.Image = ((System.Drawing.Image)(resources.GetObject("picture_support.Image")));
            this.picture_support.Location = new System.Drawing.Point(679, 9);
            this.picture_support.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picture_support.Name = "picture_support";
            this.picture_support.Size = new System.Drawing.Size(47, 56);
            this.picture_support.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_support.TabIndex = 46;
            this.picture_support.TabStop = false;
            this.picture_support.Click += new System.EventHandler(this.picture_support_Click);
            // 
            // picture_logout
            // 
            this.picture_logout.Image = ((System.Drawing.Image)(resources.GetObject("picture_logout.Image")));
            this.picture_logout.Location = new System.Drawing.Point(749, 9);
            this.picture_logout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picture_logout.Name = "picture_logout";
            this.picture_logout.Size = new System.Drawing.Size(42, 56);
            this.picture_logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_logout.TabIndex = 45;
            this.picture_logout.TabStop = false;
            this.picture_logout.Click += new System.EventHandler(this.picture_logout_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(254, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(321, 50);
            this.label5.TabIndex = 44;
            this.label5.Text = "일이삼사 도서관";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtbox_loannum);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtbox_status);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtbox_loancnt);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtbox_booknum);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.btn_load);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.data_book);
            this.groupBox2.Location = new System.Drawing.Point(13, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 496);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(56, 219);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(403, 20);
            this.label14.TabIndex = 56;
            this.label14.Text = "도서 대출한 사용자 관리번호 (사용자에게 보이지 않음)";
            this.label14.Visible = false;
            // 
            // txtbox_loannum
            // 
            this.txtbox_loannum.Location = new System.Drawing.Point(59, 237);
            this.txtbox_loannum.Name = "txtbox_loannum";
            this.txtbox_loannum.ReadOnly = true;
            this.txtbox_loannum.Size = new System.Drawing.Size(272, 26);
            this.txtbox_loannum.TabIndex = 57;
            this.txtbox_loannum.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(56, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(281, 20);
            this.label13.TabIndex = 54;
            this.label13.Text = "사용자 상태 (사용자에게 보이지 않음)";
            this.label13.Visible = false;
            // 
            // txtbox_status
            // 
            this.txtbox_status.Location = new System.Drawing.Point(59, 181);
            this.txtbox_status.Name = "txtbox_status";
            this.txtbox_status.ReadOnly = true;
            this.txtbox_status.Size = new System.Drawing.Size(272, 26);
            this.txtbox_status.TabIndex = 55;
            this.txtbox_status.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(318, 20);
            this.label12.TabIndex = 52;
            this.label12.Text = "사용자 책 대여수 (사용자에게 보이지 않음)";
            this.label12.Visible = false;
            // 
            // txtbox_loancnt
            // 
            this.txtbox_loancnt.Location = new System.Drawing.Point(59, 123);
            this.txtbox_loancnt.Name = "txtbox_loancnt";
            this.txtbox_loancnt.ReadOnly = true;
            this.txtbox_loancnt.Size = new System.Drawing.Size(272, 26);
            this.txtbox_loancnt.TabIndex = 53;
            this.txtbox_loancnt.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(56, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(334, 20);
            this.label11.TabIndex = 50;
            this.label11.Text = "책 대여용 관리번호 (사용자에게 보이지 않음)";
            this.label11.Visible = false;
            // 
            // txtbox_booknum
            // 
            this.txtbox_booknum.Location = new System.Drawing.Point(59, 73);
            this.txtbox_booknum.Name = "txtbox_booknum";
            this.txtbox_booknum.ReadOnly = true;
            this.txtbox_booknum.Size = new System.Drawing.Size(272, 26);
            this.txtbox_booknum.TabIndex = 51;
            this.txtbox_booknum.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.btn_bookback);
            this.groupBox4.Controls.Add(this.btn_bookloan);
            this.groupBox4.Location = new System.Drawing.Point(445, 286);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(327, 204);
            this.groupBox4.TabIndex = 51;
            this.groupBox4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(404, 100);
            this.label10.TabIndex = 54;
            this.label10.Text = "1. 현재 \'대출 중\' 인 도서는 대출 신청이 되지 않습니다.\r\n2. 로그인 한 회원 명의로 대출한 도서만\r\n    반납 신청이 가능합니다.\r\n3" +
    ". 1 회원당 최대 10권까지 대출 가능합니다.\r\n4. 분실 시, 도서가격에 맞는 금액을 배상해야 합니다.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(45, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(323, 23);
            this.label9.TabIndex = 54;
            this.label9.Text = "<도서 대출 / 반납 신청 전 주의사항>";
            // 
            // btn_bookback
            // 
            this.btn_bookback.Location = new System.Drawing.Point(164, 139);
            this.btn_bookback.Name = "btn_bookback";
            this.btn_bookback.Size = new System.Drawing.Size(157, 59);
            this.btn_bookback.TabIndex = 50;
            this.btn_bookback.Text = "반납신청";
            this.btn_bookback.UseVisualStyleBackColor = true;
            this.btn_bookback.Click += new System.EventHandler(this.btn_bookback_Click);
            // 
            // btn_bookloan
            // 
            this.btn_bookloan.Location = new System.Drawing.Point(6, 139);
            this.btn_bookloan.Name = "btn_bookloan";
            this.btn_bookloan.Size = new System.Drawing.Size(157, 59);
            this.btn_bookloan.TabIndex = 49;
            this.btn_bookloan.Text = "대출신청";
            this.btn_bookloan.UseVisualStyleBackColor = true;
            this.btn_bookloan.Click += new System.EventHandler(this.btn_bookloan_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(6, 453);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(433, 37);
            this.btn_load.TabIndex = 49;
            this.btn_load.Text = "조회 / 재조회";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.combobox_searchbystatus);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btn_search);
            this.groupBox3.Controls.Add(this.combobox_search);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtbox_search);
            this.groupBox3.Location = new System.Drawing.Point(445, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 147);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            // 
            // combobox_searchbystatus
            // 
            this.combobox_searchbystatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_searchbystatus.FormattingEnabled = true;
            this.combobox_searchbystatus.Items.AddRange(new object[] {
            "대출 중",
            "대출 가능"});
            this.combobox_searchbystatus.Location = new System.Drawing.Point(49, 49);
            this.combobox_searchbystatus.Name = "combobox_searchbystatus";
            this.combobox_searchbystatus.Size = new System.Drawing.Size(272, 27);
            this.combobox_searchbystatus.TabIndex = 54;
            this.combobox_searchbystatus.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(342, 40);
            this.label8.TabIndex = 53;
            this.label8.Text = "※ 자세한 도서정보 검색 및 열람은,\r\n메인 화면의 \'도서 검색\' 메뉴를 이용 바랍니다.";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(49, 77);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(272, 31);
            this.btn_search.TabIndex = 52;
            this.btn_search.Text = "검색";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // combobox_search
            // 
            this.combobox_search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_search.FormattingEnabled = true;
            this.combobox_search.Items.AddRange(new object[] {
            "제목",
            "저자",
            "출판사",
            "대출여부"});
            this.combobox_search.Location = new System.Drawing.Point(49, 21);
            this.combobox_search.Name = "combobox_search";
            this.combobox_search.Size = new System.Drawing.Size(272, 27);
            this.combobox_search.TabIndex = 50;
            this.combobox_search.SelectedIndexChanged += new System.EventHandler(this.combobox_search_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "검색";
            // 
            // txtbox_search
            // 
            this.txtbox_search.Location = new System.Drawing.Point(49, 49);
            this.txtbox_search.Name = "txtbox_search";
            this.txtbox_search.Size = new System.Drawing.Size(272, 26);
            this.txtbox_search.TabIndex = 45;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbox_title);
            this.groupBox1.Controls.Add(this.txtbox_publisher);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbox_loanstatus);
            this.groupBox1.Controls.Add(this.txtbox_writer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(445, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 115);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            // 
            // txtbox_title
            // 
            this.txtbox_title.Location = new System.Drawing.Point(49, 20);
            this.txtbox_title.Name = "txtbox_title";
            this.txtbox_title.ReadOnly = true;
            this.txtbox_title.Size = new System.Drawing.Size(272, 26);
            this.txtbox_title.TabIndex = 43;
            // 
            // txtbox_publisher
            // 
            this.txtbox_publisher.Location = new System.Drawing.Point(49, 76);
            this.txtbox_publisher.Name = "txtbox_publisher";
            this.txtbox_publisher.ReadOnly = true;
            this.txtbox_publisher.Size = new System.Drawing.Size(136, 26);
            this.txtbox_publisher.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "제목";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "출판사";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "저자";
            // 
            // txtbox_loanstatus
            // 
            this.txtbox_loanstatus.Location = new System.Drawing.Point(252, 76);
            this.txtbox_loanstatus.Name = "txtbox_loanstatus";
            this.txtbox_loanstatus.ReadOnly = true;
            this.txtbox_loanstatus.Size = new System.Drawing.Size(69, 26);
            this.txtbox_loanstatus.TabIndex = 47;
            // 
            // txtbox_writer
            // 
            this.txtbox_writer.Location = new System.Drawing.Point(49, 48);
            this.txtbox_writer.Name = "txtbox_writer";
            this.txtbox_writer.ReadOnly = true;
            this.txtbox_writer.Size = new System.Drawing.Size(272, 26);
            this.txtbox_writer.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "대출여부";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 41;
            this.label2.Text = "도서목록";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // data_book
            // 
            this.data_book.AllowUserToAddRows = false;
            this.data_book.AllowUserToDeleteRows = false;
            this.data_book.AllowUserToResizeColumns = false;
            this.data_book.AllowUserToResizeRows = false;
            this.data_book.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_book.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.data_book.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.data_book.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_book.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.data_book.Location = new System.Drawing.Point(6, 22);
            this.data_book.MultiSelect = false;
            this.data_book.Name = "data_book";
            this.data_book.ReadOnly = true;
            this.data_book.RowHeadersWidth = 51;
            this.data_book.RowTemplate.Height = 25;
            this.data_book.Size = new System.Drawing.Size(433, 425);
            this.data_book.TabIndex = 40;
            this.data_book.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_book_CellClick);
            // 
            // Normal_loanBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(802, 579);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_main);
            this.Controls.Add(this.picture_support);
            this.Controls.Add(this.picture_logout);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Normal_loanBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Normal_loanBook";
            this.Load += new System.EventHandler(this.Normal_loanBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture_support)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_logout)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_book)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_main;
        private System.Windows.Forms.PictureBox picture_support;
        private System.Windows.Forms.PictureBox picture_logout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_bookback;
        private System.Windows.Forms.Button btn_bookloan;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ComboBox combobox_search;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbox_search;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbox_title;
        private System.Windows.Forms.TextBox txtbox_publisher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbox_loanstatus;
        private System.Windows.Forms.TextBox txtbox_writer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView data_book;
        private System.Windows.Forms.ComboBox combobox_searchbystatus;
        private System.Windows.Forms.TextBox txtbox_booknum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtbox_loancnt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtbox_status;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtbox_loannum;
    }
}