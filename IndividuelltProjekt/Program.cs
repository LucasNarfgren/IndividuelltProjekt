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
            Console.WriteLine("Välkommen till ALN Banken.");
            Console.ReadKey();
            LoginLogout();


        }
        public static void LoginLogout() // funktion för att logga in eller logga ut.
        {
            Console.WriteLine("Logga in på ett konto");
            Console.Write("Användarnamn: ");
            string UserLogin = Console.ReadLine();
            Console.Write("Pinkod: ");
            int PinLogin = int.Parse(Console.ReadLine());
            Console.ReadKey();
        }

        public static void AddUser() //Funktion för att lägga till användare.
        {

        }

        public static void CreateDeleteAccount() // Funktion för att skapa eller tabort ett konto.
        {

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
    }

    class UserAccount
    {
        string AccountName = "";
        int AccountNumber = 0;
        double Balance = 0;
    }
}
