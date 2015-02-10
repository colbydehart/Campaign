using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campaign.Model;

namespace Campaign
{
    class Panel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CampaignId { get; set; }
        public int AdventureId { get; set; }
        public int PanelId { get; set; }

        public Panel(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }
}
