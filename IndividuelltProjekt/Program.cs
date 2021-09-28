﻿using System;
using System.Collections.Generic;

namespace IndividuelltProjekt
{
    class Program
    {

        static void Main(string[] args)
        {
            
            

            StartMeny();
            
            
            

        }
    
        public static void StartMeny()
        {
            List<User> Users = new List<User>();
            
            Users.Add(new User("Lucas",1234,"PrivatKonto",25000));
            

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
                            Login(Users);
                            break;
                        case 2:
                           Users = CreateAccount(Users);
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
        public static void Login(List<User> Users) // funktion för att logga in.
        {
            bool Loggedin = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Logga in på ett konto");
                    Console.Write("Användarnamn: ");
                    string UserLogin = Console.ReadLine();
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
                Console.Clear();
                Console.WriteLine("Inloggad som: {0}");
                Console.WriteLine();
                Console.WriteLine("1. Mina Konton");
                Console.WriteLine("2. Överför till Konto");
                Console.WriteLine("3. Ta ut pengar");
                Console.WriteLine("4. Logga ut");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        //PrintCurrentAccountInfo(Users);
                        foreach (var item in Users)
                        {
                            Console.WriteLine(item);
                        }
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
            int PinCode = 0;
            int CheckPin = 0;
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
            } while (PinCode != CheckPin);

            do
            {

                try
                {
                    Console.Clear();
                    Console.Write("Pinkod: ");
                    NewUser.PinCode = int.Parse(Console.ReadLine());
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
                    
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltlig Pinkod.");                    
                }

                Console.WriteLine();
                Console.WriteLine("Välkommen till ALN Bank {0}!", NewUser.UserName);
                break;


            } while (true);
            

            CurrentUsers.Add(NewUser);
            Console.ReadKey();
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
        public string UserName = "";
        public int PinCode = 0;       
        public string AccountName = "";
        public double Balance = 0;


    } 

    //class UserAccount // Klass Objekt för konton.
    //{
    //    string AccountName = "";
    //    int AccountNumber = 0;
    //    double Balance = 0;
    //} 
}
