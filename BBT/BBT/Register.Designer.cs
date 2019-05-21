namespace BBT
{
    partial class BBT_Register
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BBT_Register));
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Url = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Url = new System.Windows.Forms.TextBox();
            this.btn_Sumbit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Mac = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.ctms.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(124, 22);
            this.Exit.Text = "退出";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ctms
            // 
            this.ctms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.Exit});
            this.ctms.Name = "contextMenuStrip1";
            this.ctms.Size = new System.Drawing.Size(125, 48);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem.Text = "打开面板";
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.ctms;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "班班通登记";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(63, 36);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(53, 12);
            this.lbl_Name.TabIndex = 15;
            this.lbl_Name.Text = "设备名称";
            // 
            // lbl_Url
            // 
            this.lbl_Url.AutoSize = true;
            this.lbl_Url.Location = new System.Drawing.Point(63, 79);
            this.lbl_Url.Name = "lbl_Url";
            this.lbl_Url.Size = new System.Drawing.Size(53, 12);
            this.lbl_Url.TabIndex = 16;
            this.lbl_Url.Text = "服务地址";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(171, 33);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(258, 21);
            this.txt_Name.TabIndex = 17;
            // 
            // txt_Url
            // 
            this.txt_Url.Location = new System.Drawing.Point(171, 76);
            this.txt_Url.Name = "txt_Url";
            this.txt_Url.Size = new System.Drawing.Size(258, 21);
            this.txt_Url.TabIndex = 18;
            // 
            // btn_Sumbit
            // 
            this.btn_Sumbit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Sumbit.Font = new System.Drawing.Font("隶书", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Sumbit.Location = new System.Drawing.Point(354, 113);
            this.btn_Sumbit.Name = "btn_Sumbit";
            this.btn_Sumbit.Size = new System.Drawing.Size(75, 45);
            this.btn_Sumbit.TabIndex = 19;
            this.btn_Sumbit.Text = "注册";
            this.btn_Sumbit.UseVisualStyleBackColor = true;
            this.btn_Sumbit.Click += new System.EventHandler(this.btn_Sumbit_Click);
            this.btn_Sumbit.Enter += new System.EventHandler(this.btn_Sumbit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbl_Mac);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbl_IP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 30);
            this.panel1.TabIndex = 20;
            // 
            // lbl_Mac
            // 
            this.lbl_Mac.AutoSize = true;
            this.lbl_Mac.Font = new System.Drawing.Font("隶书", 10F);
            this.lbl_Mac.Location = new System.Drawing.Point(276, 5);
            this.lbl_Mac.Name = "lbl_Mac";
            this.lbl_Mac.Size = new System.Drawing.Size(0, 14);
            this.lbl_Mac.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "物理地址：";
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Font = new System.Drawing.Font("隶书", 10F);
            this.lbl_IP.Location = new System.Drawing.Point(60, 6);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(0, 14);
            this.lbl_IP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地IP：";
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Location = new System.Drawing.Point(13, 170);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(0, 12);
            this.lbl_Message.TabIndex = 21;
            // 
            // BBT_Register
            // 
            this.AcceptButton = this.btn_Sumbit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 224);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Sumbit);
            this.Controls.Add(this.txt_Url);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_Url);
            this.Controls.Add(this.lbl_Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BBT_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备注册";
            this.MinimumSizeChanged += new System.EventHandler(this.BBT_Register_MinimumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BBT_Register_FormClosing);
            this.Load += new System.EventHandler(this.BBT_Register_Load);
            this.ctms.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ContextMenuStrip ctms;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Url;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Url;
        private System.Windows.Forms.Button btn_Sumbit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Mac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Message;
    }
}

