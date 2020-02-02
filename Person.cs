using System;
using System.Collections.Generic;
using System.Text;

namespace SmallCrm
{
    class Person
    {
        private int age_;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age
        {
            get {

                return age_;
            }
            set {
                if (value >= 1 && value < 120) {
                    age_ = value;
                    return;
                }
                throw new ArgumentOutOfRangeException("age", "Age must be in range [1-120]");

            }
        }

        public Person(string lsName)
        {
            if (string.IsNullOrEmpty(lsName)) {
                throw new ArgumentNullException(nameof(LastName));
            }
            LastName = lsName;
        }


        public string PrintFullName()
        {

            return $" fullname {FirstName}   {LastName} ";


        }

        public bool IsAdultPerson()
        {

            return Age >= 18;

        }
    }
}
