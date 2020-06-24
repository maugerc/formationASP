using System.Collections.Generic;

namespace KanbanBoard.Web.Models
{
    public class KanbanBoardViewModel
    {
        public List<PostItViewModel> PostIts { get; set; }

        public KanbanBoardViewModel()
        {
            PostIts = new List<PostItViewModel>();
        }
    }
}
