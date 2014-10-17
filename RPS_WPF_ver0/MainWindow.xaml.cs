using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameLibrary;

namespace RPS_WPF_ver0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RPS play;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRock_Click(object sender, RoutedEventArgs e)
        {
            play = new RPS();
            play.PlayerChoice = (int)RPS.Choice.Rock;
            PlayGame();
        }

        private void btnPaper_Click(object sender, RoutedEventArgs e)
        {
            play = new RPS();
            play.PlayerChoice = (int)RPS.Choice.Paper;
            PlayGame();
        }

        private void btnScissors_Click(object sender, RoutedEventArgs e)
        {
            play = new RPS();
            play.PlayerChoice = (int)RPS.Choice.Scissors;
            PlayGame();
        }

        private void PlayGame()
        {
            string playerChoice = play.DisplayChoice(play.PlayerChoice);
            string computerChoice = play.DisplayChoice(play.ComputerChoice);
            tbDisplayChoice.Text = playerChoice + "\r\n" + "\r\n" + computerChoice;
            int outcome = play.DetermineOutcome();
            string showOutcome = play.DisplayOutcome(outcome);
            tbResult.Text = showOutcome;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
       
    }
}
