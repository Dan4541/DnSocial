using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dn.Domain.Aggregates.UserProfileAggregate
{
    public class BasicInfo
    {
        private BasicInfo() { }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string Phone { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string CurrentCity { get; private set; }

        //Factory method
        public static BasicInfo CreateBasicInfo(string FirstName, string LastName, string EmailAddress,
            string Phone, DateTime DateOfBirth, string CurrentCity)
        {
            //TO DO: Add validation, error handling strategies, error notification strategies
            return new BasicInfo()
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = EmailAddress,
                Phone = Phone,
                DateOfBirth = DateOfBirth,
                CurrentCity = CurrentCity
            };
        }

        

    }
}
