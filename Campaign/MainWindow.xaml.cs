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
using Campaign.Model;
using Campaign.Repository;

namespace Campaign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SetCampaignList();
            InitializeComponent();
        }

        private void SetCampaignList()
        {
            var repo = new CampaignRepository();
            repo.Add(new Camp("Hello"));
        }

        private void AddCampaign_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
