using GameTest.Models;
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

namespace GameTest
{
    public partial class Game : Form
    {
        public DataHandling dataHandling = new DataHandling();

        public Color SwitchedOnColour;
        public Color SwitchedOffColour;
        public Int32 NumberOfLightsSwitchedOn;
        public Int32 BoardSize;

        public TableLayoutPanel panel;

        public Game()
        {
            InitializeComponent();
            SetParams();
            CreateSquareWithButtons();
            InitGame();
        }

        public void SetParams()
        {
            Params gameParameters = dataHandling.GetParams();
            SwitchedOnColour = Color.FromName(gameParameters.SwitchedOnColour);
            SwitchedOffColour = Color.FromName(gameParameters.SwitchedOffColour);
            NumberOfLightsSwitchedOn = gameParameters.NumberOfLightsOn;
            BoardSize = gameParameters.BoardSize;
        }


        public void InitGame()
        {
            var rnd = new Random();

            if (NumberOfLightsSwitchedOn >= (BoardSize * BoardSize))
            {
                NumberOfLightsSwitchedOn = BoardSize / 2;
            }

            var randomNumbers = Enumerable.Range(1, BoardSize * BoardSize).OrderBy(x => rnd.Next()).Take(NumberOfLightsSwitchedOn).ToList();


            //Get Buttons
            for (int i = 1; i <= BoardSize * BoardSize; i++)
            {
                Control btnX = panel.Controls["btn" + i];
                btnX.Click += ButtonClick;
                if ((randomNumbers).Contains(i))
                {
                    btnX.BackColor = SwitchedOnColour;
                }
                else
                {
                    btnX.BackColor = SwitchedOffColour;
                }
            }
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            Button b = sender as Button;

            int btnID = Convert.ToInt32(b.Name.Replace("btn", ""));

            SwitchButtons(btnID);

            //Loop buttons to check if all buttons are switched off
            bool finished = FinishCheck();

            if (finished)
            {
                MessageBox.Show("Game Finished !");
            }
        }

        public void SwitchButtons(int buttonID)
        {
            //Get Controls


            //Switch current button
            Control CurrentButton = panel.Controls["btn" + buttonID];
            SwitchSingleButton(CurrentButton);

            List<int> leftButtonsList = new List<int>();
            for (int i = 1; i <= (BoardSize * BoardSize); i += 5)
            {
                leftButtonsList.Add(i);
            }

            Int32[] LeftButtons = leftButtonsList.ToArray();

            //Switch button to the left
            if (LeftButtons.Contains(buttonID) == false)
            {
                Control ButtonLeft = panel.Controls["btn" + (buttonID - 1)];
                SwitchSingleButton(ButtonLeft);
            }

            //Switch button to the right
            if (buttonID % BoardSize != 0) //Check if right side of the grid
            {
                Control ButtonRight = panel.Controls["btn" + (buttonID + 1)];
                SwitchSingleButton(ButtonRight);
            }

            //Switch button above
            if (buttonID >= BoardSize + 1) //Check if second row or below
            {
                Control ButtonTop = panel.Controls["btn" + (buttonID - BoardSize)];
                SwitchSingleButton(ButtonTop);
            }

            //Switch button below
            if (buttonID <= BoardSize * (BoardSize - 1)) //Check if fourth row or above
            {
                Control ButtonBelow = panel.Controls["btn" + (buttonID + BoardSize)];
                SwitchSingleButton(ButtonBelow);
            }
        }

        public void SwitchSingleButton(Control Button)
        {
            if (Button.BackColor == SwitchedOnColour)
            {
                Button.BackColor = SwitchedOffColour;
            }
            else
            {
                Button.BackColor = SwitchedOnColour;
            }
        }

        public void CreateSquareWithButtons()
        {

            panel = new TableLayoutPanel();
            panel.Name = "TablePnl";

            panel.RowCount = BoardSize;
            panel.ColumnCount = BoardSize;
            panel.AutoSize = true;

            for (int i = 0; i < BoardSize; i++)
            {
                var percent = 100f / (float)BoardSize;
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, percent));

            }

            int count = 1;
            for (var i = 0; i < BoardSize; i++)
            {
                for (var j = 0; j < BoardSize; j++)
                {
                    Button button = new Button();
                    button.Text = "";
                    button.Name = "btn" + count;
                    button.Size = new Size(40, 40);
                    button.Dock = DockStyle.Fill;
                    count++;
                    panel.Controls.Add(button, j, i);
                }
            }


            switch (BoardSize)
            {
                case 1:
                    panel.Location = new Point(70, 75);
                    panel.Anchor = AnchorStyles.Top;
                    break;
                case 2:
                    panel.Location = new Point(70, 65);
                    panel.Anchor = AnchorStyles.Top;
                    break;
                case 3:
                    panel.Location = new Point(70, 55);
                    panel.Anchor = AnchorStyles.Top;
                    break;
                case 4:
                    panel.Location = new Point(65, 45);
                    panel.Anchor = AnchorStyles.Top;
                    break;
                case 5:
                    panel.Location = new Point(50, 35);
                    panel.Anchor = AnchorStyles.Top;
                    break;
                case 6:
                    panel.Location = new Point(28, 25);
                    panel.Anchor = AnchorStyles.Top;
                    break;
                case 7:
                    panel.Location = new Point(5, 30);
                    panel.Anchor = AnchorStyles.Top;
                    break;              
                default:
                    break;
            }

            ////panel.Location = new Point(50, 35);
            //panel.Anchor = AnchorStyles.Top;

            this.Controls.Add(panel);
        }


        public bool FinishCheck()
        {
            bool finished = true;
            //Get Buttons

            for (int i = 1; i <= (BoardSize * BoardSize); i++)
            {
                Control btnX = panel.Controls["btn" + i];
                if (btnX.BackColor == SwitchedOnColour)
                {
                    finished = false;
                    break;
                }
            }

            return finished;
        }

    }
}
