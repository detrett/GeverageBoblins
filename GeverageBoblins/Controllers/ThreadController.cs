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
        public async Task<IActionResult> Container()
        {
            // Get Data
            var threads = await _threadRepository.GetAll();

            // Make ViewModel with Data and return it
            var threadListViewModel = new ThreadListViewModel(threads, "Container");
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
        public async Task<IActionResult> Create(Models.Thread thread)
        {
            if (ModelState.IsValid)
            {
                await _threadRepository.Create(thread);
                return RedirectToAction(nameof(Container));
            }
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
