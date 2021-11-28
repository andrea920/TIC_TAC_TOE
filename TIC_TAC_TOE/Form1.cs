using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIC_TAC_TOE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int player = 2;
        public int turns = 0;
        public int X = 0;
        public int O = 0;
        public int D = 0;

        private void buttonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "")
            {
                if (player % 2 == 0)
                {
                    btn.Text = "X";
                    btn.ForeColor = Color.Blue;
                    lblDisplay.Text = "O Turn Now";
                    player++;
                    turns++;
                }
                else
                {
                    btn.Text = "0";
                    btn.ForeColor = Color.Red;
                    lblDisplay.Text = "X Turn Now";
                    player++;
                    turns++;
                }
                if (Draw() == true)
                {
                    lblDisplay.Text = "Draw Game";
                    MessageBox.Show("Game Draw, Click OK");
                    lblDisplay.Text = "Game Start";
                    D++;
                    ClearBoard();
                }
                if (GameWinner() == true)
                {
                    if (btn.Text == "X")
                    {
                        lblDisplay.Text = "X Won";
                        MessageBox.Show("X Won, Click OK");
                        lblDisplay.Text = "Game Start";
                        X++;
                        ClearBoard();
                    }
                    else
                    {
                        lblDisplay.Text = "O Won";
                        MessageBox.Show("O Won, Click OK");
                        lblDisplay.Text = "Game Start";
                        O++;
                        ClearBoard();
                    }
                }
            }
        }

        private void btnExitGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblX.Text = "X: " + X;
            lblO.Text = "O: " + O;
            lblDraw.Text = "Draw: " + D;
        }
        void ClearBoard()
        {
            player = 2;
            turns = 0;
            btn00.Text = btn01.Text = btn02.Text = btn10.Text = btn11.Text = btn12.Text = btn20.Text = btn21.Text = btn22.Text = "";
            lblX.Text = "X: " + X;
            lblO.Text = "O: " + O;
            lblDraw.Text = "Draw: " + D;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearBoard();
        }
        bool Draw()
        {
            if ((turns == 9) && GameWinner() == false)
                return true;
            else
                return false;
        }
        bool GameWinner()
        {
            //horizontal
            if ((btn00.Text == btn01.Text) && (btn01.Text == btn02.Text) && btn00.Text != "")
                return true;
            else if ((btn10.Text == btn11.Text) && (btn11.Text == btn12.Text) && btn10.Text != "")
                return true;
            else if ((btn20.Text == btn21.Text) && (btn21.Text == btn22.Text) && btn20.Text != "")
                return true;

            //vertical
            if ((btn00.Text == btn10.Text) && (btn10.Text == btn20.Text) && btn00.Text != "")
                return true;
            else if ((btn01.Text == btn11.Text) && (btn11.Text == btn21.Text) && btn01.Text != "")
                return true;
            else if ((btn02.Text == btn12.Text) && (btn12.Text == btn22.Text) && btn02.Text != "")
                return true;

            //diagonal
            if ((btn00.Text == btn11.Text) && (btn11.Text == btn22.Text) && btn00.Text != "")
                return true;
            else if ((btn02.Text == btn11.Text) && (btn11.Text == btn20.Text) && btn02.Text != "")
                return true;
            else return false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            X = O = D = 0;
            ClearBoard();
        }
    }
}
