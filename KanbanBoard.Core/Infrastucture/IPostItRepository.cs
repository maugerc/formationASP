using System.Collections.Generic;
using KanbanBoard.Core.Domain;

namespace KanbanBoard.Core.Infrastucture
{
    public interface IPostItRepository
    {
        List<PostIt> GetAll();
        void Add(PostIt postIt);
        PostIt GetById(long id);
        void Update(PostIt postIt);
    }
}
