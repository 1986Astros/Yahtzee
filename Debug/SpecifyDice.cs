using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class SpecifyDice : Form
    {
        public SpecifyDice()
        {
            InitializeComponent();
        }

        public int[] Dice = new int[5];

        private void textBoxDice_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDice.Text.Trim().Length == 0)
            {
                textBoxDice.Enabled = false;
            }
            Regex rx = new Regex("((?<die>[1-6])[^1-6]*){5}");
            Match m = rx.Match(textBoxDice.Text);
            if (m.Success)
            {
                for (int i = 0; i < 5;i++)
                {
                    Dice[i] = Convert.ToInt32(m.Groups["die"].Captures[i].Value);
                }
                buttonOK.Enabled = true;
            }
            else
            {
                buttonOK.Enabled = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
