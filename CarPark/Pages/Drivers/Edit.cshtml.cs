using CarPark.Models;
using CarPark.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPark.Pages.Drivers
{
    public class EditModel : PageModel
    {
        private readonly IDriverRepo _repo;

        public EditModel(IDriverRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Driver Item { get; set; }

        public async void OnGetAsync(string id)
        {
            Item = await _repo.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _repo.UpdateAsync(Item);
            return RedirectToPage("Index");
        }
    }
}
