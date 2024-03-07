using System.Windows.Forms;
namespace TOL.yfhntCts
{
    partial class ToastTips
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
            this.components = new System.ComponentModel.Container();
            this.lbTips_CardID = new System.Windows.Forms.Label();
            this.timer_AutoHide = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbTips_CardID
            // 
            this.lbTips_CardID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTips_CardID.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbTips_CardID.Location = new System.Drawing.Point(0, 0);
            this.lbTips_CardID.Name = "lbTips_CardID";
            this.lbTips_CardID.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lbTips_CardID.Size = new System.Drawing.Size(144, 43);
            this.lbTips_CardID.TabIndex = 494;
            this.lbTips_CardID.Text = "Tips";
            this.lbTips_CardID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer_AutoHide
            // 
            this.timer_AutoHide.Interval = 2000;
            this.timer_AutoHide.Tick += new System.EventHandler(this.timer_AutoHide_Tick);
            // 
            // ToastTips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbTips_CardID);
            this.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ToastTips";
            this.Size = new System.Drawing.Size(144, 43);
            this.Load += new System.EventHandler(this.ToastTips_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lbTips_CardID;
        private System.Windows.Forms.Timer timer_AutoHide;
    }
}
