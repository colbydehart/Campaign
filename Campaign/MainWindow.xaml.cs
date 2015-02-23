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
using System.Text.RegularExpressions;

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
            repo.SaveChanges();
            CurrentCampaign = null;
            CurrentAdventure = null;
            CurrentPanel = null;
            Title.Content = "Campaigns";

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
            Parents.Visibility = CurrentPanel.PanelId == CurrentAdventure.PanelId ?
                Visibility.Hidden : Visibility.Visible;
            AddParent.Visibility = Parents.Visibility;
            Delete.Visibility = Parents.Visibility;

            Title.Content = CurrentAdventure.Title;
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
            // check for reference
            var text = NewChild.Text;
            var m = new Regex(@"^@(\d+)").Match(text);
            if (m.Success)
            {
                Model.Panel p;
                try
                {
                    p = repo.GetPanelById(Int32.Parse(m.Groups[1].Value));
                    repo.CreateRelationship(CurrentPanel, p);
                    NewChild.Text = "";
                    editPanel(p);
                }
                catch (IndexOutOfRangeException err)
                {
                    NewChild.Text = "";
                    System.Windows.MessageBox.Show(err.Message);
                }
            }
            else
            {
                var p = new Model.Panel(NewChild.Text, "Write content here", CurrentCampaign.CampaignId);
                repo.AddPanel(p, CurrentAdventure.PanelId, CurrentPanel.PanelId);
                NewChild.Text = "";
                editPanel(p);
            }
        }
        
        private void AddParentClick(object sender, RoutedEventArgs e)
        {
            if (CurrentPanel == CurrentAdventure)
            {
                MessageBox.Show("Cannot add parents to root adventure");
                return;
            }
            repo.SaveChanges();
            //check for reference
            var text = NewParent.Text;
            var m = new Regex(@"^@(\d+)").Match(text);
            if (m.Success)
            {
                Model.Panel p;
                try
                {
                    p = repo.GetPanelById(Int32.Parse(m.Groups[1].Value));
                    repo.CreateRelationship(p, CurrentPanel);
                    NewParent.Text = "";
                    editPanel(p);
                }
                catch (IndexOutOfRangeException err)
                {
                    NewParent.Text = "";
                    System.Windows.MessageBox.Show(err.Message);
                }
            }
            else
            {
                var p = new Model.Panel(text, "Write content here", CurrentCampaign.CampaignId);
                repo.AddParentToChild(p, CurrentPanel);
                NewParent.Text = "";
                editPanel(p);
            }
        }

        private void DeletePanelClick(object sender, RoutedEventArgs e)
        {
            var pars = repo.Parents(CurrentPanel.PanelId) as List<Model.Panel>;
            var p = pars.Count < 1 ? CurrentAdventure : pars[0];
            repo.DeletePanel(CurrentPanel);
            editPanel(p);
        }
    }
}
