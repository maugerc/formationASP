﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KanbanBoard.Core.Command;
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

        [HttpGet]
        public IActionResult Index()
        {
            List<PostIt> postIts = _kanbanBoardService.GetAllPostIts();

            var vm = new KanbanBoardViewModel
            {
                PostIts = postIts.Select(_mapper.Map<PostItViewModel>).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult AddPostIt()
        {
            return View(new AddPostItViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPostIt([FromForm] AddPostItViewModel addPostIt)
        {
            if (ModelState.IsValid)
            {
                _kanbanBoardService.AddPostIt(_mapper.Map<AddPostItCommand>(addPostIt));
                return RedirectToAction(nameof(Index));
            }

            return View(addPostIt);
        }

        [HttpGet("KanbanBoard/PostIt/{id}")]
        public IActionResult UpdatePostIt(long id)
        {
            var postIt = _kanbanBoardService.GetPostIt(id);

            return View(_mapper.Map<UpdatePostItViewModel>(postIt));
        }

        [HttpPost("KanbanBoard/PostIt/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePostIt([FromForm] UpdatePostItViewModel updatedPostIt)
        {
            if (ModelState.IsValid)
            {
                _kanbanBoardService.UpdatePostIt(_mapper.Map<UpdatePostItCommand>(updatedPostIt));
                return RedirectToAction(nameof(Index));
            }

            return View(updatedPostIt);
        }
    }
}
