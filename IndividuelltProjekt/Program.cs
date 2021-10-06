using System;
using System.Collections.Generic;

namespace IndividuelltProjekt
{
    class Program
    {

        static void Main(string[] args)
        {
            List<User> Users = new List<User>();
            Users.Add(new User("Lucas", "Privat-Konto", "Spar-Konto", 1337, 56000.56,0));
            Users.Add(new User("Johnny", "Privat-Konto", "Spar-Konto", 1234, 44500.50,0));
            Users.Add(new User("Conny", "Privat-Konto", "Spar-Konto", 1234, 106708.50,0));
            Users.Add(new User("Ronny", "Privat-Konto", "Spar-Konto", 1234, 1000506.50,0));
            Users.Add(new User("Lenny", "Privat-Konto", "Spar-Konto", 1234, 150,0));

            //foreach (var User in Users)
            //{
            //    Console.WriteLine(User.UserName);
            //}

            //for (int i = 0; i < Users.Count; i++)
            //{
            //    Console.WriteLine(Users[i].UserName + " " + Users[i].AccountName); 

            //}

            int menu = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Välkommen till ALN Banken.");
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
                    Console.ReadKey();
                }

            } while (true);
        }
        
        public static void Login(List<User> Users) // funktion för att logga in.
        {
            string userinput;
            int pincode;
            
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Logga in på ett konto");
                    Console.Write("Användarnamn: ");
                    userinput = userinput = Console.ReadLine();
                    
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
                    pincode = pincode = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltigt Val");
                }
            } while (true);

            bool loggedin = false;
            foreach (var user in Users)
            {


                if (userinput == user.UserName && pincode == user.PinCode)
                {
                    loggedin = true;
                    LoggedIn(Users,userinput);
                }

            }
            if(loggedin == false)
            {
                Console.WriteLine("Fel Användarnamn eller pinkod.");
            }
            Console.ReadKey();

             

            

        }
        public static void LoggedIn(List<User> Users,string CurrentUser) //login screen.
        {

            int menu = 0;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Inloggad som {0}!", CurrentUser);
                    Console.WriteLine();
                    Console.WriteLine("1. Mina Konton");
                    Console.WriteLine("2. Överför mellan Konton");
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
                        
                        Console.Clear();
                        foreach (var user in Users)
                        {
                            if (CurrentUser == user.UserName)
                            {
                                Console.WriteLine(user.AccountName + " : " +  user.Balance);
                                Console.WriteLine(user.AccountName2 + " : " + user.Balance2);
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 2:

                        TransferCurrency(Users,CurrentUser);

                        break;
                    case 3:
                        WithdrawCurrency(Users,CurrentUser);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Du är nu utloggad.");
                        Console.ReadKey();
                        Main(null);
                        break;
                }


            } while (menu != 0);




            Console.ReadKey();
        } 
        public static List<User> CreateAccount(List<User> CurrentUsers) // Funktion för att skapa konto.
        {

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
            } while (true);

            Console.Clear();
            Console.WriteLine("Välkommen till ALN Banken {0}!", NewUser.UserName);
            Console.ReadKey();

            NewUser.AccountName = "Privat-Konto";
            NewUser.AccountName2 = "Spar-Konto";
            NewUser.Balance = 25000.50;
            NewUser.Balance2 = 0;

            CurrentUsers.Add(NewUser);
            return CurrentUsers;
            

        }
        public static void PrintCurrentAccountInfo() // Funktion för att skriva ut information om inloggat account.
        {

        }
        public static void WithdrawCurrency(List<User> Users, string CurrentUser) // Funktion för att ta ut pengar. 
        {
            Console.WriteLine("Hur mycket pengar vill du ta ut?");
            int userinput = int.Parse(Console.ReadLine());
            foreach (var user in Users)
            {
                if(CurrentUser == user.UserName)
                {
                    user.Balance = user.Balance - userinput;
                    break;
                }
            }

            Console.WriteLine("Du har nu tagit ut {0} från ditt privatkonto.", userinput);
            Console.ReadKey();
        }
        public static void TransferCurrency(List<User> Users,string CurrentUser) // Funktion för att flytta pengar över konton.
        {
            
            Console.WriteLine("Från vilket konto vill du överföra pengar från: ");
            string userinput = Console.ReadLine();
            foreach (var user in Users)
            {
                if(CurrentUser == user.UserName)
                {
                    if (userinput == user.AccountName)
                    {
                        Console.WriteLine("Hur mycket pengar vill du överföra?:");
                        double transfer = int.Parse(Console.ReadLine());
                        user.Balance = user.Balance - transfer;
                        user.Balance2 = user.Balance2 + transfer;
                        break;

                    }
                    else if (userinput == user.AccountName2)
                    {
                        Console.WriteLine("Hur mycket pengar vill du överföra?:");
                        double transfer = int.Parse(Console.ReadLine());
                        user.Balance2 = user.Balance2 - transfer;
                        user.Balance = user.Balance + transfer;
                        break;
                    }
                }

                

            }
        }
        
    }

    class User  // En Klass eller Objekt för Användare.
    {
        private string username;
        private string accountname = "Privat-Konto";
        private string accountname2 = "Spar-Konto";
        private int pincode;
        private double balance;
        private double balance2;

        public User(string _UserName = "", string _AccountName = "Privat-Konto", string _AccountName2 = "Spar-Konto", int _PinCode = 1234, double _Balance = 25050.59, double _Balance2 = 0)
        {
            this.UserName = _UserName;
            this.PinCode = _PinCode;
            this.AccountName = _AccountName;
            this.AccountName2 = _AccountName2;
            this.Balance = _Balance;
            this.balance2 = _Balance2;


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
        public double Balance2
        {
            get { return balance2; }
            set { balance2 = value; }
        }

    } 
}
