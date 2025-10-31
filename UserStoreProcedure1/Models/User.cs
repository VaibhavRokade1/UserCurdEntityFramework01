using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStoreProcedure1.Models
{
    public class User
    {
        public int Uid { get; set; }
        public string Uname { get; set; }
        public string Uemail { get; set;  }
        public string Upassword { get; set; }
        public int Uage { get; set; }

        public override string ToString()
        {
            return $"User : {{ id : {this.Uid} , Name : {this.Uname} , Eamil : {this.Uemail} , Uage : {this.Uage} }}";
        }

    }
}
