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
        public void GetAllTest()
        {
            CampaignRepository repo = new CampaignRepository();
            repo.Clear();

            repo.Add(new Campaign("DRAGONS!!!"));
            repo.Add(new Campaign("ELVES!!!"));
            var all = repo.All();
            Assert.AreEqual(2, (all as List<Campaign>).Count);
        }

        [TestMethod]
        public void AddTest()
        {
            CampaignRepository repo = new CampaignRepository();
            repo.Clear();
            repo.Add(new Campaign("DRAGONS!!!"));
            repo.Add(new Campaign("ELVES!!!"));
            Assert.AreEqual(2, repo.GetDbSet().Local.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            CampaignRepository repo = new CampaignRepository();
            repo.Clear();
            var cmp = new Campaign("DWARVES!!!");
            repo.Add(cmp);
            Assert.AreEqual(1, repo.GetCount());
            repo.Delete(cmp);
            Assert.AreEqual(0, repo.GetCount());
        }

        [TestMethod]
        public void GetCountTest()
        {
            CampaignRepository repo = new CampaignRepository();
            repo.Clear();
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Campaign("ELVES!!!"));
            Assert.AreEqual(1, repo.GetCount());
            repo.Add(new Campaign("DRAGONS!!!"));
            Assert.AreEqual(2, repo.GetCount());
            
        }

        [TestMethod]
        public void GetByIdTest()
        {
            CampaignRepository repo = new CampaignRepository();
            repo.Clear();
            repo.Add(new Campaign("DRAGONSSS!!!"));
            var cmp = repo.GetDbSet().Local[0];
            Assert.AreEqual(cmp, repo.GetById(cmp.CampaignId));
        }

        [TestMethod]
        public void ClearTest()
        {
            var repo = new CampaignRepository();
            repo.Add(new Campaign("DRAGONS!!!"));
            repo.Add(new Campaign("ELVES!!!"));
            Assert.IsTrue(repo.GetDbSet().Local.Count > 1);
            repo.Clear();
            Assert.AreEqual(0, repo.GetDbSet().Local.Count);
        }
    }
}
