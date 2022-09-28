namespace Yahtzee
{
    partial class Die
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
            // Die
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DoubleBuffered = true;
            this.Name = "Die";
            this.Size = new System.Drawing.Size(75, 75);
            this.Load += new System.EventHandler(this.Die_Load);
            this.SizeChanged += new System.EventHandler(this.Die_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Die_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Die_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
