using System;
using System.Collections.Generic;

namespace IndividuelltProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] WelcomeMSG = new string[5];
            WelcomeMSG[0] = "Välkommen till ALN Banken.";
            WelcomeMSG[1] = "Hej och välkommen till ALN Banken!";
            WelcomeMSG[2] = "ALN Banken, Där vi ger ut gratis pengar!";
            WelcomeMSG[3] = "ALN Banken";
            WelcomeMSG[4] = "Välkommen!";
            Random r = new Random();
            int random = r.Next(0,4);
            
            List<User> Users = new List<User>();
            Users.Add(new User("lucas", "Privat-Konto", "Spar-Konto", 1337, 56000, 0));
            Users.Add(new User("johnny", "Privat-Konto", "Spar-Konto", 1234, 44500, 0));
            Users.Add(new User("conny", "Privat-Konto", "Spar-Konto", 1234, 106708, 0));
            Users.Add(new User("ronny", "Privat-Konto", "Spar-Konto", 1234, 1000506, 0));
            Users.Add(new User("lenny", "Privat-Konto", "Spar-Konto", 1234, 150, 0));

            int menu = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(WelcomeMSG[random]);
                try
                {

                    Console.WriteLine("1. Logga in");
                    Console.WriteLine("2. Skapa konto");
                    Console.WriteLine("3. Avsluta program");
                    menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Login(Users);
                            break;
                        case 2:
                            Users = CreateAccount(Users);
                            break;
                        case 3:
                            Environment.Exit(0);
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
            string userinput="";
            int pincode=0;
            int tries = 1;

            do
            {
                do
                {

                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Logga in på ett konto, försök {0}",tries);
                        Console.Write("Användarnamn: ");
                        userinput = userinput = Console.ReadLine();
                        break;


                    }
                    catch (FormatException)
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

                tries++;

                bool loggedin = false;
                foreach (var user in Users)
                {


                    if (userinput == user.UserName && pincode == user.PinCode)
                    {
                        loggedin = true;
                        LoggedIn(Users, userinput);
                    }
                }
                if (loggedin == false)
                {
                    Console.WriteLine("Du har skrivit in fel användarnamn eller pinkod för många gånger.");
                    if (tries == 4)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Programmet avslutas . . .");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }

                }

            } while (tries < 4);

            Console.ReadKey();





        }
        public static void LoggedIn(List<User> Users, string CurrentUser) //login screen.
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
                catch (FormatException)
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
                                Console.WriteLine(user.AccountName + " : " + user.Balance);
                                Console.WriteLine(user.AccountName2 + " : " + user.Balance2);
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 2:

                        TransferCurrency(Users, CurrentUser);

                        break;
                    case 3:
                        WithdrawCurrency(Users, CurrentUser);
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
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltligt användarnamn.");
                    Console.ReadKey();
                }
                break;
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
                    if (CheckPin == NewUser.PinCode)
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
        public static void WithdrawCurrency(List<User> Users, string CurrentUser) // Funktion för att ta ut pengar. 
        {
            Console.Clear();
            Console.WriteLine("Från vilket konto vill du ta ut pengar från: ");
            Console.WriteLine("1. Privat-Konto");
            Console.WriteLine("2. Spar-Konto");
            int menu;
            menu = int.Parse(Console.ReadLine());
            string userinput = "";
            switch (menu)
            {
                case 1:
                    userinput = "Privat-Konto";
                    break;
                case 2:
                    userinput = "Spar-Konto";
                    break;
            }
            foreach (var user in Users)
            {
                if (CurrentUser == user.UserName)
                {
                    if (userinput == user.AccountName)
                    {
                        Console.WriteLine("Hur mycket pengar vill du ta ut?:");
                        double transfer = int.Parse(Console.ReadLine());
                        if (transfer > user.Balance)
                        {
                            Console.WriteLine("Du har inte tillräckligt med pengar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            user.Balance = user.Balance - transfer;
                            Console.WriteLine("Du har nu tagit ut {0} kr från ditt Privat-Konto.",transfer);
                            Console.WriteLine("Du har nu {0}kr på ditt Privat-Konto.",user.Balance);
                            Console.WriteLine("Tryck på ENTER för gå vidare . . . ");
                            Console.ReadKey();
                        }
                        break;
                    }
                    else if (userinput == user.AccountName2)
                    {
                        Console.WriteLine("Hur mycket pengar vill du ta ut?:");
                        double transfer = int.Parse(Console.ReadLine());
                        if (transfer > user.Balance2)
                        {
                            Console.WriteLine("Du har inte tillräckligt med pengar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            user.Balance2 = user.Balance2 - transfer;
                            Console.WriteLine("Du har nu tagit ut {0} kr från ditt Spar-Konto.", transfer);
                            Console.WriteLine("Du har nu {0}kr på ditt Spar-Konto.", user.Balance2);
                            Console.WriteLine("Tryck på ENTER för gå vidare . . . ");
                            Console.ReadKey();
                        }
                        break;
                    }
                }
            }
        }
        public static void TransferCurrency(List<User> Users, string CurrentUser) // Funktion för att flytta pengar över konton.
        {
            Console.Clear();
            Console.WriteLine("Från vilket konto vill du överföra pengar från: ");
            Console.WriteLine("1. Privat-Konto");
            Console.WriteLine("2. Spar-Konto");
            int menu;
            menu = int.Parse(Console.ReadLine());
            string userinput = "";
            switch (menu)
            {
                case 1:
                    userinput = "Privat-Konto";
                    break;
                case 2:
                    userinput = "Spar-Konto";
                    break;
            }
            foreach (var user in Users)
            {
                if (CurrentUser == user.UserName)
                {
                    if (userinput == user.AccountName)
                    {
                        Console.WriteLine("Hur mycket pengar vill du överföra?:");
                        double transfer = int.Parse(Console.ReadLine());
                        if (transfer > user.Balance)
                        {
                            Console.WriteLine("Du har inte tillräckligt med pengar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            user.Balance = user.Balance - transfer;
                            user.Balance2 = user.Balance2 + transfer;
                            Console.WriteLine("Du har överfört {0} kr till ditt spar-konto.", transfer);
                            Console.WriteLine("Tryck på ENTER för gå vidare . . . ");
                            Console.ReadKey();
                        }
                        break;
                    }
                    else if (userinput == user.AccountName2)
                    {
                        Console.WriteLine("Hur mycket pengar vill du överföra?:");
                        double transfer = int.Parse(Console.ReadLine());
                        if (transfer > user.Balance2)
                        {
                            Console.WriteLine("Du har inte tillräckligt med pengar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            user.Balance2 = user.Balance2 - transfer;
                            user.Balance = user.Balance + transfer;
                            Console.WriteLine("Du har överfört {0} kr till ditt privat-konto.", transfer);
                            Console.WriteLine("Tryck på ENTER för gå vidare . . . ");
                            Console.ReadKey();
                        }
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
     

