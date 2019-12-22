using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            _db = db;
        }

        public Restaurants Add(Restaurants newRestaurant)
        {
            _db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Restaurants Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                _db.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurants GetById(int id)
        {
            return _db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurants> GetRestaurantsByName(string name)
        {
            var query = from r in _db.Restaurants
                where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                orderby r.Name
                select r;
            return query;

        }

        public Restaurants Update(Restaurants updateRestaurant)
        {
            var entity = _db.Restaurants.Attach(updateRestaurant);
            entity.State = EntityState.Modified;
            return updateRestaurant;
        }
    }
}