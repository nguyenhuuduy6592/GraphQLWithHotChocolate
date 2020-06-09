using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQLWithHotChocolate.Models
{
    public class SecurityProfile
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public long? ModifiedBy { get; set; }
        public virtual ICollection<SecurityProfileRole> SecurityProfileRoles { get; set; } = new List<SecurityProfileRole>();
        public virtual ICollection<UserSecurityProfile> UserSecurityProfiles { get; set; } = new List<UserSecurityProfile>();
    }
}
