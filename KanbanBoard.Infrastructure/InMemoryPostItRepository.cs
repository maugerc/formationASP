using System.Collections.Generic;
using System.Linq;
using KanbanBoard.Core.Domain;
using KanbanBoard.Core.Infrastucture;

namespace KanbanBoard.Infrastructure
{
    public class InMemoryPostItRepository : IPostItRepository
    {
        private static List<PostIt> _postIts = new List<PostIt>();

        public List<PostIt> GetAll()
        {
            return _postIts;
        }

        public void Add(PostIt postIt)
        {
            postIt.Id = _postIts.Any() ? _postIts.Max(p => p.Id) + 1 : 0;
            _postIts.Add(postIt);
        }

        public PostIt GetById(long id)
        {
            return _postIts.SingleOrDefault(p => p.Id == id);
        }

        public void Update(PostIt postIt)
        {
            var pi = _postIts.SingleOrDefault(p => p.Id == postIt.Id);
            pi = postIt;
        }
    }
}
