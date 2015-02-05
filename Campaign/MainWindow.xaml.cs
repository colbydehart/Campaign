using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Campaign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetCampaignList();
        }

        private void SetCampaignList()
        {
            var campaigns = Panel.AllCampaigns();
            foreach (string camp in campaigns)
            {
                var newPanel = new TextBox();
                newPanel.Text = camp;
                CampaignList.Children.Add(newPanel);
            }
        }
    }
}
