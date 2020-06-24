using AutoMapper;
using KanbanBoard.Core.Domain;

namespace KanbanBoard.Web.Models
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<PostIt, PostItViewModel>();
        }
    }
}
