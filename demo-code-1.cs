using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lucy_Simulator_Nostalgic
{
    class saveVar
    {
        public static string getCash; //convert to int 32 for cash
        public static string getLucyRep; //convert to int 32 for lucy rep
    }
    class gv
    {
        public static string lucyType;
        public static int cash;
        public static int lucyRep;
        public static string inventorySlotOne;
        public static string inventorySlotTwo;
        public static string inventorySlotThree;
        public static bool loopActive;
        public static string input;
        public static string activity;
        public static int cashLeftForArcade;
    }
    class Program
    {
        static void saveData()
        {
            try
            {
                TextWriter tw = new StreamWriter("save-data.txt");
                tw.WriteLine("datafilled");
                tw.WriteLine("basic");
                tw.WriteLine("0");
                tw.WriteLine("0");
                tw.WriteLine("none");
                tw.WriteLine("none");
                tw.WriteLine("none");
                tw.Close();
                Console.WriteLine("Save data written.");
            }
            catch
            {
                Console.WriteLine("Error: could not save data.\nSave data file could not be found, or there was an internal error with streamwriter.");
                Thread.Sleep(3000);
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Lucy Simulator Nostalgic";
            Console.WriteLine("Loading save data. Please wait a minute.");
            string checkForData;
            TextReader tr = new StreamReader("save-data.txt");
            checkForData = tr.ReadLine();
            if (checkForData == "datafilled")
            {
                gv.lucyType = tr.ReadLine();

                saveVar.getCash = tr.ReadLine();
                gv.cash = Convert.ToInt32(saveVar.getCash); //switch get cash to int

                saveVar.getLucyRep = tr.ReadLine();
                gv.lucyRep = Convert.ToInt32(saveVar.getLucyRep); //switch get lucy rep to int

                gv.inventorySlotOne = tr.ReadLine();
                gv.inventorySlotTwo = tr.ReadLine();
                gv.inventorySlotThree = tr.ReadLine();
                tr.Close();
                Console.WriteLine("Save data successfully loaded.");
            }
            else
            {
                Console.WriteLine("Save data not found. Writing save data.");
                tr.Close();
                TextWriter tw = new StreamWriter("save-data.txt");
                tw.WriteLine("datafilled");
                tw.WriteLine("basic");
                tw.WriteLine("0");
                tw.WriteLine("0");
                tw.WriteLine("none");
                tw.WriteLine("none");
                tw.WriteLine("none");
                tw.Close();
                Console.WriteLine("Save data written.");
            }
            gv.loopActive = true;
            Thread.Sleep(2000);
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Lucy Simulator Nostalgic.");
                Console.WriteLine("[1] begin game");
                Console.WriteLine("[2] credits/settings");
                Console.WriteLine("[3] exit");
                gv.input = Console.ReadLine();
                if (gv.input == "3")
                {
                    Environment.Exit(0);
                }
                else if (gv.input == "2")
                {
                    Console.Clear();
                    Console.WriteLine("CREDITS ---");
                    Console.WriteLine("Lucy Simulator Nostalgic created by Threesodas - 2021. \nLucy Simulator(original) created by Prodski - 2017. \n\nPlease do not copy anything from this application. \nOnly developers (Prodski & Threesodas) are allowed to view, edit, and remix code. \n\ntheft bad");
                    Console.WriteLine("\nSETTINGS PANEL --- \n[1] reset data \n[2] go back");
                    gv.input = Console.ReadLine();
                    if (gv.input == "1")
                    {
                        Console.WriteLine("\nTo confirm reset, please type \"Lucy Simulator Nostalgic\". If not, press enter.");
                        gv.input = Console.ReadLine();
                        gv.input.ToLower();
                        if (gv.input == "lucy simulator nostalgic")
                        {
                            TextWriter tw = new StreamWriter("save-data.txt");
                            tw.WriteLine(" ");
                            tw.Close();
                            Process.Start("Lucy Simulator Nostalgic.exe");
                            Environment.Exit(0);
                        }
                    }
                }
                else if (gv.input == "1")
                {
                    gv.loopActive = false;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            while (gv.loopActive == true);
            gv.loopActive = true;
            gv.activity = "home";
            //main game below
            do
            {
                Console.Clear();
                if (gv.activity == "home")
                {
                    Console.WriteLine("Another day with Lucy. What will you do today? \n[1] walk lucy \n[2] work \n[3] visit the store \n[4] view stats \n[5] save data and quit");
                    gv.input = Console.ReadLine();
                    if (gv.input == "1")
                    {
                        gv.activity = "walk";
                    }
                    else if (gv.input == "2")
                    {
                        gv.activity = "getcash";
                    }
                    else if (gv.input == "3")
                    {
                        gv.activity = "store";
                    }
                    else if (gv.input == "4")
                    {
                        gv.activity = "stats";
                    }
                    else if (gv.input == "5")
                    {
                        saveData();
                        Environment.Exit(100);
                    }
                }
                else if (gv.activity == "walk")
                {
                    Console.WriteLine("You and Lucy go on a walk. You pass by the arcade. Will you visit the arcade? (y/n)");
                    gv.input = Console.ReadLine();
                    if (gv.input == "y")
                    {
                        if (gv.cash >= 20)
                        {
                            gv.cash = gv.cash - 20;
                            Console.WriteLine("You took Lucy to the arcade. \n+25 Lucy rep \n-20 cash");
                            Console.WriteLine("\nLucy rep score: " + gv.lucyRep);
                            gv.lucyRep = gv.lucyRep + 25;
                            Console.WriteLine("New Lucy rep score: " + gv.lucyRep + "\nPress enter to continue.");
                            gv.input = Console.ReadLine();
                        }
                        else
                        {
                            gv.cashLeftForArcade = 20 - gv.cash;
                            Console.WriteLine("Sorry, but you don't have enough money to visit the arcade. Maybe work some and earn some money? \nBalance: " + gv.cash + "\nArcade cost: 20 \nYou need " + gv.cashLeftForArcade + " more cash to visit the arcade. \nPress enter to continue.");
                            gv.input = Console.ReadLine();
                        }
                    }
                    else if (gv.input == "n")
                    {
                        Console.WriteLine("\nYou took Lucy for a nice and pleasent walk. \n+5 Lucy rep");
                        Console.WriteLine("\nLucy rep score: " + gv.lucyRep);
                        gv.lucyRep = gv.lucyRep + 5;
                        Console.WriteLine("New Lucy rep score: " + gv.lucyRep + "\nPress enter to continue.");
                        gv.input = Console.ReadLine();
                    }
                    gv.activity = "home";
                }
                else if (gv.activity == "getcash")
                {
                    Console.WriteLine("You worked hard at your job and earned 2 cash.\nHowever, Lucy misses you.\n-5 Lucy rep.\n\nPress enter to continue.");
                    gv.lucyRep = gv.lucyRep - 5;
                    gv.input = Console.ReadLine();
                    gv.activity = "home";
                }
                else if (gv.activity == "store")
                {
                    //You left off here.
                }
            }
            while (gv.loopActive == true);
        }
    }
}
