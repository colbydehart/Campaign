using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Campaign.Repository
{
    public class CampaignRepository : ICampaignRepository
    {

        private CampaignContext _db;
        public CampaignRepository()
        {
            _db = new CampaignContext();
        }

        public DbSet<Model.Camp> GetDbSet()
        {
            return _db.Campaigns;
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void Add(Model.Camp C)
        {
            _db.Campaigns.Add(C);
            _db.SaveChanges();
        }

        public void Delete(Model.Camp E)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            _db.Campaigns.RemoveRange(_db.Campaigns.Local);
            _db.SaveChanges();
        }

        public IEnumerable<Model.Camp> All()
        {
            throw new NotImplementedException();
        }

        public Model.Camp GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
