using CarPark.Models;
using CarPark.Repos;
using CarPark.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPark.Pages.TripTickets
{
    public class EditModel : PageModel
    {
        private readonly ITripTicketRepo _repo;
        private readonly ICarRepo _carRepo;
        private readonly IDriverRepo _driverRepo;

        public EditModel(ITripTicketRepo repo, ICarRepo carRepo, IDriverRepo driverRepo)
        {
            _repo = repo;
            _carRepo = carRepo;
            _driverRepo = driverRepo;
        }

        [BindProperty]
        public TripTicket Item { get; set; }

        public async void OnGetAsync(string id)
        {
            Item = await _repo.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(string carId, string driverId)
        {
            if (string.IsNullOrWhiteSpace(carId))
            {
                ModelState.AddModelError("Item.Car.Id", "Choose car");
            }

            if (string.IsNullOrWhiteSpace(driverId))
            {
                ModelState.AddModelError("Item.Driver.Id", "Choose driver");
            }

            if (!ModelState.IsValid)
                return Page();

            Car car = await _carRepo.GetByIdAsync(carId);
            Item.Car = car;

            Driver driver = await _driverRepo.GetByIdAsync(driverId);
            Item.Driver = driver;

            await _repo.UpdateAsync(Item);
            return RedirectToPage("../Index");
        }
    }
}
