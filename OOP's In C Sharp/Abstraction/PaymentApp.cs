using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOPsInCSharp.Abstraction
{
    public abstract class PaymentApp
    {

        public abstract void MakePayment(int amount);
        public string Id { get; set; }
        public PaymentApp() {
            Random random = new Random();
           Id =  random.ToString();
        }
    }

    //make payment by 

    public class CreaditCard : PaymentApp
    {
        public override void MakePayment(int amount)
        {
            Console.WriteLine("by creadit card id" , Id);
            Console.WriteLine("amount : " , amount);
        } 
       
    }

    public class UPIId : PaymentApp 
    {
        public override void MakePayment(int amount)
        {
            Console.WriteLine("by UPI id", Id);
            Console.WriteLine("amount : ", amount);
        }
    }
}
