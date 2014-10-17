using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPSConsole_ver1
{

    class RPS
    {
        public enum Choice { Rock = 1, Paper = 2, Scissors = 3}
        public enum Outcome { Win = 10, Lose = 11, Draw = 12}
        // create a constructor
        private string resultsFileName;
        private int Computer;
        private int Player;

        public RPS()
        {
            Player = 0;
            Computer = 0;
            resultsFileName = "../../RPSresults.txt";
        }

        // define player's choice field and property
        private int playerChoice; 
        public int PlayerChoice
        {
            get { return playerChoice; }
            set {playerChoice = value; }
        }

        // get computer's choice (initiate a random number).
        private static readonly Random num = new Random();
        int computerChoice = num.Next(3) + 1;
        public int ComputerChoice
        {
            // computer choice is set to read-only
            get { return computerChoice; }
        }

 
        // Method to get player choice
        public int GetPlayerChoice(string choice)
        {
            int playerChoice = -1;
            
            switch (choice)
            {
                case "R":
                    playerChoice = (int)Choice.Rock;
                    break;
                case "P":
                    playerChoice = (int)Choice.Paper;
                    break;
                case "S":
                    playerChoice = (int)Choice.Scissors;
                    break;
            }
            return playerChoice;
        }

        // method to display choice 
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

        // Method to record the results 
        private void RecordResults()
        {
            try
            {
                // Declare a StreamWriter variable.
                StreamWriter outputFile;
                // Create a file and get a StreamWriter object.
                outputFile = File.AppendText(resultsFileName);
                outputFile.WriteLine(PlayerChoice);
                outputFile.WriteLine(ComputerChoice);
                // Call the Determine outcome method to get the outcome
                outputFile.WriteLine(DetermineOutcome());
                // Close the file.
                outputFile.Close();
            }
            catch (Exception ex)
            {
                // Display an error message.
                Console.WriteLine(ex.Message);
            }
        }

        // Method to read results total. Set to private.
        private int ReadResultsTotal(int results)
        {
            // Variables to hold the numbers read from the file and total
            int number, resultsTotal = 0;
            try
            {
                // Declare a streamReader variable.
                StreamReader inputFile;
                // Open the file and get a StreamReader object.
                inputFile = File.OpenText(resultsFileName);
                // Read entire contents of the file
                string line;
                while (!inputFile.EndOfStream)
                {
                    // Read results from the file.
                    line = inputFile.ReadLine();
                    number = int.Parse(line);
                    // accumulate the count of the numbers.
                    if (number == results)
                        ++resultsTotal;
                }
                // Close the file.
                inputFile.Close();
            }
            catch (Exception ex)
            {
                // Display an error message.
                Console.WriteLine(ex.Message);  
            }
            return resultsTotal;
        }

        public string ShowResultStats()
        {
            RecordResults();
            string result = "";
            // Declare variables to count wins, losses, draws. throws and games.
            int winCount = 0, loseCount = 0, drawCount = 0,
                throwCount = 0, gameCount = 0;
            // Determine numbes of wins, losses and draws.
            winCount = ReadResultsTotal((int)Outcome.Win);
            loseCount = ReadResultsTotal((int)Outcome.Lose);
            drawCount = ReadResultsTotal((int)Outcome.Draw);
            // Compute numbers of throws.
            throwCount = winCount + loseCount + drawCount;
            // Compute number of games.
            gameCount = winCount + loseCount;
            // display outcome statistics
            result = "WINS: " + winCount + ", LOSSES: "+ loseCount +", DRAWS: "+ drawCount+", THROWS: "+ throwCount + ", GAMES: " + gameCount;
            return result;
        }
  
    }
}
