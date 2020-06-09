using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLWithHotChocolate.Models
{
    [Table("Notifications", Schema = "workflw")]
    public class Notification
    {
        [Key]
        public long Id { get; set; }
        public string ActionName { get; set; }
        public string ActionLink { get; set; }
        public string Message { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string Icon { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual User Creator { get; set; }
        public virtual ICollection<UserNotification> UserNotifications { get; set; }
    }
}
