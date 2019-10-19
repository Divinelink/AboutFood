using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AboutFood.Data.Models;

namespace AboutFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly AboutFoodDbContext db;
        public SqlRestaurantData(AboutFoodDbContext db)
        {
            this.db = db;
        }

        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in db.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {
            //  var r = Get(restaurant.Id);
            //  r.Name = ""; // The entity framework detects that something has changed in - in this case - the name property
            //  db.SaveChanges(); // So when I call SaveChanges, the entity framework be will able to look at the changes and issue update statements
            // Not the best approach, check optimistic concurrency
            
            // Better Version
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
