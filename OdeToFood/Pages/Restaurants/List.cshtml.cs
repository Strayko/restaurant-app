using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger<ListModel> _logger;
        public string Message { get; set; }
        public IEnumerable<Core.Restaurants> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            _config = config;
            _restaurantData = restaurantData;
            _logger = logger;
        }
        public void OnGet()
        {
            _logger.LogError("Executing ListModel");
            Message = _config["Message"];
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
