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
    public partial class MainWindow : Window
    {
        private CampaignRepository repo;
        private Campaign CurrentCampaign;
        private Model.Panel CurrentAdventure;
        private Model.Panel CurrentPanel;
        public MainWindow()
        {
            InitializeComponent();
            SetCampaignList();
        }

        private void SetCampaignList()
        {
            repo = new CampaignRepository();
            //repo.ClearCampaigns();
            //repo.ClearPanels();
            //repo.ClearRelationships();
            CampaignList.DataContext = repo.GetObservableCampaigns();
        }

        private void AddCampaign_Click(object sender, RoutedEventArgs e)
        {
            var c = new Campaign(NewTextbox.Text);
            repo.AddCampaign(c);
            NewTextbox.Text = "";
        }

        private void AddAdventure_Click(object sender, RoutedEventArgs e)
        {
            var p = new Model.Panel(NewTextbox.Text, NewTextbox.Text, CurrentCampaign.CampaignId);
            repo.AddAdventure(p);
            NewTextbox.Text = "";
            AdventureList.DataContext = repo.AdventuresForCampaign(CurrentCampaign.CampaignId);
        }

        private void Campaign_Show(object sender, RoutedEventArgs e)
        {
            Campaign camp = ((Button)e.OriginalSource).DataContext as Campaign;
            AdventureList.DataContext = repo.AdventuresForCampaign(camp.CampaignId);
            Title.Content = "Adventures";

            AdventureList.Visibility = Visibility.Visible;
            CampaignList.Visibility = Visibility.Hidden;

            AddCampaign.Visibility = Visibility.Hidden;
            AddAdventure.Visibility = Visibility.Visible;
            CurrentCampaign = camp;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            CurrentCampaign = null;
            CurrentAdventure = null;
            CurrentPanel = null;

            CampaignList.DataContext = repo.GetObservableCampaigns();
            Editor.Visibility = Visibility.Hidden;
            AdventureList.Visibility = Visibility.Hidden;
            CampaignList.Visibility = Visibility.Visible;
            AddCampaign.Visibility = Visibility.Visible;
            AddAdventure.Visibility = Visibility.Hidden;
            CampaignBreadcrumb.Visibility = Visibility.Hidden;
            AdventureBreadcrumb.Visibility = Visibility.Hidden;
        }

        private void EditClickedPanel(object sender, RoutedEventArgs e)
        {
            repo.SaveChanges();
            Editor.Visibility = Visibility.Visible;
            var a = ((Button)e.OriginalSource).DataContext as Model.Panel;
            editPanel(a);
        }

        private void editPanel(Model.Panel P)
        {
            CurrentPanel = P;
            CurrentAdventure = repo.GetPanelById(P.AdventureId);
            Editor.DataContext = P;
            Parents.ItemsSource = repo.Parents(P.PanelId);
            Children.ItemsSource = repo.Children(P.PanelId);
        }

        private void SavePanel(object sender, RoutedEventArgs e)
        {
            repo.SaveChanges();
        }
        private void AddPanel(object sender, RoutedEventArgs e)
        {
            repo.SaveChanges();
            var p = new Model.Panel("Insert a title", "Write content here", CurrentCampaign.CampaignId);
            repo.AddPanel(p, CurrentAdventure.PanelId, CurrentPanel.PanelId);
            editPanel(p);
        }

    }
}
