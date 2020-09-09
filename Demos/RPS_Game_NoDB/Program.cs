using System;
using System.Collections.Generic;
using System.Linq;

namespace RPS_Game_NoDB
{
    class Program
    {
        public enum Choice
        {
            Rock,//can be accessed with a 0
            Paper,//can be accessed with a 1
            Scissors//can be accessed with a 2
        }
        static void Main(string[] args)
        {

            List<Player> players = new List<Player>();
            List<Game> games = new List<Game>();
            List<Round> rounds = new List<Round>();
            int choice;

            do//game loop
            {
                //get a choice from the user (play or quit)
                bool inputInt;
                do//prompt loop
                {
                    System.Console.WriteLine("Please choose 1 for Play or 2 for Quit");
                    string input = Console.ReadLine();
                    inputInt = int.TryParse(input, out choice);
                } while (!inputInt || choice <= 0 || choice >= 3);//end of promt loop

                if (choice == 2)//if the user chose 2, break out of the game.
                {
                    break;
                }
                //System.Console.WriteLine("made it out of the loop");

                //get the player name
                System.Console.WriteLine("What is your name?");
                string playerName = Console.ReadLine();
                Player p1 = new Player();//p1 is null here.

                Player computer = new Player() { Name = "Computer" };//instantiate a Player and give a value to the Name all at once.

                // check the list of players to see if this payer is a returning player.
                foreach (Player item in players)
                {
                    if (item.Name == playerName)
                    {
                        p1 = item;
                        System.Console.WriteLine("You are a returning player");
                        break;
                    }
                }

                if (p1.Name == "null")
                {
                    p1.Name = playerName;
                }

                Game game = new Game();
                game.Player1 = p1;
                game.Computer = computer;

                Random rand = new Random();

                //play rounds till one player has 2 wins
                //assign the winner to the game and check that property to break out of the loop.
                while (game.winner.Name == "null")
                {
                    Round round = new Round();//declare a round for this iteration
                    round.game = game;

                    //get the choices for the 2 players
                    Choice p1Choice = (Choice)rand.Next(3);//this will give a randonm number starting at 0 to arg-1;
                    Choice computerChoice = (Choice)rand.Next(3);

                    if (p1Choice == computerChoice)
                    {
                        rounds.Add(round);
                        game.rounds.Add(round);
                        continue;
                    }
                    else if ((int)computerChoice == ((int)p1Choice + 1 % 3))//Alex will show this method after 2.
                    {

                        // Rock,//can be accessed with a 0
                        // Paper,//can be accessed with a 1
                        // Scissors//can be accessed with a 2
                    }

                    // (round.PlayerChoice == Choice.ROCK && round.ComputerChoice == Choice.SCISSORS
                    // || round.PlayerChoice == Choice.PAPER && round.ComputerChoice == Choice.ROCK
                    // || round.PlayerChoice == Choice.SCISSORS && round.ComputerChoice == Choice.PAPER)






                    game.winner.Name = "mark";






                    //evaluate a winner of the round


                    //set the outcome variable to 1(player1 wins), or 2(player2 wins) or leave it at 0.


                    //add the round to the List<> of rounds

                    //add the round to the game.

                    //search the game.rounds List<> to see if one player has 2 wins
                    //if not loop to another round


                }



















                //create a game

                //play rounds till one player has 2 wins
                //record each round into the game

                //record the game

                //increment wins/losses for each player

                //print out the game results - rounds data



            } while (choice != 2);//end of game loop






            //on quitting....
            //print out the win.loss record for all players












        }
    }
}
