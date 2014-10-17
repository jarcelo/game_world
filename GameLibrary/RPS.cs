using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace GameLibrary
{
    public class RPS
    {
        public enum Choice {Rock = 0, Paper = 1, Scissors = 2}
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
        private int computerChoice = num.Next(3);
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

        // display the game outcome
        public string DisplayOutcome(int outcome)
        {
            string result = "";
            switch (outcome)
            {
                case (int)Outcome.Win:
                    result = "You Win!";
                    break;
                case (int)Outcome.Lose:
                    result = "You Lose!";
                    break;
                case (int)Outcome.Draw:
                    result = "It's a Draw!";
                    break;
            }
            return result;
        }

         // Determine outcome using 2D Array
        public int DetermineOutcome()
        {
            int result;
            int[,] selection = new int[3, 3] {  {(int)Outcome.Draw,(int)Outcome.Lose,(int)Outcome.Win},
                                                {(int)Outcome.Win,(int)Outcome.Draw,(int)Outcome.Lose},
                                                {(int)Outcome.Lose,(int)Outcome.Win,(int)Outcome.Draw}  };
            result = selection[PlayerChoice, ComputerChoice];
            return result;
        }
  
    }
}
