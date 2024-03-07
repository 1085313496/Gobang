namespace FIM
{
    partial class Logo_CustomPainted
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
            this.lb_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_title
            // 
            this.lb_title.BackColor = System.Drawing.Color.Transparent;
            this.lb_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_title.Font = new System.Drawing.Font("黑体", 40F);
            this.lb_title.ForeColor = System.Drawing.Color.White;
            this.lb_title.Location = new System.Drawing.Point(0, 0);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(132, 125);
            this.lb_title.TabIndex = 0;
            this.lb_title.Text = "益砼叁和";
            this.lb_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_title.Visible = false;
            // 
            // Logo_CustomPainted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_title);
            this.Name = "Logo_CustomPainted";
            this.Size = new System.Drawing.Size(132, 125);
            this.Load += new System.EventHandler(this.Logo_CustomPainted_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Logo_CustomPainted_Paint);
            this.Resize += new System.EventHandler(this.Logo_CustomPainted_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_title;
    }
}
