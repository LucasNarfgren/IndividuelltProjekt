using System;
using System.Collections.Generic;

namespace IndividuelltProjekt
{
    class Program
    {

        static void Main(string[] args)
        {
            List<User> Users = new List<User>();
            Users.Add(new User("Lucas", "Privat-Konto", "Spar-Konto", 1234, 25000.50));
            Users.Add(new User("Johnny", "Privat-Konto", "Spar-Konto", 1234, 25000.50));
            Users.Add(new User("Conny", "Privat-Konto", "Spar-Konto", 1234, 25000.50));
            Users.Add(new User("Ronny", "Privat-Konto", "Spar-Konto", 1234, 25000.50));
            Users.Add(new User("Lenny", "Privat-Konto", "Spar-Konto", 1234, 25000.50));

            //foreach (var User in Users)
            //{
            //    Console.WriteLine(User.UserName);
            //}

            //for (int i = 0; i < Users.Count; i++)
            //{
            //    Console.WriteLine(Users[i].UserName + " " + Users[i].AccountName); 

            //}

            int menu = 0;

            Console.Clear();
            Console.WriteLine("Välkommen till ALN Banken.");
            do
            {
                try
                {
                    Console.WriteLine("1. Logga in");
                    Console.WriteLine("2. Skapa konto");
                    menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Login(Users);
                            break;
                        case 2:
                            Users = CreateAccount(Users);
                            break;
                        default:
                            break;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltligt Val");
                }

            } while (menu != 0);
        }
        
        public static void Login(List<User> Users) // funktion för att logga in.
        {
            
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Logga in på ett konto");
                    Console.Write("Användarnamn: ");
                    string UserInput = Console.ReadLine();
                    
                    break;
                    
                }
                catch(FormatException)
                {
                    Console.WriteLine("Ogiltigt Val");
                }

            } while (true);
            do
            {
                try
                {
                    Console.Write("Pinkod: ");
                    int PinLogin = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltigt Val");
                }
            } while (true);

            LoggedIn(Users);

        }
        public static void LoggedIn(List<User> Users) //login screen.
        {
            int menu = 0;

            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Inloggad som: {0}");
                    Console.WriteLine();
                    Console.WriteLine("1. Mina Konton");
                    Console.WriteLine("2. Överför till Konto");
                    Console.WriteLine("3. Ta ut pengar");
                    Console.WriteLine("4. Logga ut");
                    menu = int.Parse(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Ogiltligt Val");
                }


                switch (menu)
                {
                    case 1:
                        //PrintCurrentAccountInfo(Users);
                        Console.WriteLine(Users[1].UserName);
                        //foreach (var user in Users)
                        //{
                        //    Console.WriteLine(user.UserName);
                        //}
                        Console.ReadKey();
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }


            } while (menu != 0);




            Console.ReadKey();
        } 
        public static void Logout() // Funktion för att logga ut.
        {
            
        }
        public static List<User> CreateAccount(List<User> CurrentUsers) // Funktion för att skapa konto.
        {
            
            //string UserName = "";
            //int PinCode = 0;
            //int CheckPin = 0;

            User NewUser = new User();

            do
            {
                
                Console.Clear();
                Console.WriteLine("Skapa Konto");
                try
                {
                    Console.Write("Användarnamn: ");
                    NewUser.UserName = Console.ReadLine();
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltligt användarnamn.");
                    Console.ReadKey();
                }
            } while (true);

            do
            {

                try
                {
                    
                    Console.Write("Pinkod: ");
                    NewUser.PinCode = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltlig pinkod");
                    
                }
            } while (true);

            do
            {
                try
                {
                    
                    Console.Write("Verifiera pinkod: ");
                    int CheckPin = int.Parse(Console.ReadLine());
                    if(CheckPin == NewUser.PinCode)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pinkod är inte samma");
                    }
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltlig Pinkod.");                    
                }

                Console.WriteLine();
                Console.WriteLine("Välkommen till ALN Bank {0}!", NewUser.UserName);
                



            } while (true);
            
            Console.ReadKey();

            NewUser.AccountName = "Privat-Konto";
            NewUser.AccountName = "Spar-Konto";
            NewUser.Balance = 25000.50;

            CurrentUsers.Add(NewUser);
            return CurrentUsers;
            

        }
        public static void PrintCurrentAccountInfo(List<User> Users) // Funktion för att skriva ut information om inloggat account.
        {

            foreach (var item in Users)
            {
                Console.WriteLine(item);
            }
        }
        public static void WithdrawCurrency() // Funktion för att ta ut pengar. 
        {

        }
        public static void TransferCurrency() // Funktion för att flytta pengar över konton.
        {

        }
        
    }

    class User  // En Klass eller Objekt för Användare.
    {
        private string username;
        private string accountname = "Privat-Konto";
        private string accountname2 = "Spar-Konto";
        private int pincode;
        private double balance;


        public User(string _UserName="", string _AccountName="Privat-Konto", string _AccountName2="Spar-Konto", int _PinCode = 1234, double _Balance=25050.59)
        {
            this.UserName = _UserName;
            this.PinCode = _PinCode;
            this.AccountName = _AccountName;
            this.AccountName2 = _AccountName2;
            this.Balance = _Balance;
        }
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string AccountName
        {
            get { return accountname; }
            set { accountname = value; }
        }
        public string AccountName2
        {
            get { return accountname2; }
            set { accountname2 = value; }
        }
        public int PinCode
        {
            get { return pincode; }
            set { pincode = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
    } 
}
