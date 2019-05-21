namespace ComputerRoom
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Psw
            // 
            this.lbl_Psw.AutoSize = true;
            this.lbl_Psw.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Psw.Location = new System.Drawing.Point(328, 153);
            this.lbl_Psw.Name = "lbl_Psw";
            this.lbl_Psw.Size = new System.Drawing.Size(29, 12);
            this.lbl_Psw.TabIndex = 14;
            this.lbl_Psw.Text = "密码";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Name.Location = new System.Drawing.Point(328, 98);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(29, 12);
            this.lbl_Name.TabIndex = 13;
            this.lbl_Name.Text = "姓名";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(372, 86);
            this.txt_Name.Multiline = true;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(178, 34);
            this.txt_Name.TabIndex = 12;
            // 
            // txt_Psw
            // 
            this.txt_Psw.Location = new System.Drawing.Point(372, 140);
            this.txt_Psw.Multiline = true;
            this.txt_Psw.Name = "txt_Psw";
            this.txt_Psw.Size = new System.Drawing.Size(178, 34);
            this.txt_Psw.TabIndex = 11;
            // 
            // btn_Submit
            // 
            this.btn_Submit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Submit.BackgroundImage")));
            this.btn_Submit.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Submit.Location = new System.Drawing.Point(361, 208);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(152, 48);
            this.btn_Submit.TabIndex = 10;
            this.btn_Submit.Text = "     登  记";
            this.btn_Submit.UseVisualStyleBackColor = true;
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
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 193);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("隶书", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(314, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 33);
            this.label1.TabIndex = 16;
            this.label1.Text = "学生上机登记系统";
            // 
            // CheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(207)))), ((int)(((byte)(142)))));
            this.ClientSize = new System.Drawing.Size(613, 335);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_Psw);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_Psw);
            this.Controls.Add(this.btn_Submit);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CheckIn";
            this.Text = "机房登记";
            this.TopMost = true;
            this.MinimumSizeChanged += new System.EventHandler(this.CheckIn_MinimumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckIn_FormClosing);
            this.Load += new System.EventHandler(this.CheckIn_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}