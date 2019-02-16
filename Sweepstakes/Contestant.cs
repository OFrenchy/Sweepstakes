using System;
using System.Collections;
using System.Linq;

namespace Sweepstakes
{
    public class Contestant
    {
        int registrationNumber;
        string lastName;
        string firstName;
        string emailAddress;
        bool winner = false;

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
            set { if (registrationNumber = 0) registrationNumber = value; }
        }
    }
}