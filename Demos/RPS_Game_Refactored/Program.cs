using System;
using System.Collections.Generic;
using System.Linq;

namespace RPS_Game_Refactored
{
    public enum Choice
    {
        Rock,//can be accessed with a 0
        Paper,//can be accessed with a 1
        Scissors//can be accessed with a 2
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Lists to hold the game data
            List<Player> players = new List<Player>();
            List<Game> games = new List<Game>();
            List<Round> rounds = new List<Round>();

            int choice;//this is be out variable choice of the player to 1 (play) or 2 (quit)
            Player computer = new Player() { Name = "Computer" };//instantiate a Player and give a value to the Name all at once.
            players.Add(computer);//add the computer to List<Player> players
            int gameCounter = 1;//to keep track of how many games have been played so far in this compilation

            do//game loop
            {
                choice = RpsGameMethods.GetUsersIntent();//get a choice from the user (play or quit)
                if (choice == 2) { break; }  //if the user chose 2, break out of the game.

                System.Console.WriteLine($"\n\t\tThis is game #{gameCounter++}\n");

                string playerName = RpsGameMethods.GetPlayerName();//get the player name. this is a place to make sure the user isn't using forbidden words or symbols

                Player p1 = RpsGameMethods.VerifyPlayer(players, playerName);

                Game game = new Game();// create a game
                game.Player1 = p1;//
                game.Computer = computer;//

                //play rounds till one player has 2 wins
                //assign the winner to the game and check that property to break out of the loop.
                while (game.winner.Name == "null")
                {
                    Round round = new Round();//declare a round for this iteration
                    round.game = game;// add the game to this round
                    round.player1 = p1;// add user (p1) to this round
                    round.Computer = computer;// add computer to this round

                    //get the choices for the 2 players
                    //insert the players choices directly into the round
                    int rpsChoice;
                    bool p1Choicebool;
                    do
                    {
                        System.Console.WriteLine("Do you want to choose rock{0}, paper{1}, or scissors{2}?");
                        string userChoice = Console.ReadLine();
                        p1Choicebool = int.TryParse(userChoice, out rpsChoice);//followed the same kind of format we used for pick 1 to play and 2 for quit.  
                    } while(!p1Choicebool || rpsChoice < 0 || rpsChoice > 2);//this will allow the user to pick his/her choice for rock, paper or scissors.
                    
                    round.p1Choice = (Choice)rpsChoice;
                    round.ComputerChoice = RpsGameMethods.GetRandomChoice();

                    RpsGameMethods.GetRoundWinner(round);//check the choices to see who won.
                    game.rounds.Add(round);//add this round to the games List of rounds

                    //search the game.rounds List<> to see if one player has 2 wins
                    //if not loop to another round
                    System.Console.WriteLine($"\tFor this Game so far:\n\t\tp1wins => {game.rounds.Count(x => x.Outcome == 1)} \n\t\tcomputer wins {game.rounds.Count(x => x.Outcome == 2)}");

                    int whoWon = RpsGameMethods.GetWinner(game);
                    //assign the winner to the game and increment wins and losses for both
                    if (whoWon == 1)
                    {
                        game.winner = p1;
                        p1.record["wins"]++;//increments wins and losses.
                        computer.record["losses"]++;//increments wins and losses.
                        System.Console.WriteLine($"\tThe winner of this game was Player1\n");
                    }
                    else if (whoWon == 2)
                    {
                        game.winner = computer;
                        p1.record["losses"]++;//increments wins and losses.
                        computer.record["wins"]++;//increments wins and losses.
                        System.Console.WriteLine($"\tThe winner of this game was the computer\n");
                    }
                }//end of rounds loop

                games.Add(game);
            } while (choice != 2);//end of game loop

            RpsGameMethods.PrintAllCurrentData(games, players, rounds);
        }//end of main
    }//end of program
}//end of namaespace
