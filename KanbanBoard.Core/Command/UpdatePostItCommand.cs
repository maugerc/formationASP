namespace KanbanBoard.Core.Command
{
    public class UpdatePostItCommand
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}