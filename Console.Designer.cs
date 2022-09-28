namespace Yahtzee
{
    partial class Console
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Console));
            this.buttonRoll = new System.Windows.Forms.Button();
            this.panelPlayingSurface = new System.Windows.Forms.Panel();
            this.panelSelectedDice = new System.Windows.Forms.Panel();
            this.labelRoll = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originalYahtzeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bonusYahtzeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tripleYahtzeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programmerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specifyDiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDieAsPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewHighScores = new System.Windows.Forms.ListView();
            this.columnHeaderPlayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRecordScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRecordDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAverage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHighScoresRight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.labelLeagueAverage = new System.Windows.Forms.Label();
            this.tableLayoutPanelLeagueLeaders = new System.Windows.Forms.TableLayoutPanel();
            this.panelScorecardOuter = new System.Windows.Forms.Panel();
            this.panelScorecardInner = new System.Windows.Forms.Panel();
            this.tableLayoutPanelScorecards = new System.Windows.Forms.TableLayoutPanel();
            this.playerControl1 = new Yahtzee.PlayerControl();
            this.scorecard1 = new Yahtzee.Scorecard();
            this.die6 = new Yahtzee.Die();
            this.die10 = new Yahtzee.Die();
            this.die7 = new Yahtzee.Die();
            this.die9 = new Yahtzee.Die();
            this.die8 = new Yahtzee.Die();
            this.die5 = new Yahtzee.Die();
            this.die4 = new Yahtzee.Die();
            this.die3 = new Yahtzee.Die();
            this.die2 = new Yahtzee.Die();
            this.die1 = new Yahtzee.Die();
            this.panelPlayingSurface.SuspendLayout();
            this.panelSelectedDice.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanelLeagueLeaders.SuspendLayout();
            this.panelScorecardOuter.SuspendLayout();
            this.panelScorecardInner.SuspendLayout();
            this.tableLayoutPanelScorecards.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRoll
            // 
            this.buttonRoll.AutoSize = true;
            this.buttonRoll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRoll.Enabled = false;
            this.buttonRoll.Location = new System.Drawing.Point(12, 40);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(35, 23);
            this.buttonRoll.TabIndex = 0;
            this.buttonRoll.Text = "&Roll";
            this.buttonRoll.UseVisualStyleBackColor = true;
            this.buttonRoll.Click += new System.EventHandler(this.roll_Click);
            // 
            // panelPlayingSurface
            // 
            this.panelPlayingSurface.BackColor = System.Drawing.Color.ForestGreen;
            this.panelPlayingSurface.Controls.Add(this.die5);
            this.panelPlayingSurface.Controls.Add(this.die4);
            this.panelPlayingSurface.Controls.Add(this.die3);
            this.panelPlayingSurface.Controls.Add(this.die2);
            this.panelPlayingSurface.Controls.Add(this.die1);
            this.panelPlayingSurface.Location = new System.Drawing.Point(12, 69);
            this.panelPlayingSurface.Name = "panelPlayingSurface";
            this.panelPlayingSurface.Size = new System.Drawing.Size(316, 188);
            this.panelPlayingSurface.TabIndex = 1;
            // 
            // panelSelectedDice
            // 
            this.panelSelectedDice.Controls.Add(this.die6);
            this.panelSelectedDice.Controls.Add(this.die10);
            this.panelSelectedDice.Controls.Add(this.die7);
            this.panelSelectedDice.Controls.Add(this.die9);
            this.panelSelectedDice.Controls.Add(this.die8);
            this.panelSelectedDice.Location = new System.Drawing.Point(335, 72);
            this.panelSelectedDice.Name = "panelSelectedDice";
            this.panelSelectedDice.Size = new System.Drawing.Size(34, 182);
            this.panelSelectedDice.TabIndex = 7;
            // 
            // labelRoll
            // 
            this.labelRoll.AutoSize = true;
            this.labelRoll.Location = new System.Drawing.Point(55, 45);
            this.labelRoll.Name = "labelRoll";
            this.labelRoll.Size = new System.Drawing.Size(168, 13);
            this.labelRoll.TabIndex = 9;
            this.labelRoll.Text = "Click \"Start game\" to start playing.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startGameToolStripMenuItem,
            this.gameSettingsToolStripMenuItem,
            this.programmerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1172, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startGameToolStripMenuItem
            // 
            this.startGameToolStripMenuItem.Name = "startGameToolStripMenuItem";
            this.startGameToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.startGameToolStripMenuItem.Text = "Start game";
            this.startGameToolStripMenuItem.Click += new System.EventHandler(this.startGameToolStripMenuItem_Click);
            // 
            // gameSettingsToolStripMenuItem
            // 
            this.gameSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.originalYahtzeeToolStripMenuItem,
            this.bonusYahtzeeToolStripMenuItem,
            this.tripleYahtzeeToolStripMenuItem});
            this.gameSettingsToolStripMenuItem.Name = "gameSettingsToolStripMenuItem";
            this.gameSettingsToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.gameSettingsToolStripMenuItem.Text = "Game settings";
            // 
            // originalYahtzeeToolStripMenuItem
            // 
            this.originalYahtzeeToolStripMenuItem.Checked = true;
            this.originalYahtzeeToolStripMenuItem.CheckOnClick = true;
            this.originalYahtzeeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.originalYahtzeeToolStripMenuItem.Name = "originalYahtzeeToolStripMenuItem";
            this.originalYahtzeeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.originalYahtzeeToolStripMenuItem.Text = "Original Yahtzee";
            this.originalYahtzeeToolStripMenuItem.Click += new System.EventHandler(this.originalYahtzeeToolStripMenuItem_Click);
            // 
            // bonusYahtzeeToolStripMenuItem
            // 
            this.bonusYahtzeeToolStripMenuItem.CheckOnClick = true;
            this.bonusYahtzeeToolStripMenuItem.Name = "bonusYahtzeeToolStripMenuItem";
            this.bonusYahtzeeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.bonusYahtzeeToolStripMenuItem.Text = "Bonus Yahtzee";
            this.bonusYahtzeeToolStripMenuItem.Click += new System.EventHandler(this.bonusYahtzeeToolStripMenuItem_Click);
            // 
            // tripleYahtzeeToolStripMenuItem
            // 
            this.tripleYahtzeeToolStripMenuItem.CheckOnClick = true;
            this.tripleYahtzeeToolStripMenuItem.Name = "tripleYahtzeeToolStripMenuItem";
            this.tripleYahtzeeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.tripleYahtzeeToolStripMenuItem.Text = "Triple Yahtzee";
            this.tripleYahtzeeToolStripMenuItem.Click += new System.EventHandler(this.tripleYahtzeeToolStripMenuItem_Click);
            // 
            // programmerToolStripMenuItem
            // 
            this.programmerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.specifyDiceToolStripMenuItem,
            this.saveDieAsPNGToolStripMenuItem});
            this.programmerToolStripMenuItem.Name = "programmerToolStripMenuItem";
            this.programmerToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.programmerToolStripMenuItem.Text = "Programmer";
            // 
            // specifyDiceToolStripMenuItem
            // 
            this.specifyDiceToolStripMenuItem.Enabled = false;
            this.specifyDiceToolStripMenuItem.Name = "specifyDiceToolStripMenuItem";
            this.specifyDiceToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.specifyDiceToolStripMenuItem.Text = "Specify dice";
            this.specifyDiceToolStripMenuItem.Click += new System.EventHandler(this.specifyDiceToolStripMenuItem_Click);
            // 
            // saveDieAsPNGToolStripMenuItem
            // 
            this.saveDieAsPNGToolStripMenuItem.Name = "saveDieAsPNGToolStripMenuItem";
            this.saveDieAsPNGToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.saveDieAsPNGToolStripMenuItem.Text = "Save die as PNG";
            this.saveDieAsPNGToolStripMenuItem.Click += new System.EventHandler(this.saveDieAsPNGToolStripMenuItem_Click);
            // 
            // listViewHighScores
            // 
            this.listViewHighScores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPlayerName,
            this.columnHeaderRecordScore,
            this.columnHeaderRecordDate,
            this.columnHeaderAverage,
            this.columnHeaderHighScoresRight});
            this.listViewHighScores.FullRowSelect = true;
            this.listViewHighScores.GridLines = true;
            this.listViewHighScores.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewHighScores.HideSelection = false;
            this.listViewHighScores.Location = new System.Drawing.Point(12, 263);
            this.listViewHighScores.MultiSelect = false;
            this.listViewHighScores.Name = "listViewHighScores";
            this.listViewHighScores.Size = new System.Drawing.Size(256, 222);
            this.listViewHighScores.TabIndex = 12;
            this.listViewHighScores.UseCompatibleStateImageBehavior = false;
            this.listViewHighScores.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderPlayerName
            // 
            this.columnHeaderPlayerName.Text = "Player";
            this.columnHeaderPlayerName.Width = 41;
            // 
            // columnHeaderRecordScore
            // 
            this.columnHeaderRecordScore.Text = "Score";
            this.columnHeaderRecordScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderRecordScore.Width = 40;
            // 
            // columnHeaderRecordDate
            // 
            this.columnHeaderRecordDate.Text = "Date";
            this.columnHeaderRecordDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderRecordDate.Width = 35;
            // 
            // columnHeaderAverage
            // 
            this.columnHeaderAverage.Text = "Average";
            this.columnHeaderAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderAverage.Width = 52;
            // 
            // columnHeaderHighScoresRight
            // 
            this.columnHeaderHighScoresRight.Text = "";
            this.columnHeaderHighScoresRight.Width = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "League average";
            // 
            // labelLeagueAverage
            // 
            this.labelLeagueAverage.AutoSize = true;
            this.labelLeagueAverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLeagueAverage.Location = new System.Drawing.Point(3, 13);
            this.labelLeagueAverage.Name = "labelLeagueAverage";
            this.labelLeagueAverage.Size = new System.Drawing.Size(85, 13);
            this.labelLeagueAverage.TabIndex = 14;
            this.labelLeagueAverage.Text = "000";
            this.labelLeagueAverage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanelLeagueLeaders
            // 
            this.tableLayoutPanelLeagueLeaders.AutoSize = true;
            this.tableLayoutPanelLeagueLeaders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelLeagueLeaders.ColumnCount = 1;
            this.tableLayoutPanelLeagueLeaders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelLeagueLeaders.Controls.Add(this.labelLeagueAverage, 0, 1);
            this.tableLayoutPanelLeagueLeaders.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelLeagueLeaders.Location = new System.Drawing.Point(274, 263);
            this.tableLayoutPanelLeagueLeaders.Name = "tableLayoutPanelLeagueLeaders";
            this.tableLayoutPanelLeagueLeaders.RowCount = 2;
            this.tableLayoutPanelLeagueLeaders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLeagueLeaders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLeagueLeaders.Size = new System.Drawing.Size(91, 26);
            this.tableLayoutPanelLeagueLeaders.TabIndex = 15;
            // 
            // panelScorecardOuter
            // 
            this.panelScorecardOuter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelScorecardOuter.AutoScroll = true;
            this.panelScorecardOuter.Controls.Add(this.panelScorecardInner);
            this.panelScorecardOuter.Location = new System.Drawing.Point(375, 12);
            this.panelScorecardOuter.Name = "panelScorecardOuter";
            this.panelScorecardOuter.Size = new System.Drawing.Size(785, 495);
            this.panelScorecardOuter.TabIndex = 17;
            // 
            // panelScorecardInner
            // 
            this.panelScorecardInner.AutoSize = true;
            this.panelScorecardInner.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelScorecardInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelScorecardInner.Controls.Add(this.tableLayoutPanelScorecards);
            this.panelScorecardInner.Location = new System.Drawing.Point(3, 3);
            this.panelScorecardInner.Name = "panelScorecardInner";
            this.panelScorecardInner.Size = new System.Drawing.Size(325, 443);
            this.panelScorecardInner.TabIndex = 0;
            // 
            // tableLayoutPanelScorecards
            // 
            this.tableLayoutPanelScorecards.AutoSize = true;
            this.tableLayoutPanelScorecards.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelScorecards.ColumnCount = 1;
            this.tableLayoutPanelScorecards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelScorecards.Controls.Add(this.playerControl1, 0, 0);
            this.tableLayoutPanelScorecards.Controls.Add(this.scorecard1, 0, 1);
            this.tableLayoutPanelScorecards.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelScorecards.Name = "tableLayoutPanelScorecards";
            this.tableLayoutPanelScorecards.RowCount = 2;
            this.tableLayoutPanelScorecards.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScorecards.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScorecards.Size = new System.Drawing.Size(316, 434);
            this.tableLayoutPanelScorecards.TabIndex = 0;
            this.tableLayoutPanelScorecards.Resize += new System.EventHandler(this.tableLayoutPanelScorecards_Resize);
            // 
            // playerControl1
            // 
            this.playerControl1.AutoSize = true;
            this.playerControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerControl1.Location = new System.Drawing.Point(0, 0);
            this.playerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.playerControl1.Name = "playerControl1";
            this.playerControl1.PlayerName = "";
            this.playerControl1.Size = new System.Drawing.Size(316, 26);
            this.playerControl1.TabIndex = 0;
            // 
            // scorecard1
            // 
            this.scorecard1.AutoSize = true;
            this.scorecard1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.scorecard1.Location = new System.Drawing.Point(0, 26);
            this.scorecard1.Margin = new System.Windows.Forms.Padding(0);
            this.scorecard1.Name = "scorecard1";
            this.scorecard1.Size = new System.Drawing.Size(316, 408);
            this.scorecard1.TabIndex = 1;
            // 
            // die6
            // 
            this.die6.Angle = 0F;
            this.die6.BackColor = System.Drawing.Color.Red;
            this.die6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.die6.ForeColor = System.Drawing.Color.White;
            this.die6.Location = new System.Drawing.Point(2, 3);
            this.die6.Name = "die6";
            this.die6.Selected = false;
            this.die6.Size = new System.Drawing.Size(30, 30);
            this.die6.TabIndex = 2;
            this.die6.Value = 1;
            this.die6.Visible = false;
            this.die6.ClickDie += new Yahtzee.Die.DieClickEventHandler(this.die_ClickDie);
            // 
            // die10
            // 
            this.die10.Angle = 0F;
            this.die10.BackColor = System.Drawing.Color.Red;
            this.die10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.die10.ForeColor = System.Drawing.Color.White;
            this.die10.Location = new System.Drawing.Point(2, 148);
            this.die10.Name = "die10";
            this.die10.Selected = false;
            this.die10.Size = new System.Drawing.Size(30, 30);
            this.die10.TabIndex = 6;
            this.die10.Value = 1;
            this.die10.Visible = false;
            this.die10.ClickDie += new Yahtzee.Die.DieClickEventHandler(this.die_ClickDie);
            // 
            // die7
            // 
            this.die7.Angle = 0F;
            this.die7.BackColor = System.Drawing.Color.Red;
            this.die7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.die7.ForeColor = System.Drawing.Color.White;
            this.die7.Location = new System.Drawing.Point(2, 40);
            this.die7.Name = "die7";
            this.die7.Selected = false;
            this.die7.Size = new System.Drawing.Size(30, 30);
            this.die7.TabIndex = 3;
            this.die7.Value = 1;
            this.die7.Visible = false;
            this.die7.ClickDie += new Yahtzee.Die.DieClickEventHandler(this.die_ClickDie);
            // 
            // die9
            // 
            this.die9.Angle = 0F;
            this.die9.BackColor = System.Drawing.Color.Red;
            this.die9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.die9.ForeColor = System.Drawing.Color.White;
            this.die9.Location = new System.Drawing.Point(2, 112);
            this.die9.Name = "die9";
            this.die9.Selected = false;
            this.die9.Size = new System.Drawing.Size(30, 30);
            this.die9.TabIndex = 5;
            this.die9.Value = 1;
            this.die9.Visible = false;
            this.die9.ClickDie += new Yahtzee.Die.DieClickEventHandler(this.die_ClickDie);
            // 
            // die8
            // 
            this.die8.Angle = 0F;
            this.die8.BackColor = System.Drawing.Color.Red;
            this.die8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.die8.ForeColor = System.Drawing.Color.White;
            this.die8.Location = new System.Drawing.Point(2, 76);
            this.die8.Name = "die8";
            this.die8.Selected = false;
            this.die8.Size = new System.Drawing.Size(30, 30);
            this.die8.TabIndex = 4;
            this.die8.Value = 1;
            this.die8.Visible = false;
            this.die8.ClickDie += new Yahtzee.Die.DieClickEventHandler(this.die_ClickDie);
            // 
            // die5
            // 
            this.die5.Angle = 0F;
            this.die5.BackColor = System.Drawing.Color.Red;
            this.die5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.die5.ForeColor = System.Drawing.Color.White;
            this.die5.Location = new System.Drawing.Point(224, 102);
            this.die5.Name = "die5";
            this.die5.Selected = false;
            this.die5.Size = new System.Drawing.Size(50, 50);
            this.die5.TabIndex = 4;
            this.die5.Value = 6;
            this.die5.Visible = false;
            this.die5.ClickDie += new Yahtzee.Die.DieClickEventHandler(this.die_ClickDie);
            // 
            // die4
            // 
            this.die4.Angle = 0F;
            this.die4.BackColor = System.Drawing.Color.Red;
            this.die4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.die4.ForeColor = System.Drawing.Color.White;
            this.die4.Location = new System.Drawing.Point(43, 102);
            this.die4.Name = "die4";
            this.die4.Selected = false;
            this.die4.Size = new System.Drawing.Size(50, 50);
            this.die4.TabIndex = 3;
            this.die4.Value = 4;
            this.die4.Visible = false;
            this.die4.ClickDie += new Yahtzee.Die.DieClickEventHandler(this.die_ClickDie);
            // 
            // die3
            // 
            this.die3.Angle = 0F;
            this.die3.BackColor = System.Drawing.Color.Red;
            this.die3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.die3.ForeColor = System.Drawing.Color.White;
            this.die3.Location = new System.Drawing.Point(206, 17);
            this.die3.Name = "die3";
            this.die3.Selected = false;
            this.die3.Size = new System.Drawing.Size(50, 50);
            this.die3.TabIndex = 2;
            this.die3.Value = 3;
            this.die3.Visible = false;
            this.die3.ClickDie += new Yahtzee.Die.DieClickEventHandler(this.die_ClickDie);
            // 
            // die2
            // 
            this.die2.Angle = 0F;
            this.die2.BackColor = System.Drawing.Color.Red;
            this.die2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.die2.ForeColor = System.Drawing.Color.White;
            this.die2.Location = new System.Drawing.Point(109, 26);
            this.die2.Name = "die2";
            this.die2.Selected = false;
            this.die2.Size = new System.Drawing.Size(50, 50);
            this.die2.TabIndex = 1;
            this.die2.Value = 2;
            this.die2.Visible = false;
            this.die2.ClickDie += new Yahtzee.Die.DieClickEventHandler(this.die_ClickDie);
            // 
            // die1
            // 
            this.die1.Angle = 0F;
            this.die1.BackColor = System.Drawing.Color.Red;
            this.die1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.die1.ForeColor = System.Drawing.Color.White;
            this.die1.Location = new System.Drawing.Point(16, 17);
            this.die1.Name = "die1";
            this.die1.Selected = false;
            this.die1.Size = new System.Drawing.Size(50, 50);
            this.die1.TabIndex = 0;
            this.die1.Value = 1;
            this.die1.Visible = false;
            this.die1.ClickDie += new Yahtzee.Die.DieClickEventHandler(this.die_ClickDie);
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 547);
            this.Controls.Add(this.panelScorecardOuter);
            this.Controls.Add(this.tableLayoutPanelLeagueLeaders);
            this.Controls.Add(this.listViewHighScores);
            this.Controls.Add(this.labelRoll);
            this.Controls.Add(this.panelSelectedDice);
            this.Controls.Add(this.panelPlayingSurface);
            this.Controls.Add(this.buttonRoll);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Console";
            this.Text = "Yahtzee";
            this.Load += new System.EventHandler(this.Console_Load);
            this.panelPlayingSurface.ResumeLayout(false);
            this.panelSelectedDice.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanelLeagueLeaders.ResumeLayout(false);
            this.tableLayoutPanelLeagueLeaders.PerformLayout();
            this.panelScorecardOuter.ResumeLayout(false);
            this.panelScorecardOuter.PerformLayout();
            this.panelScorecardInner.ResumeLayout(false);
            this.panelScorecardInner.PerformLayout();
            this.tableLayoutPanelScorecards.ResumeLayout(false);
            this.tableLayoutPanelScorecards.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRoll;
        private System.Windows.Forms.Panel panelPlayingSurface;
        private Die die5;
        private Die die4;
        private Die die3;
        private Die die2;
        private Die die1;
        private Die die6;
        private Die die7;
        private Die die8;
        private Die die9;
        private Die die10;
        private System.Windows.Forms.Panel panelSelectedDice;
        private System.Windows.Forms.Label labelRoll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programmerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specifyDiceToolStripMenuItem;
        private System.Windows.Forms.ListView listViewHighScores;
        private System.Windows.Forms.ColumnHeader columnHeaderRecordScore;
        private System.Windows.Forms.ColumnHeader columnHeaderPlayerName;
        private System.Windows.Forms.ColumnHeader columnHeaderRecordDate;
        private System.Windows.Forms.ColumnHeader columnHeaderAverage;
        private System.Windows.Forms.ColumnHeader columnHeaderHighScoresRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLeagueAverage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeagueLeaders;
        private System.Windows.Forms.ToolStripMenuItem originalYahtzeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bonusYahtzeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tripleYahtzeeToolStripMenuItem;
        private System.Windows.Forms.Panel panelScorecardOuter;
        private System.Windows.Forms.Panel panelScorecardInner;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelScorecards;
        private Scorecard scorecard1;
        private PlayerControl playerControl1;
        private System.Windows.Forms.ToolStripMenuItem saveDieAsPNGToolStripMenuItem;
    }
}

