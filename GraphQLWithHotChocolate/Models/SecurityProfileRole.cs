namespace GraphQLWithHotChocolate.Models
{
    public class SecurityProfileRole
    {
        public long SecurityProfileId { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
        public SecurityProfile SecurityProfile { get; set; }
    }
}
