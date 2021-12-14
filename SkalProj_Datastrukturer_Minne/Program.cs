using System;
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
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }

}





