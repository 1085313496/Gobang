using System;
using System.Drawing;
using System.Windows.Forms;

namespace GDIPlusTest
{
    public partial class PlayerExample : UserControl
    {
        /// <summary>
        /// 玩家代号
        /// </summary>
        public string PlayerName { get { return lb_Name.Text; } set { lb_Name.Text = value; tb_Name.Text = value; } }

        /// <summary>
        /// 玩家颜色
        /// </summary>
        public Color MainColor { get { return lb_Color.BackColor; } set { lb_Color.BackColor = value; } }
        /// <summary>
        /// 玩家ID
        /// </summary>
        public int PlayerID
        {
            get
            {
                int i = -1;
                int r = int.TryParse(lb_Color.Text, out i) ? i : -1;
                return r;
            }
            set { lb_Color.Text = value + ""; }
        }


        public delegate void ChangeColorEventHandle(object obj, EventArgs e);
        public delegate void ValueChangedEventHandle(object sender, object value);
        /// <summary>
        /// 更换颜色
        /// </summary>
        public ChangeColorEventHandle ChangeColorEvent = null;
        public event ValueChangedEventHandle PlayerNameChanged = null;

        public PlayerExample()
        {
            InitializeComponent();
        }

        private void lb_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                lb_Color.BackColor = cd.Color;

                if (ChangeColorEvent != null)
                    ChangeColorEvent(this, e);
            }
        }

        private void tb_Name_MouseLeave(object sender, EventArgs e)
        {
            tb_Name.Hide();
            lb_Name.Show();
        }

        private void lb_Name_Click(object sender, EventArgs e)
        {
            tb_Name.Text = lb_Name.Text;
            tb_Name.Show();
            lb_Name.Hide();
            tb_Name.Focus();
        }

        private void tb_Name_TextChanged(object sender, EventArgs e)
        {
            lb_Name.Text = tb_Name.Text;
            if (PlayerNameChanged != null)
                PlayerNameChanged(this, tb_Name.Text);
        }
    }
}
