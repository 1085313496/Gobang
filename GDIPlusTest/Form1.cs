using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GDIPlusTest
{
    public partial class Form1 : Form
    {
        private BufferedGraphics graphBuffer;

        /// <summary>
        /// 检查方向
        /// </summary>
        private enum CheckDirection
        {
            /// <summary>
            /// 东方-中部-西方
            /// </summary>
            W_E = 1,
            /// <summary>
            /// 北方-中部-南方
            /// </summary>
            N_S = 2,
            /// <summary>
            /// 西北方-中部-东南方
            /// </summary>
            NW_SE = 3,
            /// <summary>
            /// 西南方-中部-东北方
            /// </summary>
            SW_NE = 4
        };
        /// <summary>
        /// 棋子落下位置方向
        /// </summary>
        private enum ChessPointDirection
        {
            /// <summary>
            /// 西北
            /// </summary>
            NW = 1,
            /// <summary>
            /// 北
            /// </summary>
            N = 2,
            /// <summary>
            /// 东北
            /// </summary>
            NE = 3,
            /// <summary>
            /// 东
            /// </summary>
            E = 4,
            /// <summary>
            /// 东南
            /// </summary>
            SE = 5,
            /// <summary>
            /// 南
            /// </summary>
            S = 6,
            /// <summary>
            /// 西南
            /// </summary>
            SW = 7,
            /// <summary>
            /// 西
            /// </summary>
            W = 8
        }

        /// <summary>
        /// 棋盘左上角顶点
        /// </summary>
        private Point ChessBoardOriPoint = new Point(200, 20);
        /// <summary>
        /// 棋子大小
        /// </summary>
        private int ChessSize = 35;
        /// <summary>
        /// 行宽
        /// </summary>
        private int BoardRowSize = 50;
        /// <summary>
        /// 列高
        /// </summary>
        private int BoardColumnSize = 50;
        /// <summary>
        /// 行数
        /// </summary>
        private static int BoardRowNumber = 16;
        /// <summary>
        /// 列数
        /// </summary>
        private static int BoardColumnNumber = 16;

        /// <summary>
        /// 棋盘点位
        /// </summary>
        private Chess[,] Chesses = new Chess[BoardRowNumber + 1, BoardColumnNumber + 1];

        /// <summary>
        /// 记录该谁下子
        /// </summary>
        private int TurnCounter = 1;
        /// <summary>
        /// 玩家数量
        /// </summary>
        private int PlayerNumber = 2;
        /// <summary>
        /// 设置几个棋子连为一线为胜利
        /// </summary>
        private int WinChessNumber = 5;

        /// <summary>
        /// 是否在棋子上绘制玩家ID
        /// </summary>
        private bool ShowChessPlayerID = false;
        /// <summary>
        /// 是否可以下子
        /// </summary>
        private bool AllowPutChess = true;

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1050, 880);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphBuffer = (new BufferedGraphicsContext()).Allocate(this.CreateGraphics(), this.DisplayRectangle);
            InitPlayersList(2);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            graphBuffer = (new BufferedGraphicsContext()).Allocate(this.CreateGraphics(), this.DisplayRectangle);
        }

        /// <summary>
        /// 重新开始
        /// </summary>
        private void Restart()
        {
            TurnCounter = 1;
            AllowPutChess = true;
            Chesses = new Chess[BoardRowNumber + 1, BoardColumnNumber + 1];
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) { PaintChessboard(); }
        private void btn_Reset_Click(object sender, EventArgs e) { Restart(); }
        private void ckb_ShowChessPlayerID_CheckedChanged(object sender, EventArgs e) { ShowChessPlayerID = ckb_ShowChessPlayerID.Checked; Invalidate(); }
        private void Form1_MouseClick(object sender, MouseEventArgs e) { PlayerPutChessAt(TurnCounter, new Point(e.X - ChessBoardOriPoint.X, e.Y - ChessBoardOriPoint.Y)); }
        /// <summary>
        /// 修改玩家数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_Player_Counter_TextChanged(object sender, EventArgs e)
        {
            int i = 2;
            int r = int.TryParse(tb_Player_Counter.Text, out i) ? i : 2;
            r = r <= 1 ? 2 : r;
            r = r > (BoardRowNumber + 1) * (BoardColumnNumber + 1) ? (BoardRowNumber + 1) * (BoardColumnNumber + 1) : r;

            InitPlayersList(r);
        }


        /// <summary>
        /// 绘制棋盘
        /// </summary>
        private void PaintChessboard()
        {
            Graphics g = null;

            try
            {
                Bitmap b = new Bitmap(this.DisplayRectangle.Width, this.DisplayRectangle.Height);
                g = Graphics.FromImage((System.Drawing.Image)b);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


                Pen p = new Pen(Color.Purple, 3);
                g.TranslateTransform(ChessBoardOriPoint.X, ChessBoardOriPoint.Y);

                for (int j = 0; j <= BoardRowNumber; j++)
                {
                    p.Width = (j == 0 || j == BoardRowNumber) ? 3 : 1;
                    int y = BoardRowSize * j;
                    g.DrawLine(p, new Point(0, y), new Point(BoardRowNumber * BoardRowSize, y));
                }

                for (int i = 0; i <= BoardColumnNumber; i++)
                {
                    p.Width = (i == 0 || i == BoardColumnNumber) ? 3 : 1;
                    int x = BoardColumnSize * i;
                    g.DrawLine(p, new Point(x, 0), new Point(x, BoardColumnNumber * BoardColumnSize));
                }

                foreach (Chess c in Chesses)
                {
                    if (c == null || !c.IsValid)
                        continue;

                    int NewX = c.LocationPoint.X - ChessSize / 2;
                    int NewY = c.LocationPoint.Y - ChessSize / 2;

                    SolidBrush sbM = new SolidBrush(c.MainColor);
                    SolidBrush sbBD = new SolidBrush(c.BorderColor);
                    SolidBrush sbNumber = new SolidBrush(Color.White);

                    g.FillEllipse(sbBD, NewX, NewY, ChessSize + 1, ChessSize + 1);
                    g.FillEllipse(sbM, NewX, NewY, ChessSize, ChessSize);

                    if (ShowChessPlayerID)
                        g.DrawString(c.OwnerPlayer.ID + "", this.Font, sbNumber, c.LocationPoint.X - 5, c.LocationPoint.Y - 5);

                    sbM.Dispose();
                    sbBD.Dispose();
                }

                Graphics diaplayGraphic = this.graphBuffer.Graphics;
                diaplayGraphic.Clear(this.BackColor);
                diaplayGraphic.DrawImage(b, 0, 0);
                this.graphBuffer.Render();
                ShowNexeTurnTips();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                g.Dispose();
                GC.Collect();
            }
        }
        /// <summary>
        /// 在棋盘上放置棋子
        /// </summary>
        /// <param name="ChessType"></param>
        /// <param name="pt"></param>
        private void PlayerPutChessAt(int ChessType, Point pt)
        {
            if (!AllowPutChess)
                return;

            int EX = ChessSize / 2;
            int BW = BoardRowNumber * BoardRowSize;
            int BH = BoardColumnNumber * BoardColumnSize;
            if (pt.X > (BW + EX) || pt.X < (0 - EX) || pt.Y > (BH + EX) || pt.Y < (0 - EX))
                return;

            bool IsAvailable = false;
            Point Apt = GetAvailablePoint(pt, out IsAvailable);
            if (IsAvailable)
            {
                int x = Apt.X / BoardRowSize;
                int y = Apt.Y / BoardColumnSize;

                Chess c = new Chess(ChessType);
                c.LocationPoint = Apt;
                c.IsValid = true;

                foreach (Player p in ls_p)
                {
                    if (p.ID == TurnCounter)
                    {
                        c.OwnerPlayer = p;

                        c.OwnerPlayer.ChangeCColorEvent += (s, e) =>
                        {
                            Player pyr = (Player)s;
                            foreach (Chess chs in Chesses)
                            {
                                if (chs != null && c.IsValid && chs.OwnerPlayer.ID == pyr.ID)
                                {
                                    chs.MainColor = pyr.ChessColor;
                                }
                            }
                        };
                        break;
                    }
                }
                c.MainColor = c.OwnerPlayer.ChessColor;

                if (Chesses[x, y] != null && Chesses[x, y].IsValid)
                    return;
                Chesses[x, y] = c;
                Invalidate();

                CheckPosition(x, y, c);

                TurnCounter++;
                if (TurnCounter > PlayerNumber)
                    TurnCounter = 1;

                ShowNexeTurnTips();
            }
        }
        /// <summary>
        /// 显示下一人提示
        /// </summary>
        private void ShowNexeTurnTips()
        {
            if (AllowPutChess)
            {
                foreach (Player p in ls_p)
                {
                    if (p.ID == TurnCounter)
                    {
                        lb_turn.Show();
                        lb_turn.BackColor = p.ChessColor;
                        lb_turn.ForeColor = Color.White;
                        lb_turn.Text = p.ID + "";
                        break;
                    }
                }
            }
            else
            {
                lb_turn.BackColor = Color.White;
                lb_turn.ForeColor = Color.White;
                lb_turn.Hide();
            }
        }
        /// <summary>
        /// 根据输入的点获取实际可用的点
        /// </summary>
        /// <param name="OriginPoint">输入的点</param>
        /// <param name="IsAvailable">点位是否可以摆放棋子</param>
        /// <returns>Point point实际可用的点</returns>
        private Point GetAvailablePoint(Point OriginPoint, out bool IsAvailable)
        {
            IsAvailable = false;

            bool CheckRange = true;
            Point Apt = new Point();

            try
            {
                //X坐标
                double d0 = (double)(OriginPoint.X) / (double)BoardRowSize;
                double d1 = Math.Round(d0, 0, MidpointRounding.AwayFromZero);
                int AX = Convert.ToInt32(d1 * BoardRowSize);//距输入值最近的一个可用值
                int EXx = ChessSize / 2;

                if (CheckRange)
                {
                    if (OriginPoint.X < AX)
                    {
                        IsAvailable = OriginPoint.X > AX - EXx;
                    }
                    else
                    {
                        IsAvailable = OriginPoint.X < AX + EXx;
                    }
                }
                Apt.X = AX;

                //Y坐标
                double dy0 = (double)(OriginPoint.Y) / (double)BoardColumnSize;
                double dy1 = Math.Round(dy0, 0, MidpointRounding.AwayFromZero);
                int AY = Convert.ToInt32(dy1 * BoardColumnSize);//距输入值最近的一个可用值
                int EXy = ChessSize / 2;

                if (CheckRange)
                {
                    if (OriginPoint.Y < AY)
                    {
                        IsAvailable = OriginPoint.Y > AY - EXy;
                    }
                    else
                    {
                        IsAvailable = OriginPoint.Y < AY + EXy;
                    }
                }
                Apt.Y = AY;
            }
            catch (Exception ex) { }

            return Apt;

        }
        /// <summary>
        /// 检查指定点位周围的我方棋子连接数量
        /// </summary>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <param name="c">棋子</param>
        private void CheckPosition(int x, int y, Chess c)
        {
            //x-1,y-1     x,y-1   x+1,y-1   
            //x-1,y       x,y     x+1,y
            //x-1,y+1     x,y+1   x+1,y+1

            List<Chess> ls = new List<Chess>();
            foreach (CheckDirection cdir in Enum.GetValues(typeof(CheckDirection)))
            {
                switch (cdir)
                {
                    case CheckDirection.W_E:
                        ls = new List<Chess>();
                        FindNearbyChess(c, x, y, ChessPointDirection.W, ref ls);
                        FindNearbyChess(c, x, y, ChessPointDirection.E, ref ls);
                        break;//W_E
                    case CheckDirection.N_S:
                        ls = new List<Chess>();
                        FindNearbyChess(c, x, y, ChessPointDirection.N, ref ls);
                        FindNearbyChess(c, x, y, ChessPointDirection.S, ref ls);
                        break;//N_S
                    case CheckDirection.NW_SE:
                        ls = new List<Chess>();
                        FindNearbyChess(c, x, y, ChessPointDirection.NW, ref ls);
                        FindNearbyChess(c, x, y, ChessPointDirection.SE, ref ls);
                        break;//NW_SE
                    case CheckDirection.SW_NE:
                        ls = new List<Chess>();
                        FindNearbyChess(c, x, y, ChessPointDirection.SW, ref ls);
                        FindNearbyChess(c, x, y, ChessPointDirection.NE, ref ls);
                        break;//SW_NE
                }

                if (ls.Count >= WinChessNumber)
                {
                    AllowPutChess = false;
                    // ttp.MessageStrColor = ls[0].OwnerPlayer.ChessColor;
                    ttp.BackColor = ls[0].OwnerPlayer.ChessColor;
                    ttp.MessageStrColor = Color.White;
                    ttp.ShowTips(string.Format(@"{1}[{0}]  Win!", ls[0].OwnerPlayer.ID, ls[0].OwnerPlayer.Name));
                    break;
                }
            }
        }
        /// <summary>
        /// 查找某一方向的下一个位置 [递归]
        /// </summary>
        /// <param name="c"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Direct">查找方向 1NW 2N 3NE 4E 5SE 6S 7SW 8W</param>
        /// <param name="ls">该方向上己方棋子队列</param>
        private void FindNearbyChess(Chess c, int x, int y, ChessPointDirection Direct, ref List<Chess> ls)
        {
            try
            {
                if (!ls.Contains(c))
                    ls.Add(c);

                int ChessType = c.OwnerPlayer.ID;
                int X = x, Y = y;
                switch (Direct)
                {
                    case ChessPointDirection.NW: X = x - 1; Y = y - 1; break;
                    case ChessPointDirection.N: X = x; Y = y - 1; break;
                    case ChessPointDirection.NE: X = x + 1; Y = y - 1; break;
                    case ChessPointDirection.E: X = x + 1; Y = y; break;
                    case ChessPointDirection.SE: X = x + 1; Y = y + 1; break;
                    case ChessPointDirection.S: X = x; Y = y + 1; break;
                    case ChessPointDirection.SW: X = x - 1; Y = y + 1; break;
                    case ChessPointDirection.W: X = x - 1; Y = y; break;
                    default: X = x; Y = y; break;
                }

                Chess cn = Chesses[X, Y];
                if (cn == null || cn.IsValid == false || cn.OwnerPlayer.ID != ChessType || ls.Count >= WinChessNumber)
                    return;

                ls.Add(cn);
                FindNearbyChess(cn, X, Y, Direct, ref ls);
            }
            catch (IndexOutOfRangeException e)
            {
                return;
            }
        }


        /// <summary>
        /// 玩家列表
        /// </summary>
        private List<Player> ls_p = new List<Player>();
        /// <summary>
        /// 初始化玩家列表
        /// </summary>
        /// <param name="_PlayerNumber"></param>
        private void InitPlayersList(int _PlayerNumber = 2)
        {
            PlayerNumber = _PlayerNumber;
            ls_p.Clear();
            for (int i = 1; i <= _PlayerNumber; i++)
            {
                Player p = new Player();
                p.ID = i;
                p.Name = "Player" + i;
                p.ChessColor = GetRandomColor();
                ls_p.Add(p);
            }

            ShowPlayerList(ls_p);
            Restart();
        }
        /// <summary>
        /// 显示玩家列表
        /// </summary>
        /// <param name="ls"></param>
        private void ShowPlayerList(List<Player> ls)
        {
            flp_PlayerList.Controls.Clear();
            foreach (Player p in ls)
            {
                PlayerExample pe = new PlayerExample();
                pe.PlayerID = p.ID;
                pe.PlayerName = p.Name;
                pe.MainColor = p.ChessColor;
                pe.Size = new Size(125, 37);
                pe.ChangeColorEvent += (s, e) =>
                {
                    PlayerExample pel = (PlayerExample)s;
                    foreach (Player pyr in ls)
                    {
                        if (pyr.ID == pel.PlayerID)
                        {
                            pyr.ChessColor = pel.MainColor;
                            Invalidate();
                            break;
                        }
                    }
                };
                pe.PlayerNameChanged += (s, e) =>
                {
                    PlayerExample pel = (PlayerExample)s;
                    string name = e.ToString();

                    foreach (Player pyr in ls)
                    {
                        if (pyr.ID == pel.PlayerID)
                        {
                            pyr.Name = pel.PlayerName;
                            Invalidate();
                            break;
                        }
                    }

                };
                flp_PlayerList.Controls.Add(pe);
            }
        }
        /// <summary>
        /// 获取随机颜色
        /// </summary>
        /// <returns></returns>
        public Color GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            //  对于C#的随机数，没什么好说的
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);


            //  为了在白色背景上显示，尽量生成深色
            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;
            return Color.FromArgb(int_Red, int_Green, int_Blue);
        }

    }
}
