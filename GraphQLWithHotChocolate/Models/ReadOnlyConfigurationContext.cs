using Microsoft.EntityFrameworkCore;

namespace GraphQLWithHotChocolate.Models
{
    /// <summary>
    /// Include all defined of entities DbSet and config relations.
    /// </summary>
    public partial class ReadOnlyConfigurationContext : DbContext
    {
        public ReadOnlyConfigurationContext(DbContextOptions<ReadOnlyConfigurationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<UserNotification> UserNotifications { get; set; }
        public virtual DbSet<SecurityProfile> SecurityProfiles { get; set; }
        public virtual DbSet<UserSecurityProfile> UserSecurityProfiles { get; set; }
        public virtual DbSet<SecurityProfileRole> SecurityProfileRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(sc => new { sc.RoleId, sc.UserId });

            modelBuilder.Entity<UserNotification>().HasKey(sc => new { sc.NotificationId, sc.UserId });

            // Map relationships
            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(bc => bc.RoleId);

            modelBuilder.Entity<Notification>()
                .HasMany(x => x.UserNotifications)
                .WithOne(x => x.Notification);

            modelBuilder.Entity<UserSecurityProfile>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserSecurityProfiles)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserSecurityProfile>()
                .HasOne(bc => bc.SecurityProfile)
                .WithMany(c => c.UserSecurityProfiles)
                .HasForeignKey(bc => bc.SecurityProfileId);

            modelBuilder.Entity<UserSecurityProfile>().HasKey(r => new
            {
                r.UserId,
                r.SecurityProfileId
            });

            modelBuilder.Entity<SecurityProfileRole>().HasKey(r => new
            {
                r.RoleId,
                r.SecurityProfileId
            });

            modelBuilder.Entity<SecurityProfileRole>()
                .HasOne(x => x.SecurityProfile)
                .WithMany(bc => bc.SecurityProfileRoles)
                .HasForeignKey(bc => bc.SecurityProfileId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
