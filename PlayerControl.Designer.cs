namespace Yahtzee
{
    partial class PlayerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerControl));
            this.panelSample = new System.Windows.Forms.Panel();
            this.dieSample = new Yahtzee.Die();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.playerTtoolStrip = new System.Windows.Forms.ToolStrip();
            this.playerToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPlayerLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPlayerToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.computerPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beavisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStrip = new System.Windows.Forms.ToolStrip();
            this.settingsToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.addOpponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tableColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableRedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableGreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableBlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableBlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableBrownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablePurpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dieColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dieRedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dieGreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dieBlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dieWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dieBlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dieYellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diePurpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSample.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.playerTtoolStrip.SuspendLayout();
            this.optionsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSample
            // 
            this.panelSample.BackColor = System.Drawing.Color.ForestGreen;
            this.panelSample.Controls.Add(this.dieSample);
            this.panelSample.Location = new System.Drawing.Point(83, 3);
            this.panelSample.Name = "panelSample";
            this.panelSample.Size = new System.Drawing.Size(20, 20);
            this.panelSample.TabIndex = 4;
            // 
            // dieSample
            // 
            this.dieSample.Angle = 0F;
            this.dieSample.BackColor = System.Drawing.Color.Red;
            this.dieSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dieSample.ForeColor = System.Drawing.Color.White;
            this.dieSample.Location = new System.Drawing.Point(2, 2);
            this.dieSample.Name = "dieSample";
            this.dieSample.Selected = false;
            this.dieSample.Size = new System.Drawing.Size(16, 16);
            this.dieSample.TabIndex = 0;
            this.dieSample.Value = 6;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.playerTtoolStrip, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelSample, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.optionsToolStrip, 2, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(149, 26);
            this.tableLayoutPanelMain.TabIndex = 6;
            // 
            // playerTtoolStrip
            // 
            this.playerTtoolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.playerTtoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerToolStripDropDownButton});
            this.playerTtoolStrip.Location = new System.Drawing.Point(0, 0);
            this.playerTtoolStrip.Name = "playerTtoolStrip";
            this.playerTtoolStrip.Size = new System.Drawing.Size(80, 25);
            this.playerTtoolStrip.TabIndex = 8;
            this.playerTtoolStrip.Text = "toolStrip1";
            // 
            // playerToolStripDropDownButton
            // 
            this.playerToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.playerToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.computerPlayerToolStripMenuItem});
            this.playerToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("playerToolStripDropDownButton.Image")));
            this.playerToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playerToolStripDropDownButton.Name = "playerToolStripDropDownButton";
            this.playerToolStripDropDownButton.Size = new System.Drawing.Size(52, 22);
            this.playerToolStripDropDownButton.Text = "Player";
            this.playerToolStripDropDownButton.DropDownOpening += new System.EventHandler(this.playerToolStripDropDownButton_DropDownOpening);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlayerLabelToolStripMenuItem,
            this.newPlayerToolStripTextBox});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.newToolStripMenuItem.Text = "New ...";
            // 
            // newPlayerLabelToolStripMenuItem
            // 
            this.newPlayerLabelToolStripMenuItem.Enabled = false;
            this.newPlayerLabelToolStripMenuItem.Name = "newPlayerLabelToolStripMenuItem";
            this.newPlayerLabelToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.newPlayerLabelToolStripMenuItem.Text = "New player name:";
            this.newPlayerLabelToolStripMenuItem.Click += new System.EventHandler(this.newPlayerLabelToolStripMenuItem_Click);
            // 
            // newPlayerToolStripTextBox
            // 
            this.newPlayerToolStripTextBox.BackColor = System.Drawing.Color.MistyRose;
            this.newPlayerToolStripTextBox.Name = "newPlayerToolStripTextBox";
            this.newPlayerToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.newPlayerToolStripTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.newPlayerToolStripTextBox_KeyDown);
            this.newPlayerToolStripTextBox.TextChanged += new System.EventHandler(this.newPlayerToolStripTextBox_TextChanged);
            // 
            // computerPlayerToolStripMenuItem
            // 
            this.computerPlayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beavisToolStripMenuItem,
            this.jonesToolStripMenuItem,
            this.hALToolStripMenuItem});
            this.computerPlayerToolStripMenuItem.Name = "computerPlayerToolStripMenuItem";
            this.computerPlayerToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.computerPlayerToolStripMenuItem.Text = "Computer";
            this.computerPlayerToolStripMenuItem.Visible = false;
            // 
            // beavisToolStripMenuItem
            // 
            this.beavisToolStripMenuItem.Enabled = false;
            this.beavisToolStripMenuItem.Name = "beavisToolStripMenuItem";
            this.beavisToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.beavisToolStripMenuItem.Text = "* Beavis";
            this.beavisToolStripMenuItem.Click += new System.EventHandler(this.computerPlayerToolStripMenuItem_Click);
            // 
            // jonesToolStripMenuItem
            // 
            this.jonesToolStripMenuItem.Enabled = false;
            this.jonesToolStripMenuItem.Name = "jonesToolStripMenuItem";
            this.jonesToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.jonesToolStripMenuItem.Text = "* Jones";
            this.jonesToolStripMenuItem.Click += new System.EventHandler(this.computerPlayerToolStripMenuItem_Click);
            // 
            // hALToolStripMenuItem
            // 
            this.hALToolStripMenuItem.Enabled = false;
            this.hALToolStripMenuItem.Name = "hALToolStripMenuItem";
            this.hALToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.hALToolStripMenuItem.Text = "* HAL";
            this.hALToolStripMenuItem.Click += new System.EventHandler(this.computerPlayerToolStripMenuItem_Click);
            // 
            // optionsToolStrip
            // 
            this.optionsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.optionsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripDropDownButton});
            this.optionsToolStrip.Location = new System.Drawing.Point(106, 0);
            this.optionsToolStrip.Name = "optionsToolStrip";
            this.optionsToolStrip.Size = new System.Drawing.Size(43, 25);
            this.optionsToolStrip.TabIndex = 9;
            this.optionsToolStrip.Text = "toolStrip2";
            // 
            // settingsToolStripDropDownButton
            // 
            this.settingsToolStripDropDownButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.settingsToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOpponentToolStripMenuItem,
            this.removeFromGameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.tableColorToolStripMenuItem,
            this.dieColorToolStripMenuItem,
            this.confirmScoreToolStripMenuItem});
            this.settingsToolStripDropDownButton.Image = global::Yahtzee.Properties.Resources.Settings_dots_horizontal;
            this.settingsToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsToolStripDropDownButton.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.settingsToolStripDropDownButton.Name = "settingsToolStripDropDownButton";
            this.settingsToolStripDropDownButton.ShowDropDownArrow = false;
            this.settingsToolStripDropDownButton.Size = new System.Drawing.Size(20, 22);
            this.settingsToolStripDropDownButton.DropDownOpening += new System.EventHandler(this.settingsToolStripDropDownButton_DropDownOpening);
            // 
            // addOpponentToolStripMenuItem
            // 
            this.addOpponentToolStripMenuItem.Name = "addOpponentToolStripMenuItem";
            this.addOpponentToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.addOpponentToolStripMenuItem.Text = "Add opponent";
            // 
            // removeFromGameToolStripMenuItem
            // 
            this.removeFromGameToolStripMenuItem.Enabled = false;
            this.removeFromGameToolStripMenuItem.Image = global::Yahtzee.Properties.Resources.close;
            this.removeFromGameToolStripMenuItem.Name = "removeFromGameToolStripMenuItem";
            this.removeFromGameToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.removeFromGameToolStripMenuItem.Text = "Remove from game";
            this.removeFromGameToolStripMenuItem.Click += new System.EventHandler(this.removeFromGameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 6);
            // 
            // tableColorToolStripMenuItem
            // 
            this.tableColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableRedToolStripMenuItem,
            this.tableGreenToolStripMenuItem,
            this.tableBlueToolStripMenuItem,
            this.tableBlackToolStripMenuItem,
            this.tableWhiteToolStripMenuItem,
            this.tableBrownToolStripMenuItem,
            this.tablePurpleToolStripMenuItem});
            this.tableColorToolStripMenuItem.Name = "tableColorToolStripMenuItem";
            this.tableColorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.tableColorToolStripMenuItem.Text = "Table color";
            this.tableColorToolStripMenuItem.DropDownOpening += new System.EventHandler(this.tableColorToolStripMenuItem_DropDownOpening);
            // 
            // tableRedToolStripMenuItem
            // 
            this.tableRedToolStripMenuItem.BackColor = System.Drawing.Color.DarkRed;
            this.tableRedToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tableRedToolStripMenuItem.Name = "tableRedToolStripMenuItem";
            this.tableRedToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tableRedToolStripMenuItem.Text = "Red";
            this.tableRedToolStripMenuItem.Click += new System.EventHandler(this.tableColorToolStripMenuItem_Click);
            // 
            // tableGreenToolStripMenuItem
            // 
            this.tableGreenToolStripMenuItem.BackColor = System.Drawing.Color.ForestGreen;
            this.tableGreenToolStripMenuItem.Checked = true;
            this.tableGreenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableGreenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tableGreenToolStripMenuItem.Name = "tableGreenToolStripMenuItem";
            this.tableGreenToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tableGreenToolStripMenuItem.Text = "Green";
            this.tableGreenToolStripMenuItem.Click += new System.EventHandler(this.tableColorToolStripMenuItem_Click);
            // 
            // tableBlueToolStripMenuItem
            // 
            this.tableBlueToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue;
            this.tableBlueToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tableBlueToolStripMenuItem.Name = "tableBlueToolStripMenuItem";
            this.tableBlueToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tableBlueToolStripMenuItem.Text = "Blue";
            this.tableBlueToolStripMenuItem.Click += new System.EventHandler(this.tableColorToolStripMenuItem_Click);
            // 
            // tableBlackToolStripMenuItem
            // 
            this.tableBlackToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.tableBlackToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tableBlackToolStripMenuItem.Name = "tableBlackToolStripMenuItem";
            this.tableBlackToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tableBlackToolStripMenuItem.Text = "Black";
            this.tableBlackToolStripMenuItem.Click += new System.EventHandler(this.tableColorToolStripMenuItem_Click);
            // 
            // tableWhiteToolStripMenuItem
            // 
            this.tableWhiteToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.tableWhiteToolStripMenuItem.Name = "tableWhiteToolStripMenuItem";
            this.tableWhiteToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tableWhiteToolStripMenuItem.Text = "White";
            this.tableWhiteToolStripMenuItem.Click += new System.EventHandler(this.tableColorToolStripMenuItem_Click);
            // 
            // tableBrownToolStripMenuItem
            // 
            this.tableBrownToolStripMenuItem.BackColor = System.Drawing.Color.BurlyWood;
            this.tableBrownToolStripMenuItem.Name = "tableBrownToolStripMenuItem";
            this.tableBrownToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tableBrownToolStripMenuItem.Text = "Brown";
            this.tableBrownToolStripMenuItem.Click += new System.EventHandler(this.tableColorToolStripMenuItem_Click);
            // 
            // tablePurpleToolStripMenuItem
            // 
            this.tablePurpleToolStripMenuItem.BackColor = System.Drawing.Color.Plum;
            this.tablePurpleToolStripMenuItem.Name = "tablePurpleToolStripMenuItem";
            this.tablePurpleToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tablePurpleToolStripMenuItem.Text = "Purple";
            this.tablePurpleToolStripMenuItem.Click += new System.EventHandler(this.tableColorToolStripMenuItem_Click);
            // 
            // dieColorToolStripMenuItem
            // 
            this.dieColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dieRedToolStripMenuItem,
            this.dieGreenToolStripMenuItem,
            this.dieBlueToolStripMenuItem,
            this.dieWhiteToolStripMenuItem,
            this.dieBlackToolStripMenuItem,
            this.dieYellowToolStripMenuItem,
            this.diePurpleToolStripMenuItem});
            this.dieColorToolStripMenuItem.Name = "dieColorToolStripMenuItem";
            this.dieColorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.dieColorToolStripMenuItem.Text = "Die color";
            this.dieColorToolStripMenuItem.DropDownOpening += new System.EventHandler(this.dieColorToolStripMenuItem_DropDownOpening);
            // 
            // dieRedToolStripMenuItem
            // 
            this.dieRedToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.dieRedToolStripMenuItem.Checked = true;
            this.dieRedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dieRedToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.dieRedToolStripMenuItem.Name = "dieRedToolStripMenuItem";
            this.dieRedToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.dieRedToolStripMenuItem.Text = "Red";
            this.dieRedToolStripMenuItem.Click += new System.EventHandler(this.dieColorToolStripMenuItem_Click);
            // 
            // dieGreenToolStripMenuItem
            // 
            this.dieGreenToolStripMenuItem.BackColor = System.Drawing.Color.LimeGreen;
            this.dieGreenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.dieGreenToolStripMenuItem.Name = "dieGreenToolStripMenuItem";
            this.dieGreenToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.dieGreenToolStripMenuItem.Text = "Green";
            this.dieGreenToolStripMenuItem.Click += new System.EventHandler(this.dieColorToolStripMenuItem_Click);
            // 
            // dieBlueToolStripMenuItem
            // 
            this.dieBlueToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.dieBlueToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.dieBlueToolStripMenuItem.Name = "dieBlueToolStripMenuItem";
            this.dieBlueToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.dieBlueToolStripMenuItem.Text = "Blue";
            this.dieBlueToolStripMenuItem.Click += new System.EventHandler(this.dieColorToolStripMenuItem_Click);
            // 
            // dieWhiteToolStripMenuItem
            // 
            this.dieWhiteToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.dieWhiteToolStripMenuItem.Name = "dieWhiteToolStripMenuItem";
            this.dieWhiteToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.dieWhiteToolStripMenuItem.Text = "White";
            this.dieWhiteToolStripMenuItem.Click += new System.EventHandler(this.dieColorToolStripMenuItem_Click);
            // 
            // dieBlackToolStripMenuItem
            // 
            this.dieBlackToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.dieBlackToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.dieBlackToolStripMenuItem.Name = "dieBlackToolStripMenuItem";
            this.dieBlackToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.dieBlackToolStripMenuItem.Text = "Black";
            this.dieBlackToolStripMenuItem.Click += new System.EventHandler(this.dieColorToolStripMenuItem_Click);
            // 
            // dieYellowToolStripMenuItem
            // 
            this.dieYellowToolStripMenuItem.BackColor = System.Drawing.Color.Yellow;
            this.dieYellowToolStripMenuItem.Name = "dieYellowToolStripMenuItem";
            this.dieYellowToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.dieYellowToolStripMenuItem.Text = "Yellow";
            this.dieYellowToolStripMenuItem.Click += new System.EventHandler(this.dieColorToolStripMenuItem_Click);
            // 
            // diePurpleToolStripMenuItem
            // 
            this.diePurpleToolStripMenuItem.BackColor = System.Drawing.Color.Purple;
            this.diePurpleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.diePurpleToolStripMenuItem.Name = "diePurpleToolStripMenuItem";
            this.diePurpleToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.diePurpleToolStripMenuItem.Text = "Purple";
            this.diePurpleToolStripMenuItem.Click += new System.EventHandler(this.dieColorToolStripMenuItem_Click);
            // 
            // confirmScoreToolStripMenuItem
            // 
            this.confirmScoreToolStripMenuItem.CheckOnClick = true;
            this.confirmScoreToolStripMenuItem.Name = "confirmScoreToolStripMenuItem";
            this.confirmScoreToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.confirmScoreToolStripMenuItem.Text = "Confirm score";
            this.confirmScoreToolStripMenuItem.Click += new System.EventHandler(this.confirmScoreToolStripMenuItem_Click);
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(149, 26);
            this.Load += new System.EventHandler(this.PlayerControl_Load);
            this.panelSample.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.playerTtoolStrip.ResumeLayout(false);
            this.playerTtoolStrip.PerformLayout();
            this.optionsToolStrip.ResumeLayout(false);
            this.optionsToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelSample;
        private Die dieSample;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.ToolStrip playerTtoolStrip;
        private System.Windows.Forms.ToolStripDropDownButton playerToolStripDropDownButton;
        private System.Windows.Forms.ToolStrip optionsToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton settingsToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem tableColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confirmScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeFromGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dieColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beavisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hALToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableGreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableBlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableBlackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableBrownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablePurpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableRedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dieRedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dieBlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diePurpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dieYellowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dieBlackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dieWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dieGreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox newPlayerToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem newPlayerLabelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addOpponentToolStripMenuItem;
    }
}
