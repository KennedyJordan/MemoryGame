using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1: Form
    {
        Random random = new Random();

        //Setting up the images for clicking
        List<string> icons = new List<string>()
        {
            "!","!","N","N",",",",","k","k",
            "b","b","w","w","v","v","z","z"
        };

        //Storing the Information on Clicks
        Label firstClick, secondClick;

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void label_click(object sender, EventArgs e)
        {
            if (firstClick != null && secondClick != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;

            if (clickedLabel.ForeColor == Color.Black)
                return;

            if(firstClick == null)
            {
                firstClick = clickedLabel;
                firstClick.ForeColor = Color.Black;
                return;
            }

            secondClick = clickedLabel;
            secondClick.ForeColor = Color.Black;

            CheckForWin();

            if(firstClick.Text == secondClick.Text)
            {
                firstClick = null;
                secondClick = null;
            }
            else
                timer1.Start();

        }

        private void CheckForWin()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            MessageBox.Show("Congratz You Win The Game!");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClick.ForeColor = firstClick.BackColor;
            secondClick.ForeColor = secondClick.BackColor;

            firstClick = null;
            secondClick = null;
         
        }

        //Attaching Images to Individual Squares
        private void AssignIconsToSquares()
        {
            Label label;
            int randomNumber;

            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];

                else
                    continue;

                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);
            }
        }
    }
}
