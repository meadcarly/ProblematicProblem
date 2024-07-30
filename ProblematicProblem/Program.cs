using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
public class Program
{ 
static Random _rng = new Random();
static bool _cont = true;
static List<string> _activities = new List<string> { "Movies", "Paintball", "Bowling", "Laser Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

static void Main(string[] args)
{
string generateRandomActivity;
    Console.Write("Hello, welcome to the random activity generator!");
    Console.WriteLine("you like to generate a random activity? yes/no:");

    generateRandomActivity = Console.ReadLine().ToLower();
    while (generateRandomActivity != "yes" && generateRandomActivity != "no")
    {
        Console.WriteLine("Invalid input, please choose yes or no");
        generateRandomActivity = Console.ReadLine().ToLower();
    } 
    if (generateRandomActivity == "yes")
    {
        _cont = false;
    }
    else if (generateRandomActivity == "no")
    {
        _cont = true;
    }
    


Console.WriteLine();
    if (!_cont)
    {
        Console.Write("We are going to need your information first! What is your name? ");

        string userName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(userName))
        {
            Console.WriteLine("Sorry, we need your name");
            userName = Console.ReadLine();
        }
        Console.WriteLine();
        Console.Write("What is your age? ");
        int userAge;
        while (!int.TryParse(Console.ReadLine(), out userAge))
        {
            Console.WriteLine("Please enter a valid age");
        }
        Console.WriteLine();
        Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
        string seeList = Console.ReadLine().ToLower();
        while (seeList != "sure" && seeList != "no thanks")
        {
            Console.WriteLine("Invalid input, please choose 'sure' or 'no thanks'");
            seeList = Console.ReadLine().ToLower();
        }
        if (seeList == "sure")
        {
            foreach (string activity in _activities)
            {
                Console.Write($"{activity} ");
                Thread.Sleep(250);
            }

            Console.WriteLine();
            Console.Write("Would you like to add any activities before we generate one? yes/no: ");
            string userInput = Console.ReadLine().ToLower();
            while (userInput != "yes" && userInput != "no")
            {
                Console.WriteLine("Invalid input, please choose 'yes' or 'no'.");
                userInput = Console.ReadLine().ToLower();
            }
            bool addToList = userInput == "yes";
            Console.WriteLine();
            while (addToList)
            {
                Console.Write("What would you like to add? ");
                string userAddition = Console.ReadLine();
                _activities.Add(userAddition);
                foreach (string activity in _activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.WriteLine("Would you like to add more? yes/no: ");
                string addMoreUserInput = Console.ReadLine().ToLower();
                while (addMoreUserInput != "yes" && addMoreUserInput != "no")
                {
                    Console.WriteLine("Invalid input, please choose 'yes' or 'no'.");
                    addMoreUserInput = Console.ReadLine().ToLower();
                }
                addToList = addMoreUserInput == "yes";
            }
            if (!addToList)
            {
                _cont = true;
            }
        }
        else if (seeList == "no thanks")
        {
            _cont = true;
        }
        

        while (_cont)
        {
            Console.Write("Connecting to the database");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(". ");
                Thread.Sleep(500);
            }

            Console.WriteLine();
            Console.Write("Choosing your random activity");
            for (int i = 0; i < 9; i++)
            {
                Console.Write(". ");
                Thread.Sleep(500);
            }

            Console.WriteLine();
            int randomNumber = _rng.Next(_activities.Count);
            string randomActivity = _activities[randomNumber];
            if (userAge > 21 && randomActivity == "Wine Tasting")
            {
                Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                Console.WriteLine("Pick something else!");
                _activities.Remove(randomActivity);
                randomNumber = _rng.Next(_activities.Count);
                randomActivity = _activities[randomNumber];
            }

            Console.Write(
                $"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
            string keepOrRedo;
            keepOrRedo = Console.ReadLine().ToLower();
            while (keepOrRedo != "keep" && keepOrRedo != "redo")
            {
                Console.WriteLine("Sorry, please choose 'keep' or 'redo'.");
                keepOrRedo = Console.ReadLine().ToLower();
            }
            if (keepOrRedo == "keep")
            {
                Console.WriteLine("Great!");
                _cont = false;
            }
            else if (keepOrRedo == "redo")
            {
                _cont = true;
            }
            
        }
    }
}
    }
        }
    

