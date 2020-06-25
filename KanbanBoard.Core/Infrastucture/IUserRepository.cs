using KanbanBoard.Core.Domain;

namespace KanbanBoard.Core.Infrastucture
{
    public interface IUserRepository
    {
        User GetByUserNamePassword(string userName, string password);
    }
}
