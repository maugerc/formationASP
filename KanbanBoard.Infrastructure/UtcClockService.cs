using System;
using KanbanBoard.Core.Infrastucture;

namespace KanbanBoard.Infrastructure
{
    public class UtcClockService : IClockService
    {
        public DateTime GetNow() => DateTime.UtcNow;
    }
}
