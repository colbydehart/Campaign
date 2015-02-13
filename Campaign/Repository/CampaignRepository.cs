using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;

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

        public ObservableCollection<Model.Campaign> GetObservableCampaigns()
        {
            return _db.Campaigns.Local;
        }

        public int GetCampaignCount()
        {
            return this.AllCampaigns().Count<Model.Campaign>();
        }

        public void AddCampaign(Model.Campaign C)
        {
            _db.Campaigns.Local.Add(C);
            _db.SaveChanges();
        }

        public void DeleteCampaign(Model.Campaign C)
        {
            _db.Campaigns.Remove(C);
            _db.SaveChanges();
        }

        public void ClearCampaigns()
        {
            _db.Campaigns.RemoveRange(_db.Campaigns.Local);
            _db.SaveChanges();
        }

        public IEnumerable<Model.Campaign> AllCampaigns()
        {
            var q = from c in _db.Campaigns
                    select c;

            return q.ToList<Model.Campaign>();
        }

        public Model.Campaign GetCampaignById(int id)
        {
            var que = from c in _db.Campaigns
                      where c.CampaignId == id
                      select c;

            return que.First<Model.Campaign>();
        }

        //PANEL METHODS
        public ObservableCollection<Model.Panel> GetObservablePanels()
        {
            return _db.Panels.Local;
        }

        public int GetPanelCount()
        {
            return _db.Panels.Local.Count;
        }

        public void AddAdventure(Model.Panel P)
        {
            _db.Panels.Add(P);
            _db.SaveChanges();
            P.AdventureId = P.PanelId;
            _db.SaveChanges();
        }

        public void AddPanel(Model.Panel P, int adventureId, int parentId)
        {
            P.AdventureId = adventureId;
            _db.Panels.Add(P);
            _db.SaveChanges();
            _db.Relationships.Add(new Model.Relationship(P.PanelId, parentId));
            _db.SaveChanges();
        }

        public void DeletePanel(Model.Panel P)
        {
            _db.Panels.Remove(P);
            _db.SaveChanges();
        }

        public void ClearPanels()
        {
            var all = (from P in _db.Panels
                       select P).ToList();
            _db.Panels.RemoveRange(all);
        }

        public Model.Panel GetPanelById(int id)
        {
            var q = from p in _db.Panels
                    where p.PanelId == id
                    select p;
            return q.ToList<Model.Panel>().First<Model.Panel>();
        }

        public IEnumerable<Model.Panel> AllPanels()
        {
            return _db.Panels.ToList<Model.Panel>();
        }

        public IEnumerable<Model.Panel> AllAdventures()
        {
            var q = from p in _db.Panels
                    where p.PanelId == p.AdventureId
                    select p;

            return q.ToList<Model.Panel>();
        }

        public IEnumerable<Model.Panel> AdventuresForCampaign(int campId)
        {
            var q = from p in _db.Panels
                    where p.CampaignId == campId
                    where p.AdventureId == p.PanelId
                    select p;

            return q.ToList<Model.Panel>();
        }

        public IEnumerable<Model.Panel> PanelsForAdventure(int adventureId)
        {
            var q = from p in _db.Panels
                    where p.AdventureId == adventureId
                    select p;

            return q.ToList<Model.Panel>();
        }

        public void AddParentToChild(Model.Panel par, Model.Panel chi)
        {
            _db.Panels.Add(par);
            _db.SaveChanges();
            _db.Relationships.Add(new Model.Relationship(chi.PanelId, par.PanelId));
            _db.SaveChanges();
        }

        public IEnumerable<Model.Panel> Parents(int childID)
        {
            var q = from p in _db.Panels
                    join r in _db.Relationships on p.PanelId equals r.ParentId
                    where r.ChildId == childID
                    select p;

            return q.ToList<Model.Panel>();
        }

        public IEnumerable<Model.Panel> Children(int parentId)
        {
            var q = from p in _db.Panels
                    join r in _db.Relationships on p.PanelId equals r.ChildId
                    where r.ParentId == parentId
                    select p;

            return q.ToList<Model.Panel>();
        }

        public void Dispose()
        {
            _db.Dispose();
        }



        public void ClearRelationships()
        {
            _db.Relationships.RemoveRange(_db.Relationships.ToList<Model.Relationship>());
        }

        internal void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
