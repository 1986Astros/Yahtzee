﻿namespace Yahtzee
{
    partial class Scorecard
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
            this.SuspendLayout();
            // 
            // Scorecard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DoubleBuffered = true;
            this.Name = "Scorecard";
            this.Size = new System.Drawing.Size(0, 0);
            this.Load += new System.EventHandler(this.Scorecard_Load);
            this.EnabledChanged += new System.EventHandler(this.Scorecard_EnabledChanged);
            this.Click += new System.EventHandler(this.Scorecard_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Scorecard_Paint);
            this.MouseLeave += new System.EventHandler(this.Scorecard_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scorecard_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
