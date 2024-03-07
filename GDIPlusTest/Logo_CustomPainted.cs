using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FIM
{
    public partial class Logo_CustomPainted : UserControl
    {
        public string text { get; set; }
        public int BorderWidth { get; set; }
        public int BorderRadius { get; set; }
        public Point OriginPoint { get; set; }


        BufferedGraphics graphBuffer;
        public Logo_CustomPainted()
        {
            OriginPoint = new Point(0, 0);
            BorderWidth = 2;
            BorderRadius = 10;

            InitializeComponent();

            graphBuffer = (new BufferedGraphicsContext()).Allocate(this.CreateGraphics(), this.DisplayRectangle);
        }

        private void Logo_CustomPainted_Load(object sender, EventArgs e)
        {

           
        }

        private void Logo_CustomPainted_Paint(object sender, PaintEventArgs e)
        {
            DrawImg();
        }

        private void DrawImg()
        {
            try
            {
                Bitmap b = new Bitmap(this.DisplayRectangle.Width, this.DisplayRectangle.Height);
                Graphics g = Graphics.FromImage((System.Drawing.Image)b);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                SolidBrush sb_Border = new SolidBrush(Color.FromArgb(57, 120, 172));
                SolidBrush sb_BorderPie = new SolidBrush(Color.FromArgb(57, 120, 172));

                g.FillRectangle(sb_Border, OriginPoint.X + BorderRadius, OriginPoint.Y, this.Width - BorderRadius * 2, this.Height);
                g.FillRectangle(sb_Border, OriginPoint.X, OriginPoint.Y + BorderRadius, this.Width, this.Height - BorderRadius * 2);

                g.FillPie(sb_BorderPie, OriginPoint.X, OriginPoint.Y, BorderRadius * 2 + 1, BorderRadius * 2 + 1, -180, 90);
                g.FillPie(sb_BorderPie, this.Width - BorderRadius * 2 - 1, OriginPoint.Y, BorderRadius * 2 + 1, BorderRadius * 2 + 1, 0, -90);
                g.FillPie(sb_BorderPie, this.Width - BorderRadius * 2 - 1, this.Height - BorderRadius * 2 - 1, BorderRadius * 2 + 1, BorderRadius * 2 + 1, 0, 90);
                g.FillPie(sb_BorderPie, OriginPoint.X, this.Height - BorderRadius * 2 - 1, BorderRadius * 2 + 1, BorderRadius * 2 + 1, -180, -90);



                SolidBrush sb_Main = new SolidBrush(Color.FromArgb(89, 154, 218));
                SolidBrush sb_MainPie = new SolidBrush(Color.FromArgb(89, 154, 218));

                g.FillRectangle(sb_Main, OriginPoint.X + BorderRadius + BorderWidth, OriginPoint.Y + BorderWidth, this.Width - BorderRadius * 2 - BorderWidth * 2, this.Height - BorderWidth * 2 - 1);
                g.FillRectangle(sb_Main, OriginPoint.X + BorderWidth, OriginPoint.Y + BorderRadius + BorderWidth, this.Width - BorderWidth * 2 - 1, this.Height - BorderRadius * 2 - BorderWidth * 2);

                g.FillPie(sb_MainPie, OriginPoint.X + BorderWidth, OriginPoint.Y + BorderWidth, BorderRadius * 2 + 1, BorderRadius * 2 + 1, -180, 90);
                g.FillPie(sb_MainPie, this.Width - BorderRadius * 2 - 1 - BorderWidth, OriginPoint.Y + BorderWidth, BorderRadius * 2 + 1, BorderRadius * 2 + 1, 0, -90);
                g.FillPie(sb_MainPie, this.Width - BorderRadius * 2 - 1 - BorderWidth, this.Height - BorderRadius * 2 - 1 - BorderWidth, BorderRadius * 2 + 1, BorderRadius * 2 + 1, 0, 90);
                g.FillPie(sb_MainPie, OriginPoint.X + BorderWidth, this.Height - BorderRadius * 2 - 1 - BorderWidth, BorderRadius * 2 + 1, BorderRadius * 2 + 1, -180, -90);

                g.DrawString("微软雅黑18f", new Font("微软雅黑", 18f), new SolidBrush(Color.White), OriginPoint.X + BorderWidth, OriginPoint.Y + BorderWidth);


                Graphics diaplayGraphic = this.graphBuffer.Graphics;
                diaplayGraphic.Clear(this.BackColor);
                diaplayGraphic.DrawImage(b, 0, 0);
                this.graphBuffer.Render();
            }
            catch { }
            finally { GC.Collect(); }
        }

        private void Logo_CustomPainted_Resize(object sender, EventArgs e)
        {
            graphBuffer = (new BufferedGraphicsContext()).Allocate(this.CreateGraphics(), this.DisplayRectangle);
        }


    }
}
