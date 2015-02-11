using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignMaker.Model
{
    public class Panel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CampaignId { get; set; }
        public int AdventureId { get; set; }
        public int PanelId { get; set; }

        public Panel(string title, string content, int campaignId, int adventureId)
        {
            this.Title = title;
            this.Content = content;
            this.CampaignId = campaignId;
            this.AdventureId = adventureId;
        }

        public Panel() { }
    }
}
