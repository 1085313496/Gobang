using System.Drawing;

namespace GDIPlusTest
{
    public class Chess
    {
        /// <summary>
        /// 是否绘制
        /// </summary>
        public bool IsValid { get; set; }
       
        /// <summary>
        /// 所属玩家
        /// </summary>
        public Player OwnerPlayer{ get; set; }

        /// <summary>
        /// 主要颜色
        /// </summary>
        public Color MainColor { get; set; }
        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color BorderColor { get; set; }
        /// <summary>
        /// 位置坐标
        /// </summary>
        public Point LocationPoint { get; set; }

        public Chess() { }
        public Chess(int ChessType)
        {
            //IsValid = true;
            switch (ChessType)
            {
                case 1: MainColor = Color.White; BorderColor = Color.Gray; break;
                case 2: MainColor = Color.Black; BorderColor = Color.DarkCyan; break;
                case 3: MainColor = Color.RoyalBlue; BorderColor = Color.DarkCyan; break;
                default: MainColor = Color.DarkCyan; BorderColor = Color.Black; break;
            }

        }

    }
}
