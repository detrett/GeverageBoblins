using GeverageBoblins.DAL;
using GeverageBoblins.Models;
using GeverageBoblins.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using Thread = GeverageBoblins.Models.Thread;

namespace GeverageBoblins.Controllers
{
    public class ThreadController : Controller
    {
        // Injecting the Thread's Repository
        private readonly IThreadRepository _threadRepository;

        public ThreadController(IThreadRepository threadRepository)
        {
            _threadRepository = threadRepository;
        }

        // This method creates a container for a thread
        public async Task<IActionResult> Container(int id, int commentId)
        {
            // Redirects to the last comment if its ID was given
            if(commentId != 0)
            {
                return Redirect($"{Url.Action("Container", "Thread", new { id = id })}#comment-" + commentId);
            }

            // Get Data
            var thread = await _threadRepository.GetThreadById(id);

            // Make ViewModel with Data and return it
            var threadListViewModel = new ThreadListViewModel(thread, "Container");
            return View(threadListViewModel);
        }

        // CRUD

        // CREATE
        // Redirect the user to a form to input the data
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Inject data into the DB
        [HttpPost]
        public async Task<IActionResult> Create(Thread thread)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Model State valid");
                thread.Comments = new List<Comment>();

                // Add thread to DB
                await _threadRepository.Create(thread);

                var firstComment = new Comment();
                firstComment.Title = thread.Name;
                firstComment.UserId = thread.UserId;
                firstComment.Body = thread.Description;
                firstComment.ThreadId = thread.ThreadId;
                firstComment.CreatedAt = thread.CreatedAt;
                     
                await _threadRepository.CreateComment(firstComment);

                thread.ParentSubforum = await _threadRepository.GetSubforumById(thread.SubforumId);

                return Redirect($"{Url.Action("Container", "Thread", new { id = thread.ThreadId })}#comment-" + firstComment.CommentId);
            }
            Console.WriteLine("Model State NOT valid");

            return View(thread);
        }

        // READ
        // Obtain data from an item based on its id
        public async Task<IActionResult> Details(int id)
        {
            // Get Data
            var item = await _threadRepository.GetThreadById(id);

            if (item == null)
            {
                return BadRequest("Thread not found.");
            }

            return View(item);
        }

        // UPDATE
        // Return a Forum object based on its id
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var item = await _threadRepository.GetThreadById(id);

            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // Inject updated data into the DB
        [HttpPost]
        public async Task<IActionResult> Update(Models.Thread thread)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Model State valid");

                await _threadRepository.Update(thread);

                return Redirect($"{Url.Action("Container", "Thread", new { id = thread.ThreadId })}");
            }
            return View(thread);
        }

        // DELETE
        // Return a Forum object based on its id
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _threadRepository.GetThreadById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // Delete data from the DB
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _threadRepository.Delete(id);
            return RedirectToAction(nameof(Container));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
