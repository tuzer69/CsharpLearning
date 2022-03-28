using System;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        public static uint Akkerman(uint n, uint m)
        {
            if (n == 0)
                return m + 1;
            else
            if ((n != 0) && (m == 0))
                return Akkerman(n - 1, 1);
            else
                return Akkerman(n - 1, Akkerman(n, m - 1));
        }
    }
}
