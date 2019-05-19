using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TheGuessingGame.Models
{

    public class Employee
    {
        [DataMember(Name = "id")]
        public string Id           { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName        { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName        { get; set; }
        //public Headshot Headshot      { get; set; }
    }



}
