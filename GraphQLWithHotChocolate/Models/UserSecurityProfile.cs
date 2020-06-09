namespace GraphQLWithHotChocolate.Models
{
    public class UserSecurityProfile
    {
        public long UserId { get; set; }
        public long SecurityProfileId { get; set; }
        public bool IsDefault { get; set; }
        public virtual User User { get; set; }
        public virtual SecurityProfile SecurityProfile { get; set; }
    }
}
