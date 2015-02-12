using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampaignMaker;
using CampaignMaker.Model;
using CampaignMaker.Repository;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace CampaignTests
{
    [TestClass]
    public class CampaignRepositoryTest
    {
        [TestMethod]
        public void CampaignGetAllTest()
        {
            CampaignRepository repo = new CampaignRepository();
            repo.ClearCampaigns();

            repo.AddCampaign(new Campaign("DRAGONS!!!"));
            repo.AddCampaign(new Campaign("ELVES!!!"));
            var all = repo.AllCampaigns();
            Assert.AreEqual(2, (all as List<Campaign>).Count);
        }

        [TestMethod]
        public void CampaignAddTest()
        {
            CampaignRepository repo = new CampaignRepository();
            repo.ClearCampaigns();
            repo.AddCampaign(new Campaign("DRAGONS!!!"));
            repo.AddCampaign(new Campaign("ELVES!!!"));
            Assert.AreEqual(2, repo.GetObservableCampaigns().Count);
        }

        [TestMethod]
        public void CampaignDeleteTest()
        {
            CampaignRepository repo = new CampaignRepository();
            repo.ClearCampaigns();
            var cmp = new Campaign("DWARVES!!!");
            repo.AddCampaign(cmp);
            Assert.AreEqual(1, repo.GetCampaignCount());
            repo.DeleteCampaign(cmp);
            Assert.AreEqual(0, repo.GetCampaignCount());
        }

        [TestMethod]
        public void CampaignGetCountTest()
        {
            CampaignRepository repo = new CampaignRepository();
            repo.ClearCampaigns();
            Assert.AreEqual(0, repo.GetCampaignCount());
            repo.AddCampaign(new Campaign("ELVES!!!"));
            Assert.AreEqual(1, repo.GetCampaignCount());
            repo.AddCampaign(new Campaign("DRAGONS!!!"));
            Assert.AreEqual(2, repo.GetCampaignCount());
            
        }

        [TestMethod]
        public void CampaignGetByIdTest()
        {
            CampaignRepository repo = new CampaignRepository();
            repo.ClearCampaigns();
            repo.AddCampaign(new Campaign("DRAGONSSS!!!"));
            var cmp = repo.GetObservableCampaigns()[0];
            Assert.AreEqual(cmp, repo.GetCampaignById(cmp.CampaignId));
        }

        [TestMethod]
        public void CampaignClearTest()
        {
            var repo = new CampaignRepository();
            repo.AddCampaign(new Campaign("DRAGONS!!!"));
            repo.AddCampaign(new Campaign("ELVES!!!"));
            Assert.IsTrue(repo.GetObservableCampaigns().Count > 1);
            repo.ClearCampaigns();
            Assert.AreEqual(0, repo.GetObservableCampaigns().Count);
        }

        public Campaign camp;
        public Panel adv;
        public Panel pan1;
        public Panel pan2;


    }
}
