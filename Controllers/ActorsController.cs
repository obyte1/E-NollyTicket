using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NollyTickets.Ng.Data;
using NollyTickets.Ng.Data.Services;
using NollyTickets.Ng.Models;

namespace NollyTickets.Ng.Controllers
{
    public class ActorsController : Controller
    {
        //inject the services
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAllAsync();
            return View(allActors);
        }
        //Get: Actors/Create
        public  IActionResult Create()
        {

            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
             await _service.AddAsync(actor);
            TempData["success"] = "Actor Created successfully";
            return   RedirectToAction(nameof(Index));
 
        }

        //Get : Actors/Details
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit( int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id,actor);
            TempData["success"] = $"{actor.FullName} Updated successfully";
            return RedirectToAction(nameof(Index));

        }
        //Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
      
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
         
            TempData["success"] = $"{actorDetails.FullName} Deleted successfully";
            return RedirectToAction(nameof(Index));

        }

    }
}
