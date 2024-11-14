using CarPark.Models;
using CarPark.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPark.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ICarRepo _repo;

        public CreateModel(ICarRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Car Item { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _repo.AddAsync(Item);
            return RedirectToPage("Index");
        }
    }
}
