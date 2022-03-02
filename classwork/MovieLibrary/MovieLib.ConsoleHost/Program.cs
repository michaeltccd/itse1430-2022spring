/*
 * Classwork
 * ITSE 1430 
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
            var done = false;
            do
            {
                char input = DisplayMenu();

                #region Comments

                //Handle input
                //if (input == 'A')
                //    AddMovie();
                //else if (input == 'V')
                //    ViewMovie();
                //else if (input == 'Q')
                //    if (ConfirmQuit())
                //        break;  //Exits the loop

                //Switch statement replaces a series of if-else-if where a single expression
                // is compared to constant values
                // - Expression can be any expression type
                // - Case labels must be:
                //     - Compile time constants
                //     - Unique within the statement
                // - Fallthrough is not allowed in C# unless the previous case statement is empty
                // - Block statement should be used for multiple statements but
                //   because of compilation issues is not required in many cases
                //   Most developers use block statement when there is more than 1 statement excluding break
                #endregion
                switch (input)
                {
                    case 'a':   //Fallthrough allowed when case statement is empty
                    case 'A': AddMovie(); break;

                    case 'v':
                    case 'V': ViewMovie(); break;

                    case 'd':
                    case 'D': DeleteMovie(); break;

                    case 'q':
                    case 'Q':
                    {
                        if (ConfirmQuit())
                            done = true;

                        break;
                    };
                    default: Console.WriteLine("Unknown option"); break;
                };
            } while (!done);
        }

        //Display the main menu
        static char DisplayMenu ()
        {
            Console.WriteLine("Movie Library");
            //Console.WriteLine("--------------");
            Console.WriteLine("".PadLeft(20, '-'));
            Console.WriteLine("A)dd Movie");
            Console.WriteLine("V)iew Movie");
            Console.WriteLine("E)dit Movie");
            Console.WriteLine("D)elete Movie");
            Console.WriteLine("Q)uit");

            do
            {
                string input = Console.ReadLine();

                //Validate input, case insensitive
                if (String.Compare(input, "A", true) == 0)
                    return 'A';
                else if (String.Compare(input, "V", true) == 0)
                    return 'V';
                else if (String.Equals(input, "E", StringComparison.CurrentCultureIgnoreCase))
                    return 'E';
                else if (String.Compare(input, "D", true) == 0)
                    return 'D';
                else if (String.Compare(input, "Q", true) == 0)
                    return 'Q';
                else
                    Console.WriteLine("Invalid input");
            } while (true);
        }

        // Adds a movie
        private static void AddMovie ()
        {
            movie = new Movie();

            object val = 10;
            val = "Hello";
            val = null;
            
            //movie.IsBlackAndWhite = false;
            do
            {
                movie.Title = ReadString("Enter a movie title: ", true);
                movie.Duration = ReadInt32("Enter duration in minutes (>= 0): ", 0);
                movie.ReleaseYear = ReadInt32("Enter the release year: ", 1900);
                movie.Rating = ReadString("Enter a rating (e.g. PG, PG-13): ", true);
                movie.Genre = ReadString("Enter a genre (optional): ", false);
                movie.IsClassic = ReadBoolean("Is classic (Y/N)?");
                movie.Description = ReadString("Enter a description (optional): ", false);

                //movie.isBlackAndWhite = movie.releaseYear <= 1939;
                //movie.CalculateBlackAndWhite();

                var error = movie.Validate();
                if (String.IsNullOrEmpty(error))
                    return;

                Console.WriteLine(error);
            } while (true);
        }

        // Deletes a movie
        private static void DeleteMovie ()
        {
            //if (String.IsNullOrEmpty(movie.title))
            if (movie == null)
            {
                Console.WriteLine("No movie to delete");
                return;
            };

            //Confirm and delete the movie
            if (ReadBoolean($"Are you sure you want to delete '{movie.Title}' (Y/N)"))
                movie = null;
        }

        //View a movie
        private static void ViewMovie ()
        {
            //Does movie exist
            //if (String.IsNullOrEmpty(movie.title))
            if (movie == null)
            {
                Console.WriteLine("No movie to view");
                return;
            };

            Console.WriteLine(movie.Title);

            //Desired format: releaseYear (duration mins) rating
            
            //Formatting 1 - string concatenation
            //  Console.WriteLine(releaseYear + " (" + duration + " mins) " + rating);
            //Formatting 2 - string formatting
            //  Console.WriteLine("{0} ({1} mins) {2}", releaseYear, duration, rating);
            //  string temp = String.Format("{0} ({1} mins) {2}", releaseYear, duration, rating);
            //  Console.WriteLine(temp);
            //Formatting 3 - string interpolation
            Console.WriteLine($"{movie.ReleaseYear} ({movie.Duration} mins) {movie.Rating}");
            
            //Conditional operator
            Console.WriteLine($"{movie.Genre} ({(movie.IsClassic ? "Classic" : "")})");
            Console.WriteLine(movie.Description);
        }

        //TODO: Fix these variables to remove warnings
        static Movie movie;

        //Type checking
        static void Display ( object data )
        {
            //Assume a string

            //C-style cast ::= (T) E
            //    Runtime error if wrong
            //    No way to validate at runtime
            //    Still compile time safe (string)10;
            // is-operator ::= E is T  (boolean)
            //    Still need a type cast 
            // as-operator ::= E as T (returns T or null)
            //    Only works with T if T is nullable (string, object, class types)
            // pattern-matching ::= E is T id (boolean with id as typed value if true)
            var dataString = (string)data;                        

            if (data is string)
            {
                dataString = (string)data;
            };

            //data as int
            dataString = data as string;
            if (dataString != null) { };

            //Pattern matching
            if (data is string dataString2)
            {
            };
        }

        #region Helper Functions

        // Get confirmation from user to quit
        static bool ConfirmQuit ()
        {
            return ReadBoolean("Are you sure you want to quit (y/n)? ");
        }
                
        // Reads a boolean input from user
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

        // Reads an integral value from user
        static int ReadInt32 ( string message, int minimumValue )
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

        // Reads a(n), optionally required, string from the user
        private static string ReadString ( string message, bool required )
        {
            Console.WriteLine(message);

            do
            {
                string input = Console.ReadLine();

                //Validate if required
                if (!required || !String.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine("Value is required");
            } while (true);
        }
        #endregion
    }
}
