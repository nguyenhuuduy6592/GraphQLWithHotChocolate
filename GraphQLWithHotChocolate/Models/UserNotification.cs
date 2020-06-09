using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLWithHotChocolate.Models
{
    [Table("UserNotifications", Schema = "workflw")]
    public class UserNotification
    {
        [Key]
        public long NotificationId { get; set; }
        [Key]
        public long UserId { get; set; }
        public bool Readed { get; set; }

        [ForeignKey("NotificationId")]
        public Notification Notification { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
