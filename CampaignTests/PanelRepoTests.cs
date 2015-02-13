using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampaignMaker.Repository;
using CampaignMaker.Model;
using System.Collections.Generic;

namespace CampaignTests
{
    [TestClass]
    public class PanelRepoTests
    {
        private void makeCampaignTree(CampaignRepository repo)
        {
            repo.AddCampaign(new Campaign("DRAGONS"));
            var cmp = repo.GetObservableCampaigns()[0];
            repo.AddAdventure(new Panel("Foo", "Bar", cmp.CampaignId));
            var adv = repo.GetObservablePanels()[0];
            var pan = new Panel("Qaz", "Baz", cmp.CampaignId);
            repo.AddPanel(pan, adv.PanelId, adv.PanelId);
            repo.AddPanel(new Panel("Fizz", "Buzz", cmp.CampaignId), adv.PanelId, pan.PanelId);
        }

        [TestMethod]
        public void PanelAddAdventureTest()
        {
            var repo = new CampaignRepository();
            repo.AddCampaign(new Campaign("DRAGONS!!"));
            var camp = repo.GetObservableCampaigns()[0];
            repo.AddAdventure(new Panel("Foo", "Bar", camp.CampaignId));
            Assert.AreEqual(1, repo.GetObservablePanels().Count);
            var adv = repo.GetObservablePanels()[0];
            Assert.AreEqual(adv.PanelId, adv.AdventureId);
        }

        [TestMethod]
        public void PanelAddPanelTest()
        {
            var repo = new CampaignRepository();
            repo.AddCampaign(new Campaign("DRAGONS!!"));
            var camp = repo.GetObservableCampaigns()[0];
            repo.AddAdventure(new Panel("Foo", "Bar", camp.CampaignId));
            var adv = repo.GetObservablePanels()[0];
            var pan = new Panel("Qaz", "Baz", camp.CampaignId);
            repo.AddPanel(pan, adv.PanelId, adv.PanelId);
            Assert.AreEqual(pan, repo.GetObservablePanels()[1]);
            Assert.AreEqual(pan.AdventureId, adv.PanelId);
        }

        [TestMethod]
        public void PanelGetCountTest()
        {
            var repo = new CampaignRepository();
            makeCampaignTree(repo);
            Assert.AreEqual(3, repo.GetPanelCount());
        }

        [TestMethod]
        public void PanelDeleteTest()
        {
            var repo = new CampaignRepository();
            makeCampaignTree(repo);
            var pan = new Panel("What", "ever", 1);
            repo.AddAdventure(pan);
            Assert.AreEqual(4, repo.GetPanelCount());
            repo.DeletePanel(pan);
            Assert.AreEqual(3, repo.GetPanelCount());
        }


        [TestMethod]
        public void PanelAllTest()
        {
            var repo = new CampaignRepository();
            makeCampaignTree(repo);
            var pan = new Panel("What", "ever", 1);
            repo.AddAdventure(pan);
            var all = repo.AllPanels();
            Assert.AreEqual(4, (all as List<Panel>).Count);
        }

        [TestMethod]
        public void PanelAllAdventuresTest()
        {
            var repo = new CampaignRepository();
            makeCampaignTree(repo);
            Assert.AreEqual(1, (repo.AllAdventures() as List<Panel>).Count);
            repo.AddAdventure(new Panel("What", "ever", 0));
            Assert.AreEqual(2, (repo.AllAdventures() as List<Panel>).Count);
        }

        [TestMethod]
        public void PanelPanelsForAdventureTest()
        {
            var repo = new CampaignRepository();
            var cmp = new Campaign("Hi");
            repo.AddCampaign(cmp);
            var adv = new Panel("Foo", "Bar", cmp.CampaignId);
            repo.AddAdventure(adv);

            Assert.AreEqual(1, (repo.PanelsForAdventure(adv.PanelId) as List<Panel>).Count);

            repo.AddPanel(new Panel("Bax", "Qux", cmp.CampaignId), adv.PanelId, adv.PanelId);
            Assert.AreEqual(2, (repo.PanelsForAdventure(adv.PanelId) as List<Panel>).Count);
        }

        [TestMethod]
        public void PanelAddParentTest()
        {
            var repo = new CampaignRepository();
            var cmp = new Campaign("Hi");
            repo.AddCampaign(cmp);
            var par = new Panel("Foo", "Bar", cmp.CampaignId);
            repo.AddAdventure(par);
            var chi = new Panel("Baz", "Qux", cmp.CampaignId);
            repo.AddPanel(chi, par.AdventureId, par.PanelId);
            var par2 = new Panel("Far", "Lie", cmp.CampaignId);
            repo.AddParentToChild(par2, chi);
            Assert.AreEqual(3, repo.GetObservablePanels().Count);
        }

        [TestMethod]
        public void PanelParentsTest()
        {
            var repo = new CampaignRepository();
            var cmp = new Campaign("Hi");
            repo.AddCampaign(cmp);
            var par = new Panel("Foo", "Bar", cmp.CampaignId);
            repo.AddAdventure(par);
            var chi = new Panel("Baz", "Qux", cmp.CampaignId);
            repo.AddPanel(chi, par.AdventureId, par.PanelId);
            var par2 = new Panel("Far", "Lie", cmp.CampaignId);
            repo.AddParentToChild(par2, chi);

            Assert.AreEqual(2, (repo.Parents(chi.PanelId) as List<Panel>).Count);
        }

        [TestMethod]
        public void PanelChildrenTest()
        {
            var repo = new CampaignRepository();
            var cmp = new Campaign("Hi");
            repo.AddCampaign(cmp);
            var adv = new Panel("Foo", "Bar", cmp.CampaignId);
            repo.AddAdventure(adv);
            var chi = new Panel("Star", "Wars", cmp.CampaignId);
            repo.AddPanel(chi, adv.AdventureId, adv.PanelId);
            var chi2 = new Panel("Far", "Scape", cmp.CampaignId);
            repo.AddPanel(chi2, adv.AdventureId, adv.PanelId);

            Assert.AreEqual(2, (repo.Children(adv.PanelId) as List<Panel>).Count);
        }

        [TestMethod]
        public void PanelGetByIdTest()
        {
            var repo = new CampaignRepository();
            var cmp = new Campaign("Hi");
            repo.AddCampaign(cmp);
            var adv = new Panel("Foo", "Bar", cmp.CampaignId);
            repo.AddAdventure(adv);

            Assert.AreEqual(adv, repo.GetPanelById(adv.PanelId));
        }

        [TestMethod]
        public void PanelClearTest()
        {
            var repo = new CampaignRepository();
            repo.AddAdventure(new Panel("Foo", "Bar", 1));
            Assert.AreEqual(1, repo.GetObservablePanels().Count);
            repo.ClearPanels();
            Assert.AreEqual(0, repo.GetObservablePanels().Count);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            var repo = new CampaignRepository();
            repo.ClearPanels();
            repo.ClearCampaigns();
            repo.ClearRelationships(); 
        }

    }
}
