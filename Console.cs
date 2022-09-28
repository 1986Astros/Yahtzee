using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class Console : Form
    {
        public Console()
        {
            InitializeComponent();
            Records.ReadRecords();
        }

        private List<Die> SelectedDice = new List<Die>();
        private int Rolls;
        private int CurrentPlayer;
        private Dictionary<Die, Die> SelectedDieList = new Dictionary<Die, Die>();
        private List<Scorecard> ScoreCards = new List<Scorecard>();

        private void Console_Load(object sender, EventArgs e)
        {
            Globals.Registry.AddFormKey(this);

            foreach (Die die in panelPlayingSurface.Controls.OfType<Die>())
            {
                Globals.Dice.Add(die);
            }
            foreach (Die die in panelSelectedDice.Controls.OfType<Die>().OrderBy(d => d.Top))
            {
                SelectedDice.Add(die);
            }
            ScoreCards.Add(scorecard1);
            switch (Globals.Variation)
            {
                case Globals.Variations.Original:
                    originalYahtzeeToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Globals.Variations.Bonus:
                    bonusYahtzeeToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Globals.Variations.Triple:
                    tripleYahtzeeToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                default:
                    break;
            }
            IEnumerable<string> LastPlayers = Globals.LastPlayers;
            scorecard1.EndOfTurn += Scorecard_EndOfTurn;
            scorecard1.ScorecardCompleted += Scorecard_GameCompleted;
            ScoreCards[0].PlayerName = LastPlayers.ElementAt(0);
            ScoreCards[0].Enabled = false;
            originalYahtzeeToolStripMenuItem.Checked = !ScoreCards[CurrentPlayer].YahtzeeBonuses && !ScoreCards[CurrentPlayer].TripleYahtzee;
            bonusYahtzeeToolStripMenuItem.Checked = ScoreCards[CurrentPlayer].YahtzeeBonuses;
            tripleYahtzeeToolStripMenuItem.Checked = ScoreCards[CurrentPlayer].TripleYahtzee;

            Globals.NamePlates.Add(playerControl1);
            playerControl1.PlayerName = LastPlayers.ElementAt(0);
            playerControl1.NewPlayer += PlayerControl_NewPlayer;
            playerControl1.ReplacePlayer += PlayerControl_ReplacePlayer;
            playerControl1.RemovePlayer += PlayerControl_RemovePlayer;
            playerControl1.ChangeTableColor += PlayerControl_ChangeTableColor;
            playerControl1.ChangeDieColor += PlayerControl_ChangeDieColor;

            for (int i = 1; i < LastPlayers.Count(); i++)
            {
                PlayerControl_NewPlayer(this, new PlayerControl.NewPlayerEventArgs(LastPlayers.ElementAt(i)));
            }
            tableLayoutPanelScorecards_Resize(this, EventArgs.Empty);

            UpdateHighScoresListView();
            SetColors();
            Initialized = true;
        }
        private bool Initialized = false;
        private void UpdateHighScoresListView()
        {
            listViewHighScores.Items.Clear();
            switch (Globals.Variation)
            {
                case Globals.Variations.Original:
                     listViewHighScores.Columns[0].Text = "Original";
                    break;
               case Globals.Variations.Bonus:
                     listViewHighScores.Columns[0].Text = "Bonus";
                    break;
                case Globals.Variations.Triple:
                     listViewHighScores.Columns[0].Text = "Triple";
                    break;
            }
            IEnumerable<Records.HighScoreInfo> HighScorers;
            float Average;
            Records.LoadHighScores(out HighScorers, out Average);
            List<string> PlayersAlreadyListedOnce = new List<string>();
            for (int i = 0; i < Math.Min(HighScorers.Count(), 10); i++)
            {
                ListViewItem lvi = new ListViewItem(HighScorers.ElementAt(i).Name) { UseItemStyleForSubItems = false } ;
                lvi.SubItems.Add(HighScorers.ElementAt(i).Score.ToString());
                lvi.SubItems.Add(HighScorers.ElementAt(i).When.ToShortDateString());
                if (!PlayersAlreadyListedOnce.Contains(HighScorers.ElementAt(i).Name))
                {
                    ListViewItem.ListViewSubItem lvis = lvi.SubItems.Add(Convert.ToDecimal(HighScorers.ElementAt(i).Average).ToString("N1") + " ");
                    lvis.Font = new Font(listViewHighScores.Font,  FontStyle.Italic);
                    lvis.ForeColor = Color.Gray;
                    PlayersAlreadyListedOnce.Add(HighScorers.ElementAt(i).Name);
                }
                else
                {
                    lvi.SubItems.Add("");
                }
                listViewHighScores.Items.Add(lvi);
            }
            labelLeagueAverage.Text = Math.Round((double)Average, 1).ToString();
            foreach (ColumnHeader ch in listViewHighScores.Columns)
            {
                ch.Width = -2;
            }
        }
        private void UpdateLeagueAverage()
        {
            labelLeagueAverage.Text = Records.LoadLeagueAverage().ToString();
        }

        private void Scorecard_EndOfTurn(object sender, EventArgs e)
        {
            buttonRoll.Enabled = true;
            foreach (Die die in Globals.Dice)
            {
                die.Visible = false;
                die.Selected = false;
            }
            foreach (Die die in SelectedDice)
            {
                die.Visible = false;
            }
            Rolls = 0;
            SelectedDieList.Clear();
            ScoreCards[CurrentPlayer].Enabled = false;
            if (ScoreCards.Count > 1)
            {
                // shift the scorecards so that current player is left-most and closest to the playing surface
                System.Threading.Thread.Sleep(1000);
                tableLayoutPanelScorecards.SuspendLayout();
                tableLayoutPanelScorecards.Controls.Remove(Globals.NamePlates[CurrentPlayer]);
                tableLayoutPanelScorecards.Controls.Remove(ScoreCards[CurrentPlayer]);
                for (int i = 1; i < ScoreCards.Count; i++)
                {
                    tableLayoutPanelScorecards.SetCellPosition(tableLayoutPanelScorecards.GetControlFromPosition(i, 0), new TableLayoutPanelCellPosition(i - 1, 0));
                    tableLayoutPanelScorecards.SetCellPosition(tableLayoutPanelScorecards.GetControlFromPosition(i, 1), new TableLayoutPanelCellPosition(i - 1, 1));
                }
                tableLayoutPanelScorecards.Controls.Add(Globals.NamePlates[CurrentPlayer], ScoreCards.Count - 1, 0);
                tableLayoutPanelScorecards.Controls.Add(ScoreCards[CurrentPlayer], ScoreCards.Count - 1, 1);
                tableLayoutPanelScorecards.ResumeLayout();
            }
            CurrentPlayer = ++CurrentPlayer % ScoreCards.Count;
            SetColors();
            ScoreCards[CurrentPlayer].Enabled = true;
            labelRoll.Text = "Throw the dice!";
        }

        private void SetColors()
        {
            Records.PlayerInfo pi = Records.Player(ScoreCards[CurrentPlayer].PlayerName);
            Color c;
            c = pi.PipColor;
            if (Globals.Dice[0].ForeColor.ToArgb() != c.ToArgb())
            {
                foreach (Die die in Globals.Dice)
                {
                    die.ForeColor = c;
                }
                foreach (Die die in SelectedDice)
                {
                    die.ForeColor = c;
                }
            }
            c = pi.DieColor;
            if (Globals.Dice[0].BackColor.ToArgb() != c.ToArgb())
            {
                foreach (Die die in Globals.Dice)
                {
                    die.BackColor = c;
                }
                foreach (Die die in SelectedDice)
                {
                    die.BackColor = c;
                }
            }
            c = pi.TableColor;
            if (panelPlayingSurface.BackColor.ToArgb() != c.ToArgb())
            {
                panelPlayingSurface.BackColor = c;
            }
        }

        private void Scorecard_GameCompleted(object sender, EventArgs e)
        {
            Scorecard sc = (Scorecard)sender;
            if (sc == ScoreCards.Last())
            {
                buttonRoll.Enabled = false;
                labelRoll.Text = "Game over. Click \"Start game\" to being the next game.";
                startGameToolStripMenuItem.Enabled = true;
                gameSettingsToolStripMenuItem.Enabled = true;
                specifyDiceToolStripMenuItem.Enabled = false;
                foreach (PlayerControl np in Globals.NamePlates)
                {
                    np.Enabled = true;
                    np.GameOver();
                }
            }

            if (Records.AddGamePlayed(Records.Player(sc.PlayerName).ID, sc.GrandTotal()))
            {
                UpdateHighScoresListView();
                // enhancement: list of top 10 scores for each player,in different tabs alongside the High Scores tab
            }
            else
            {
                UpdateLeagueAverage();
            }
            Records.WriteRecords();

            // enhancement: make a hand-drawn-looking ellipse around the winning score would be cool
            // enhancement: highlight the winning score, or shuffle the cards to winner first, and so on
        }

        private void roll_Click(object sender, EventArgs e)
        {
            if (Rolls == 0)
            {
                foreach (Die die in Globals.Dice)
                {
                    die.Visible = true;
                }
                ScoreCards[CurrentPlayer].Enabled = true;
            }
            // move the dice around into random positions
            int DieWidth = Globals.Dice[0].Width;
            int DieHeight = Globals.Dice[0].Height;
            int WidthRange = panelPlayingSurface.Width - 2 - DieWidth;
            int HeightRange = panelPlayingSurface.Height - 2 - DieHeight;
            List<Rectangle> RectanglesSoFar = new List<Rectangle>() { new Rectangle(Globals.rnd.Next(2, WidthRange), Globals.rnd.Next(2, HeightRange), DieWidth, DieHeight) };
            Rectangle Candidate;
            for (int i = 1; i < 5; i++)
            {
                do
                {
                    Candidate = new Rectangle(Globals.rnd.Next(2, WidthRange), Globals.rnd.Next(2, HeightRange), DieWidth, DieHeight);
                    // BUG: This is potentially an endless loop or at least one that feels endless if the scoring area is smaller
                } while (RectanglesSoFar.Any(d => d.IntersectsWith(Candidate)));
                RectanglesSoFar.Add(Candidate);
            }
            for (int i = 0;i < 5; i++)
            {
                Globals.Dice[i].Location = RectanglesSoFar[i].Location;
            }
            // set the die values
            foreach (Die die in Globals.Dice.Where(d => d.Visible))
            {
                die.Roll();
            }
            switch (++Rolls)
            {
                case 1:
                    labelRoll.Text = "1 roll. Take score or throw your second roll.";
                    break;
                case 2:
                    labelRoll.Text = "2 rolls. Take score or throw a last row.";
                    break;
                case 3:
                    labelRoll.Text = "Take your score.";
                    buttonRoll.Enabled = false;
                    break;
            }
        }

        private void die_ClickDie(object sender, EventArgs e)
        {
            Die ClickedDie = (Die)sender;
            if (SelectedDice.Contains(ClickedDie))
            {
                Die OriginalDie = SelectedDieList[ClickedDie];
                SelectedDieList.Remove(ClickedDie);
                OriginalDie.Visible = true;
                ClickedDie.Visible = false;
                buttonRoll.Enabled = true;
            }
            else
            {
                int NextDiePosition = Enumerable.Range(0, 5).First(i => !SelectedDice[i].Visible);
                SelectedDice[NextDiePosition].Value = ClickedDie.Value;
                SelectedDice[NextDiePosition].Visible = true;
                ClickedDie.Visible = false;
                ClickedDie.Selected = true;
                SelectedDieList.Add(SelectedDice[NextDiePosition], ClickedDie);
                if (SelectedDice.Count(d => d.Visible) == 5)
                {
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonRoll.Enabled = true;
            labelRoll.Text = "Throw the dice!";
            startGameToolStripMenuItem.Enabled = false;
            gameSettingsToolStripMenuItem.Enabled = false;
            specifyDiceToolStripMenuItem.Enabled = true;
            CurrentPlayer = 0;
            ScoreCards[CurrentPlayer].Enabled = true;
            SetColors();
            foreach (Scorecard sc in ScoreCards)
            {
                sc.InitializeGameScores();
            }
            foreach (PlayerControl np in Globals.NamePlates)
            {
                np.StartGame();
            }
        }

        #region "game variation"
        private void originalYahtzeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Scorecard sc in ScoreCards)
            {
                sc.TripleYahtzee = false;
                sc.YahtzeeBonuses = false;
            }
            bonusYahtzeeToolStripMenuItem.Checked = false;
            tripleYahtzeeToolStripMenuItem.Checked = false;
            Globals.Variation = Globals.Variations.Original;
            UpdateHighScoresListView();
            Globals.LastVariation = Globals.Variations.Original;
        }

        private void bonusYahtzeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Scorecard sc in ScoreCards)
            {
                sc.YahtzeeBonuses = true;
            }
            originalYahtzeeToolStripMenuItem.Checked = false;
            tripleYahtzeeToolStripMenuItem.Checked = false;
            Globals.Variation = Globals.Variations.Bonus;
            UpdateHighScoresListView();
            Globals.LastVariation = Globals.Variations.Bonus;
        }

        private void tripleYahtzeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Scorecard sc in ScoreCards)
            {
                sc.TripleYahtzee = true;
            }
            originalYahtzeeToolStripMenuItem.Checked = false;
            bonusYahtzeeToolStripMenuItem.Checked = false;
            Globals.Variation = Globals.Variations.Triple;
            UpdateHighScoresListView();
            Globals.LastVariation = Globals.Variations.Triple;
        }
        #endregion

        private void tableLayoutPanelScorecards_Resize(object sender, EventArgs e)
        {
            panelScorecardOuter.Size = new Size(panelScorecardOuter.Width, tableLayoutPanelScorecards.Margin.Vertical + panelScorecardInner.Margin.Vertical + 2 + tableLayoutPanelScorecards.Height + SystemInformation.HorizontalScrollBarHeight);
        }

        private void PlayerControl_NewPlayer(object sender, PlayerControl.NewPlayerEventArgs e)
        {
            PlayerControl pc = new PlayerControl() { PlayerName = e.PlayerName, Dock = DockStyle.Fill , Margin = Globals.NamePlates[0].Margin};
            Scorecard sc = new Scorecard() { PlayerName  = e.PlayerName , YahtzeeBonuses = ScoreCards[0].YahtzeeBonuses, TripleYahtzee = ScoreCards[0].TripleYahtzee, Dock = DockStyle.Fill,Enabled = false, Margin = ScoreCards[0].Margin };
            sc.EndOfTurn += Scorecard_EndOfTurn;
            sc.ScorecardCompleted += Scorecard_GameCompleted;
            ScoreCards.Add(sc);
            pc.NewPlayer += PlayerControl_NewPlayer;
            pc.ReplacePlayer += PlayerControl_ReplacePlayer;
            pc.RemovePlayer += PlayerControl_RemovePlayer;
            Globals.NamePlates.Add(pc);
            tableLayoutPanelScorecards.ColumnCount++;
            tableLayoutPanelScorecards.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanelScorecards.Controls.Add(pc, Globals.NamePlates.Count - 1, 0);
            tableLayoutPanelScorecards.Controls.Add(sc, Globals.NamePlates.Count - 1, 1);
            if (Initialized)
            {
                Globals.LastPlayers = Globals.NamePlates.Select(np => np.PlayerName).ToArray();
                SetColors();
            }
        }

        private void PlayerControl_ReplacePlayer(object sender, PlayerControl.ReplacePlayerEventArgs e)
        {
            Scorecard sc = ScoreCards.First(s => s.PlayerName.Equals(e.PreviousPlayerName, StringComparison.CurrentCultureIgnoreCase));
            sc.PlayerName = e.ReplacingPlayerName;
            sc.InitializeGameScores();
            if (Initialized)
            {
                Globals.LastPlayers = Globals.NamePlates.Select(np => np.PlayerName).ToArray();
                SetColors();
            }
        }

        private void PlayerControl_RemovePlayer(object sender, EventArgs e)
        {
            PlayerControl pc = (PlayerControl)sender;
            Scorecard sc = ScoreCards.First(scs => scs.PlayerName.Equals(pc.PlayerName, StringComparison.CurrentCultureIgnoreCase));
            int col = tableLayoutPanelScorecards.GetColumn(pc);
            bool ControlIsInThere = tableLayoutPanelScorecards.Controls.Contains(sc);
            tableLayoutPanelScorecards.Controls.Remove(sc);
            tableLayoutPanelScorecards.Controls.Remove(pc);
            foreach (Control c in tableLayoutPanelScorecards.Controls)
            {
                if (tableLayoutPanelScorecards.GetColumn(c) > col)
                {
                    tableLayoutPanelScorecards.SetColumn(c, tableLayoutPanelScorecards.GetColumn(c) - 1);
                }
            }
            tableLayoutPanelScorecards.ColumnStyles.RemoveAt(--tableLayoutPanelScorecards.ColumnCount);
            ScoreCards.Remove(sc);
            Globals.NamePlates.Remove(pc);
            if (Initialized)
            {
                Globals.LastPlayers = Globals.NamePlates.Select(np => np.PlayerName).ToArray();
                SetColors();
            }
        }

        private void PlayerControl_ChangeTableColor(object sender, PlayerControl.ChangedColorsEventArgs e)
        {
            if (e.PlayerName.Equals(ScoreCards[CurrentPlayer].PlayerName))
            {
                SetColors();
                panelPlayingSurface.Invalidate();
            }
        }

        private void PlayerControl_ChangeDieColor(object sender, PlayerControl.ChangedColorsEventArgs e)
        {
            if (e.PlayerName.Equals(ScoreCards[CurrentPlayer].PlayerName))
            {
                SetColors();
                panelPlayingSurface.Invalidate();
            }
        }

        #region "programmer"
                private void specifyDiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecifyDice sd = new SpecifyDice();
            if (sd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < 5; i++)
                {
                    Globals.Dice[i].DebugRoll(sd.Dice[i]);
                }
            }
        }

        private Debug.SaveDieAsImage sdai = null;
        private void saveDieAsPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sdai == null)
            {
                sdai = new Debug.SaveDieAsImage();
            }
            sdai.ShowDialog();
        }
        #endregion
    }
}
