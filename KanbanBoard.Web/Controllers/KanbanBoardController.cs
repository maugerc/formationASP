using System.Collections.Generic;
using KanbanBoard.Core.Domain;
using KanbanBoard.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.Web.Controllers
{
    public class KanbanBoardController : Controller
    {
        private readonly KanbanBoardService _kanbanBoardService;

        public KanbanBoardController(KanbanBoardService kanbanBoardService)
        {
            _kanbanBoardService = kanbanBoardService;
        }

        public IActionResult Index()
        {
            List<PostIt> postIts = _kanbanBoardService.GetAllPostIts();

            return View(postIts);
        }
    }
}
