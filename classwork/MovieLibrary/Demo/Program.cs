using System;

namespace Demo
{
    class Program
    {
        static void Main ( string[] args )
        {
            //DemoPrimitives();
            //DemoArithmetic();
            DemoStrings();
        }

        static void DemoStrings ()
        { 
            // All expressions convertible to string using `.ToString()` function
            var payRate = 8.75;            
            var payRateString = payRate.ToString();
            payRateString = 5.ToString();
            payRateString = (4 + 5).ToString();

            // Escape sequences - character sequence that represents something that is unprintable
            //    \n - newline
            //    \t - horizontal tab
            //    \\ - single slash
            //    \" - double quote
            string literal = "Hello World\nBob";
            string filePath = "C:\\windows\\system32";
            string filePath2 = @"C:\windows\system32";  //Verbatim string - ignores escape sequences

            string nullString = null;  //no value
            string emptyString = "";
            string emptyString2 = String.Empty;
            bool areNotEqual = nullString == emptyString;
            //nullString.ToString();     //Crash
            //nullString + emptyString;  //OK

            //Determine if string is null or empty
            bool isEmpty = (emptyString == null || emptyString == ""); //Don't do this!!!
            isEmpty = String.IsNullOrEmpty(emptyString);
            isEmpty = emptyString.Length == 0;  //Will crash if null

            // Case sensitive
            string lowerName = "bob", upperName = "BOB";
            bool areStringsEqual = lowerName == upperName;  //False
            areStringsEqual = lowerName.ToUpper() == upperName.ToUpper(); //Normalize, true
            areStringsEqual = String.Compare(lowerName, upperName, true) == 0;  //StringComparison.IgnoreCase
            areStringsEqual = String.Equals(lowerName, upperName, StringComparison.CurrentCultureIgnoreCase);

            // Useful string functions
            bool startsWithLetter = lowerName.StartsWith("B");  //EndsWith("B");
            lowerName = "  Bob  ";
            lowerName = lowerName.Trim();  //"Bob"  //TrimStart, TrimEnd

            //Add leading spaces
            lowerName = lowerName.PadLeft(20);  //PadRight

            //Joining strings
            string fullName = String.Join(' ', "Bob", "William", "Smith");  //"Bob William Smith"
            string numbers = String.Join(", ", 1, 2, 3, 4);   //"1, 2, 3, 4"

            //Split a string
            var tokens = "1 | 2 | 3 | 4".Split("|");
        }

        static void DemoArithmetic ()
        { 
            //Arithmetic operators
            int x = 10, y = 20, z;

            z = x + y;
            z = x - y;
            z = x * y;
            z = x / y;
            z = x % y;

            //x++ prefix increment
            // temp = x;
            // x += 1;
            // temp;
            x = 10;
            x++;

            //++x postfix incremnt
            // x += 1;
            // x;
            ++x;

            //x-- prefix decrement
            // temp = x;
            // x -= 1;
            // temp;
            x = 10;
            x--;

            //--x postfix decremnt
            // x -= 1;
            // x;
            --x;
        }

        static void DemoPrimitives ()
        { 
            //Primitives
            //Integrals
        sbyte sbyteValue = 10;
            short shortValue = 20;
            int intValue = 62_543;
            long longValue = 40L;

            //Floats
            float floatValue = 45.6F;
            double doubleValue = 5678.115;
            decimal payRate = 17.50M;

            bool isSuccessful = true;
            bool isFailing = false;

            char letterGrade = 'A';
            string name = "Bob";

            //Please don't do this
            int hoursWorked;
            hoursWorked = 0;

            //Definitely assigned
            //hoursWorked = 10;
            intValue = hoursWorked;
        }
    }
}
