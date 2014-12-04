using System;

namespace App1.Models.Household
{
    public class Person
    {
        public Person()
        {
            Title = new KeyValue();
            MaritalStatus = new KeyValue();
            Gender = new KeyValue();
        }

        public KeyValue Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public KeyValue MaritalStatus { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public KeyValue Gender { get; set; }
        public bool InsuranceDeclined { get; set; }
        public KeyValue Occupation { get; set; }
    }
}