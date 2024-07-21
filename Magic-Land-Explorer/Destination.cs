using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Magic_Land_Explorer
{
    public class Destination
    {
        //"name": "Space Mountain",
        //"type": "Indoor Roller Coaster",
        //"location": "Tomorrowland",
        //"duration": "98 minutes",
        //"description"
        public string name { get; set; }
        public string type { get; set; }

        public  string location { get; set; }

        public string description { get; set; }

        public string duration { get; set; }

        public int DurationInMinutes
        {
            get
            {
                if (duration == null) return 0;

                // Use a regular expression to find the first integer in the string
                var match = Regex.Match(duration, @"\d+");
                if (match.Success && int.TryParse(match.Value, out int minutes))
                {
                    return minutes;
                }
                return 0; // or throw an exception if you prefer
            }
        }
    }
}
