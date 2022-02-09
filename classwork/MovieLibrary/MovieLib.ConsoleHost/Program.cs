/*
 * Your Name
 * ITSE 1430
 * Lab 1
 */
using System;

namespace MovieLib.ConsoleHost
{
    class Program
    {
        //Entry point
        static void Main ( string[] args )
        {
            //Block style declaration - all variables declared at top of function
            //On demand/inline declaration - variables are declared as needed
            do
            {
                char input = DisplayMenu();

                //Handle input
                //if (input == 'A')
                //    AddMovie();
                //else if (input == 'V')
                //    ViewMovie();
                //else if (input == 'Q')
                //    if (ConfirmQuit())
                //        break;  //Exits the loop
                switch (input)
                {
                    case 'a':   //Fallthrough allowed when case statement is empty
                    case 'A': AddMovie(); break;

                    case 'v':
                    case 'V': ViewMovie(); break;

                    case 'q':
                    case 'Q':
                    {
                        if (ConfirmQuit())
                            break;

                        break;
                    };
                    default: Console.WriteLine("Unknown option"); break;
                };
            } while (true);
        }

        private static void ViewMovie ()
        {
            //TODO: Does movie exist
            Console.WriteLine(title);

            //releaseYear (duration mins) rating
            //Formatting 1 - string concatenation
            //Console.WriteLine(releaseYear + " (" + duration + " mins) " + rating);

            //Formatting 2 - string formatting
            //Console.WriteLine("{0} ({1} mins) {2}", releaseYear, duration, rating);
            //string temp = String.Format("{0} ({1} mins) {2}", releaseYear, duration, rating);
            //Console.WriteLine(temp);

            //Formatting 3 - string interpolation
            Console.WriteLine($"{releaseYear} ({duration} mins) {rating}");

            //genre (Color | Black White)
            //Console.WriteLine(genre + " (" + isColor + ")");
            //if (isColor)
            //    Console.WriteLine($"{genre} (Color)");
            //else
            //    Console.WriteLine($"{genre} (Black and White)");
            //Conditional operator
            Console.WriteLine($"{genre} ({(isColor ? "Color" : "Black and White")})");

            //Console.WriteLine(duration);
            //Console.WriteLine(isColor);
            //Console.WriteLine(rating);
            //Console.WriteLine(genre);
            Console.WriteLine(description);
        }

        static bool ConfirmQuit ()
        {
            return ReadBoolean("Are you sure you want to quit (y/n)? ");
        }

        private static void AddMovie () 
        {
            title = ReadString("Enter a movie title: ", true);
            duration = ReadInt32("Enter duration in minutes (>= 0): ", 0);
            releaseYear = ReadInt32("Enter the release year: ", 1900);
            rating = ReadString("Enter a rating (e.g. PG, PG-13): ", true);
            genre = ReadString("Enter a genre (optional): ", false);
            isColor = ReadBoolean("In color (Y/N)?");
            description = ReadString("Enter a description (optional): ", false);
        }

        //Unit 1 only!!!
        static string title;
        static int duration;
        static int releaseYear;
        static string rating;
        static string genre;
        static bool isColor;
        static string description;

        static bool ReadBoolean ( string message )
        {            
            Console.Write(message);

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Y)
                {
                    Console.WriteLine('Y');
                    return true;
                } else if (key.Key == ConsoleKey.N)
                {
                    Console.WriteLine('N');
                    return false;
                };
            } while (true);
        }

        private static int ReadInt32 ( string message, int minimumValue )
        {
            Console.Write(message);

            while (true)
            {
                //Type inferencing - compiler infers actual type based upon usage
                // Has 0 impact on runtime behavior
                //string input = Console.ReadLine();
                var input = Console.ReadLine();

                //Validate
                //int result = Int32.Parse(input);
                //int result;
                //if (Int32.TryParse(input, out result))

                //Inline variable declaration - declare and pass a variable to an output parameter
                //   Identical to above code
                //if (Int32.TryParse(input, out int result))
                //    if (result >= minimumValue)
                if (Int32.TryParse(input, out var result) && result >= minimumValue)
                    return result;

                Console.WriteLine("Value must be >= " + minimumValue);
            };
        }

        //Function naming rules
        //  Functions are actions -> verbs
        //  Functions are always Pascal cased
        // Functions should do a single, logical thing
        private static string ReadString ( string message, bool required )
        {
            Console.WriteLine(message);

            string input = Console.ReadLine();

            //TODO: Validate input, if required

            return input;
        }

        static char DisplayMenu ()
        {
            Console.WriteLine("A)dd Movie");
            Console.WriteLine("V)iew Movie");
            Console.WriteLine("E)dit Movie");
            Console.WriteLine("D)elete Movie");
            Console.WriteLine("Q)uit");

            string input = Console.ReadLine();

            //Validate input
            if (input == "A")
                return 'A';
            else if (input == "V")
                return 'V';
            else if (input == "E")
                return 'E';
            else if (input == "D")
                return 'D';
            else if (input == "Q")
                return 'Q';
            else
            {
                Console.WriteLine("Invalid input");
                return 'X';
            };
        }
            
    }
}
