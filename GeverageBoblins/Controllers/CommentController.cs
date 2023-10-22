using GeverageBoblins.DAL;
using GeverageBoblins.Models;
using GeverageBoblins.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeverageBoblins.Controllers
{
    public class CommentController : Controller
    {
        // Injecting the Subforum's Repository
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        // This method creates a container for a subforum
        public async Task<IActionResult> Container()
        {
            Console.WriteLine("In CommentController: Container");

            // Get Data
            var comments = await _commentRepository.GetAll();

            // Make ViewModel with Data and return it
            var commentListViewModel = new CommentListViewModel(comments, "Container");
            return View(commentListViewModel);
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
        public async Task<IActionResult> Create(Comment comment)
        {
            Console.WriteLine("In CommentController: Create");

            if (ModelState.IsValid)
            {
                Console.WriteLine("Comment Model State valid");

                await _commentRepository.Create(comment);

                //return RedirectToAction("Container", "Thread", new { id = comment.ThreadId});
                return Redirect($"{Url.Action("Container", "Thread", new { id = comment.ThreadId })}#comment-" + comment.CommentId);


            }
                Console.WriteLine("Comment Model State NOT valid");
            return View(comment);
        }

        // READ
        // Obtain data from an item based on its id
        public async Task<IActionResult> Details(int id)
        {
            Console.WriteLine("In CommentController: Details");

            // Get Data
            var item = await _commentRepository.GetCommentById(id);

            if (item == null)
            {
                return BadRequest("Comment not found.");
            }

            return View(item);
        }

        // UPDATE
        // Return a Forum object based on its id
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Console.WriteLine("In CommentController: Update");

            var item = await _commentRepository.GetCommentById(id);

            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // Inject updated data into the DB
        [HttpPost]
        public async Task<IActionResult> Update(Comment comment)
        {
            Console.WriteLine("In CommentController: Update");

            if (ModelState.IsValid)
            {
                await _commentRepository.Update(comment);

                return RedirectToAction(nameof(Container));
            }
            return View(comment);
        }

        // DELETE
        // Return a Forum object based on its id
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine("In CommentController: Delete");

            var item = await _commentRepository.GetCommentById(id);
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
            Console.WriteLine("In COMMENT CONTROLLER: DeleteConfirmed, comment id = " + id);

            var comment = await _commentRepository.GetCommentById(id);
            var threadId = comment.ThreadId;

            bool returnOk = await _commentRepository.Delete(id);
            if (!returnOk)
            {
                return BadRequest("Comment deletion failed");
            }
            return RedirectToAction("Container", "Thread", new { id = threadId });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
