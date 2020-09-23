using System;
using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;//use this if you want to sopecify which property will be the Primary Key

namespace RPS_Game_Refactored
{
    public class Round
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoundId { get; set; }
        public Player player1 { get; set; }
        public Player Computer { get; set; }
        public Choice p1Choice { get; set; }
        public Choice ComputerChoice { get; set; }
        public int Outcome { get; set; } = 0; //0 == Tie, 1 ==P1 wins, 2 == computer wins
        //public Game game { get; set; }
    }
}