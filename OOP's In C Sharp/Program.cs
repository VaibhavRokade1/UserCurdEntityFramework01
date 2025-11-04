using OOP_s_In_C_Sharp.Polymorephism;
using OOPsInCSharp.Abstraction;
using OOPsInCSharp.Collections;
using OOPsInCSharp.File_Handling;
using System;
using System.CodeDom;
using System.Collections;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
namespace OOP_s_In_C_Sharp
{

    public class Program {
       
        public static void Main(String[] args) 
        {
            string Str = "Vaibhav";
            StringBuilder Rev_Str = new StringBuilder();

            for(int i = Str.Length-1 ; i >= 0; i--)
            {
                Rev_Str.Append(Str[i]);
            }

            Console.WriteLine(Rev_Str);
        }

    }
}
