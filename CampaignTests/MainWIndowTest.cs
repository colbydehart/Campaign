using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using System.IO;

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
            TextBox

            Assert.IsTrue(true);
            //Assert.IsTrue(left_button.Enabled);
            //Assert.IsTrue(right_button.Enabled);
            //Assert.IsTrue(text_box.IsReadOnly);
            //Assert.AreEqual(text_box.Text, "");
            //Assert.IsFalse(reset_button.Enabled);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            window.Close();
            application.Close();
        }
    }
}
