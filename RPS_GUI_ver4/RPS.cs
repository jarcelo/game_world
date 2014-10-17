using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPS_GUI_ver2
{
    class RPS
    {
        public enum Choice {Rock = 1, Paper = 2, Scissors = 3}
        public enum Outcome {Win = 10, Lose = 11, Draw = 12}
        // create a constructor
        public RPS() { }
        // define player's choice field and property
        int playerChoice; 
        public int PlayerChoice
        {
            get { return playerChoice; }
            set { playerChoice = value; }
        }
        // get computer's choice (initiate a random number).
        private static readonly Random num = new Random();
        private int computerChoice = num.Next(3) + 1;
        public int ComputerChoice
        {
            // computer choice is set to read-only
            get { return computerChoice; }
        }
 
        public string DisplayChoice(int choice)
        {
            string show = "";
            switch (choice)
            {
                case (int)Choice.Rock:
                    show = "ROCK";
                    break;
                case (int)Choice.Paper:
                    show = "PAPER";
                    break;
                case (int)Choice.Scissors:
                    show = "SCISSORS";
                    break;
            }
            return show;
        }

        // method to determine winner
        public int DetermineOutcome()
        {
            int outcome = 0;         
            //if (computerChoice == playerChoice)
            if (ComputerChoice == PlayerChoice)
            {
                outcome = (int)Outcome.Draw;
            }
            else 
            {
                // check for instances where player wins
                if ((ComputerChoice == (int)Choice.Rock && PlayerChoice == (int)Choice.Paper)
                || (ComputerChoice == (int)Choice.Paper && PlayerChoice == (int)Choice.Scissors)
                || (ComputerChoice == (int)Choice.Scissors && PlayerChoice == (int)Choice.Rock))
                {
                    outcome = (int)Outcome.Win;
                }
                else
                {
                    outcome = (int)Outcome.Lose;
                }
            }
            return outcome;
        }

        public string DisplayOutcome()
        {
            int outcome = DetermineOutcome();
            string show = "";
            switch (outcome)
            {
                case (int)Outcome.Win:
                    show = "You Win!";
                    break;
                case (int)Outcome.Lose:
                    show = "You Lose!";
                    break;
                case (int)Outcome.Draw:
                    show = "It's a Draw!";
                    break;
            }
            return show;
        }
  
    }
}
