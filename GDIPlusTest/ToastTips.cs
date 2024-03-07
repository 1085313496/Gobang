using System;
using System.Drawing;
using System.Windows.Forms;

namespace TOL.yfhntCts
{
    /// <summary>
    /// Toast提示控件，定时关闭
    /// </summary>
    public partial class ToastTips : UserControl
    {
        /// <summary>
        /// 要显示的提示信息
        /// </summary>
        public string MessageStr
        {
            get { return lbTips_CardID.Text; }
            set { lbTips_CardID.Text = value; }
        }
        /// <summary>
        /// 提示信息字体颜色
        /// </summary>
        public Color MessageStrColor
        {
            get { return lbTips_CardID.ForeColor; }
            set { lbTips_CardID.ForeColor = value; }
        }
        /// <summary>
        /// 显示时间，到时自动关闭
        /// </summary>
        public int ShowInterval
        {
            get { return timer_AutoHide.Interval; }
            set { timer_AutoHide.Interval = value; }
        }
        /// <summary>
        /// 文本对齐方式
        /// </summary>
        public ContentAlignment TipsTextAlign
        {
            get { return lbTips_CardID.TextAlign; }
            set { lbTips_CardID.TextAlign = value; }
        }

        /// <summary>
        /// 超出的文本是否以省略号代表
        /// </summary>
        public bool AutoEllipsis
        {
            get { return lbTips_CardID.AutoEllipsis; }
            set { lbTips_CardID.AutoEllipsis = value; }
        }
        /// <summary>
        /// 边框样式
        /// </summary>
        public BorderStyle TipsBorderStyle
        {
            get { return lbTips_CardID.BorderStyle; }
            set { lbTips_CardID.BorderStyle = value; }
        }
        /// <summary>
        /// 提示信息字体
        /// </summary>
        public Font MessageFont
        {
            get { return lbTips_CardID.Font; }
            set { lbTips_CardID.Font = value; }
        }

        public ToastTips() { InitializeComponent(); }
        public ToastTips(string msg)
        {
            InitializeComponent();
            MessageStr = msg;
        }

        private void ToastTips_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
        }
        /// <summary>
        /// 显示提示
        /// </summary>
        public void ShowTips(string msg = "")
        {
            if (!string.IsNullOrWhiteSpace(msg))
                MessageStr = msg;

            this.Show();
            this.BringToFront();
            timer_AutoHide.Start();
        }
        private void timer_AutoHide_Tick(object sender, EventArgs e)
        {
            timer_AutoHide.Stop();
            this.Hide();
        }
    }
}
