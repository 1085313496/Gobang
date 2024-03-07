namespace GDIPlusTest
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Reset = new System.Windows.Forms.Button();
            this.tb_Player_Counter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flp_PlayerList = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.ckb_ShowChessPlayerID = new System.Windows.Forms.CheckBox();
            this.lb_turn = new System.Windows.Forms.Label();
            this.playerExample1 = new GDIPlusTest.PlayerExample();
            this.ttp = new TOL.yfhntCts.ToastTips();
            this.flp_PlayerList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Reset.FlatAppearance.BorderSize = 0;
            this.btn_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Reset.ForeColor = System.Drawing.Color.White;
            this.btn_Reset.Location = new System.Drawing.Point(19, 23);
            this.btn_Reset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(124, 37);
            this.btn_Reset.TabIndex = 1;
            this.btn_Reset.Text = "重新开始";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // tb_Player_Counter
            // 
            this.tb_Player_Counter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tb_Player_Counter.Location = new System.Drawing.Point(61, 68);
            this.tb_Player_Counter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_Player_Counter.Name = "tb_Player_Counter";
            this.tb_Player_Counter.Size = new System.Drawing.Size(82, 23);
            this.tb_Player_Counter.TabIndex = 2;
            this.tb_Player_Counter.Text = "2";
            this.tb_Player_Counter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_Player_Counter.TextChanged += new System.EventHandler(this.tb_Player_Counter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(17, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "人数";
            // 
            // flp_PlayerList
            // 
            this.flp_PlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flp_PlayerList.AutoScroll = true;
            this.flp_PlayerList.Controls.Add(this.playerExample1);
            this.flp_PlayerList.Location = new System.Drawing.Point(15, 151);
            this.flp_PlayerList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flp_PlayerList.Name = "flp_PlayerList";
            this.flp_PlayerList.Size = new System.Drawing.Size(145, 258);
            this.flp_PlayerList.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(17, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "列表";
            // 
            // ckb_ShowChessPlayerID
            // 
            this.ckb_ShowChessPlayerID.Location = new System.Drawing.Point(15, 99);
            this.ckb_ShowChessPlayerID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_ShowChessPlayerID.Name = "ckb_ShowChessPlayerID";
            this.ckb_ShowChessPlayerID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckb_ShowChessPlayerID.Size = new System.Drawing.Size(128, 23);
            this.ckb_ShowChessPlayerID.TabIndex = 7;
            this.ckb_ShowChessPlayerID.Text = "在棋子上显示ID";
            this.ckb_ShowChessPlayerID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckb_ShowChessPlayerID.UseVisualStyleBackColor = true;
            this.ckb_ShowChessPlayerID.CheckedChanged += new System.EventHandler(this.ckb_ShowChessPlayerID_CheckedChanged);
            // 
            // lb_turn
            // 
            this.lb_turn.Location = new System.Drawing.Point(123, 130);
            this.lb_turn.Name = "lb_turn";
            this.lb_turn.Size = new System.Drawing.Size(20, 20);
            this.lb_turn.TabIndex = 8;
            this.lb_turn.Text = "1";
            this.lb_turn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerExample1
            // 
            this.playerExample1.BackColor = System.Drawing.Color.White;
            this.playerExample1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.playerExample1.Location = new System.Drawing.Point(3, 7);
            this.playerExample1.MainColor = System.Drawing.Color.Salmon;
            this.playerExample1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.playerExample1.Name = "playerExample1";
            this.playerExample1.PlayerID = 1;
            this.playerExample1.PlayerName = "Tom";
            this.playerExample1.Size = new System.Drawing.Size(125, 37);
            this.playerExample1.TabIndex = 4;
            // 
            // ttp
            // 
            this.ttp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ttp.AutoEllipsis = false;
            this.ttp.BackColor = System.Drawing.Color.Transparent;
            this.ttp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ttp.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ttp.Location = new System.Drawing.Point(103, 44);
            this.ttp.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.ttp.MessageFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ttp.MessageStr = "Tips";
            this.ttp.MessageStrColor = System.Drawing.SystemColors.ControlText;
            this.ttp.Name = "ttp";
            this.ttp.ShowInterval = 2000;
            this.ttp.Size = new System.Drawing.Size(300, 319);
            this.ttp.TabIndex = 0;
            this.ttp.TipsBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ttp.TipsTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttp.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(501, 422);
            this.Controls.Add(this.lb_turn);
            this.Controls.Add(this.ckb_ShowChessPlayerID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flp_PlayerList);
            this.Controls.Add(this.tb_Player_Counter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.ttp);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "五子棋";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.flp_PlayerList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.TextBox tb_Player_Counter;
        private System.Windows.Forms.Label label1;
        private PlayerExample playerExample1;
        private System.Windows.Forms.FlowLayoutPanel flp_PlayerList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckb_ShowChessPlayerID;
        private System.Windows.Forms.Label lb_turn;
        private TOL.yfhntCts.ToastTips ttp;

    }
}

