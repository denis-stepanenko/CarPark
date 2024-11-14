using CarPark.Models;
using CarPark.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPark.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITripTicketRepo _repo;

        public IndexModel(ITripTicketRepo repo)
        {
            _repo = repo;
        }

        public PaginatedResult<TripTicket> Data { get; set; }
        public long Count { get; set; }
        public int PageNumber { get; set; }

        public async Task OnGetAsync(int pageNumber = 1)
        {
            Data = await _repo.GetPaginatedAsync(pageNumber, pageSize: 2);
        }

        public async Task<IActionResult> OnPostMarkAsync(string id)
        {
            TripTicket ticket = await _repo.GetByIdAsync(id);
            ticket.IsMarked = !ticket.IsMarked;

            await _repo.UpdateAsync(ticket);

            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostCloseAsync(string id)
        {
            TripTicket ticket = await _repo.GetByIdAsync(id);
            ticket.IsClosed = !ticket.IsClosed;

            await _repo.UpdateAsync(ticket);

            return RedirectToPage("Index");
        }
    }
}
