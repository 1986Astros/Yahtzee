using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Yahtzee
{
    public partial class Die : UserControl
    {
        public Die()
        {
            InitializeComponent();
        }

        public int Value
        {
            get
            {
                return shhValue;
            }
            set
            {
                if (value != shhValue)
                {
                    Invalidate();
                    Invalidate(Spots[shhValue - 1]);
                    shhValue = value;
                    Invalidate(Spots[shhValue - 1]);
                }
            }
        }
        private int shhValue = 6;

        public float Angle { get; set; } = 0;
        public bool Selected { get; set; } = false;

        public int Roll(bool Spin = false)
        {
            Invalidate(Spots[Value - 1]);
            Value = rnd.Next(1, 7);
            Invalidate(Spots[Value - 1]);
            return Value;
        }
        private static Random rnd = new Random();
        public void DebugRoll(int NewValue)
        {
            Invalidate(Spots[Value - 1]);
            Value = NewValue;
            Invalidate(Spots[Value - 1]);
        }

        private void Die_Load(object sender, EventArgs e)
        {
            CalculateDots();
        }

        private Size LastSize = Size.Empty;
        private Region[] Spots = Enumerable.Range(0, 6).Select(r => new Region()).ToArray();
        private static List<List<int>> SpotCollection = new List<List<int>> {
            new List<int> {4},
            new List<int> {0,8},
            new List<int> {0,4,8},
            new List<int> {0,2,6,8},
            new List<int> {0,2,4,6,8},
            new List<int> {0,1,2,6,7,8},
            };
        RectangleF[] SpotRectangle = Enumerable.Range(0, 9).Select(sr => RectangleF.Empty).ToArray();

        private void CalculateDots()
        {
            float w = Width;
            float BorderWidth = 0;
            switch (BorderStyle)
            {
                case BorderStyle.None:
                    break;
                case BorderStyle.FixedSingle:
                    BorderWidth = SystemInformation.BorderSize.Width;
                    break;
                case BorderStyle.Fixed3D:
                    BorderWidth = SystemInformation.Border3DSize.Width;
                    break;
            }
            w -= 2 * BorderWidth;
            RectangleF r = new RectangleF(-BorderWidth / 2f, -BorderWidth / 2f, w / 5f, w / 5f);
            Region[] SpotRegion = Enumerable.Range(0, 9).Select(sr => new Region()).ToArray();
            RectangleF rThisSpot;
            GraphicsPath gp;

            int d = 0;
            for (int col = 1; col < 10; col += 3)
            {
                rThisSpot = r;
                rThisSpot.Offset(col * w / 10, w / 10);
                for (int row = 1; row < 10; row += 3)
                {
                    gp = new GraphicsPath();
                    gp.AddEllipse(rThisSpot);
                    SpotRectangle[d] = rThisSpot;
                    SpotRegion[d++] = new Region(gp);
                    rThisSpot.Offset(0, 3 * w / 10);
                }
            }

            d = 0;
            foreach (List<int> SpotIndex in SpotCollection)
            {
                Spots[d].MakeEmpty();
                foreach (int ThisSpot in SpotIndex)
                {
                    Spots[d].Union(SpotRegion[ThisSpot]);
                }
                d++;
            }
            LastSize = Size;
        }

        public void Die_Paint(object sender, PaintEventArgs e)
        {
            using (Brush br = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(br, 0, 0, Width, Width);
            }
            using (Brush br = new SolidBrush(ForeColor))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                foreach (int pip in SpotCollection[Value - 1])
                {
                    e.Graphics.FillEllipse(br, SpotRectangle[pip]);
                }
            }
        }

        private void Die_SizeChanged(object sender, EventArgs e)
        {
            Size NewSize = new Size(Math.Min(Width, Height), Math.Min(Width, Height));
            if (!LastSize.Equals(NewSize))
            {
                if (!LastSize.IsEmpty)
                {
                    Invalidate(Spots[Value - 1]);
                    CalculateDots();
                    Invalidate(Spots[Value - 1]);
                }
                Size = NewSize;
                LastSize = Size;
            }
        }

        public delegate void DieClickEventHandler(Object sender, EventArgs e);
        public event DieClickEventHandler ClickDie;

        private void Die_MouseClick(object sender, MouseEventArgs e)
        {
            ClickDie?.Invoke(this, EventArgs.Empty);
        }
    }
}
