using System;
using System.Collections.Generic;
using System.Text;
using P0;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P0.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{CustomerId}\n{FirstName}\n{LastName}\n{Username}\n{Password}";
        }
    }
}
