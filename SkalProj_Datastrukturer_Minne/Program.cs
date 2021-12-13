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

            Console.WriteLine("--------------------------------Welcome--------------------------------");
            Console.WriteLine("\nTo add something to the list type + followed by its name. e.g +Adam");
            Console.WriteLine("\nTo remove something, simply type - followed by its name. e.g -Adam");
            Console.WriteLine("\nTo exit back to the menu, type Q");
            Console.WriteLine("\n======================================================================");

            do
            {

                string input = Console.ReadLine();
                char nav = input[0];
                string navString = nav.ToString();
                string valString = navString.ToUpper();
                if (valString == "Q")
                {
                    isModdingList = false;
                }

                string value = input.Substring(1);
                if (value.Length > 10)
                {
                    Console.WriteLine("Please specify a name under 10 characters.");
                    break;
                }
                else if (value.Length < 2)
                {
                    Console.WriteLine("Please specify a name longer than 1 character.");
                    break;
                }
                switch (nav)
                {
                    case '+':
                        theList.Add(value);

                        break;
                    case '-':
                        theList.Remove(value);

                        break;


                    default:
                        Console.WriteLine("I want you to input a + or - unless you want to quit, then Q.");
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
             * Loop this method untill the user inputs something to exit to main menue.
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





