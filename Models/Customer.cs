using System;

namespace usergate2.Models
{
    public class Customer
    {


        public string Name { get; set; }

        public string Date {get; set;}

//public int SexId {get; set;}
        public string Sex {get; set;}

        public string Born{get; set;}

        public string Registration{get; set;}

        public string Address{get; set;}

        public string Passport{get; set;}

        public string Phone { get; set; }

        public string Price {get; set;}

        public string Service{get; set;}

        public string Comment {get; set;}

        public string Login {get; set;}

        public string NumberDocument {get; set;}

        public string NowDate{get; set;}


        public override string ToString(){
            return "Name="+Name+"&Sex="+Sex;
        }
    }
}
