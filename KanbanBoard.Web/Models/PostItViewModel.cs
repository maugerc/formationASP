using KanbanBoard.Core.Domain;

namespace KanbanBoard.Web.Models
{
    public class PostItViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public PostItStatus Status { get; set; }
    }
}