using System;
using System.Collections;
using System.Linq;

namespace Sweepstakes
{
    public class Contestant
    {
        int registrationNumber= -1;
        string lastName;
        string firstName;
        string emailAddress;
        
        public Contestant(string lastName, string firstName, string emailAddress)
        {
            // require last, first, email
            this.lastName = lastName;
            this.firstName = firstName;
            this.emailAddress = emailAddress;
        }
        public override string ToString()
        {
            return $"{lastName}, {firstName}, {emailAddress}, {registrationNumber}";
        }
        //public override string ToString()
        //{
        //    //return base.ToString();
        //    return $"Last name = {lastName}\nFirst name = {firstName}\n Email address = {emailAddress}\nRegistration number = {registrationNumber}";
        //}
        public string EmailAddress
        {
            get => emailAddress;
            set { if (emailAddress == null) emailAddress = value; }
        }

        public string LastName
        {
            get => lastName;
            set { if (lastName == null) lastName = value; }
        }

        public string FirstName
        {
            get => firstName;
            set { if (firstName == null) firstName = value; }
        }

        public int RegistrationNumber
        {
            get => registrationNumber;
            set { if (registrationNumber == -1) registrationNumber = value; }
        }
    }
}