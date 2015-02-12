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
using CampaignMaker.Model;
using CampaignMaker.Repository;

namespace CampaignMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CampaignRepository repo;
        public MainWindow()
        {
            SetCampaignList();
            InitializeComponent();
        }

        private void SetCampaignList()
        {
            repo = new CampaignRepository();
            repo.AddCampaign(new Campaign("Hello"));
            CampaignList.DataContext = repo.AllCampaigns();
        }

        private void AddCampaign_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
