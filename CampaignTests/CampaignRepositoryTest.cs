using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Campaign;
using Campaign.Model;
using Campaign.Repository;
using System.Data.Entity;

namespace CampaignTests
{
    [TestClass]
    public class CampaignRepositoryTest
    {
        [TestMethod]
        public void TestAddToDatabase()
        {
            CampaignRepository repo = new CampaignRepository();
            repo.Add(new Camp("Quest of fightin' dragons"));
            Assert.AreEqual(repo.GetDbSet().Local.Count , 1);
        }
    }
}
