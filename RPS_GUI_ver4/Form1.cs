/*  Name: Joseph Arcelo
 *  Date: September 30, 2014
 *  Revised: October 17, 2014
 *  Version: 2.0
 *  Description: This is RPS GUI version that allows the user to click on buttons to pick their choices. The textbox will
 *               then show both the user and computer choices, and then display the result in another textbox.
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GameLibrary
{
    public partial class Form1 : Form
    {
        RPS play;
        public Form1()
        {
            InitializeComponent();
        }
        // player chooses Rock
        private void btnRock_Click(object sender, EventArgs e)
        {
            play = new RPS();
            play.PlayerChoice = (int)RPS.Choice.Rock;
            PlayGame();
        }
        // player chooses Paper
        private void btnPaper_Click(object sender, EventArgs e)
        {
            play = new RPS();
            play.PlayerChoice = (int)RPS.Choice.Paper;
            PlayGame();
        }
        // player chooses Scissors
        private void btnScissors_Click(object sender, EventArgs e)
        {
            play = new RPS();
            play.PlayerChoice = (int)RPS.Choice.Scissors;
            PlayGame();
        }
        private void PlayGame()
        {
            string playerChoice = play.DisplayChoice(play.PlayerChoice);
            string computerChoice = play.DisplayChoice(play.ComputerChoice);
            tbDisplayChoices.Text =  playerChoice + "\r\n" + "\r\n" + computerChoice;
            int outcome = play.DetermineOutcome();
            string showOutcome = play.DisplayOutcome(outcome);
            tbResult.Text = "\r\n" + showOutcome;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
