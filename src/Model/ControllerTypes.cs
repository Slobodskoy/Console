using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Notes.Model
{
    public enum ControllerTypes
    {
        [Description("return to start")]
        StartController = 0,
        [Description("view all notes")]
        ViewAllController,
        [Description("view note by id")]
        ViewNoteController,
        [Description("add  note")]
        CreateNoteController,
        [Description("edit  note")]
        EditNoteController,
        [Description("delete  note")]
        DeleteNoteController,
        [Description("help")]
        HelpController,
        Unknow
    }
}
