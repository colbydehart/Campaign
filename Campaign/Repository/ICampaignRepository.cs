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
        // Campaign methods
        int GetCampaignCount(); 
        void AddCampaign(Model.Campaign E); 
        void DeleteCampaign(Model.Campaign E); 
        void ClearCampaigns(); 
        IEnumerable<Model.Campaign> AllCampaigns(); 
        Model.Campaign GetCampaignById(int id); 
        //Panel methods
        int GetPanelCount(); 
        void AddAdventure(Panel P); 
        void AddPanel(Panel P, int adventureId, int parentId); 
        void DeletePanel(Panel P); 
        void ClearPanels(); 
        Panel GetPanelById(int id); 
        IEnumerable<Panel> AllPanels();
        IEnumerable<Panel> AllAdventures();
        IEnumerable<Panel> PanelsForAdventure(int adventureId);
        IEnumerable<Panel> Parents(int childID);
        IEnumerable<Panel> Children(int parentId);
    }
}
