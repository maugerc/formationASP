using System;

namespace KanbanBoard.Core.Domain.Exceptions
{
    public class InvalideTransitionForPostItException : Exception
    {
        public string Id => this.Data["Id"].ToString();

        public InvalideTransitionForPostItException(long id, PostItStatus sourceStatus, PostItStatus destStatus)
        {
            this.Data.Add("Id", id);
            this.Data.Add("SourceStatus", sourceStatus);
            this.Data.Add("DescStatus", destStatus);
        }
    }
}