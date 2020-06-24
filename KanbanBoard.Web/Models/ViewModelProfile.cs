using AutoMapper;
using KanbanBoard.Core.Command;
using KanbanBoard.Core.Domain;

namespace KanbanBoard.Web.Models
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<PostIt, PostItViewModel>();
            CreateMap<AddPostItViewModel, AddPostItCommand>();
            CreateMap<PostIt, UpdatePostItViewModel>();
            CreateMap<UpdatePostItViewModel, UpdatePostItCommand>();
        }
    }
}
