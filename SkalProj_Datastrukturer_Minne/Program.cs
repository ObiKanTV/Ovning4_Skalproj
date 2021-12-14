using System;
using System.Collections;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    // Frågor 1-3 här nedan. 
    // Som i exemplet under dessa frågor har du två exempel, den första så deklarerar du values i klassnivå,
    // du deklarerar då två Integers vilket blir value types och dom lagras på stacken. 
    // När du lagrar en integer på stacken och sen säger y = x och sen ändrar på y = 4 så ändras inte x för det är inte en referens. 
    // När du istället deklarerar som i det undre exemplet så skapar man ett ebject som är av typen referens, 
    // du använde new Int förut vilket var value type, nu refererar du till något annat i din kod. 
    // Så i det andra exemplet så pekar y och x på samma referens i heap, ändrar du då y till 4 så ändras också x. 
    // Skillnaden mellan stack och heap är då att stacken behåller värdet för x tills du ändrar det, när du sen säger att y = x så är det inte samma värde utan en kopia. 
    // Stacken är också lokal, medans heapen är global. Du kommer alltså bara åt en value type innanför scopet på t.ex klassen,
    // men du kan referera till ett object i heapen globalt.
    class Program
    {







        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            bool isModdingList = true;
            List<string> theList = new List<string>();
            // prints a very nice menu
            Console.WriteLine($"--------------------------------Welcome--------------------------------" +
                               "\nTo add something to the list type + followed by its name. e.g +Adam" +
                               "\nTo remove something, simply type - followed by its name. e.g -Adam" +
                               "\nTo exit back to the menu, type Q/q" +
                               "\n=====================================================================");

            // notering, använde mig inte av Capacity Metoden, Capacity syns i debuggern om du har theList på view under RAW. 
            // Svar på frågor Övning 1: ExamineList()
            // 2. arrayen ökar capacity varje gång du försöker lägga till något men arrayen är full
            // 3. den ökar då med sig själv. Alltså dubblar arrayens storlek. array x2.
            // 4. troligtvis för att inte behöva reservera minne varje gång du vill lägga till något i listan, därför så reserverar den när det behövs istället.
            // 5. Nej, Capacity minskar inte om man använder List.Remove() 
            // 6. när man vet att det inte kommer vara mer i den listan än antalet man definerar. 
            // Då kan du i förväg reservera just den summan och inte använda onödigt mycket reserverat minne
            do
            {
                string? input = Console.ReadLine();

                if (input == null)
                {
                    throw new Exception("Must Input a +/- followed by a word or name e.g. +Banana");
                }
                input = input.Trim();
                char nav = input[0];


                string navString = nav.ToString(); // this validation is to make sure you can type Q or q as well to exit. I'm sure I could've done this better. Will come back later.
                string valString = navString.ToUpper();

                string value = input.Substring(1);
                if (valString == "Q")
                {
                    Console.Clear();
                    isModdingList = false;
                }
                else if (value.Length > 10) // several validation to make sure the user input is correct
                {
                    Console.WriteLine("Please specify a name under 10 characters.");
                    break;
                }
                else if (value.Length < 2)
                {
                    Console.WriteLine("Please specify a name longer than 1 character.");
                    break;
                }
                else if (String.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("You need to add a word. e.g +Apple or -Adam");
                }
                switch (nav)
                {
                    case '+':
                        Console.Clear(); // Console Clears are to make things easier to read. I hate cluttered consoles. even just for testing.
                        theList.Add(value);
                        Console.WriteLine($"Added {value} to the List. You can continue add/remove from the list or Q/q to quit to Main Menu");

                        break;
                    case '-':

                        if (theList.Remove(value)) // added an if-statement here to make sure the user actually removes something and tells the user if they did. 
                        {
                            Console.WriteLine($"{value} has been succesfully removed from the list\nYou can continue to add/remove from the list or" +
                                "press Q/q to exit to the Main Menu");
                        }
                        else
                        {
                            Console.WriteLine($"Could not remove {value} from the list, are you sure you typed it correctly?");
                        }
                        break;

                    default:
                        Console.WriteLine("I want you to input a + or - followed by a word e.g. +Pie. Unless you want to quit, then Q/q.");
                        break;
                }

            } while (isModdingList);



        }


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */



            // Jag gjorde ingen TestQueue, provade istället med samma logik som förra uppgiften att lägga till och ta bort.
            // Använde förra som mall för denna, kastade om koden lite för att få den att funka här med.
            // Koden valideras nu också, du kan lägga till och ta bort från kön. 
            bool isQueueing = true;
            Queue<string> queue = new Queue<string>();

            Console.Clear();
            Console.WriteLine("===================ICA======================\n"
                + "Welcome to ICA, You can enter people into the store with the + and a name\ne.g. +Rulle" +
                "or you can serve the one first in line with -. type Q/q to quit to Main Menu");
            // I did some copy paste with my previous code, Normally I would've made a validate Method with all these validations, but this time no.
            do
            {
                string? input = Console.ReadLine();

                if (input == null)
                {
                    throw new Exception("Must Input a +/- followed by a name e.g. +Anna");
                }
                input = input.Trim();
                char nav = input[0];


                string navString = nav.ToString(); // this validation is to make sure you can type Q or q as well to exit.   
                string valString = navString.ToUpper(); // I'm sure I could've done this better. Will come back later.

                string value = input.Substring(1);
                if (valString == "Q")
                {
                    Console.Clear();
                    isQueueing = false;
                }
                else
                {

                    switch (nav)
                    {
                        case '+':
                            if (value.Length > 10) // several validation to make sure the user input is correct
                            {
                                Console.WriteLine("Please specify a name under 10 characters.");
                                break;
                            }
                            else if (value.Length < 2)
                            {
                                Console.WriteLine("Please specify a name longer than 1 character.");
                                break;
                            }
                            else if (String.IsNullOrWhiteSpace(value))
                            {
                                Console.WriteLine("You need to add a word. e.g +Adam or -Adam");
                            }
                            else
                            {
                                Console.Clear(); // Console Clears are to make things easier to read. I hate cluttered consoles. even just for testing.
                                queue.Enqueue(value);
                                Console.WriteLine($"{value} has now entered our store, They grabbed what they wanted from the shelves and is now in Queue." +
                                    " You can continue queue/dequeue people or Q/q to quit to Main Menu");
                            }
                            break;
                        case '-':

                            if (queue.TryDequeue(out value!)) // added an if-statement here to make sure the user actually removes something and tells the user if they did. 
                            {
                                Console.WriteLine($"{value} have successfully been served and is now leaving our store.\nYou can continue to queue/dequeue people or" +
                                    "press Q/q to exit to the Main Menu");
                            }
                            else
                            {
                                Console.WriteLine($"There was no person in the store, You can add someone with the + followed by a Name e.g. +Jocke or Q/q to exit.");
                            }
                            break;

                        default:
                            Console.WriteLine("I want you to input a + or - followed by a Name e.g. +Penny. Unless you want to quit, then Q/q.");
                            break;
                    }
                }

            } while (isQueueing);

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            // Svar på fråga 3.1: Om man använder en stack här istället för Kö, så tar den bort den som senast lades till,
            // vilket betyder att Kalle som va först i kön får vänta och eventuellt så får han inte komma hem alls.
            ReverseText();
        }

        private static void ReverseText()
        {
            // Tried making this as simple as I could. I doubt Stacks are the most effecient way of reversing a string though.
            var revString = "";
            Console.WriteLine("Please enter a text you would like to reverse.");
            string? input = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(input))
            {
               input = input.Trim();
                Stack rTSStack = new Stack();
                foreach (char c in input)
                {
                    rTSStack.Push(c);
                }
                while (rTSStack.Count > 0)
                {
                    revString += rTSStack.Pop();
                }
                    Console.WriteLine($"This is what I got: {revString}");
            }
            else { Console.WriteLine("You must enter a valid text"); }

        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */


            // ToDo: Make a plan in Corel for taking a string, making a char array, foreach loop to loop until it hits a {/(/[/]/)/} and then check so that the next one
            // is also of the same type. I will probably need several nested if-statements in the foreach loop. 

        }

    }

}





