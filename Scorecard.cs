using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

// https://gamerules.com/rules/yahtzee-dice-game/

namespace Yahtzee
{
    public partial class Scorecard : UserControl
    {
        public Scorecard()
        {
            InitializeComponent();
        }

        #region "Fonts"
        [Category("Fonts")]
        [DefaultValue(typeof(Font), HeaderFontString)]
        public Font HeaderFont
        {
            get
            {
                return shhHeaderFont;
            }
            set
            {
                shhHeaderFont = value;
                Invalidate();
            }
        }
        private const String HeaderFontString = "Franklin Gothic Demi, 12pt";
        private Font shhHeaderFont = ExtensionMethods.MyExtensions.FontFromString(HeaderFontString);
        private float HeaderHeight;

        [Category("Fonts")]
        [DefaultValue(typeof(Font), LineScoreFontString)]
        public Font LinescoreFont
        {
            get
            {
                return shhHLineScoreFont;
            }
            set
            {
                shhHLineScoreFont = value;
                Invalidate();
            }
        }
        private float LineScoreHeight;
        private const String LineScoreFontString = "Franklin Gothic Medium Cond, 12pt";
        private Font shhHLineScoreFont = ExtensionMethods.MyExtensions.FontFromString(LineScoreFontString);

        [Category("Fonts")]
        [DefaultValue(typeof(Font), AnnotationFontString)]
        public Font AnnotationFont
        {
            get
            {
                return shhAnnotationFont;
            }
            set
            {
                shhAnnotationFont = value;
                Invalidate();
            }
        }
        private float AnnotationHeight;
        private const String AnnotationFontString = "Microsoft Sans Serif, 6.75pt";
        private Font shhAnnotationFont = ExtensionMethods.MyExtensions.FontFromString(AnnotationFontString);

        [Category("Fonts")]
        [DefaultValue(typeof(Font), BonusFontString)]
        public Font BonusFont
        {
            get
            {
                return shhBonusFont;
            }
            set
            {
                shhBonusFont = value;
                Invalidate();
            }
        }
        private float BonusHeight;
        private const String BonusFontString = "Franklin Gothic Heavy, 12pt";
        private Font shhBonusFont = ExtensionMethods.MyExtensions.FontFromString(BonusFontString);

        [Category("Fonts")]
        [DefaultValue(typeof(Font), ScoreFontString)]
        public Font ScoreFont
        {
            get
            {
                return shhScoreFont;
            }
            set
            {
                shhScoreFont = value; Invalidate();
            }
        }
        private float ScoreFontHeight;
        private const String ScoreFontString = "Comic Sans MS, 12pt, style=Bold, Italic";
        private Font shhScoreFont = ExtensionMethods.MyExtensions.FontFromString(ScoreFontString);
        #endregion

        #region "Game play"
        [Category("Game play")]
        [DefaultValue(false)]
        public bool YahtzeeBonuses
        {
            get
            {
                return shhYahtzeeBonuses;
            }
            set
            {
                if (value != shhYahtzeeBonuses)
                {
                    shhYahtzeeBonuses = value;
                    if (shhYahtzeeBonuses && TripleYahtzee)
                    {
                        TripleYahtzee = false;
                    }
                    foreach (GameScore gs in ColumnScore)
                    {
                        gs.UseBonusYahtzees = shhYahtzeeBonuses;
                    }
                    MeasureEverything();
                    ResizeForAutoSize();
                    Invalidate();
                }
            }
        }
        private bool shhYahtzeeBonuses = false;

        [Category("Game play")]
        [DefaultValue(false)]
        public bool TripleYahtzee
        {
            get
            {
                return shhTripleYahtzee;
            }
            set
            {
                if (value != shhTripleYahtzee)
                {
                    shhTripleYahtzee = value;
                    if (shhTripleYahtzee && YahtzeeBonuses)
                    {
                        YahtzeeBonuses = false;
                    }
                    InitializeGameScores();
                    MeasureEverything();
                    ResizeForAutoSize();
                    Invalidate();
                }
            }
        }
        private bool shhTripleYahtzee = false;
        #endregion

        public int GrandTotal()
        {
            if (TripleYahtzee)
            {
                return ColumnScore[0].GrandTotal + 2 * ColumnScore[1].GrandTotal + 3 * ColumnScore[2].GrandTotal;
            }
            else
            {
                return ColumnScore[0].GrandTotal;
            }
        }

        public List<GameScore> ColumnScore = new List<Yahtzee.GameScore>();
        public string PlayerName = "Guest";

        public delegate void EndOfTurnEventHandler(object sender, EventArgs e);
        public event EndOfTurnEventHandler EndOfTurn;
        public delegate void ScorecardCompletedEventHandler(object sender, EventArgs e);
        public event ScorecardCompletedEventHandler ScorecardCompleted;

        private void Scorecard_Load(object sender, EventArgs e)
        {
            InitializeGameScores();
            MeasureEverything();
            ResizeForAutoSize();
        }

        public void InitializeGameScores()
        {
            ColumnScore.Clear();
            ColumnScore.Add(new Yahtzee.GameScore() { UseBonusYahtzees = YahtzeeBonuses });
            if (TripleYahtzee)
            {
                ColumnScore.Add(new Yahtzee.GameScore() { UseBonusYahtzees = false });
                ColumnScore.Add(new Yahtzee.GameScore() { UseBonusYahtzees = false });
            }
            Invalidate();   // need all the scoring areas + first column of last hit area; ScorecardCompleted correctly sets LastHit = null; could clear it first, but it's cool seeing the final roll.
        }

        #region "Control sizing"
        private float LinescoreColumnWidth;
        private float HowToScoreColumnWidth;
        private float GameColumnWidth;
        private Size shhPreferredSize;
        private void MeasureEverything()
        {
            using (Graphics g = CreateGraphics())
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                HeaderHeight = HeaderFont.Height;
                LineScoreHeight = LinescoreFont.Height;
                AnnotationHeight = AnnotationFont.Height;
                BonusHeight = BonusFont.Height;
                ScoreFontHeight = ScoreFont.Height;

                LinescoreColumnWidth = g.MeasureString("BONUSMM", BonusFont).Width + g.MeasureString("If total score", AnnotationFont).Width;
                HowToScoreColumnWidth = g.MeasureString("HOW TO SCORE", HeaderFont).Width;
                GameColumnWidth = g.MeasureString("99999", ScoreFont).Width;

                MaxWidthOfLeftColumnText = g.MeasureString("SM Straight", LinescoreFont).Width;
            }
            float AutosizeWidth = LinescoreColumnWidth + HowToScoreColumnWidth + (TripleYahtzee ? 3 : 1) * GameColumnWidth;
            float AutosizeHeight = 7 * HeaderHeight + 13 * LineScoreHeight + BonusHeight + PaddingConst;

            if (YahtzeeBonuses)
            {
                AutosizeHeight += 2 * BonusHeight;
            }
            else if (TripleYahtzee)
            {

                AutosizeHeight += 3 * HeaderHeight;
            }
            shhPreferredSize = new Size((int)Math.Ceiling(AutosizeWidth) + 1, (int)Math.Ceiling(AutosizeHeight) + 1);

            // prepare for painting
            RectangleF r;
            AllHitAreas.Clear();
            UpperLines.Clear();
            UpperLines.Add(HeaderHeight);
            r = new RectangleF(LinescoreColumnWidth + HowToScoreColumnWidth, HeaderHeight, GameColumnWidth, LineScoreHeight);
            r.Inflate(-2, -2);
            for (int i = 0; i < 6; i++)
            {
                AllHitAreas.Add(new LayoutArea(LayoutArea.Areas.UpperSectionScoring, r, 0, i));
                UpperLines.Add(UpperLines.Last() + LineScoreHeight);
                r.Offset(0, LineScoreHeight);
            }
            UpperLines.Add(UpperLines.Last() + HeaderHeight);
            AllHitAreas.Add(new LayoutArea(LayoutArea.Areas.UpperSectionTotalWithoutBonus, r, 0));
            r.Offset(0, HeaderHeight);
            UpperLines.Add(UpperLines.Last() + BonusHeight);
            AllHitAreas.Add(new LayoutArea(LayoutArea.Areas.UpperSectionBonus, r, 0));
            r.Offset(0, BonusHeight);
            UpperLines.Add(UpperLines.Last() + HeaderHeight);
            AllHitAreas.Add(new LayoutArea(LayoutArea.Areas.UpperSectionBonusTotal, r, 0));
            r.Offset(0, 2 * HeaderHeight + PaddingConst);

            LowerLines.Clear();
            LowerLines.Add(UpperLines.Last() + PaddingConst);
            LowerLines.Add(LowerLines.Last() + HeaderHeight);
            for (int i = 0; i < 7; i++)
            {
                AllHitAreas.Add(new LayoutArea(LayoutArea.Areas.LowerSectionScoring, r, 0, i));
                LowerLines.Add(LowerLines.Last() + LineScoreHeight);
                r.Offset(0, LineScoreHeight);
            }
            if (YahtzeeBonuses)
            {
                r.Offset(0, BonusHeight - LineScoreHeight);
                AllHitAreas.Add(new LayoutArea(LayoutArea.Areas.YahtzeeBonuses, r, 0));
                LowerLines.Add(LowerLines.Last() + BonusHeight);
                r.Offset(0, BonusHeight);
                AllHitAreas.Add(new LayoutArea(LayoutArea.Areas.YahtzeeBonusScore, r, 0));
                LowerLines.Add(LowerLines.Last() + BonusHeight);
                r.Offset(0, BonusHeight);
            }
            LayoutArea.Areas[] LowerTotalAreas = new LayoutArea.Areas[] { LayoutArea.Areas.LowerSectionTotal, LayoutArea.Areas.LowerSectionUpperTotal, LayoutArea.Areas.LowerSectionGrandTotal };
            for (int i = 0; i < 3; i++)
            {
                AllHitAreas.Add(new LayoutArea(LowerTotalAreas[i], r, 0));
                LowerLines.Add(LowerLines.Last() + HeaderHeight);
                r.Offset(0, HeaderHeight);
            }
            if (TripleYahtzee )
            {
                LowerLines.Add(LowerLines.Last() + HeaderHeight);
                LowerLines.Add(LowerLines.Last() + HeaderHeight);
                LowerLines.Add(LowerLines.Last() + HeaderHeight);
            }
            // add the hitpoints in other columns
            List<LayoutArea> OriginalList = new List<LayoutArea>(AllHitAreas);
            foreach (LayoutArea la in OriginalList)
            {
                r = la.BoundingRectangle;
                if (TripleYahtzee)
                {
                    r.Offset(GameColumnWidth, 0);
                    AllHitAreas.Add(la.Clone(r, 1));
                    r.Offset(GameColumnWidth, 0);
                    AllHitAreas.Add(la.Clone(r, 2));
                }
            }
            // add the hitpoints for tourney total
            if (TripleYahtzee)
            {
                r = new RectangleF(LinescoreColumnWidth + HowToScoreColumnWidth, ((IEnumerable<float>)LowerLines).Reverse().Skip(2).First(), AutosizeWidth - (LinescoreColumnWidth + HowToScoreColumnWidth), HeaderHeight);
                for (int i = 0; i < 3; i++)
                {
                    RectangleF MultiplierRectangle = new RectangleF(r.Left + i * (r.Width / 3), r.Top, r.Width / 3, r.Height);
                    MultiplierRectangle.Inflate(-2, -2);
                    AllHitAreas.Add(new LayoutArea(LayoutArea.Areas.TripleYahtzeeGrandTotal, MultiplierRectangle, i));
                }
                r = new RectangleF(LinescoreColumnWidth + HowToScoreColumnWidth, ((IEnumerable<float>)LowerLines).Reverse().Skip(1).First(), AutosizeWidth - (LinescoreColumnWidth + HowToScoreColumnWidth), HeaderHeight);
                r.Inflate(-2, -2);
                AllHitAreas.Add(new LayoutArea(LayoutArea.Areas.TournamentTotal, r, 0));
            }
        }

        // https://stackoverflow.com/questions/9857041/how-can-i-implement-an-autosize-property-to-a-custom-control
        /// <summary>
        /// Method that forces the control to resize itself when in AutoSize following
        /// a change in its state that affect the size.
        /// </summary>
        private void ResizeForAutoSize()
        {
            if (this.AutoSize)
                this.SetBoundsCore(this.Left, this.Top, this.Width, this.Height,
                            BoundsSpecified.Size);
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which
        /// a control can be fitted.
        /// </summary>
        public override Size GetPreferredSize(Size proposedSize)
        {
            return shhPreferredSize;
        }

        /// <summary>
        /// Performs the work of setting the specified bounds of this control.
        /// </summary>
        protected override void SetBoundsCore(int x, int y, int width, int height,
                BoundsSpecified specified)
        {
            //  Only when the size is affected...
            if (this.AutoSize && (specified & BoundsSpecified.Size) != 0)
            {
                Size size = shhPreferredSize;

                width = size.Width;
                height = size.Height;
            }

            base.SetBoundsCore(x, y, width, height, specified);
        }
        #endregion

        const float PaddingConst = 8;
        private List<float> UpperLines = new List<float>();
        private List<float> LowerLines = new List<float>();
        private float MaxWidthOfLeftColumnText;

        private void Scorecard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            RectangleF r;

            if (LastHit != null)
            {
                e.Graphics.FillRectangle(Brushes.PowderBlue, Rectangle.Round(LastHit.BoundingRectangle));
                r = new RectangleF(1, LastHit.BoundingRectangle.Top, LinescoreColumnWidth - 2, LastHit.BoundingRectangle.Height);
                e.Graphics.FillRectangle(Brushes.PowderBlue, Rectangle.Round(r));
            }

            // enhancement: shade the card background in the areas that show totals and bonuses so that they stand out from scoring areas
            using (Brush ForeBrush = new SolidBrush(this.ForeColor))
            {
                using (Pen ForePen = new Pen(this.ForeColor))
                {
                    #region "horizontal lines"
                    e.Graphics.DrawLine(ForePen, 0, 0, Width, 0);

                    foreach (float ul in UpperLines)
                    {
                        e.Graphics.DrawLine(ForePen, 0, ul, Width, ul);
                    }

                    e.Graphics.DrawLine(ForePen, 0, LowerLines[0], LinescoreColumnWidth, LowerLines[0]);
                    if (YahtzeeBonuses)
                    {
                        foreach (float ll in LowerLines.Skip(1).Take(8))
                        {
                            e.Graphics.DrawLine(ForePen, 0, ll, Width, ll);
                        }
                        e.Graphics.DrawLine(ForePen, LinescoreColumnWidth, LowerLines.Skip(9).First(), Width, LowerLines.Skip(9).First());
                        foreach (float ll in LowerLines.Skip(10))
                        {
                            e.Graphics.DrawLine(ForePen, 0, ll, Width, ll);
                        }
                    }
                    else
                    {
                        foreach (float ll in LowerLines.Skip(1))
                        {
                            e.Graphics.DrawLine(ForePen, 0, ll, Width, ll);
                        }
                    }
                    #endregion

                    #region "vertical lines"
                    e.Graphics.DrawLine(ForePen, 0, 0, 0, UpperLines.Last());
                    e.Graphics.DrawLine(ForePen, 0, LowerLines[0], 0, LowerLines.Last());
                    e.Graphics.DrawLine(ForePen, LinescoreColumnWidth, 0, LinescoreColumnWidth, UpperLines.Last());
                    if (TripleYahtzee)
                    {
                        e.Graphics.DrawLine(ForePen, LinescoreColumnWidth, LowerLines[0], LinescoreColumnWidth, LowerLines.ElementAt(LowerLines.Count - 4));
                        e.Graphics.DrawLine(ForePen, LinescoreColumnWidth, LowerLines.ElementAt(LowerLines.Count - 3), LinescoreColumnWidth, LowerLines.Last());
                    }
                    else
                    {
                        e.Graphics.DrawLine(ForePen, LinescoreColumnWidth, LowerLines[0], LinescoreColumnWidth, LowerLines.Last());
                    }
                    float x = LinescoreColumnWidth + HowToScoreColumnWidth;
                    for (int i = 0; i < (TripleYahtzee ? 3 : 1); i++)
                    {
                        e.Graphics.DrawLine(ForePen, x, 0, x, UpperLines.Last());
                        e.Graphics.DrawLine(ForePen, x, LowerLines[1], x,i  == 0 ?  LowerLines.Last():LowerLines.ElementAt(LowerLines.Count-2));
                        x += GameColumnWidth;
                    }
                    e.Graphics.DrawLine(ForePen, Width - 1, 0, Width - 1, UpperLines.Last());
                    e.Graphics.DrawLine(ForePen, Width - 1, LowerLines[1], Width - 1, LowerLines.Last());
                    if (YahtzeeBonuses)
                    {
                        x = LinescoreColumnWidth + HowToScoreColumnWidth;
                        float x2;
                        for (int i = 0; i < (TripleYahtzee ? 3 : 1); i++)
                        {
                            x2 = x + GameColumnWidth / 3;
                            for (int j = 1; j < 3; j++)
                            {
                                e.Graphics.DrawLine(ForePen, x2, LowerLines[8], x2, LowerLines[9]);
                                x2 += GameColumnWidth / 3;
                            }
                            x += GameColumnWidth;
                        }
                    }
                    #endregion

                    #region "labels - left column"
                    r = new RectangleF(1, 1, LinescoreColumnWidth - 1, HeaderHeight - 1);
                    e.Graphics.DrawString("UPPER SECTION", HeaderFont, ForeBrush, r, Globals.sfLeft);
                    r = new RectangleF(1, r.Top + HeaderHeight, LinescoreColumnWidth - 1, LineScoreHeight - 1);

                    for (int i = 0; i < 6; i++)
                    {
                        e.Graphics.DrawString(Globals.UpperSectionNames[i], LinescoreFont, ForeBrush, r, Globals.sfLeft);
                        r.Offset(0, LineScoreHeight);
                    }

                    r = new RectangleF(1, r.Top, LinescoreColumnWidth, HeaderHeight - 1);
                    e.Graphics.DrawString("TOTAL", HeaderFont, ForeBrush, r, Globals.sfLeft);

                    r = new RectangleF(1,r.Top + HeaderHeight, LinescoreColumnWidth, BonusHeight - 1);
                    e.Graphics.DrawString("BONUS", BonusFont, ForeBrush, r, Globals.sfLeft);

                    r = new RectangleF(1, r.Top + BonusHeight, LinescoreColumnWidth, HeaderHeight - 1);
                    e.Graphics.DrawString("TOTAL", HeaderFont, ForeBrush, r, Globals.sfLeft);

                    r = new RectangleF(1, r.Top + HeaderHeight + PaddingConst, LinescoreColumnWidth, HeaderHeight - 1);
                    e.Graphics.DrawString("LOWER SECTION", HeaderFont, ForeBrush, r, Globals.sfLeft);
                    r.Offset(0, HeaderHeight);

                    for (int i = 0; i < 7; i++)
                    {
                        e.Graphics.DrawString(Globals.LowerSectionNames[i], LinescoreFont, ForeBrush, r, Globals.sfLeft);
                        r.Offset(0, LineScoreHeight);
                    }

                    if (YahtzeeBonuses)
                    {
                        r = new RectangleF(1, r.Top, LinescoreColumnWidth, 2 * BonusHeight - 1);
                        e.Graphics.DrawString("YAHTZEE\nBONUS", BonusFont, ForeBrush, r, Globals.sfCenter);
                        r.Offset(00, 2 * BonusHeight);
                    }

                    r = new RectangleF(1,r.Top, LinescoreColumnWidth, HeaderHeight - 1);
                    e.Graphics.DrawString("TOTAL", HeaderFont, ForeBrush, r, Globals.sfLeft);
                    r.Offset(0, HeaderHeight);

                    e.Graphics.DrawString("TOTAL", HeaderFont, ForeBrush, r, Globals.sfLeft);
                    r.Offset(0, HeaderHeight);

                    if (TripleYahtzee)
                    {
                        e.Graphics.DrawString("COMBINED TOTAL", HeaderFont, ForeBrush, r, Globals.sfLeft);
                        r.Offset(0, 2 * HeaderHeight);
                        e.Graphics.DrawString("TRIPLE YAHTZEE", HeaderFont, ForeBrush, r, Globals.sfLeft);
                        r.Offset(0, HeaderHeight);
                    }

                    e.Graphics.DrawString("GRAND TOTAL", HeaderFont, ForeBrush, r, Globals.sfLeft);
                    r.Offset(0, HeaderHeight);
                    #endregion

                    #region "annotations"
                    Controls.Clear();
                    void DrawLineItemDie(int DieValue, RectangleF ValueRect)
                    {
                        float WidthOfDiePlusNumber = ValueRect.Height - 2 + e.Graphics.MeasureString(" = 8", LinescoreFont).Width;
                        float DieX = ValueRect.Width - WidthOfDiePlusNumber;
                        float WidthOfDie = ValueRect.Height - 2;
                        Die NewDie = new Die()
                        {
                            Value = DieValue,
                            Left = (int)Math.Floor(DieX),
                            Top = (int)Math.Floor(ValueRect.Top),
                            Width = (int)Math.Ceiling(WidthOfDie),
                            Height = (int)Math.Ceiling(WidthOfDie)
                        };
                        Controls.Add(NewDie);   // todo: instead of adding as a Control, create a static function in the DieControl to just paint it
                        ValueRect = new RectangleF(DieX + WidthOfDie, ValueRect.Top, ValueRect.Right - DieX - WidthOfDie, ValueRect.Height);
                        e.Graphics.DrawString($" = {DieValue}", LinescoreFont, ForeBrush, ValueRect, Globals.sfLeft);
                    }

                    // measure the width of the widest LineItemDie word
                    float MaxUpperSectionNamesWidth = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        MaxUpperSectionNamesWidth = Math.Max(MaxUpperSectionNamesWidth, e.Graphics.MeasureString(Globals.UpperSectionNames[i], LinescoreFont).Width);
                    }
                    r = new RectangleF(1, HeaderHeight + 1, LinescoreColumnWidth - MaxUpperSectionNamesWidth, LineScoreHeight);
                    for (int i = 1; i < 7; i++)
                    {
                        DrawLineItemDie(i, r);
                        r.Offset(0, LineScoreHeight);
                    }

                    r = new RectangleF(MaxWidthOfLeftColumnText, UpperLines[7] + 1, LinescoreColumnWidth - MaxWidthOfLeftColumnText, BonusHeight);
                    e.Graphics.DrawString("If total score\nis 63 or over", AnnotationFont, ForeBrush, r, Globals.sfCenter);

                    r = new RectangleF(MaxWidthOfLeftColumnText, r.Top + BonusHeight, r.Width, HeaderHeight);
                    e.Graphics.DrawString("Of Upper\nsection", AnnotationFont, ForeBrush, r, Globals.sfCenter);

                    r = new RectangleF(MaxWidthOfLeftColumnText, LowerLines[4] + 1, r.Width, LineScoreHeight);
                    e.Graphics.DrawString("Sequence\nof 4", AnnotationFont, ForeBrush, r, Globals.sfCenter);

                    r.Offset(0, LineScoreHeight);
                    e.Graphics.DrawString("Sequence\nof 5", AnnotationFont, ForeBrush, r, Globals.sfCenter);

                    r.Offset(0, LineScoreHeight);
                    e.Graphics.DrawString("5 of\nA Kind", AnnotationFont, ForeBrush, r, Globals.sfCenter);

                    r = new RectangleF(r.Left, LowerLines[YahtzeeBonuses ? 10 : 8] + 1, r.Width, HeaderHeight);
                    e.Graphics.DrawString("Of Lower\nSection", AnnotationFont, ForeBrush, r, Globals.sfCenter);

                    r.Offset(0, HeaderHeight);
                    e.Graphics.DrawString("Of Upper\nSection", AnnotationFont, ForeBrush, r, Globals.sfCenter);
                    #endregion

                    #region "how to score"
                    r = new RectangleF(LinescoreColumnWidth + 1, 1, HowToScoreColumnWidth, HeaderHeight);
                    e.Graphics.DrawString("HOW TO SCORE", HeaderFont, ForeBrush, r, Globals.sfCenter);

                    r = new RectangleF(r.Left, r.Top + HeaderHeight, HowToScoreColumnWidth, LineScoreHeight);
                    for (int i = 0; i < 6; i++)
                    {
                        e.Graphics.DrawString($"Count and Add\nonly {Globals.UpperSectionNames[i]}", AnnotationFont, ForeBrush, r, Globals.sfCenter);
                        r.Offset(0, LineScoreHeight);
                    }

                    void DrawArrow(RectangleF ArrowRect)
                    {
                        using (Pen ArrowPen = new Pen(Color.LightGray, 5) { EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor })
                        {
                            e.Graphics.DrawLine(ArrowPen, ArrowRect.Left + ArrowRect.Width / 3, ArrowRect.Top + ArrowRect.Height / 2, ArrowRect.Right - ArrowRect.Width / 3, ArrowRect.Top + ArrowRect.Height / 2);
                        }
                    }

                    r = new RectangleF(r.Left, r.Top, HowToScoreColumnWidth, HeaderHeight);
                    DrawArrow(r);

                    r = new RectangleF(r.Left, r.Top + HeaderHeight, HowToScoreColumnWidth, BonusHeight);
                    DrawArrow(r);

                    r = new RectangleF(LinescoreColumnWidth + 1, r.Top+BonusHeight, HowToScoreColumnWidth, HeaderHeight);
                    DrawArrow(r);

                    r = new RectangleF(r.Left, LowerLines[1]+1, HowToScoreColumnWidth, LineScoreHeight);
                    for (int i = 0; i < 2; i++)
                    {
                        e.Graphics.DrawString("Addition\nof all dice", AnnotationFont, ForeBrush, r, Globals.sfCenter);
                        r.Offset(0, LineScoreHeight);
                    }

                    foreach (int score in new int[] { 25, 30, 40, 50 })
                    {
                        e.Graphics.DrawString($"SCORE {score}", AnnotationFont, ForeBrush, r, Globals.sfCenter);
                        r.Offset(0, LineScoreHeight);
                    }

                    e.Graphics.DrawString("Score total\nof all dice", AnnotationFont, ForeBrush, r, Globals.sfCenter);
                    r.Offset(0, LineScoreHeight);

                    if (YahtzeeBonuses)
                    {
                        r = new RectangleF(r.Left, r.Top, r.Width, BonusHeight);
                        e.Graphics.DrawString("X FOR\nEACH BONUS", AnnotationFont, ForeBrush, r, Globals.sfCenter);
                        r.Offset(0, BonusHeight);

                        e.Graphics.DrawString("SCORE 100\nPER X", AnnotationFont, ForeBrush, r, Globals.sfCenter);
                        r.Offset(0, BonusHeight);
                    }

                    r = new RectangleF(r.Left, r.Top-1, r.Width, HeaderHeight);
                    for (int i = 0; i < 3; i++)
                    {
                        DrawArrow(r);
                        r.Offset(0, HeaderHeight);
                    }
                    if (TripleYahtzee)
                    {
                        RectangleF TripleYahtzeeMutltipliers = new RectangleF(r.Left + HowToScoreColumnWidth,r.Top, GameColumnWidth,r.Height);

                        r.Offset(0, HeaderHeight);
                        for (int i = 0; i < 2; i++)
                        {
                            DrawArrow(r);
                            r.Offset(0, HeaderHeight);
                        }

                        for (int i = 1; i < 4; i++)
                        {
                            e.Graphics.DrawString($"x{i}", HeaderFont, ForeBrush, TripleYahtzeeMutltipliers, Globals.sfCenter);
                            TripleYahtzeeMutltipliers.Offset(GameColumnWidth, 0);
                        }
                    }
                    #endregion
                }
            }

            #region "Fill in the scorecard."
            for (int g = 0; g < (TripleYahtzee ? 3 : 1); g++)
            {
                for (int us = 0; us < 6; us++)
                {
                    if (ColumnScore[g].ScoredUpperSection[us])
                    {
                        LayoutArea la = AllHitAreas.First(ha => ha.Game == g && ha.Row == us && ha.ScoringArea == LayoutArea.Areas.UpperSectionScoring);
                        e.Graphics.DrawString(ColumnScore[g].UpperSection[us].ToString(), ScoreFont, Brushes.Red, la.BoundingRectangle, Globals.sfRight);
                    }
                }
                if (ColumnScore[g].UpperSectionIsFilled())
                {
                    e.Graphics.DrawString(ColumnScore[g].UpperScoreWithoutBonus.ToString(), ScoreFont, Brushes.Red,
                        Rectangle.Round(AllHitAreas.First(ha => ha.Game == g && ha.ScoringArea == LayoutArea.Areas.UpperSectionTotalWithoutBonus).BoundingRectangle),
                        Globals.sfRight);
                    e.Graphics.DrawString(ColumnScore[g].UpperBonus.ToString(), ScoreFont, Brushes.Red,
                        Rectangle.Round(AllHitAreas.First(ha => ha.Game == g && ha.ScoringArea == LayoutArea.Areas.UpperSectionBonus).BoundingRectangle),
                        Globals.sfRight);
                    e.Graphics.DrawString(ColumnScore[g].UpperScoreWithBonus.ToString(), ScoreFont, Brushes.Red,
                        Rectangle.Round(AllHitAreas.First(ha => ha.Game == g && ha.ScoringArea == LayoutArea.Areas.UpperSectionBonusTotal).BoundingRectangle),
                        Globals.sfRight);
                    e.Graphics.DrawString(ColumnScore[g].UpperScoreWithBonus.ToString(), ScoreFont, Brushes.Red,
                        Rectangle.Round(AllHitAreas.First(ha => ha.Game == g && ha.ScoringArea == LayoutArea.Areas.LowerSectionUpperTotal).BoundingRectangle),
                        Globals.sfRight);
                }
                for (int ls = 0; ls < 7; ls++)
                {
                    if (ColumnScore[g].ScoredLowerSection[ls])
                    {
                        LayoutArea la = AllHitAreas.First(ha => ha.Game == g && ha.Row == ls && ha.ScoringArea == LayoutArea.Areas.LowerSectionScoring);
                        e.Graphics.DrawString(ColumnScore[g].LowerSection[ls].ToString(), ScoreFont, Brushes.Red, la.BoundingRectangle, Globals.sfRight);
                    }
                }
                if (ColumnScore[g].LowerSectionIsFilled())
                {
                    e.Graphics.DrawString(ColumnScore[g].LowerScore.ToString(), ScoreFont, Brushes.Red, Rectangle.Round(AllHitAreas.First(ha => ha.Game == g && ha.ScoringArea == LayoutArea.Areas.LowerSectionTotal).BoundingRectangle), Globals.sfRight);
                }
                if (YahtzeeBonuses)
                {
                    if (ColumnScore[g].BonusYahtzees > 0)
                    {
                        r = AllHitAreas.First(aha => aha.ScoringArea == LayoutArea.Areas.YahtzeeBonuses).BoundingRectangle;
                        if (ColumnScore[g].BonusYahtzees < 4)
                        {
                            RectangleF FullRectangle = new RectangleF(r.Location, r.Size);
                            FullRectangle.Inflate(2, 2);
                            for (int i = 0; i < ColumnScore[g].BonusYahtzees; i++)
                            {
                                RectangleF ThirdRectangle = new RectangleF(FullRectangle.Left + i * FullRectangle.Width / 3, FullRectangle.Top, FullRectangle.Width / 3, FullRectangle.Height);
                                ThirdRectangle.Inflate(-2, -2);
                                e.Graphics.DrawString("X", ScoreFont, Brushes.Red, new RectangleF(r.Left + i * r.Width / 3, r.Top, r.Width / 3, r.Height), Globals.sfRight);
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString($"x{ColumnScore[g].BonusYahtzees.ToString()}", ScoreFont, Brushes.Red, r, Globals.sfRight);
                        }
                        r = AllHitAreas.First(aha => aha.ScoringArea == LayoutArea.Areas.YahtzeeBonusScore).BoundingRectangle;
                        e.Graphics.DrawString(ColumnScore[g].YahtzeeBonus.ToString(), ScoreFont, Brushes.Red, r, Globals.sfRight);
                    }
                }
                if (ColumnScore[g].GameIsCompleted())
                {
                    e.Graphics.DrawString(  ColumnScore[g].GrandTotal.ToString(), ScoreFont, Brushes.Red, Rectangle.Round(AllHitAreas.First(aha => aha.Game == g && aha.ScoringArea == LayoutArea.Areas.LowerSectionGrandTotal).BoundingRectangle), Globals.sfRight);
                    if (TripleYahtzee)
                    {
                        e.Graphics.DrawString(((g + 1) * ColumnScore[g].GrandTotal).ToString(), ScoreFont, Brushes.Red, Rectangle.Round(AllHitAreas.First(aha => aha.Game == g && aha.ScoringArea == LayoutArea.Areas.TripleYahtzeeGrandTotal).BoundingRectangle), Globals.sfRight);
                    }
                }
            }
            if (TripleYahtzee && ColumnScore.All(gs => gs.GameIsCompleted()))
            {
                e.Graphics.DrawString(GrandTotal().ToString(), ScoreFont, Brushes.Red, Rectangle.Round(AllHitAreas.First(aha => aha.ScoringArea == LayoutArea.Areas.TournamentTotal).BoundingRectangle), Globals.sfRight);
            }
            #endregion
        }

        #region "Mouse"
        private List<LayoutArea> AllHitAreas = new List<LayoutArea>();
        private LayoutArea LastHit = null;
        private bool MouseTrackingEnabled = true;
        private class LayoutArea
        {
            private LayoutArea()
            {
            }
            public  LayoutArea(Areas Area, RectangleF BoundingRectangle , int Game, int Row)
            {
                ScoringArea = Area;
                IsPlayerScoringArea = true;
                this.BoundingRectangle = BoundingRectangle;
                this.Game = Game;
                this.Row = Row;
            }
            public  LayoutArea(Areas Area, RectangleF BoundingRectangle , int Game)
            {
                ScoringArea = Area;
                IsPlayerScoringArea = false;
                this.BoundingRectangle = BoundingRectangle;
                this.Game = Game;
                this.Row = -1;
            }
            public enum Areas
            {
                UpperSectionScoring,
                UpperSectionTotalWithoutBonus,
                UpperSectionBonus,
                UpperSectionBonusTotal,
                LowerSectionScoring,
                YahtzeeBonuses,
                YahtzeeBonusScore,
                LowerSectionTotal,
                LowerSectionUpperTotal,
                LowerSectionGrandTotal,
                TripleYahtzeeGrandTotal,
                TournamentTotal
            }
            public Areas ScoringArea;
            public bool IsPlayerScoringArea ;
            public RectangleF BoundingRectangle;
            public int Game;
            public int Row;
            public LayoutArea Clone(RectangleF r, int Game)
            {
                LayoutArea NewLayoutArea = (LayoutArea)MemberwiseClone();
                NewLayoutArea.BoundingRectangle = r;
                NewLayoutArea.Game = Game;
                return NewLayoutArea;
            }
            public override string ToString()
            {
                return $"LayoutArea: ScoreArea={ScoringArea.ToString()}, IsPlayerScoringArea={IsPlayerScoringArea}, Game={Game}, Row={Row}, BoundingRectangle={BoundingRectangle.ToString()}";
            }
        }

        private void InvalidateLastHit()
        {
            RectangleF r = new RectangleF(1, LastHit.BoundingRectangle.Top, LinescoreColumnWidth - 2, LastHit.BoundingRectangle.Height);
            Invalidate(Rectangle.Round(LastHit.BoundingRectangle));
            Invalidate(Rectangle.Round(r));
        }
        private void Scorecard_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseTrackingEnabled)
            {
                LayoutArea NewHit = AllHitAreas.FirstOrDefault(a => a.IsPlayerScoringArea && a.BoundingRectangle.Contains(e.Location));
                // todo: It needs to also be available for scoring
                if (NewHit != null)
                {
                    if (NewHit.ScoringArea == LayoutArea.Areas.UpperSectionScoring)
                    {
                        if (ColumnScore[NewHit.Game].ScoredUpperSection[NewHit.Row])
                        {
                            NewHit = null;
                        }
                    }
                    else
                    {
                        if (ColumnScore[NewHit.Game].ScoredLowerSection[NewHit.Row])
                        {
                            NewHit = null;
                        }
                    }
                }
                if (NewHit != LastHit)
                {
                    if (LastHit != null)
                    {
                        InvalidateLastHit();
                    }
                    LastHit = NewHit;
                    if (LastHit != null)
                    {
                        InvalidateLastHit();
                        Cursor = Cursors.Cross;
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void Scorecard_MouseLeave(object sender, EventArgs e)
        {
            if (MouseTrackingEnabled && LastHit != null)
            {
                InvalidateLastHit();
                LastHit = null;
            }
            Cursor = Cursors.Default;
        }

        private void Scorecard_Click(object sender, EventArgs e)
        {
            if (LastHit != null)
            {
                    MouseTrackingEnabled = false;
                if (Records.Player(PlayerName).ConfirmPlay)
                {
                    string msg;
                    string RowName;
                    int PotentialScore;
                    if (LastHit.ScoringArea == LayoutArea.Areas.UpperSectionScoring)
                    {
                        RowName = Globals.UpperSectionNames[LastHit.Row];
                        PotentialScore = ColumnScore[LastHit.Game].CalculateUpperScore(LastHit.Row);
                    }
                    else
                    {
                        RowName = Globals.LowerSectionNames[LastHit.Row];
                        PotentialScore = ColumnScore[LastHit.Game].CalculateLowerScore((GameScore.LowerSectionLineItems)LastHit.Row);
                    }
                    string pts = (PotentialScore == 1) ? "point" : "points";
                    msg = $"Play {RowName}?\n\n{PotentialScore} {pts}";
                    // enhancement: Put the confirmation box to the right of the scoring area.
                    if (MessageBox.Show(this, msg, "Confirm play", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        MouseTrackingEnabled = true;
                        return;
                    }
                }
                if (LastHit.ScoringArea == LayoutArea.Areas.UpperSectionScoring)
                {
                    ColumnScore[LastHit.Game].AddUpperScore(LastHit.Row);
                    Invalidate(Rectangle.Round(LastHit.BoundingRectangle));
                    if (ColumnScore[LastHit.Game].UpperSectionIsFilled())
                    {
                        LayoutArea.Areas[] BonusAreas = new LayoutArea.Areas[] { LayoutArea.Areas.UpperSectionTotalWithoutBonus, LayoutArea.Areas.UpperSectionBonus, LayoutArea.Areas.UpperSectionBonusTotal, LayoutArea.Areas.LowerSectionUpperTotal };
                        foreach (LayoutArea BonusArea in AllHitAreas.Where(ha => ha.Game == LastHit.Game && BonusAreas.Contains(ha.ScoringArea)))
                        {
                            Invalidate(Rectangle.Round(BonusArea.BoundingRectangle));
                        }
                        if (ColumnScore[LastHit.Game].LowerSectionIsFilled())
                        {
                            BonusAreas = new LayoutArea.Areas[] { LayoutArea.Areas.LowerSectionGrandTotal };
                            foreach (LayoutArea BonusArea in AllHitAreas.Where(ha => ha.Game == LastHit.Game && BonusAreas.Contains(LastHit.ScoringArea)))
                            {
                                Invalidate(Rectangle.Round(BonusArea.BoundingRectangle));
                            }
                        }
                    }
                }
                else
                {
                    ColumnScore[LastHit.Game].AddLowerScore((GameScore.LowerSectionLineItems)LastHit.Row);
                    Invalidate(Rectangle.Round(LastHit.BoundingRectangle));
                    if (ColumnScore[LastHit.Game].LowerSectionIsFilled())
                    {
                        Invalidate(Rectangle.Round(AllHitAreas.First(aha => aha.Game == LastHit.Game && aha.ScoringArea == LayoutArea.Areas.LowerSectionTotal).BoundingRectangle));
                    }
                }
                Cursor = Cursors.Default;
                EndOfTurn?.Invoke(this, EventArgs.Empty);
                if (ColumnScore[LastHit.Game].GameIsCompleted())
                {
                    Invalidate(Rectangle.Round(AllHitAreas.First(aha => aha.Game == LastHit.Game && aha.ScoringArea == LayoutArea.Areas.LowerSectionGrandTotal).BoundingRectangle));
                    if (ColumnScore.All(gs => gs.GameIsCompleted()))
                    {
                        if (TripleYahtzee)
                        {
                            Invalidate(Rectangle.Round(AllHitAreas.First(aha => aha.ScoringArea == LayoutArea.Areas.TournamentTotal).BoundingRectangle));
                        }
                        ScorecardCompleted?.Invoke(this, EventArgs.Empty);
                    }
                }
                LastHit = null;
                    MouseTrackingEnabled = true;
            }
        }
        #endregion

        private void Scorecard_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled)
            {
                ForeColor = SystemColors.ControlText;
            }
            else
            {
                ForeColor = SystemColors.ControlDark;
            }
        }

        public override string ToString()
        {
            return $"Scorecard: PlayerName={PlayerName}";
        }
    }
}

#if false
https://th.bing.com/th/id/R.e96bf3d50529ec9549115d751ef12f30?rik=0pRhRrgPeDSmRg&riu=http%3a%2f%2ftemplatelab.com%2fwp-content%2fuploads%2f2017%2f08%2fYahtzee-Score-Sheets-11.jpg%3fw%3d320&ehk=RaAiDEgVtHCkMT%2bJIQC%2fjahUWVl0paKAF0iS4fNG6Qs%3d&risl=&pid=ImgRaw&r=0
21 rows standard
+2 rows for Yahtzee Bonus
+1 row for tourney
#endif
