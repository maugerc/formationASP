using System;

namespace KanbanBoard.Core.Infrastucture
{
    public interface IClockService
    {
        DateTime GetNow();
    }
}