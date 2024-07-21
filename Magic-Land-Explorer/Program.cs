using Magic_Land_Explorer.Tasks;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace Magic_Land_Explorer
{

    public delegate void simpleDelegate(List<Category> categories);
    public delegate void durationDelegate(List<Category> categories, int index, bool dutation);
    internal class Program
    {
       static string json = File.ReadAllText("data.json");
      static  List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(json);

        static void Main(string[] args)
        {

            try
            {
                magicLandFlow();
            }

            catch(Exception ex){

                Console.WriteLine(ex.Message);
            }
        }


        public static void magicLandFlow()
        {

            simpleDelegate filteredDes = new simpleDelegate(FilterDestinations.filterDestinations);
            simpleDelegate orderedNames = new simpleDelegate(SortByName.sortedDestunationNames);

            durationDelegate longestDurationDelesgate = new durationDelegate(LongestDuration.longestDuration);

            while (true)
            {
                Console.WriteLine("\n-------------------------------------------------");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1.  Show filtered destinations where duration < 100 minutes");
                Console.WriteLine("2.  Show destination with the longest duration");
                Console.WriteLine("3.  Sort destinations by name");
                Console.WriteLine("4.  Show top 3 longest duration destinations");
                Console.WriteLine("5.  Exit");
                Console.WriteLine("-------------------------------------------------\n");

                
                string userInput= Console.ReadLine();

                switch (userInput) {

                    case "1":

                       filteredDes(categories);
                        break; 

                    case "2":

                        longestDurationDelesgate(categories, 1, false);
                        break;
                    case "3":

                        orderedNames(categories);
                        break;

                    case "4":

                        longestDurationDelesgate(categories, 3, true);
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


    }
}
