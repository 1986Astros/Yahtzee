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

namespace Yahtzee
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public string PlayerName
        {
            get
            {
                return shhPlayerName;
            }
            set
            {
                if (!value.Equals(shhPlayerName, StringComparison.CurrentCultureIgnoreCase))
                {
                    shhPlayerName = value;
                    playerToolStripDropDownButton.Text = shhPlayerName;
                    if (PlayerName.Length > 0)
                    {
                        Records.PlayerInfo pi = Records.Player(shhPlayerName);
                        panelSample.BackColor = pi.TableColor;
                        dieSample.ForeColor = pi.PipColor;
                        dieSample.BackColor = pi.DieColor;
                    }
                }
            }
        }
        private string shhPlayerName = "";

        private bool GameUnderway = false;

        #region "events"
        public class NewPlayerEventArgs : EventArgs
        {
            public NewPlayerEventArgs(string PlayerName)
            {
                this.PlayerName = PlayerName;
            }
            public string PlayerName;
        }
        public delegate void NewPlayerEventHandler(object sender, NewPlayerEventArgs e);
        public event NewPlayerEventHandler NewPlayer;
        public class ReplacePlayerEventArgs : EventArgs
        {
            public ReplacePlayerEventArgs(string PreviousPlayer, string ReplacementPlayer) : base()
            {
                PreviousPlayerName = PreviousPlayer;
                ReplacingPlayerName = ReplacementPlayer;
            }
            public string PreviousPlayerName;
            public string ReplacingPlayerName;
        }
        public delegate void ReplacePlayerEventHandler(object sender, ReplacePlayerEventArgs e);
        public event ReplacePlayerEventHandler ReplacePlayer;
        public delegate void RemovePlayerEventHandler(object sender, EventArgs e);
        public event RemovePlayerEventHandler RemovePlayer;
        public class ChangedColorsEventArgs : EventArgs
        {
            public ChangedColorsEventArgs(string PlayerName, Color NewColor):base()
            {
                this.PlayerName = PlayerName;
                this.NewColor = NewColor;
            }
            public ChangedColorsEventArgs(string PlayerName, Color DieColor, Color PipColor):base()
            {
                this.PlayerName = PlayerName;
                this.NewColor = PipColor;
                this.BackColor = DieColor;
            }
            public string PlayerName;
            public Color NewColor;
            public  Color ForeColor
            {
                get
                {
                    return NewColor;
                }
            }
            public Color BackColor;
        }
        public delegate void ChangedTableColor(object sender, ChangedColorsEventArgs e);
        public event ChangedTableColor ChangeTableColor;
        public delegate void ChangedDieColor(object sender, ChangedColorsEventArgs e);
        public event ChangedDieColor ChangeDieColor;
        #endregion

        private List<ToolStripMenuItem> PlayerMenuItems = new List<ToolStripMenuItem>();

        private void PlayerControl_Load(object sender, EventArgs e)
        {

        }

        public void StartGame()
        {
            playerToolStripDropDownButton.Enabled = false;
            addOpponentToolStripMenuItem.Enabled = false;
            removeFromGameToolStripMenuItem.Enabled = false;
            GameUnderway = true;
        }
        public void GameOver()
        {
            playerToolStripDropDownButton.Enabled = true;
            addOpponentToolStripMenuItem.Enabled = true;
            removeFromGameToolStripMenuItem.Enabled = Globals.NamePlates.Count > 1;
            GameUnderway = false;
        }

        #region "Player menu"
        private void playerToolStripDropDownButton_DropDownOpening(object sender, EventArgs e)
        {
            if (PlayerMenuItems.Count != 0)
            {
                foreach (ToolStripMenuItem _tsmi in PlayerMenuItems)
                {
                    playerToolStripDropDownButton.DropDownItems.Remove(_tsmi);
                }
                PlayerMenuItems.Clear();
            }

            ToolStripMenuItem tsmi;
            playerToolStripDropDownButton.Text = PlayerName;
            foreach (Records.PlayerInfo pi in Records.Players)
            {
                tsmi = new ToolStripMenuItem(pi.PlayerName, null, humanPlayerToolStripMenuItem_Click)
                {
                    Checked = pi.PlayerName == PlayerName,
                    Enabled = !Globals.NamePlates.Any(np => np.PlayerName.Equals(pi.PlayerName, StringComparison.CurrentCultureIgnoreCase))
                };
                PlayerMenuItems.Add(tsmi);
            }
            playerToolStripDropDownButton.DropDownItems.AddRange(PlayerMenuItems.ToArray());
        }

        #region "New player name"
        private void newPlayerToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Records.Players.Any(pi => pi.PlayerName.Equals(newPlayerToolStripTextBox.Text, StringComparison.CurrentCultureIgnoreCase)))
            {
                newPlayerToolStripTextBox.BackColor = Color.MistyRose;
                newPlayerLabelToolStripMenuItem.Text = "Player exists.";
                newPlayerLabelToolStripMenuItem.Enabled = false;
            }
            else if (newToolStripMenuItem.Text.Trim().Length == 0)
            {
                newPlayerToolStripTextBox.BackColor = Color.MistyRose;
                newPlayerLabelToolStripMenuItem.Text = "New player name:";
                newPlayerLabelToolStripMenuItem.Enabled = false;
            }
            else
            {
                newPlayerToolStripTextBox.BackColor = Color.LightGreen;
                newPlayerLabelToolStripMenuItem.Text = "Click or press Enter to add player.";
                newPlayerLabelToolStripMenuItem.Enabled = true;
            }
        }

        private void newPlayerToolStripTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && newPlayerLabelToolStripMenuItem.Enabled)
            {
                e.Handled = true;
                AddNewPlayer();
            }
        }

        private void newPlayerLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewPlayer();
        }

        private void AddNewPlayer()
        {
            Records.PlayerInfo pi = Records.AddPlayer(newPlayerToolStripTextBox.Text);
            ToolStripMenuItem tsmi = new ToolStripMenuItem(newPlayerToolStripTextBox.Text, null, humanPlayerToolStripMenuItem_Click) { Checked = true, Enabled = false };
            playerToolStripDropDownButton.DropDownItems.Add(tsmi);

            newPlayerToolStripTextBox.Text = "";
            newPlayerToolStripTextBox.BackColor = Color.MistyRose;
            newToolStripMenuItem.HideDropDown();

            NewPlayer?.Invoke(this, new NewPlayerEventArgs(pi.PlayerName));
            Records.WriteRecords();
        }
        #endregion

        private void computerPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // enhancement: Add computer players
        }

        private void humanPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string PreviousPlayerName = playerToolStripDropDownButton.Text;
            ToolStripMenuItem tsmi = PlayerMenuItems.First(pmi => pmi.Text == playerToolStripDropDownButton.Text);
            tsmi.Checked = false;
            tsmi.Enabled = true;
            tsmi = (ToolStripMenuItem)sender;
            PlayerName = tsmi.Text;
            playerToolStripDropDownButton.Text = PlayerName;
            tsmi.Enabled = false;
            tsmi.Checked = true;
            ReplacePlayer?.Invoke(this, new ReplacePlayerEventArgs (PreviousPlayerName,PlayerName));
        }
        #endregion

        #region "Settings menu"
        private void settingsToolStripDropDownButton_DropDownOpening(object sender, EventArgs e)
        {
            removeFromGameToolStripMenuItem.Enabled = Globals.NamePlates.Count() > 1;
            confirmScoreToolStripMenuItem.Checked = Records.Player(PlayerName).ConfirmPlay;

            addOpponentToolStripMenuItem.DropDownItems.Clear();
            foreach (Records.PlayerInfo pi in Records.Players.Where(pi => !Globals.NamePlates.Any(np => np.PlayerName.Equals(pi.PlayerName, StringComparison.CurrentCultureIgnoreCase))))
            {
                addOpponentToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(pi.PlayerName, null, addOpponent_Click));
            }
            addOpponentToolStripMenuItem.Enabled = !GameUnderway && addOpponentToolStripMenuItem.DropDownItems.Count > 0;
            confirmScoreToolStripMenuItem.Checked = Records.Player(PlayerName).ConfirmPlay;
            // enhancement:
            // * if this player hasn't played a turn, should be able to remove it
            // * if anyone hasn't started the second turn, you should be able to add opponents
        }

        private void addOpponent_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            NewPlayer?.Invoke(this, new NewPlayerEventArgs(tsmi.Text));
        }

        private void tableColorToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem tsmi in tableColorToolStripMenuItem.DropDownItems)
            {
                tsmi.Checked = tsmi.BackColor.ToArgb() == Records.Player(PlayerName).TableColor.ToArgb();
                tsmi.Enabled = tsmi.BackColor.ToArgb() != Records.Player(PlayerName).DieColor.ToArgb();
            }
        }

        private void tableColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            if (Records.Player(PlayerName).TableColor.ToArgb() != tsmi.BackColor.ToArgb())
            {
                Records.Player(PlayerName).TableColor = tsmi.BackColor;

                ChangeTableColor?.Invoke(this, new ChangedColorsEventArgs(PlayerName, tsmi.BackColor));

                panelSample.BackColor = tsmi.BackColor;

                Records.WriteRecords();
            }
        }

        private void dieColorToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem tsmi in dieColorToolStripMenuItem.DropDownItems)
            {
                tsmi.Checked = tsmi.BackColor.ToArgb() == Records.Player(PlayerName).DieColor.ToArgb();
                tsmi.Enabled = tsmi.BackColor.ToArgb() != Records.Player(PlayerName).TableColor.ToArgb();
            }
        }

        private void dieColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            if (Records.Player(PlayerName).TableColor.ToArgb() != tsmi.BackColor.ToArgb())
            {
                Records.Player(PlayerName).DieColor = tsmi.BackColor;
                Records.Player(PlayerName).PipColor = tsmi.ForeColor;

                // notify the Console
                ChangeDieColor?.Invoke(this, new ChangedColorsEventArgs(PlayerName, tsmi.BackColor, tsmi.ForeColor));

                // notify the sample die
                dieSample.ForeColor = tsmi.ForeColor;
                dieSample.BackColor = tsmi.BackColor;
                Records.WriteRecords();
            }
        }

        private void confirmScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Records.Player(PlayerName).ConfirmPlay = !Records.Player(PlayerName).ConfirmPlay;
            Records.WriteRecords();
        }

        private void removeFromGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemovePlayer?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        public override string ToString()
        {
            return $"PlayerControl PlayerName = {PlayerName}";
        }
    }
}
