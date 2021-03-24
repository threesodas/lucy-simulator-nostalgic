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
    class Program
    {
        static void saveData()
        {
            try
            {
                TextWriter tw = new StreamWriter(@"gameData\save-data.txt");
                tw.WriteLine("datafilled");
                tw.WriteLine("basic");
                tw.WriteLine("0");
                tw.WriteLine("0");
                tw.WriteLine("false");
                tw.WriteLine("false");
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
            Console.WriteLine("What's your name?");
            gv.user = Console.ReadLine();
            Console.Clear();
            Thread.Sleep(2500);
            Random rnd = new Random();
            Console.WriteLine("Loading save data. Please wait a minute.");
            string checkForData;
            TextReader tr = new StreamReader(@"gameData\save-data.txt");
            checkForData = tr.ReadLine();
            if (checkForData == "datafilled")
            {
                gv.lucyType = tr.ReadLine();

                saveVar.getCash = tr.ReadLine();
                gv.cash = Convert.ToInt32(saveVar.getCash); //switch get cash to int

                saveVar.getLucyRep = tr.ReadLine();
                gv.lucyRep = Convert.ToInt32(saveVar.getLucyRep); //switch get lucy rep to int

                saveVar.getHasArcadePass = tr.ReadLine();
                gv.hasArcadePass = Convert.ToBoolean(saveVar.getHasArcadePass);

                saveVar.getHasRaisePass = tr.ReadLine();
                gv.hasRaisePass = Convert.ToBoolean(saveVar.getHasRaisePass);

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
                TextWriter tw = new StreamWriter(@"gameData\save-data.txt");
                tw.WriteLine("datafilled");
                tw.WriteLine("basic");
                tw.WriteLine("0");
                tw.WriteLine("0");
                tw.WriteLine("false");
                tw.WriteLine("false");
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
                            TextWriter tw = new StreamWriter(@"gameData\save-data.txt");
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
                    if (gv.lucyRep >= 1499)
                    {
                        Console.WriteLine("Best Pet Owner - Ending 1/1 \n\nYE OLDE NEWS \n Today, " + gv.user + " was officially announced BEST PET OWNER. \n  " + gv.user + " and their dog Lucy came to the White House today to be elected Best Pet Owner ever. \n\n\nThank you for playing. Any save data you have will be erased. Press enter to continue.");
                        gv.input = Console.ReadLine();
                        TextWriter tw = new StreamWriter(@"gameData\save-data.txt");
                        tw.WriteLine(" ");
                        tw.Close();
                        Process.Start("Lucy Simulator Nostalgic.exe");
                        Environment.Exit(0);
                    }
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
                        if (gv.hasArcadePass == true)
                        {
                            Console.WriteLine("Since you have the arcade pass, you don't need to pay.");
                            Console.WriteLine("You took Lucy to the arcade. \n+20 Lucy rep");
                            gv.rng = rnd.Next(0, 50);
                            if (gv.rng <= 49)
                            {
                                gv.lucyRep = gv.lucyRep + 500;
                            }
                            Console.WriteLine("\nLucy rep score: " + gv.lucyRep);
                            gv.lucyRep = gv.lucyRep + 20;
                            Console.WriteLine("New Lucy rep score: " + gv.lucyRep + "\nPress enter to continue.");
                            gv.input = Console.ReadLine();
                        }
                        else
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
                    if (gv.hasRaisePass == false)
                    {
                        Console.WriteLine("You worked hard at your job and earned 2 cash.\nHowever, Lucy misses you.\n-5 Lucy rep.\n\nPress enter to continue.");
                        gv.cash = gv.cash + 2;
                        gv.lucyRep = gv.lucyRep - 5;
                    }
                    else
                    {
                        Console.WriteLine("You worked hard at your job and earned 500 cash.\nHowever, Lucy knows u got dat cahs.\n-25 Lucy rep.\n\nPress enter to continue.");
                        gv.cash = gv.cash + 500;
                        gv.lucyRep = gv.lucyRep - 25;
                    }
                    gv.input = Console.ReadLine();
                    gv.activity = "home";
                }
                else if (gv.activity == "store")
                { 
                    Console.WriteLine("You take Lucy to the store. \n\nIn order to purchase an item, you must have an empty inventory slot. \nYour inventory: \n\nSlot 1 - " + gv.inventorySlotOne + "\nSlot 2 - " + gv.inventorySlotTwo + "\nSlot 3 - " + gv.inventorySlotThree + "\n\nSales: \n[1] Arcade Pass \n-Permanently enter the arcade for free \nPrice: 100 cash \n\n[2] Raise Pass \n-Permanently get a +498 cash raise (500 cash) \nPrice: 100 cash \n\nLucy regrets coming here. She finds nothing that interests her. \n\nPress enter to continue.");
                    gv.input = Console.ReadLine();
                    gv.activity = "home";
                    /*if (gv.input == "1")
                    {
                        if (gv.cash >= 100)
                        {
                            if (gv.inventorySlotOne == "none")
                            {
                                gv.inventorySlotOne = "arcade pass";
                                gv.cash = gv.cash - 100;
                                gv.hasArcadePass = true;
                            }
                            else if (gv.inventorySlotTwo == "none" && gv.inventorySlotOne == "none" || gv.inventorySlotOne == "raise pass")
                            {
                                gv.inventorySlotTwo = "arcade pass";
                                gv.cash = gv.cash - 100;
                                gv.hasArcadePass = true;
                            }
                            else
                            {
                                Console.WriteLine("You have already purchased this, dummy!");
                            }
                            Console.WriteLine("You successfully purchased the Arcade pass.");
                        }
                    }
                    */
                }
                else if (gv.activity == "stats")
                {
                    Console.WriteLine("STATS ----- \nCash: " + gv.cash + "\nLucy rep: " + gv.lucyRep + "\n\nTo become the best pet owner, you need 1500 Lucy Rep. \n\nPress enter to continue.");
                    gv.input = Console.ReadLine();
                    gv.activity = "home";
                }
            }
            while (gv.loopActive == true);
        }
    }
}
