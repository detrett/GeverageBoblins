using GeverageBoblins.DAL;
using GeverageBoblins.Models;
using GeverageBoblins.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create(SubforumThreadComment stc)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Model State valid");
                // Add comment to thread
                stc.newThread.Comments = new List<Comment> { stc.newComment };
                stc.newThread.ParentSubforum = stc.Subforum;
                stc.newThread.UserId = 5;
                // Add thread to DB
                await _threadRepository.Create(stc.newThread);
                // Link comment to thread
                stc.newComment.ThreadId = stc.newThread.ThreadId;
                // Save comment to DB
                await _threadRepository.CreateComment(stc.newComment);

                return RedirectToAction(nameof(Container));
            }
            Console.WriteLine("Model State NOT valid");

            return View(stc.newThread);
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
                await _threadRepository.Update(thread);

                return RedirectToAction(nameof(Container));
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
