using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NollyTickets.Ng.Data;
using NollyTickets.Ng.Data.Services;
using NollyTickets.Ng.Models;

namespace NollyTickets.Ng.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public  async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        //Get: producer/detail/id
        public async Task<IActionResult> Details(int id)
        {
            var prodDetails = await _service.GetByIdAsync(id);
            if (prodDetails == null) return View("NotFound");
            return View(prodDetails);
        }


        //Get:Producers/Create
        public IActionResult Create()
        {
            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            await _service.AddAsync(producer);
            TempData["success"] = "Producer Created successfully";
            return RedirectToAction(nameof(Index));
        }

        //Get:Producers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var prodDetails = await _service.GetByIdAsync(id);
            if (prodDetails == null) return View("NotFound");
            return View(prodDetails);
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            
            if (!ModelState.IsValid) return View(producer);
            if(id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                TempData["success"] = $"{producer.FullName} Updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(producer);

          
        }

        //Get:Producers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var prodDetails = await _service.GetByIdAsync(id);
            if (prodDetails == null) return View("NotFound");
            return View(prodDetails);
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodDetails = await _service.GetByIdAsync(id);
            if (prodDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            TempData["success"] = $"{prodDetails.FullName} Deleted successfully";
            return RedirectToAction(nameof(Index));



        }
    }
}
