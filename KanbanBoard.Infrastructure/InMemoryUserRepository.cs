using System.Collections.Generic;
using System.Linq;
using KanbanBoard.Core.Domain;
using KanbanBoard.Core.Infrastucture;

namespace KanbanBoard.Infrastructure
{
    public class InMemoryUserRepository : IUserRepository
    {
        public List<User> Users { get; set; } = new List<User>()
        {
            new User()
            {
                Id = 0,
                UserName = "clement",
                Password = "password"
            }
        };

        public User GetByUserNamePassword(string userName, string password)
        {
            return Users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
