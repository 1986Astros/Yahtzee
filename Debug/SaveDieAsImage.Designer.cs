namespace Yahtzee.Debug
{
    partial class SaveDieAsImage
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.panelDie = new System.Windows.Forms.Panel();
            this.dieSample = new Yahtzee.Die();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.tableLayoutPanelSpecs = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxValue = new System.Windows.Forms.ComboBox();
            this.buttonDieColor = new System.Windows.Forms.Button();
            this.buttonPipColor = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelFIleName = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelSaveCancel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.colorDialogDie = new System.Windows.Forms.ColorDialog();
            this.colorDialogPip = new System.Windows.Forms.ColorDialog();
            this.folderBrowserDialogImage = new System.Windows.Forms.FolderBrowserDialog();
            this.panelDie.SuspendLayout();
            this.tableLayoutPanelSpecs.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanelFIleName.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelSaveCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Value:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "Format:";
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Items.AddRange(new object[] {
            "PNG"});
            this.comboBoxFormat.Location = new System.Drawing.Point(58, 114);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(68, 21);
            this.comboBoxFormat.TabIndex = 8;
            this.comboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Size:";
            // 
            // textBoxSize
            // 
            this.textBoxSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSize.Location = new System.Drawing.Point(58, 30);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(68, 20);
            this.textBoxSize.TabIndex = 3;
            this.textBoxSize.Text = "128";
            this.textBoxSize.TextChanged += new System.EventHandler(this.textBoxSize_TextChanged);
            // 
            // panelDie
            // 
            this.panelDie.AutoScroll = true;
            this.panelDie.AutoSize = true;
            this.panelDie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDie.Controls.Add(this.dieSample);
            this.panelDie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDie.Location = new System.Drawing.Point(138, 3);
            this.panelDie.Name = "panelDie";
            this.panelDie.Size = new System.Drawing.Size(319, 272);
            this.panelDie.TabIndex = 1;
            // 
            // dieSample
            // 
            this.dieSample.Angle = 0F;
            this.dieSample.BackColor = System.Drawing.Color.DarkRed;
            this.dieSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dieSample.ForeColor = System.Drawing.Color.White;
            this.dieSample.Location = new System.Drawing.Point(3, 3);
            this.dieSample.Name = "dieSample";
            this.dieSample.Selected = false;
            this.dieSample.Size = new System.Drawing.Size(128, 128);
            this.dieSample.TabIndex = 0;
            this.dieSample.Value = 6;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Directory:";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFileName.Location = new System.Drawing.Point(58, 5);
            this.textBoxFileName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(329, 20);
            this.textBoxFileName.TabIndex = 1;
            this.textBoxFileName.TextChanged += new System.EventHandler(this.textBoxFileName_TextChanged);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonBrowse.AutoSize = true;
            this.buttonBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBrowse.Location = new System.Drawing.Point(393, 3);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(64, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse ...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // tableLayoutPanelSpecs
            // 
            this.tableLayoutPanelSpecs.AutoSize = true;
            this.tableLayoutPanelSpecs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSpecs.ColumnCount = 2;
            this.tableLayoutPanelSpecs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSpecs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSpecs.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelSpecs.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanelSpecs.Controls.Add(this.textBoxSize, 1, 1);
            this.tableLayoutPanelSpecs.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanelSpecs.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanelSpecs.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanelSpecs.Controls.Add(this.comboBoxFormat, 1, 4);
            this.tableLayoutPanelSpecs.Controls.Add(this.comboBoxValue, 1, 0);
            this.tableLayoutPanelSpecs.Controls.Add(this.buttonDieColor, 1, 2);
            this.tableLayoutPanelSpecs.Controls.Add(this.buttonPipColor, 1, 3);
            this.tableLayoutPanelSpecs.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelSpecs.Name = "tableLayoutPanelSpecs";
            this.tableLayoutPanelSpecs.RowCount = 5;
            this.tableLayoutPanelSpecs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSpecs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSpecs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSpecs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSpecs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSpecs.Size = new System.Drawing.Size(129, 138);
            this.tableLayoutPanelSpecs.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Die color:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 90);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pip color:";
            // 
            // comboBoxValue
            // 
            this.comboBoxValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValue.FormattingEnabled = true;
            this.comboBoxValue.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBoxValue.Location = new System.Drawing.Point(58, 3);
            this.comboBoxValue.Name = "comboBoxValue";
            this.comboBoxValue.Size = new System.Drawing.Size(68, 21);
            this.comboBoxValue.TabIndex = 1;
            this.comboBoxValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxValue_SelectedIndexChanged);
            // 
            // buttonDieColor
            // 
            this.buttonDieColor.AutoSize = true;
            this.buttonDieColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDieColor.BackColor = System.Drawing.Color.DarkRed;
            this.buttonDieColor.ForeColor = System.Drawing.Color.White;
            this.buttonDieColor.Location = new System.Drawing.Point(58, 56);
            this.buttonDieColor.Name = "buttonDieColor";
            this.buttonDieColor.Size = new System.Drawing.Size(68, 23);
            this.buttonDieColor.TabIndex = 5;
            this.buttonDieColor.Text = "click to set";
            this.buttonDieColor.UseVisualStyleBackColor = false;
            this.buttonDieColor.Click += new System.EventHandler(this.buttonDieColor_Click);
            // 
            // buttonPipColor
            // 
            this.buttonPipColor.AutoSize = true;
            this.buttonPipColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPipColor.BackColor = System.Drawing.Color.White;
            this.buttonPipColor.Location = new System.Drawing.Point(58, 85);
            this.buttonPipColor.Name = "buttonPipColor";
            this.buttonPipColor.Size = new System.Drawing.Size(68, 23);
            this.buttonPipColor.TabIndex = 7;
            this.buttonPipColor.Text = "click to set";
            this.buttonPipColor.UseVisualStyleBackColor = false;
            this.buttonPipColor.Click += new System.EventHandler(this.buttonPipColor_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanelSpecs, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelDie, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(460, 278);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // tableLayoutPanelFIleName
            // 
            this.tableLayoutPanelFIleName.AutoSize = true;
            this.tableLayoutPanelFIleName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelFIleName.ColumnCount = 3;
            this.tableLayoutPanelFIleName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFIleName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFIleName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFIleName.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanelFIleName.Controls.Add(this.textBoxFileName, 1, 0);
            this.tableLayoutPanelFIleName.Controls.Add(this.buttonBrowse, 2, 0);
            this.tableLayoutPanelFIleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFIleName.Location = new System.Drawing.Point(3, 287);
            this.tableLayoutPanelFIleName.Name = "tableLayoutPanelFIleName";
            this.tableLayoutPanelFIleName.RowCount = 1;
            this.tableLayoutPanelFIleName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFIleName.Size = new System.Drawing.Size(460, 29);
            this.tableLayoutPanelFIleName.TabIndex = 0;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelFIleName, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelSaveCancel, 0, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(466, 371);
            this.tableLayoutPanelMain.TabIndex = 11;
            // 
            // tableLayoutPanelSaveCancel
            // 
            this.tableLayoutPanelSaveCancel.AutoSize = true;
            this.tableLayoutPanelSaveCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSaveCancel.ColumnCount = 3;
            this.tableLayoutPanelSaveCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSaveCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSaveCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSaveCancel.Controls.Add(this.buttonSave, 1, 0);
            this.tableLayoutPanelSaveCancel.Controls.Add(this.buttonClose, 2, 0);
            this.tableLayoutPanelSaveCancel.Controls.Add(this.labelFileName, 0, 0);
            this.tableLayoutPanelSaveCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSaveCancel.Location = new System.Drawing.Point(3, 322);
            this.tableLayoutPanelSaveCancel.Name = "tableLayoutPanelSaveCancel";
            this.tableLayoutPanelSaveCancel.RowCount = 1;
            this.tableLayoutPanelSaveCancel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSaveCancel.Size = new System.Drawing.Size(460, 46);
            this.tableLayoutPanelSaveCancel.TabIndex = 10;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonSave.Location = new System.Drawing.Point(264, 20);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(382, 20);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(40, 20, 3, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(3, 16);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(81, 13);
            this.labelFileName.TabIndex = 2;
            this.labelFileName.Text = "6_128x128.png";
            // 
            // SaveDieAsImage
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(466, 371);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SaveDieAsImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create image of die";
            this.panelDie.ResumeLayout(false);
            this.tableLayoutPanelSpecs.ResumeLayout(false);
            this.tableLayoutPanelSpecs.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanelFIleName.ResumeLayout(false);
            this.tableLayoutPanelFIleName.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelSaveCancel.ResumeLayout(false);
            this.tableLayoutPanelSaveCancel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Panel panelDie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSpecs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxValue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFIleName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.ColorDialog colorDialogDie;
        private System.Windows.Forms.ColorDialog colorDialogPip;
        private System.Windows.Forms.Button buttonDieColor;
        private System.Windows.Forms.Button buttonPipColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSaveCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private Die dieSample;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogImage;
        private System.Windows.Forms.Label labelFileName;
    }
}