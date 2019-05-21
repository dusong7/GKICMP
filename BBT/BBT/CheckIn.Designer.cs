namespace BBT
{
    partial class CheckIn
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckIn));
            this.setTime2 = new System.Windows.Forms.ToolStripMenuItem();
            this.setTime1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setTime = new System.Windows.Forms.ToolStripMenuItem();
            this.set = new System.Windows.Forms.ToolStripMenuItem();
            this.open = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cb_ChapterName = new System.Windows.Forms.ComboBox();
            this.cb_Accounts = new System.Windows.Forms.ComboBox();
            this.cb_Course = new System.Windows.Forms.ComboBox();
            this.btn_Register = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_Mac = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // setTime2
            // 
            this.setTime2.CheckOnClick = true;
            this.setTime2.Name = "setTime2";
            this.setTime2.Size = new System.Drawing.Size(114, 22);
            this.setTime2.Text = "90分钟";
            this.setTime2.Click += new System.EventHandler(this.setTime2_Click);
            // 
            // setTime1
            // 
            this.setTime1.CheckOnClick = true;
            this.setTime1.Name = "setTime1";
            this.setTime1.Size = new System.Drawing.Size(114, 22);
            this.setTime1.Text = "60分钟";
            this.setTime1.Click += new System.EventHandler(this.setTime1_Click);
            // 
            // setTime
            // 
            this.setTime.CheckOnClick = true;
            this.setTime.Name = "setTime";
            this.setTime.Size = new System.Drawing.Size(114, 22);
            this.setTime.Text = "30分钟";
            this.setTime.Click += new System.EventHandler(this.setTime_Click);
            // 
            // set
            // 
            this.set.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setTime,
            this.setTime1,
            this.setTime2});
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(124, 22);
            this.set.Text = "自动关机";
            // 
            // open
            // 
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(124, 22);
            this.open.Text = "打开面板";
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.set,
            this.exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(124, 22);
            this.exit.Text = "退出";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "班班通登记";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cb_ChapterName
            // 
            this.cb_ChapterName.Font = new System.Drawing.Font("宋体", 14F);
            this.cb_ChapterName.FormattingEnabled = true;
            this.cb_ChapterName.Location = new System.Drawing.Point(460, 154);
            this.cb_ChapterName.Name = "cb_ChapterName";
            this.cb_ChapterName.Size = new System.Drawing.Size(244, 27);
            this.cb_ChapterName.TabIndex = 29;
            // 
            // cb_Accounts
            // 
            this.cb_Accounts.Font = new System.Drawing.Font("宋体", 14F);
            this.cb_Accounts.FormattingEnabled = true;
            this.cb_Accounts.Location = new System.Drawing.Point(460, 197);
            this.cb_Accounts.Name = "cb_Accounts";
            this.cb_Accounts.Size = new System.Drawing.Size(244, 27);
            this.cb_Accounts.TabIndex = 28;
            // 
            // cb_Course
            // 
            this.cb_Course.BackColor = System.Drawing.SystemColors.Window;
            this.cb_Course.Font = new System.Drawing.Font("宋体", 14F);
            this.cb_Course.FormattingEnabled = true;
            this.cb_Course.Location = new System.Drawing.Point(460, 110);
            this.cb_Course.Name = "cb_Course";
            this.cb_Course.Size = new System.Drawing.Size(244, 27);
            this.cb_Course.TabIndex = 27;
            this.cb_Course.SelectionChangeCommitted += new System.EventHandler(this.cb_Course_SelectionChangeCommitted);
            // 
            // btn_Register
            // 
            this.btn_Register.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Register.FlatAppearance.BorderSize = 0;
            this.btn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Register.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Register.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Register.Location = new System.Drawing.Point(597, 247);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(107, 41);
            this.btn_Register.TabIndex = 22;
            this.btn_Register.Text = "登 记";
            this.btn_Register.UseVisualStyleBackColor = false;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.ForeColor = System.Drawing.Color.CadetBlue;
            this.label3.Location = new System.Drawing.Point(394, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 21;
            this.label3.Text = "课题：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.ForeColor = System.Drawing.Color.CadetBlue;
            this.label2.Location = new System.Drawing.Point(394, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "账号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.ForeColor = System.Drawing.Color.CadetBlue;
            this.label1.Location = new System.Drawing.Point(394, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "学科：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(323, 203);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("隶书", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(401, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 33);
            this.label4.TabIndex = 31;
            this.label4.Text = "班班通使用登记系统";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbl_Version);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lbl_Mac);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbl_IP);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 30);
            this.panel1.TabIndex = 32;
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Font = new System.Drawing.Font("隶书", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Version.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_Version.Location = new System.Drawing.Point(656, 9);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(29, 12);
            this.lbl_Version.TabIndex = 5;
            this.lbl_Version.Text = "版本";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("隶书", 10F);
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(489, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "芜湖市高科电子有限公司";
            // 
            // lbl_Mac
            // 
            this.lbl_Mac.AutoSize = true;
            this.lbl_Mac.Font = new System.Drawing.Font("隶书", 10F);
            this.lbl_Mac.Location = new System.Drawing.Point(286, 7);
            this.lbl_Mac.Name = "lbl_Mac";
            this.lbl_Mac.Size = new System.Drawing.Size(28, 14);
            this.lbl_Mac.TabIndex = 3;
            this.lbl_Mac.Text = "mac";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "物理地址：";
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Font = new System.Drawing.Font("隶书", 10F);
            this.lbl_IP.Location = new System.Drawing.Point(64, 7);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(21, 14);
            this.lbl_IP.TabIndex = 1;
            this.lbl_IP.Text = "ip";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "本地IP：";
            // 
            // CheckIn
            // 
            this.AcceptButton = this.btn_Register;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(737, 380);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cb_ChapterName);
            this.Controls.Add(this.cb_Accounts);
            this.Controls.Add(this.cb_Course);
            this.Controls.Add(this.btn_Register);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CheckIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "班班通设备使用登记系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckIn_FormClosing);
            this.Load += new System.EventHandler(this.CheckIn_Load);
            this.SizeChanged += new System.EventHandler(this.CheckIn_SizeChanged);
            this.Enter += new System.EventHandler(this.btn_Register_Click);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem setTime2;
        private System.Windows.Forms.ToolStripMenuItem setTime1;
        private System.Windows.Forms.ToolStripMenuItem setTime;
        private System.Windows.Forms.ToolStripMenuItem set;
        private System.Windows.Forms.ToolStripMenuItem open;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox cb_ChapterName;
        private System.Windows.Forms.ComboBox cb_Accounts;
        private System.Windows.Forms.ComboBox cb_Course;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Mac;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_Version;

    }
}