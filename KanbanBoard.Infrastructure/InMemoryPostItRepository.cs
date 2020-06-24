using System.Collections.Generic;
using KanbanBoard.Core.Domain;
using KanbanBoard.Core.Infrastucture;

namespace KanbanBoard.Infrastructure
{
    public class InMemoryPostItRepository : IPostItRepository
    {
        private static List<PostIt> _postIts;

        public InMemoryPostItRepository()
        {
            _postIts = new List<PostIt>()
            {
                new PostIt()
                {
                    Title = "PostIt 1"
                },
                new PostIt()
                {
                    Title = "PostIt 2"
                }
            };
        }

        public List<PostIt> GetAll()
        {
            return _postIts;
        }
    }
}
