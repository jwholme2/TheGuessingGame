using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TheGuessingGame.Models
{

    public class Employee
    {
        /// <summary>
        /// The employee Id.
        /// </summary>
        [DataMember(Name = "id")]
        public string Id           { get; set; }

        /// <summary>
        /// The first name.
        /// </summary>
        [DataMember(Name = "firstName")]
        public string FirstName        { get; set; }

        /// <summary>
        /// The last name.
        /// </summary>
        [DataMember(Name = "lastName")]
        public string LastName        { get; set; }

        /// <summary>
        /// The headshot details.
        /// </summary>
        public Headshot Headshot      { get; set; }
    }



}
