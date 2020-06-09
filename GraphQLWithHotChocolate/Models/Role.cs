using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQLWithHotChocolate.Models
{
    public class Role
    {
        public long Id { get; set; }

        [MaxLength(450)]
        public string Guid { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }


        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
