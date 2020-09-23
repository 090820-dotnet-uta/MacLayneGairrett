using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RPS_Game_Refactored.Models
{
    class DbContextClass : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured){
                options.UseSqlServer("Data Source=LAPTOP-QL1LQFMH;Initial Catalog=RPS_DB;Integrated Security=True");
            }

        }

    }
}
