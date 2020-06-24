using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KanbanBoard.Core.Domain;
using KanbanBoard.Core.Services;
using KanbanBoard.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.Web.Controllers
{
    public class KanbanBoardController : Controller
    {
        private readonly KanbanBoardService _kanbanBoardService;
        private readonly IMapper _mapper;

        public KanbanBoardController(KanbanBoardService kanbanBoardService, IMapper mapper)
        {
            _kanbanBoardService = kanbanBoardService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<PostIt> postIts = _kanbanBoardService.GetAllPostIts();

            var vm = new KanbanBoardViewModel
            {
                PostIts = postIts.Select(_mapper.Map<PostItViewModel>).ToList()
            };

            return View(vm);
        }
    }
}
