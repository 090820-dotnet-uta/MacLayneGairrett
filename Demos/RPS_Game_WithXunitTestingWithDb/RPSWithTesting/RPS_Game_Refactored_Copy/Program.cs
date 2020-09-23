using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using RPS_Game_Refactored.Models;

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
            using (var context = new DbContextClass())
            {
                Console.WriteLine("Enter 10 to start wtih a fresh Db or anything else to play with the existing records.");
                string userInput = Console.ReadLine();
                int usersNumber;
                if(int.TryParse(userInput,out usersNumber))
                {
                    if (usersNumber == 10) 
                    {
                        context.Games.FromSqlRaw("TRUNCATE TABLE Games");
                        context.Rounds.FromSqlRaw("TRUNCATE TABLE Rounds");
                        context.Players.FromSqlRaw("DELETE FROM Players WHERE PlayerId > 0 AND PlayerId < 100");
                    }
                }

                int choice;//this is be out variable choice of the player to 1 (play) or 2 (quit)
                Player computer = new Player() { Name = "Computer" };//instantiate a Player and give a value to the Name all at once.
                
                //Try to find an existing player named computer
                if(context.Players.Any(x => x.Name == "Computer"))
                {
                    computer = context.Players.Where(x => x.Name == "Computer").FirstOrDefault();
                }
                else
                {
                    computer.Name = "Computer";
                    context.Players.Add(computer);
                    context.SaveChanges();
                }
                

                int gameCounter = 1;//to keep track of how many games have been played so far in this compilation

                do//game loop
                {
                    choice = RpsGameMethods.GetUsersIntent();//get a choice from the user (play or quit)
                    if (choice == 2) { break; }  //if the user chose 2, break out of the game.

                    Console.WriteLine($"\n\t\tThis is game #{gameCounter++}");

                    string playerName = RpsGameMethods.GetPlayerName();//get the player name. this is a place to make sure the user isn't using forbidden words or symbols

                    // if the player name is not already in the Db, add him
                    Player p1 = new Player();
                    if(!RpsGameMethods.VerifyPlayer(context.Players.ToList(), playerName))
                    {
                        p1.Name = playerName;
                        context.Add(p1);
                        context.SaveChanges();
                    }
                    else{   p1 = context.Players.Where(x => x.Name == playerName).FirstOrDefault();   }

                    Game game = new Game();// create a game
                    game.Player1 = p1;//
                    game.Computer = computer;//

                    //play rounds till one player has 2 wins
                    //assign the winner to the game and check that property to break out of the loop.
                    while (game.winner.Name == "null")
                    {
                        Round round = new Round();//declare a round for this iteration
                        round.player1 = p1;// add user (p1) to this round
                        round.Computer = computer;// add computer to this round

                        //get the choices for the 2 players and insert the players choices directly into the round
                        round.p1Choice = RpsGameMethods.GetRandomChoice();//this will give a random number starting at 0 to arg-1;
                        round.ComputerChoice = RpsGameMethods.GetRandomChoice();
                        round.Outcome = RpsGameMethods.GetRoundWinner(round);//check the choices to see who won.
                        context.Add(round);
                        context.SaveChanges();
                        game.rounds.Add(round);//add this round to the games' List of rounds
                        
                        Console.WriteLine($"\tFor this Game so far:\n\t\tp1wins => {game.rounds.Count(x => x.Outcome == 1)} \n\t\tcomputer wins {game.rounds.Count(x => x.Outcome == 2)}");

                        int gameWinner = RpsGameMethods.GetWinner(game);//get a number ot say is p1(1) or computer(2) won
                        //assign the winner to the game and increment wins and losses for both
                        if (gameWinner == 1)
                        {
                            game.winner = p1;
                            p1.Wins++;//increments wins and losses.
                            computer.Losses++;//increments wins and losses.
                            Console.WriteLine($"The winner of this game was Player1\n");
                        }
                        else if (gameWinner == 2)
                        {
                            game.winner = computer;
                            p1.Losses++;//increments wins and losses.
                            computer.Wins++;//increments wins and losses.
                            Console.WriteLine($"The winner of this game was the computer\n");
                        }
                    }//end of rounds loop
                    context.Add(game);//save the game
                    context.SaveChanges();
                } while (choice != 2);//end of game loop
                RpsGameMethods.PrintAllCurrentData(context.Games.ToList(), context.Players.ToList(), context.Rounds.ToList());
            }
        }//end of main
    }//end of program
}//end of namaespace
