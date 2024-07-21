using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Land_Explorer.Tasks
{
    public static class FilterDestinations
    {
        public static void filterDestinations(List<Category> categories)
        {
            //var less_100 = from category in categories
            //               from des in category.Destinations
            //               where des.DurationInMinutes < 100
            //               select des.name;

            var destinationsAfterFiltering = categories.SelectMany(catogery => catogery.Destinations).
                Where(des => des.DurationInMinutes > 100).
                Select(name => name.name);

            foreach (var v in destinationsAfterFiltering)
                Console.WriteLine(v);
        }
    }
}
