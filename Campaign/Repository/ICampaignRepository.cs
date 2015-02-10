using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campaign.Model;

namespace Campaign.Repository
{
    public interface ICampaignRepository
    {
        int GetCount(); 
        void Add(Camp E); 
        void Delete(Camp E); 
        void Clear(); 
        IEnumerable<Camp> All(); 
        Camp GetById(int id); 
 
    }
}
