using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsInCSharp._03Top_Most_Interview_Question
{
    public static class _01_Reverce_String
    {
        public static void ReverceString(string str) 
        {
            StringBuilder strBuilder = new StringBuilder();

            for (int i = str.Length-1 ; i >=  0 ; i--) 
            {
                strBuilder.Append(str[i]);
            }

            Console.WriteLine(strBuilder);
        }
    }
}
