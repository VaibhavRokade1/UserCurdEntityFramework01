using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Store_Procedure.Models
{
    public class User
    {
        public int Uid { get; set; }
        public string Uname { get; set; }
        public string Upassword{ get; set; }
        public string Uemail{ get; set; }
        public int Uage{ get; set; }

        public override string ToString()
        {
            return $"User {{ Id : {this.Uid} , Name : {this.Uname} , Email : {this.Uemail} , Age : {this.Uage} }}";
        }
    }
}
