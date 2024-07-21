using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace Magic_Land_Explorer
{

    public delegate void simpleDelegate();
    public delegate void durationDelegate(int index, bool dutation);
    internal class Program
    {
       static string json = File.ReadAllText("data.json");
      static  List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(json);

        static void Main(string[] args)
        {
            magicLandFlow();
        }


        public static void magicLandFlow()
        {

            simpleDelegate filteredDes = new simpleDelegate(Less_100);
            simpleDelegate orderedNames = new simpleDelegate(sortedDestunationNames);

            durationDelegate longestDurationDelesgate = new durationDelegate(longestDuration);

           // durationDelegate TopThreeDuration = new durationDelegate()


            while (true)
            {
                Console.WriteLine("\n-------------------------------------------------");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Show filtered destinations (duration < 100 minutes)");
                Console.WriteLine("2 - Show destination with the longest duration");
                Console.WriteLine("3 - Sort destinations by name");
                Console.WriteLine("4 - Show top 3 longest duration destinations");
                Console.WriteLine("5 - Exit");
                Console.WriteLine("-------------------------------------------------\n");

                
                string userInput= Console.ReadLine();

                switch (userInput) {

                    case "1":

                       filteredDes();
                        break; 

                    case "2":

                        longestDurationDelesgate(1, false);
                        break;
                    case "3":

                        orderedNames();
                        break;

                    case "4":

                        longestDurationDelesgate(3, true);
                        break ;

                    case "5":

                        Environment.Exit(0);    
                        break;

                    default:
                        Console.WriteLine("Invalid input please try again");
                        break;

                }
            }
        }

        public static void Less_100() {
            //var less_100 = from category in categories
            //               from des in category.Destinations
            //               where des.DurationInMinutes < 100
            //               select des.name;

            var less_100 = categories.SelectMany(catogery => catogery.Destinations).
                Where(des => des.DurationInMinutes > 100).
                Select(name => name.name);

            foreach (var v in less_100)
                Console.WriteLine(v);
        }

        public static void longestDuration(int index, bool duration) {

            //var longestD = from category in categories
            //               from des in category.Destinations
            //               orderby des.DurationInMinutes descending
            //               select new
            //               {
            //                   des.name,
            //                   dd = duration ? $"{des.duration}" : ""

            //               };

            var longestD = categories.SelectMany(catogery => catogery.Destinations).
                OrderByDescending(des => des.DurationInMinutes).
                Select(des => new
                {
                    des.name,
                    dd=duration ? $"{des.duration}" : ""
                });

            var longestDuration = longestD.ToList();          

            for (int i = 0; i < index; i++)
            {
                if (duration)
                    Console.WriteLine($"{longestDuration[i].name} - {longestDuration[i].dd}");
                else
                    Console.WriteLine(longestDuration[i].name);
            }
         
            
        
        }

        public static void sortedDestunationNames() {

            //var sortedNames = from catogery in categories
            //                  from des in catogery.Destinations
            //                  orderby des.name 
            //                  select des.name;

            var sortedNmaes = categories.SelectMany(catogery => catogery.Destinations).
                OrderBy(des=>des.name).
                Select(des=>des.name).ToList();
        
          //  List<string> names=sortedNames.ToList();    

            foreach (var name in sortedNmaes)
                Console.WriteLine(name);
        }
    }
}
