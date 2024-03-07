using System;
using System.Drawing;

namespace GDIPlusTest
{
    public class Player
    {
        /// <summary>
        /// 玩家ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 玩家代号
        /// </summary>
        public string Name { get; set; }

        private Color _chessColor;
        /// <summary>
        /// 玩家代表颜色
        /// </summary>
        public Color ChessColor
        {
            get { return _chessColor; }
            set
            {
                _chessColor = value;

                if (ChangeCColorEvent != null)
                { ChangeCColorEvent(this, null); }
            }
        }

        public Player() { }

        public delegate void ChangeCColorEventHandle(object obj, EventArgs e);
        /// <summary>
        /// 更换颜色
        /// </summary>
        public ChangeCColorEventHandle ChangeCColorEvent = null;

    }
}
