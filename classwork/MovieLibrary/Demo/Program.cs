using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
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
