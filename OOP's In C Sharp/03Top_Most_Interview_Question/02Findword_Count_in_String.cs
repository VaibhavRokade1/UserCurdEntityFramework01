using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsInCSharp._03Top_Most_Interview_Question
{
    public static class Findword_Count_in_String
    {
        public static int PrintWordCountInString(string str) 
        {
            if (str.Trim().Length < 0) 
            {
                Console.WriteLine("String is Empty...!");
                return 0;
            }

            int coun = 0;
            for (int i = 0; i < str.Trim().Length; i++) 
            {
                if (str[i] == ' ') 
                {
                    coun++;
                }

            }
            Console.WriteLine("Total words in given String : " + (coun + 1));
            return 0;
        }
    }
}
