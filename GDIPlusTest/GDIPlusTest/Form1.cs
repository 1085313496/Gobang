using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace GDIPlusTest
{
    public partial class Form1 : Form
    {
        private BufferedGraphics graphBuffer;

        private Point ChessBoardOriPoint = new Point(20, 20);
        private int ChessSize = 35;
        private int BoardRowSize = 50;
        private int BoardColumnSize = 50;
        private static int BoardRowNumber = 16;
        private static int BoardColumnNumber = 16;

        private Chess[,] Chesses = new Chess[BoardRowNumber + 1, BoardColumnNumber + 1];

        private int TurnCounter = 1;
        private int PlayerNumber = 2;
        private int WinChessNumber = 5;

        private bool AllowPutChess = true;

        private bool IsClient = true;

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(938, 880);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphBuffer = (new BufferedGraphicsContext()).Allocate(this.CreateGraphics(), this.DisplayRectangle);
            //if (!IsClient)
            //    StartServer();

            //IsClient = false;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            graphBuffer = (new BufferedGraphicsContext()).Allocate(this.CreateGraphics(), this.DisplayRectangle);
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

                    g.FillEllipse(sbBD, NewX, NewY, ChessSize + 1, ChessSize + 1);
                    g.FillEllipse(sbM, NewX, NewY, ChessSize, ChessSize);

                    sbM.Dispose();
                    sbBD.Dispose();
                }

                Graphics diaplayGraphic = this.graphBuffer.Graphics;
                diaplayGraphic.Clear(this.BackColor);
                diaplayGraphic.DrawImage(b, 0, 0);
                this.graphBuffer.Render();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                g.Dispose();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e) { PaintChessboard(); }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            PlayerPutChessAt(TurnCounter, new Point(e.X - ChessBoardOriPoint.X, e.Y - ChessBoardOriPoint.Y));
            //if (IsClient)
            //    ConnectServer(TurnCounter, new Point(e.X - ChessBoardOriPoint.X, e.Y - ChessBoardOriPoint.Y));
        }
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
                c.owner = TurnCounter;

                if (Chesses[x, y] != null && Chesses[x, y].IsValid)
                    return;
                Chesses[x, y] = c;
                Invalidate();

                CheckPosition(x, y, c);

                TurnCounter++;
                if (TurnCounter > PlayerNumber)
                    TurnCounter = 1;
            }
        }

        /// <summary>
        /// 根据输入的点获取实际可用的点
        /// </summary>
        /// <param name="OriginPoint"></param>
        /// <param name="IsAvailable"></param>
        /// <returns></returns>
        private Point GetAvailablePoint(Point OriginPoint, out bool IsAvailable)
        {
            IsAvailable = false;

            bool CheckRange = true;
            Point Apt = new Point();

            try
            {
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

        private void CheckPosition(int x, int y, Chess c)
        {
            //x-1,y-1     x,y-1   x+1,y-1   
            //x-1,y       x,y     x+1,y
            //x-1,y+1     x,y+1   x+1,y+1

            int ChessType = c.owner;
            List<Chess> ls = new List<Chess>();
            for (int k = 1; k < 5; k++)
            {
                switch (k)
                {
                    case 1:
                        ls = new List<Chess>();
                        FindNearbyChess(c, x, y, 8, ref ls);
                        FindNearbyChess(c, x, y, 4, ref ls);
                        break;//W_E
                    case 2:
                        ls = new List<Chess>();
                        FindNearbyChess(c, x, y, 2, ref ls);
                        FindNearbyChess(c, x, y, 6, ref ls);
                        break;//N_S
                    case 3:
                        ls = new List<Chess>();
                        FindNearbyChess(c, x, y, 1, ref ls);
                        FindNearbyChess(c, x, y, 5, ref ls);
                        break;//NW_SE
                    case 4:
                        ls = new List<Chess>();
                        FindNearbyChess(c, x, y, 7, ref ls);
                        FindNearbyChess(c, x, y, 3, ref ls);
                        break;//SW_NE
                }

                if (ls.Count >= WinChessNumber)
                {
                    AllowPutChess = false;
                    MessageBox.Show(string.Format(@"{0}Win!", ls[0].owner));
                    break;
                }
            }
        }

        /// <summary>
        /// 查找某一方向的下一个位置
        /// </summary>
        /// <param name="c"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Direct">查找方向 1NW 2N 3NE 4E 5SE 6S 7SW 8W </param>
        /// <returns></returns>
        private void FindNearbyChess(Chess c, int x, int y, int Direct, ref List<Chess> ls)
        {
            try
            {
                if (!ls.Contains(c))
                    ls.Add(c);

                int ChessType = c.owner;
                int X = x, Y = y;
                switch (Direct)
                {
                    case 1: X = x - 1; Y = y - 1; break;
                    case 2: X = x; Y = y - 1; break;
                    case 3: X = x + 1; Y = y - 1; break;
                    case 4: X = x + 1; Y = y; break;
                    case 5: X = x + 1; Y = y + 1; break;
                    case 6: X = x; Y = y + 1; break;
                    case 7: X = x - 1; Y = y + 1; break;
                    case 8: X = x - 1; Y = y; break;
                    default: X = x; Y = y; break;
                }

                Chess cn = Chesses[X, Y];
                if (cn == null || cn.IsValid == false || cn.owner != ChessType || ls.Count >= WinChessNumber)
                    return;

                ls.Add(cn);
                FindNearbyChess(cn, X, Y, Direct, ref ls);
            }
            catch (IndexOutOfRangeException e)
            {
                return;
            }
        }


        private void StartServer()
        {
            try
            {
                //创建通信侦听通道对象
                TcpServerChannel channel = new TcpServerChannel(699);
                //注册通信侦听通道
                ChannelServices.RegisterChannel(channel, false);

                //注册对象URI
                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                RemotingConfiguration.CustomErrorsEnabled(false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(Form1), "ChessForm", WellKnownObjectMode.SingleCall);

                Hashtable props = new Hashtable();
                props["name"] = "tcpClient";
                props["timeout"] = 30000;
                IChannel tcc = new TcpClientChannel(props, new BinaryClientFormatterSinkProvider());
                ChannelServices.RegisterChannel(tcc, false);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void ConnectServer(int ChessType, Point pt)
        {
            string strIP = "127.0.0.1:699";
            TcpClientChannel tcc = new TcpClientChannel();
            try
            {
                ChannelServices.RegisterChannel(tcc, false);
                Form1 FM = (Form1)Activator.GetObject(typeof(Form1), string.Format("tcp://{0}/ChessForm", strIP));
                if (FM == null)
                {
                    System.Windows.Forms.MessageBox.Show("找不到服务器!");
                    return;
                }

                FM.PlayerPutChessAt(ChessType, pt);
                ChannelServices.UnregisterChannel(tcc);
            }
            catch (Exception ex)
            {
                ChannelServices.UnregisterChannel(tcc);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsClient = !IsClient;
        }

    }
}
