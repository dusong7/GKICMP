namespace MachineRoom
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
            this.lbl_Psw = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Psw = new System.Windows.Forms.TextBox();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.open = new System.Windows.Forms.ToolStripMenuItem();
            this.set = new System.Windows.Forms.ToolStripMenuItem();
            this.setTime = new System.Windows.Forms.ToolStripMenuItem();
            this.setTime1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setTime2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            // lbl_Psw
            // 
            this.lbl_Psw.AutoSize = true;
            this.lbl_Psw.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Psw.Location = new System.Drawing.Point(334, 165);
            this.lbl_Psw.Name = "lbl_Psw";
            this.lbl_Psw.Size = new System.Drawing.Size(29, 12);
            this.lbl_Psw.TabIndex = 21;
            this.lbl_Psw.Text = "密码";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Name.Location = new System.Drawing.Point(334, 110);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(29, 12);
            this.lbl_Name.TabIndex = 20;
            this.lbl_Name.Text = "帐号";
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("宋体", 15F);
            this.txt_Name.Location = new System.Drawing.Point(378, 98);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(178, 30);
            this.txt_Name.TabIndex = 19;
            // 
            // txt_Psw
            // 
            this.txt_Psw.Enabled = false;
            this.txt_Psw.Font = new System.Drawing.Font("宋体", 15F);
            this.txt_Psw.Location = new System.Drawing.Point(378, 152);
            this.txt_Psw.Multiline = true;
            this.txt_Psw.Name = "txt_Psw";
            this.txt_Psw.Size = new System.Drawing.Size(178, 34);
            this.txt_Psw.TabIndex = 18;
            // 
            // btn_Submit
            // 
            this.btn_Submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(207)))), ((int)(((byte)(142)))));
            this.btn_Submit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Submit.BackgroundImage")));
            this.btn_Submit.FlatAppearance.BorderSize = 0;
            this.btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Submit.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Submit.Location = new System.Drawing.Point(404, 221);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(152, 48);
            this.btn_Submit.TabIndex = 17;
            this.btn_Submit.Text = "     登  记";
            this.btn_Submit.UseVisualStyleBackColor = false;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
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
            // open
            // 
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(124, 22);
            this.open.Text = "打开面板";
            this.open.Click += new System.EventHandler(this.open_Click);
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
            // setTime
            // 
            this.setTime.CheckOnClick = true;
            this.setTime.Name = "setTime";
            this.setTime.Size = new System.Drawing.Size(114, 22);
            this.setTime.Text = "30分钟";
            this.setTime.Click += new System.EventHandler(this.setTime_Click);
            // 
            // setTime1
            // 
            this.setTime1.CheckOnClick = true;
            this.setTime1.Name = "setTime1";
            this.setTime1.Size = new System.Drawing.Size(114, 22);
            this.setTime1.Text = "60分钟";
            this.setTime1.Click += new System.EventHandler(this.setTime1_Click);
            // 
            // setTime2
            // 
            this.setTime2.CheckOnClick = true;
            this.setTime2.Name = "setTime2";
            this.setTime2.Size = new System.Drawing.Size(114, 22);
            this.setTime2.Text = "90分钟";
            this.setTime2.Click += new System.EventHandler(this.setTime2_Click);
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
            this.notifyIcon1.Text = "机房登记";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("隶书", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(320, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 33);
            this.label1.TabIndex = 23;
            this.label1.Text = "学生上机登记系统";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 193);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
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
            this.panel1.Location = new System.Drawing.Point(0, 305);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 30);
            this.panel1.TabIndex = 33;
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Font = new System.Drawing.Font("隶书", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Version.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_Version.Location = new System.Drawing.Point(540, 8);
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
            this.label7.Location = new System.Drawing.Point(373, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "芜湖市高科电子有限公司";
            // 
            // lbl_Mac
            // 
            this.lbl_Mac.AutoSize = true;
            this.lbl_Mac.Font = new System.Drawing.Font("隶书", 10F);
            this.lbl_Mac.Location = new System.Drawing.Point(221, 7);
            this.lbl_Mac.Name = "lbl_Mac";
            this.lbl_Mac.Size = new System.Drawing.Size(28, 14);
            this.lbl_Mac.TabIndex = 3;
            this.lbl_Mac.Text = "mac";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 10);
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
            this.AcceptButton = this.btn_Submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(207)))), ((int)(((byte)(142)))));
            this.ClientSize = new System.Drawing.Size(613, 335);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Psw);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_Psw);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CheckIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生机房登记";
            this.MinimumSizeChanged += new System.EventHandler(this.CheckIn_MinimumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckIn_FormClosing);
            this.Load += new System.EventHandler(this.CheckIn_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Psw;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Psw;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem open;
        private System.Windows.Forms.ToolStripMenuItem set;
        private System.Windows.Forms.ToolStripMenuItem setTime;
        private System.Windows.Forms.ToolStripMenuItem setTime1;
        private System.Windows.Forms.ToolStripMenuItem setTime2;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_Mac;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Label label6;
    }
}