using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign
{
    class Campaign
    {
        private List<string> models = new List<string>() { "Quest of the Ostium", "The Dragonbane Corridor", "Dwarven Paradise" };

        public string[] All()
        {
            return models.ToArray();
        }
    }
}
