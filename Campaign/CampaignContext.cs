using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Campaign.Model;

namespace Campaign
{
    class CampaignContext : DbContext
    {
        public DbSet<Camp> Campaigns { get; set; }
    }
}
