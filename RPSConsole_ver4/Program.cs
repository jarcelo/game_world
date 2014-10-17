// region_ProgramDescription
// Name: Joseph M. Arcelo
// Date Created: September -, 2014
// Date Modified: September 22, 2014
// Version: 5.0
// Description: This version uses the revised RPS class that uses a 2 dimensional array to determine the outcome. 
//              Main has been revised and the DisplayOutcome method has been transferred to RPS class for reuse in Forms and WPF versions.          
//endRegion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary;

namespace RPSConsole_ver1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Show Welcome Message
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*          Welcome to Rock, Paper, Scissors Game!         *");
            Console.WriteLine("***********************************************************");
            Console.WriteLine();
            Console.WriteLine("TO PLAY: Press R=Rock, P=Paper, or S=Scissors");

            // Declare a variable for player input
            string playerInput = GetInput();

            do
            {
                // create a new game instance
                RPS play = new RPS();
                int player = GetPlayerChoice(playerInput);
                play.PlayerChoice = player; // invokes set accessor
                // get player choice
                int playerChoice = play.PlayerChoice;
                // validate player choice
                if (!(Enum.IsDefined(typeof(RPS.Choice), playerChoice)))
                {
                    Console.WriteLine("Please enter a valid input!");
                }
                else
                {
                    // get computer choice (Invokes the get accessor)
                    int computerChoice = play.ComputerChoice;
                    
                    // display player's choice 
                    string showPlayerChoice = play.DisplayChoice(playerChoice);
                    Console.WriteLine("Your Choice       : " + showPlayerChoice);
                    // display computer choice
                    string showComputerChoice = play.DisplayChoice(computerChoice);
                    Console.WriteLine("Computer's Choice : " + showComputerChoice);
                    // determine outcome
                    int outcome = play.DetermineOutcome();
                    // display outcome
                    Console.WriteLine("Game Result       : " + play.DisplayOutcome(outcome));
                }
                // prompt if player wants to play again
                Console.WriteLine();
                Console.WriteLine("Play again? Press 'R'=rock, 'P'=paper, 'S'=Scissors, or 'N' to exit game.");
                playerInput = GetInput();
                // confirm exit
                if (playerInput == "n" || playerInput == "N")
                {
                    Console.WriteLine("Press 'Y' to confirm exit or press 'R', 'P', 'S' to play again.");
                    playerInput = GetInput();
                }

             } while ((playerInput != "y") && (playerInput != "Y"));
        }
        // method to get player input (set to uppercase)
        private static string GetInput()
        {
            Console.WriteLine();
            Console.Write("Enter Choice: ");
            string input = "";
            input = (Console.ReadLine().ToUpper());
            return input;
        }
        // Method to get player choice
        public static int GetPlayerChoice(string choice)
        {
            int playerChoice = -1;

            switch (choice)
            {
                case "R":
                    playerChoice = (int)RPS.Choice.Rock;
                    break;
                case "P":
                    playerChoice = (int)RPS.Choice.Paper;
                    break;
                case "S":
                    playerChoice = (int)RPS.Choice.Scissors;
                    break;
            }
            return playerChoice;
        }

    } 
   
}
