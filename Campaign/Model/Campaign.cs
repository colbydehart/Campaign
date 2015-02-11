using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignMaker.Model
{
    public class Campaign
    {

        public int CampaignId { get; set; }
        public string Name { get; set; }

        public Campaign(string name)
        {
            this.Name = name;
        }

        public Campaign() { }

    }
}
