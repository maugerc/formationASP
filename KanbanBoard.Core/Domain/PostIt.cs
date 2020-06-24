using System;

namespace KanbanBoard.Core.Domain
{
    public class PostIt
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PostItStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
