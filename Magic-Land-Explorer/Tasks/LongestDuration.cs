using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Land_Explorer.Tasks
{
    public static class LongestDuration
    {
        public static void longestDuration(List<Category> categories,int index, bool duration)
        {

            //var longestD = from category in categories
            //               from des in category.Destinations
            //               orderby des.DurationInMinutes descending
            //               select new
            //               {
            //                   des.name,
            //                   dd = duration ? $"{des.duration}" : ""

            //               };

            var longestDes = categories.SelectMany(catogery => catogery.Destinations).
                OrderByDescending(des => des.DurationInMinutes).
                Select(des => new
                {
                    des.name,
                    dd = duration ? $"{des.duration}" : ""
                });

            var longestDuration = longestDes.ToList();

            for (int i = 0; i < index; i++)
            {
                if (duration)
                    Console.WriteLine($"{longestDuration[i].name} - {longestDuration[i].dd}");
                else
                    Console.WriteLine(longestDuration[i].name);
            }


        }
    }
}
