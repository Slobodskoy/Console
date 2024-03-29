﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notes.DB;
using Notes.Infrastructure;
using Notes.Model;
using Notes.View;

namespace Notes.Controller
{
    public class DeleteNoteController : BaseController, IDeleteNoteController
    {
        private readonly IRepository repository;
        private readonly IView<Note, IDeleteNoteController> pageView;

        public override IEnumerable<ControllerTypes> NextSteps
        {
            get => new ControllerTypes[] { ControllerTypes.StartController, ControllerTypes.HelpController };
        }

        public DeleteNoteController(IControllerFactory controllerFactory, IRepository repository, IView<Note, IDeleteNoteController> pageView)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "Delete note by id";
            this.pageView.Controller = this;
        }

        public override void Run()
        {
            pageView.Render();
        }

        public void Run(int id)
        {
            var result = repository.DeleteNode(id);
            pageView.Model = new Note { Id = result ? id : 0 };
            pageView.Render();
        }

    }
}
