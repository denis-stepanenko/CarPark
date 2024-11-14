using CarPark.Models;
using CarPark.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPark.Pages.Drivers
{
    public class CreateModel : PageModel
    {
        private readonly IDriverRepo _repo;

        public CreateModel(IDriverRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Driver Item { get; set; }

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
