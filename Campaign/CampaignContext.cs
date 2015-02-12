using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CampaignMaker.Model;

namespace CampaignMaker
{
    class CampaignContext : DbContext
    {
        public DbSet<Model.Campaign> Campaigns { get; set; }
        public DbSet<Model.Panel> Panels { get; set; }
        public DbSet<Model.Relationship> Relationships { get; set; }
    }
}
