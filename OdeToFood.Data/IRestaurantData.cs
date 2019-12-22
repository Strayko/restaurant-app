using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurants> GetRestaurantsByName(string name);
        Restaurants GetById(int id);
        Restaurants Update(Restaurants updateRestaurant);
        Restaurants Add(Restaurants newRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurants> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurants>()
            {
                new Restaurants { Id = 1, Name = "Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Italian },
                new Restaurants { Id = 2, Name = "Cinnamon Club", Location="London", Cuisine=CuisineType.Mexican },
                new Restaurants { Id = 3, Name = "La Costa", Location="California", Cuisine=CuisineType.Indian }
            };
        }

        public Restaurants GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurants Add(Restaurants newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurants Update(Restaurants updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updateRestaurant.Id);
            if (restaurants != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurants> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)   
                    orderby r.Name
                    select r;
        }
    }
}
