using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CampaignMaker.Repository
{
    public class CampaignRepository : ICampaignRepository
    {

        private CampaignContext _db;
        public CampaignRepository()
        {
            _db = new CampaignContext();
            _db.Campaigns.Load();
        }

        public DbSet<Model.Campaign> GetDbSet()
        {
            return _db.Campaigns;
        }

        public int GetCount()
        {
            return this.All().Count<Model.Campaign>();
        }

        public void Add(Model.Campaign C)
        {
            _db.Campaigns.Local.Add(C);
            _db.SaveChanges();
        }

        public void Delete(Model.Campaign C)
        {
            _db.Campaigns.Remove(C);
            _db.SaveChanges();
        }

        public void Clear()
        {
            _db.Campaigns.RemoveRange(_db.Campaigns.Local);
            _db.SaveChanges();
        }

        public IEnumerable<Model.Campaign> All()
        {
            var q = from c in _db.Campaigns
                    select c;

            return q.ToList<Model.Campaign>();
        }

        public Model.Campaign GetById(int id)
        {
            var que = from c in _db.Campaigns
                      where c.CampaignId == id
                      select c;

            return que.First<Model.Campaign>();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
