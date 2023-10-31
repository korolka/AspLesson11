using AspLesson11.Database;
using AspLesson11.Models;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AspLesson11.Controllers
{
    public class HomeController : Controller
    {

        [Authorize(Roles = "User")]
        public IActionResult Index(string? result)
        {
            ViewBag.Result = result;
            return View();
        }
        [HttpGet]
        public IActionResult AddNote()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult AddNote(AddNoteModel note)
        {
            if (!string.IsNullOrEmpty(note.Text))
            {
                using (NoteContext context = new NoteContext())
                {
                    var users = from user in context.Users
                                where user.Email == User.Identity.Name
                                select user;
                    Notes newNote = new Notes() { Note = note.Text, UserId = users.Single().UserId };
                    context.Notes.Add(newNote);
                    context.SaveChanges();
                    return View("Index", "note was suucsess save" as object);
                }
            }
            else
            {
                return View("Index", "Note must have message");
            }
        }

        [Authorize(Roles = "User")]
        public IActionResult ReadListOfNotes()
        {
            using (NoteContext context = new NoteContext())
            {
                var users = from user in context.Users
                            where user.Email == User.Identity.Name
                            select user;
                List<Notes> notes = context.Notes.Where(notes => notes.UserId == users.Single().UserId).ToList();
                return View(notes);
            }
        }


        [Authorize(Roles = "User")]
        public IActionResult ReadNote(int noteId)
        {
            using (NoteContext contex = new NoteContext())
            {
                string note = contex.Notes.Where(note=>note.NoteId == noteId).Single().Note;
                return View(note as object);
            }
        }
    }
}
