using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee.Debug
{
    public partial class SaveDieAsImage : Form
    {
        public SaveDieAsImage()
        {
            InitializeComponent();
            comboBoxValue.SelectedIndex = 5;
            textBoxSize.Text = SizeOfDie.ToString();
            comboBoxFormat.SelectedIndex = 0;
            Directory = System.IO.Directory.GetCurrentDirectory();
            folderBrowserDialogImage.SelectedPath = Directory;
            textBoxFileName.SelectionStart = int.MaxValue;
            textBoxFileName.SelectionLength = 0;
            SetFilename();
        }

        public int Value
        {
            get
            {
                return Convert.ToInt32(comboBoxValue.Text);
            }
            set
            {
                if (value < 1 || value > 6)
                {
                    MessageBox.Show("It's a six-sided die.");
                }
                else
                {
                    comboBoxValue.SelectedIndex = value - 1;
                    SetFilename();
                }
            }
        }
        public int SizeOfDie
        {
            get
            {
                return Convert.ToInt32(textBoxSize.Text.Trim());
            }
            set
            {
                if (value < 4)
                {
                    MessageBox.Show("That's invisible.");
                }
                else
                {
                    int w = value;
                    textBoxSize.Text = value.ToString();
                    dieSample.Size = new Size(w, w);
                    SetFilename();
                }
            }
        }
        public Color DieColor
        {
            get
            {
                return buttonDieColor.BackColor;
            }
            set
            {
                buttonDieColor.BackColor = value;
            }
        }
        public Color PipColor
        {
            get
            {
                return buttonPipColor.BackColor;
            }
            set
            {
                buttonPipColor.BackColor = value;
            }
        }
        public System.Drawing.Imaging.ImageFormat ImageFormat
        {
            get
            {
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(System.Drawing.Imaging.ImageFormat));
                return (System.Drawing.Imaging.ImageFormat)tc.ConvertFromString(comboBoxFormat.SelectedItem.ToString());
            }
            set
            {
                comboBoxFormat.SelectedItem = value.ToString();
            }
        }
        public string Directory
        {
            get
            {
                return textBoxFileName.Text;
            }
            set
            {
                textBoxFileName.Text = value;
            }
        }

        private void comboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieSample.Value = Convert.ToInt32(comboBoxValue.SelectedItem);
            SetFilename();
        }

        private void textBoxSize_TextChanged(object sender, EventArgs e)
        {
            int WidthOfSide;
            if (int.TryParse(textBoxSize.Text.Trim(), out WidthOfSide))
            {
                dieSample.Size = new Size(WidthOfSide, WidthOfSide);
                SetFilename();
            }
        }

        private void buttonDieColor_Click(object sender, EventArgs e)
        {
            colorDialogDie.Color = buttonDieColor.BackColor;
            if (colorDialogDie.ShowDialog() == DialogResult.OK)
            {
                dieSample.BackColor = colorDialogDie.Color;
                buttonDieColor.BackColor = colorDialogDie.Color;
                buttonDieColor.ForeColor = HighContrastWith(colorDialogDie.Color);
            }
        }

        private void buttonPipColor_Click(object sender, EventArgs e)
        {
            colorDialogPip.Color = buttonPipColor.BackColor;
            if (colorDialogPip.ShowDialog() == DialogResult.OK)
            {
                dieSample.ForeColor = colorDialogPip.Color;
                buttonPipColor.BackColor = colorDialogPip.Color;
                buttonPipColor.ForeColor = HighContrastWith(colorDialogPip.Color);
            }
        }

        // https://stackoverflow.com/questions/3942878/how-to-decide-font-color-in-white-or-black-depending-on-background-color
        private Color HighContrastWith(Color c)
        {
            if ((c.R * 0.299 + c.G * 0.587 + c.B * 0.114) > 186)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private void comboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(System.Drawing.Imaging.ImageFormat));
            ImageFormat = (System.Drawing.Imaging.ImageFormat)tc.ConvertFromString(comboBoxFormat.SelectedItem.ToString());
        }

        private void textBoxFileName_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = (textBoxFileName.Text.Trim().Length > 0);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogImage.ShowDialog() == DialogResult.OK)
            {
                textBoxFileName.Text = folderBrowserDialogImage.SelectedPath;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(dieSample.Width, dieSample.Width);
            using (Graphics g = Graphics.FromImage(bm))
            {
                System.Diagnostics.Debug.WriteLine(dieSample.PointToScreen(Point.Empty));
                Point pt = Point.Empty;
                if (dieSample.BorderStyle == BorderStyle.FixedSingle)
                {
                    pt.Offset(SystemInformation.BorderSize.Width, SystemInformation.BorderSize.Height);
                }
                else if (dieSample.BorderStyle == BorderStyle.Fixed3D)
                {
                    pt.Offset(SystemInformation.Border3DSize.Width, SystemInformation.Border3DSize.Height);
                }
                g.CopyFromScreen(dieSample.PointToScreen(new Point(-1, -1)), Point.Empty, dieSample.Size);
            }
            bm.Save(System.IO.Path.Combine(textBoxFileName.Text.Trim(), labelFileName.Text), ImageFormat);
            MessageBox.Show("Saved.");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SetFilename()
        {
            labelFileName.Text = $"{Convert.ToInt32(comboBoxValue.SelectedItem)}_{SizeOfDie}x{SizeOfDie}.{comboBoxFormat.Text.ToLower()}";
        }
    }
}
