﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesMoshCourse
{
    public class FizzBuzz
    {
        public static string GetOutput(int number)
        {
            if ((number % 5 == 0) && (number % 3 == 0))
                return "FizzBuzz";

            if (number % 3 == 0)
                return "Fizz";

            if (number % 5 == 0)
                return "Buzz";

            return number.ToString();   
        }
    }
}
