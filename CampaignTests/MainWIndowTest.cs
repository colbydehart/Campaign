using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using System.IO;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;

namespace CampaignTests
{
    [TestClass]
    public class UITests
    {
        private static TestContext test_context;
        private static Window window;
        private static Application application;

        [ClassInitialize]
        public static void Setup(TestContext _context)
        {
            test_context = _context;
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\CampaignTests\\bin\\Debug\\Campaign");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);

        }

        [TestMethod]
        public void TestZeroState()
        {
           ListBox items = window.Get<ListBox>("CampaignList");
           Assert.AreEqual(items.Items.ToArray().Length, 0);
           var button = window.Get<Button>("AddCampaign");
           Assert.AreEqual(button.Text, "Add");
        }

        [TestMethod]
        public void CreateACampaign()
        {
            TextBox txt = window.Get<TextBox>("NewCampaignTextbox");
            txt.Text = "Hello World";
            Button btn = window.Get<Button>("AddCampaign");
            btn.Click();
            Assert.AreEqual("", txt.Text);
            ListBox lst = window.Get<ListBox>("CampaignList");
            Assert.AreEqual(1, lst.Items.Count);
            Assert.AreEqual("Hello World", lst.Items[0].Text);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            window.Close();
            application.Close();
        }
    }
}
