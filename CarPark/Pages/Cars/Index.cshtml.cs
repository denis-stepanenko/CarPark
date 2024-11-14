using CarPark.Models;
using CarPark.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPark.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ICarRepo _repo;

        public IndexModel(ICarRepo repo)
        {
            _repo = repo;
        }

        public PaginatedResult<Car> Data { get; set; }

        public async Task OnGetAsync(int pageNumber = 1)
        {
            Data = await _repo.GetPaginatedAsync(pageNumber, pageSize: 2);
        }
    }
}
