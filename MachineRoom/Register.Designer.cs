namespace MachineRoom
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.btn_Sumbit = new System.Windows.Forms.Button();
            this.txt_Url = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lbl_Url = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Mac = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Sumbit
            // 
            this.btn_Sumbit.Font = new System.Drawing.Font("隶书", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Sumbit.Location = new System.Drawing.Point(324, 107);
            this.btn_Sumbit.Name = "btn_Sumbit";
            this.btn_Sumbit.Size = new System.Drawing.Size(75, 45);
            this.btn_Sumbit.TabIndex = 24;
            this.btn_Sumbit.Text = "注册";
            this.btn_Sumbit.UseVisualStyleBackColor = true;
            this.btn_Sumbit.Click += new System.EventHandler(this.btn_Submit_Click);
            this.btn_Sumbit.Enter += new System.EventHandler(this.btn_Submit_Click);
            // 
            // txt_Url
            // 
            this.txt_Url.Location = new System.Drawing.Point(141, 70);
            this.txt_Url.Name = "txt_Url";
            this.txt_Url.Size = new System.Drawing.Size(258, 21);
            this.txt_Url.TabIndex = 23;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(141, 27);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(258, 21);
            this.txt_Name.TabIndex = 22;
            // 
            // lbl_Url
            // 
            this.lbl_Url.AutoSize = true;
            this.lbl_Url.Location = new System.Drawing.Point(33, 73);
            this.lbl_Url.Name = "lbl_Url";
            this.lbl_Url.Size = new System.Drawing.Size(53, 12);
            this.lbl_Url.TabIndex = 21;
            this.lbl_Url.Text = "服务地址";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(33, 30);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(53, 12);
            this.lbl_Name.TabIndex = 20;
            this.lbl_Name.Text = "设备名称";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Mac);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbl_IP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 180);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 27);
            this.panel1.TabIndex = 25;
            // 
            // lbl_Mac
            // 
            this.lbl_Mac.AutoSize = true;
            this.lbl_Mac.Font = new System.Drawing.Font("隶书", 10F);
            this.lbl_Mac.Location = new System.Drawing.Point(247, 6);
            this.lbl_Mac.Name = "lbl_Mac";
            this.lbl_Mac.Size = new System.Drawing.Size(0, 14);
            this.lbl_Mac.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "物理地址：";
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Font = new System.Drawing.Font("隶书", 10F);
            this.lbl_IP.Location = new System.Drawing.Point(61, 6);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(0, 14);
            this.lbl_IP.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "本地IP：";
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Location = new System.Drawing.Point(12, 156);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(0, 12);
            this.lbl_Message.TabIndex = 26;
            // 
            // Register
            // 
            this.AcceptButton = this.btn_Sumbit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(207)))), ((int)(((byte)(142)))));
            this.ClientSize = new System.Drawing.Size(432, 207);
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
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "机房登记注册";
            this.Load += new System.EventHandler(this.Register_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Sumbit;
        private System.Windows.Forms.TextBox txt_Url;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lbl_Url;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Label lbl_Mac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Label label1;

    }
}