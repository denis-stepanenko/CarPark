using CarPark.Models;
using CarPark.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPark.Pages.Drivers
{
    public class IndexModel : PageModel
    {
        private readonly IDriverRepo _repo;

        public IndexModel(IDriverRepo repo)
        {
            _repo = repo;
        }

        public PaginatedResult<Driver> Data { get; set; }

        public async Task OnGetAsync(int pageNumber = 1)
        {
            Data = await _repo.GetPaginatedAsync(pageNumber, pageSize: 2);
        }
    }
}
