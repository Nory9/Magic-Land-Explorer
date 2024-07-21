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

                //regular expression 
                //: "82 minutes",
                var match = Regex.Match(duration, @"\d+");
                if (match.Success && int.TryParse(match.Value, out int minutes))
                {
                    return minutes;
                }
                return 0; 
            }
        }
    }
}
