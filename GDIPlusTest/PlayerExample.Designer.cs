namespace GDIPlusTest
{
    partial class PlayerExample
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_Color = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.lb_Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Color
            // 
            this.lb_Color.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_Color.BackColor = System.Drawing.Color.Salmon;
            this.lb_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_Color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_Color.ForeColor = System.Drawing.Color.White;
            this.lb_Color.Location = new System.Drawing.Point(1, 2);
            this.lb_Color.Name = "lb_Color";
            this.lb_Color.Size = new System.Drawing.Size(30, 30);
            this.lb_Color.TabIndex = 0;
            this.lb_Color.Text = " 1";
            this.lb_Color.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Color.Click += new System.EventHandler(this.lb_Color_Click);
            // 
            // tb_Name
            // 
            this.tb_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Name.BackColor = System.Drawing.Color.White;
            this.tb_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Name.Location = new System.Drawing.Point(36, 8);
            this.tb_Name.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(151, 19);
            this.tb_Name.TabIndex = 1;
            this.tb_Name.TextChanged += new System.EventHandler(this.tb_Name_TextChanged);
            this.tb_Name.MouseLeave += new System.EventHandler(this.tb_Name_MouseLeave);
            // 
            // lb_Name
            // 
            this.lb_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Name.Location = new System.Drawing.Point(34, 2);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(155, 30);
            this.lb_Name.TabIndex = 2;
            this.lb_Name.Text = "Tom";
            this.lb_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Name.Click += new System.EventHandler(this.lb_Name_Click);
            // 
            // PlayerExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lb_Name);
            this.Controls.Add(this.lb_Color);
            this.Controls.Add(this.tb_Name);
            this.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "PlayerExample";
            this.Size = new System.Drawing.Size(190, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Color;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label lb_Name;
    }
}
