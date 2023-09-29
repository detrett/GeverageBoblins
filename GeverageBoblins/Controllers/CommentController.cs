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
            if (ModelState.IsValid)
            {
                await _commentRepository.Create(comment);
                return RedirectToAction(nameof(Container));
            }
            return View(comment);
        }

        // READ
        // Obtain data from an item based on its id
        public async Task<IActionResult> Details(int id)
        {
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
            await _commentRepository.Delete(id);
            return RedirectToAction(nameof(Container));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
