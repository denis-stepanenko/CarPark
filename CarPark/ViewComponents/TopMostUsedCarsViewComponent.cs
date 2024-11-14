using CarPark.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.ViewComponents
{
    public class TopMostUsedCarsViewComponent : ViewComponent
    {
        private readonly ITripTicketRepo _repo;

        public TopMostUsedCarsViewComponent(ITripTicketRepo repo)
        {
            _repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _repo.GetTopMostUsedCarsAsync();
            return View(items);
        }
    }
}
