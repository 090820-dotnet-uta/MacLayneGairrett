using System.Collections.Generic;

namespace RPS_Game_NoDB
{
    public class Player
    {
        public string Name { get; set; } = "null";

        //public string name;
        //private string name;
        // public void SetName(string name){
        //     this.name = name;
        // }



        List<Game> games = new List<Game>();
        Dictionary<string, int> record = new Dictionary<string, int>();
        //"wins" = 2
        //"losses" = 3
        //record."wins"++;

    }
}