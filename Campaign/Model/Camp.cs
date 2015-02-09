using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Model
{
    class Camp
    {
        private static ObservableCollection<string> campaigns = new ObservableCollection<string>(); 
        private string name;
        public string Name { get; set; }

        public Camp(string name)
        {
            this.name = name;
            campaigns.Add(name);
        }

        public static ObservableCollection<string> All()
        {
            return campaigns;
        }
    }
}
