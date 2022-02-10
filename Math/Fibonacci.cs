using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    public class Fibonacci
    {
        public Fibonacci()
        {
                
        }
        public int GetFibonacciNumber(int n1)
        {
            if (n1 <= 2 && n1 > 0)
                return 1;
            else if (n1 == 0) return 0;
            else
                return GetFibonacciNumber(n1 - 1) + GetFibonacciNumber(n1 - 2);
        }
    }
}
