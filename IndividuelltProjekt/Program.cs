using System;

namespace IndividuelltProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            BankSystem Session = new BankSystem();
            Session.Run();
            
            
        }
    }
    class BankSystem
    {
        public void Run()
        {
            StartMeny();
        }
        public static void StartMeny()
        {

            int menu = 0;

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
                            Login();
                            break;
                        case 2:
                            CreateAccount();
                            break;
                        default:
                            break;
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltligt Val");
                }

            } while (menu != 0);
            
        }
        public static void Login() // funktion för att logga in.
        {
            bool Loggedin = false;

            Console.WriteLine("Logga in på ett konto");
            Console.Write("Användarnamn: ");
            string UserLogin = Console.ReadLine();
            Console.Write("Pinkod: ");
            int PinLogin = int.Parse(Console.ReadLine());
            Console.ReadKey();
        }
        public static void LoggedIn()
        {

        } //login screen.
        public static void Logout() // Funktion för att logga ut.
        {

        }
        public static void CreateAccount() // Funktion för att skapa konto.
        {
            string UserName = "";
            int PinCode = 0;
            int CheckPin = 0;


            
            do
            {
                Console.Clear();
                Console.WriteLine("Skapa Konto");
                try
                {
                    Console.Write("Användarnamn: ");
                    UserName = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltligt användarnamn.");
                    Console.ReadKey();
                }
            } while (PinCode != CheckPin);

            do
            {

                try
                {
                    Console.Clear();
                    Console.Write("Pinkod: ");
                    PinCode = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltlig pinkod");
                    Console.ReadKey();
                }
            } while (true);

            do
            {
                try
                {
                    Console.Clear();
                    Console.Write("Skriv in pinkod igen:");
                    CheckPin = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltlig Pinkod.");
                    Console.ReadKey();
                    
                }
                
            } while (PinCode != CheckPin);

            

                if (CheckPin == PinCode)
                {
                    Console.Clear();
                    Console.WriteLine("Välkommen till ALN Bank {0}!", UserName);
                    
                }

            Console.ReadKey();


            


        }
        public static void PrintCurrentAccountInfo() // Funktion för att skriva ut information om inloggat account.
        {

        }
        public static void WithdrawCurrency() // Funktion för att ta ut pengar. 
        {

        }
        public static void TransferCurrency() // Funktion för att flytta pengar över konton.
        {

        }
        
    }

    class Users
    {
        string UserName = "";
        int PinCode = 0;      
    } // En Klass eller Objekt för Användare.

    class UserAccount
    {
        string AccountName = "";
        int AccountNumber = 0;
        double Balance = 0;
    } // Klass Objekt för konton.
}
