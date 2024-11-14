using CarPark.Models;
using CarPark.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPark.Pages.TripTickets
{
    public class DeleteModel : PageModel
    {
        private readonly ITripTicketRepo _repo;

        public DeleteModel(ITripTicketRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public TripTicket Item { get; set; }

        public async void OnGetAsync(string id)
        {
            Item = await _repo.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _repo.DeleteAsync(Item.Id);
            return RedirectToPage("../Index");
        }
    }
}
