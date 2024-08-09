using Dn.Domain.Exceptions;
using Dn.Domain.Validators.UserProfileValidators;

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

        /// <summary>
        /// Creates a new BasicInfo instance
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="emailAddress">Emnail address</param>
        /// <param name="phone">Phone</param>
        /// <param name="dateOfBirth">Date of Birth</param>
        /// <param name="currentCity">Current city</param>
        /// <returns><see cref="BasicInfo"/></returns>
        /// <exception cref="UserProfileNotValidException"></exception>
        public static BasicInfo CreateBasicInfo(string FirstName, string LastName, string EmailAddress,
            string Phone, DateTime DateOfBirth, string CurrentCity)
        {
            var validator = new BasicInfoValidator();
            
            var objToValidate = new BasicInfo()
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = EmailAddress,
                Phone = Phone,
                DateOfBirth = DateOfBirth,
                CurrentCity = CurrentCity
            };

            var validationResult = validator.Validate(objToValidate);

            if (validationResult.IsValid) return objToValidate;

            var exception = new UserProfileNotValidException("The user profile is no valid.");

            foreach (var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }

            throw exception;
        }

        

    }
}
