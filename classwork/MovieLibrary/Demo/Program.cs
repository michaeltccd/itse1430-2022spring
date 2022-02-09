using System;

namespace Demo
{
    class Program
    {
        static void Main ( string[] args )
        {
            //DemoPrimitives();
            //DemoArithmetic();

            //Strings
            var payRate = 8.75;
            var payRateString = payRate.ToString();

            // Escape sequences - character sequence that represents something that is unprintable
            //    \n - newline
            //    \t - horizontal tab
            //    \\ - single slash
            //    \" - double quote
            string literal = "Hello World\nBob";
            string filePath = "C:\\windows\\system32";
            string filePath2 = @"C:\windows\system32";  //Verbatim string - ignores escape sequences
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
