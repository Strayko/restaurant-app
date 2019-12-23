using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurants> GetRestaurantsByName(string name);
        Restaurants GetById(int id);
        Restaurants Update(Restaurants updateRestaurant);
        Restaurants Add(Restaurants newRestaurant);
        Restaurants Delete(int id);
        int GetCountOfRestaurants();
        int Commit();
    }
}
