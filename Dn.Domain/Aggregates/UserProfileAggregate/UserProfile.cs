namespace Dn.Domain.Aggregates.UserProfileAggregate
{
    public class UserProfile
    {
        private UserProfile() { }


        public Guid UserProfileId { get; private set; }
        public string IdentityId { get; private set; }
        public BasicInfo BasicInfo { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastModified { get; private set; }

        //Factory method
        public static UserProfile CreateUserProfile(string IdentityId, BasicInfo basicInfo)
        {
            //TO DO: Add validation, error handling strategies, error notification strategies
            return new UserProfile
            {
                IdentityId = IdentityId,
                BasicInfo = basicInfo,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };
        }

        //Public methods
        public void UpdateBasicInfo(BasicInfo newInfo)
        {
            BasicInfo = newInfo;
            LastModified = DateTime.UtcNow;
        }
    }
}
