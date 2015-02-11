using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampaignMaker.Model;

namespace CampaignMaker.Repository
{
    public interface ICampaignRepository
    {
        int GetCount(); 
        void Add(Model.Campaign E); 
        void Delete(Model.Campaign E); 
        void Clear(); 
        IEnumerable<Model.Campaign> All(); 
        Model.Campaign GetById(int id); 
 
    }
}
