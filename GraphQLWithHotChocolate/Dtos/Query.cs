using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using GraphQLWithHotChocolate.Models;

namespace GraphQLWithHotChocolate.Dtos
{
    public class Query
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        [UseSelection]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([Service]ReadOnlyConfigurationContext dbContext) => dbContext.Users;
    }
}
