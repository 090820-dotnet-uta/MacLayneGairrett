using System;
using System.Collections.Generic;
using P0.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace P0
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DbContextClass())
            {
                Customer currentCust = new Customer();//represents the current logged in user
                Store currentStore = new Store();//represents the store chosen by the user
                int locationChoice;
                int MainChoice;

                do //loop for start up, registering, and login.
                {

                    int choice = StartUp();

                    if (choice == 1)
                    {
                        Login(context, ref currentCust);
                    }
                    else if (choice == 2)
                    {
                        currentCust = Signup(context);
                    }
                    else if (choice == 0)
                    {
                        Environment.Exit(0);
                    }
                } while (currentCust.Username == null);//done with intial login/register loop

                Cart Usercart = GetCart();

                do
                {
                    locationChoice = LocationsMenu(context);
                    currentStore = context.Stores.Where(x => x.StoreId == locationChoice).FirstOrDefault();
                    MainChoice = UserChoice();
                    
                    if (MainChoice == 1)//shows products at this location 
                    {
                        ShowProducts(context, locationChoice, Usercart);
                    }
                    else if (MainChoice == 2)//see the past orders from this location or of current user.
                    {
                        double test = LocationOrdersMenu(locationChoice, context);
                    }
                    else if (MainChoice == 3)//checks cart or allows them to checkout
                    {
                        double cartTotal = ViewCart(Usercart);
                    }
                    else if (MainChoice == 4)
                    {
                        break;
                    }
                    

                } while ();
            
            }

        }
        public static int StartUp()
        {
            bool InputInt;
            int choice;

            do
            {
                Console.WriteLine("Welcome to SoccerWorld!\nThe best retail soccer stores in the US!");
                Console.WriteLine("For returning users type 1. For new users type 2. To leave the app type 0.");
                string input = Console.ReadLine();
                InputInt = int.TryParse(input, out choice);
            }
            while (!InputInt || choice <= 0 || choice >= 3);
            return choice;
        }//Prints start up screen, and recieves the input for login, register, or quit.

        public static Customer Signup(DbContextClass context)
        {
            //Try to send a new Customer into the DB
            string firstName;
            string lastName;
            string username;
            string password;

            do
            {
                Console.WriteLine("Welcome.\nTo register enter a username less than 15 characters, or 0 to exit.");
                username = Console.ReadLine().Trim();//To do: Make sure to add in an exception for usernames with too many characters
                if (username == "0")
                {
                    Environment.Exit(0);
                }
            }
            while (username.Length == 0 || username.Length > 15);
            {
                Console.WriteLine("Enter a username LESS than 15 characters.");
                username = Console.ReadLine().Trim();
            }

            int c;
            do
            {
                c = 0;
                foreach (var y in context.Customers.ToList())
                {
                    if (username == y.Username)
                    {
                        Console.WriteLine("This username is taken. Enter a different username.");
                        username = Console.ReadLine().Trim();
                        c = 1;
                        break;
                    }
                }
            } while (c == 1);

            do
            {
                Console.WriteLine("Enter your password.");
                password = Console.ReadLine().Trim();
            } while (password.Length == 0);

            do
            {
                Console.WriteLine("Enter your first name.");
                firstName = Console.ReadLine().Trim();
            } while (firstName.Length == 0);

            do
            {
                Console.WriteLine("Enter your last name.");
                lastName = Console.ReadLine().Trim();
            } while (lastName.Length == 0);

            Customer newUser= new Customer
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
            };
            context.Customers.Add(newUser);
            context.SaveChanges();
            return newUser;

        }
        public static void Login(DbContextClass context, ref Customer currentCust)
        {
            string userName;
            string Password;
            

            do
            {
                Console.WriteLine("Please enter your username, or 0 to exit.");
                userName = Console.ReadLine().Trim();
                if (userName == "0")
                {
                    Environment.Exit(0);
                }

                do
                {
                    Console.WriteLine("Please enter your password.");
                    Password = Console.ReadLine().Trim();
                } while (Password.Length == 0);

            } while (userName.Length == 0);

            var customer = context.Customers.FirstOrDefault(x => x.Username == userName && x.Password == Password);

            if (customer == null)
            {
                Console.WriteLine("Inccorrect username/password.");
                currentCust = new Customer();

            }
            else
            {
                Console.WriteLine("Congrats, you logged in.");
                currentCust = customer;
            }
        }

        public static int LocationsMenu(DbContextClass context)
        {
            int choice;
            bool inputInt;

            do
            {
                Console.WriteLine("Choose a store location from the list provided.");
                var stores = context.Stores;
                foreach (var store in stores)
                {
                    Console.WriteLine($"Store {store.StoreId} at {store.Address}");
                }

                string storeInput = Console.ReadLine();
                inputInt = int.TryParse(storeInput, out choice);
            } while (!inputInt || choice <= 0 || choice >= 5);

            return choice;
        }

        public static int UserChoice()
        {
            int choice;
            bool inputInt;
            do
            {
                Console.WriteLine("Choose an option for this location.\n1) View a list of available products at this store, and add products to your cart.\n2) View previous orders from this store or your previous orders.\n3) View your cart or checkout.\n4) Logout");
                string input = Console.ReadLine();
                inputInt = int.TryParse(input, out choice);
            } while (!inputInt || choice <= 0 || choice >= 6);

            return choice;
        }

        public static void ShowProducts(DbContextClass context, int LocationId, Cart userCart)
        {
            Console.WriteLine("Here is a list of items currently in stock. To add your item to your cart enter the Product ID, and to exit enter 0.");
            List<int> products = new List<int>();
            int choice1;
            int choice2;
            int ProdInCart = 0;
            int index = 0;
            bool inputInt1;
            bool inputInt2;
            
            

            foreach (var item in context.Products.Where(x => x.StoreId == LocationId))
            {
                Console.WriteLine($"Product ID: {item.ProductId}\n Product: {item.ProductTitle}\n {item.Quantity} left in stock.\n Price: {item.Price}");
            }
            do
            {
                do
                {
                    string input1 = Console.ReadLine();
                    inputInt1 = int.TryParse(input1, out choice1);

                    if (choice1 == 0)
                    {
                        break;
                    }

                    foreach (var item in context.Products)//Creates the list of products
                    {
                        products.Add(item.ProductId);
                    }

                    if (!products.Contains(choice1))
                    {
                        Console.WriteLine("Please enter a valid Product ID.");
                    }
                } while (!inputInt1 || !products.Contains(choice1));//This loop will make sure the user enters a valid product id

                if (choice1 != 0)
                {
                    var item = context.Products.Find(choice1);//taking the product id entered

                    do
                    {
                        Console.WriteLine("How many of that product would you like to add to your cart?");
                        string input2 = Console.ReadLine();
                        inputInt2 = int.TryParse(input2, out choice2);

                        if (choice2 < 0 || choice2 > item.Quantity)
                        {
                            Console.WriteLine("Sorry, but we do not have that many in stock.");
                        }

                        if (userCart.ProdIds.Contains(choice1))
                        {
                            for (int x = 0; x < userCart.ProdIds.Count(); x++)
                            {
                                if (userCart.ProdIds[x] == choice1)
                                {
                                    index = x;
                                    break;
                                }
                            }

                            ProdInCart = userCart.OrderQuantity[index] + choice2;
                            if (ProdInCart > item.Quantity)
                            {
                                Console.WriteLine("Your cart exceeds our inventory. Try a smaller quantity.");
                            }
                        }
                    } while (!inputInt2 || choice2 < 1 || choice2 > item.Quantity || ProdInCart > item.Quantity);

                    if (choice2 != 0)
                    {
                        if (userCart.ProdIds.Contains(choice1))
                        {
                            userCart.OrderQuantity[index] += choice2;
                        }
                        else//adding the new product to the current cart
                        {
                            userCart.ProdIds.Add(item.ProductId);
                            userCart.ProdPrice.Add(item.Price);
                            userCart.LocationIds.Add(LocationId);
                            userCart.ProdTitle.Add(item.ProductTitle);
                            userCart.OrderQuantity.Add(choice2);
                        }

                        userCart.Total = 0;//this is going to reset the total cost in the cart
                        for (int x = 0; x < userCart.ProdIds.Count(); x++)
                        {
                            userCart.Total += userCart.OrderQuantity[x] * userCart.ProdPrice[x];
                        }

                        Console.WriteLine($"The total cost of your current cart is ${Math.Round(userCart.Total, 2)}");
                    }

                    Console.WriteLine("Would you like to order something else? If not you can return by entering 0.");
                }

            } while (choice1 != 0);

        }
        public static Cart GetCart()
        {
            Cart Usercart = new Cart();
            List<int> productList = new List<int>();
            List<int> Locationids = new List<int>();
            List<int> Quantity = new List<int>();
            List<double> PriceList = new List<double>();
            List<string> prodTitle = new List<string>();

            Usercart.ProdIds = productList;
            Usercart.LocationIds = Locationids;
            Usercart.OrderQuantity = Quantity;
            Usercart.ProdPrice = PriceList;
            Usercart.ProdTitle = prodTitle;

            return Usercart;

        }

        public static double LocationOrdersMenu(DbContextClass context,  int locationId)
        {
            int choice1;
            bool inputInt1;

            do
            {
                Console.WriteLine($"1) View the order history for this location.\n2) Exit.");
                string input = Console.ReadLine();
                inputInt1 = int.TryParse(input, out choice1);
            } while (!inputInt1 || choice1 <= 0 || choice1 >= 3);

            if (choice1 == 1)
            {
                var location = context.Stores.Find(locationId);
                string locationName = location.Location;

                Console.WriteLine($"This is a list of of products ordered from our store in {locationName}.");
                var pastOrders = context.Orders.Where(x => x.LocationId == locationId).AsNoTracking();
                double TotalProfit = 0;
                using (var context2 = new DbContextClass())
                {

                    foreach (var i in pastOrders)
                    {
                        var prod = context2.Products.Find(i.ProductId);
                        Console.WriteLine($"Product: {prod.ProductTitle}\t Price: {prod.Price}\t Ordered at: {i.CheckoutTime}\t Ordered by: {i.CustomerId}");
                        TotalProfit += prod.Price;
                    }
                }  
                 Console.WriteLine($"The total profit from this location is ${Math.Round(TotalProfit, 2)}");
                 return TotalProfit;
            }

            if (choice1 == 2)
            {
                Environment.Exit(0);
            }
            return 0;        
        } 

        public static double ViewCart(Cart Usercart)
        {
            Usercart.Total = 0;//resets the costs in the cart
            for (int x = 0; x < Usercart.ProdIds.Count(); x++)
            {
                Usercart.Total += Usercart.OrderQuantity[x] * Usercart.ProdPrice[x];
            }
            for (int i = 0; i < Usercart.ProdIds.Count(); i++)
            {
                Console.WriteLine($"\t{Usercart.OrderQuantity[i]}x {Usercart.ProdTitle[i]}");
            }
            double cartTotal = Math.Round(Usercart.Total, 2);
            Console.WriteLine($"The total cost of the products currently in your cart is {cartTotal}.");
            return cartTotal;
        }

    }       
        
}
