namespace 五子棋__完整版
{
    partial class frmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiStart = new System.Windows.Forms.ToolStripMenuItem();
            this.网络对战ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.服务开启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加入游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLogic = new System.Windows.Forms.Label();
            this.lblPhysics = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBlick = new System.Windows.Forms.Button();
            this.btnWhile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblServe = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnete = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tsmiStand = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStart,
            this.网络对战ToolStripMenuItem,
            this.tsmiStand});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1251, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiStart
            // 
            this.tsmiStart.Name = "tsmiStart";
            this.tsmiStart.Size = new System.Drawing.Size(81, 24);
            this.tsmiStart.Text = "开始游戏";
            this.tsmiStart.Click += new System.EventHandler(this.tsmiStart_Click);
            // 
            // 网络对战ToolStripMenuItem
            // 
            this.网络对战ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.服务开启ToolStripMenuItem,
            this.加入游戏ToolStripMenuItem});
            this.网络对战ToolStripMenuItem.Name = "网络对战ToolStripMenuItem";
            this.网络对战ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.网络对战ToolStripMenuItem.Text = "网络对战";
            // 
            // 服务开启ToolStripMenuItem
            // 
            this.服务开启ToolStripMenuItem.Name = "服务开启ToolStripMenuItem";
            this.服务开启ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.服务开启ToolStripMenuItem.Text = "服务开启";
            this.服务开启ToolStripMenuItem.Click += new System.EventHandler(this.服务开启ToolStripMenuItem_Click);
            // 
            // 加入游戏ToolStripMenuItem
            // 
            this.加入游戏ToolStripMenuItem.Name = "加入游戏ToolStripMenuItem";
            this.加入游戏ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.加入游戏ToolStripMenuItem.Text = "加入游戏";
            this.加入游戏ToolStripMenuItem.Click += new System.EventHandler(this.加入游戏ToolStripMenuItem_Click);
            // 
            // lblLogic
            // 
            this.lblLogic.AutoSize = true;
            this.lblLogic.Location = new System.Drawing.Point(854, 100);
            this.lblLogic.Name = "lblLogic";
            this.lblLogic.Size = new System.Drawing.Size(55, 15);
            this.lblLogic.TabIndex = 2;
            this.lblLogic.Text = "label1";
            // 
            // lblPhysics
            // 
            this.lblPhysics.AutoSize = true;
            this.lblPhysics.Location = new System.Drawing.Point(854, 138);
            this.lblPhysics.Name = "lblPhysics";
            this.lblPhysics.Size = new System.Drawing.Size(55, 15);
            this.lblPhysics.TabIndex = 2;
            this.lblPhysics.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::五子棋__完整版.Properties.Resources.chessboard__1;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(17, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // btnBlick
            // 
            this.btnBlick.Location = new System.Drawing.Point(941, 416);
            this.btnBlick.Name = "btnBlick";
            this.btnBlick.Size = new System.Drawing.Size(75, 29);
            this.btnBlick.TabIndex = 6;
            this.btnBlick.Text = "黑棋";
            this.btnBlick.UseVisualStyleBackColor = true;
            // 
            // btnWhile
            // 
            this.btnWhile.Location = new System.Drawing.Point(1026, 416);
            this.btnWhile.Name = "btnWhile";
            this.btnWhile.Size = new System.Drawing.Size(75, 29);
            this.btnWhile.TabIndex = 6;
            this.btnWhile.Text = "白棋";
            this.btnWhile.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(857, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "先手:";
            // 
            // lblServe
            // 
            this.lblServe.AutoSize = true;
            this.lblServe.Font = new System.Drawing.Font("宋体", 12F);
            this.lblServe.ForeColor = System.Drawing.Color.Red;
            this.lblServe.Location = new System.Drawing.Point(852, 279);
            this.lblServe.Name = "lblServe";
            this.lblServe.Size = new System.Drawing.Size(69, 20);
            this.lblServe.TabIndex = 8;
            this.lblServe.Text = "label4";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(84, 24);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(162, 25);
            this.txtIP.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP:";
            // 
            // btnConnete
            // 
            this.btnConnete.Location = new System.Drawing.Point(266, 35);
            this.btnConnete.Name = "btnConnete";
            this.btnConnete.Size = new System.Drawing.Size(95, 54);
            this.btnConnete.TabIndex = 7;
            this.btnConnete.Text = "连接服务";
            this.btnConnete.UseVisualStyleBackColor = true;
            this.btnConnete.Click += new System.EventHandler(this.btnConnete_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(84, 73);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(162, 25);
            this.txtPort.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "端口号:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.btnConnete);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Location = new System.Drawing.Point(857, 236);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 125);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络信息";
            this.groupBox1.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(971, 593);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 259);
            this.listBox1.TabIndex = 9;
            // 
            // tsmiStand
            // 
            this.tsmiStand.Name = "tsmiStand";
            this.tsmiStand.Size = new System.Drawing.Size(81, 24);
            this.tsmiStand.Text = "单机游戏";
            this.tsmiStand.Click += new System.EventHandler(this.tsmiStand_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 1053);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnWhile);
            this.Controls.Add(this.btnBlick);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblServe);
            this.Controls.Add(this.lblPhysics);
            this.Controls.Add(this.lblLogic);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "五子棋";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiStart;
        private System.Windows.Forms.Label lblLogic;
        private System.Windows.Forms.Label lblPhysics;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 网络对战ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 服务开启ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加入游戏ToolStripMenuItem;
        private System.Windows.Forms.Button btnBlick;
        private System.Windows.Forms.Button btnWhile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblServe;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnete;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem tsmiStand;
    }
}

