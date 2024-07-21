using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Land_Explorer.Tasks
{
    public class SortByName
    {
        public static void sortedDestunationNames(List<Category> categories)
        {

            //var sortedNames = from catogery in categories
            //                  from des in catogery.Destinations
            //                  orderby des.name 
            //                  select des.name;

            var sortedNmaes = categories.SelectMany(catogery => catogery.Destinations).
                OrderBy(des => des.name).
                Select(des => des.name).ToList();

            //  List<string> names=sortedNames.ToList();    

            foreach (var name in sortedNmaes)
                Console.WriteLine(name);
        }
    }
}
