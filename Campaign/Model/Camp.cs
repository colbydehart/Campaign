using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Model
{
    public class Camp
    {

        public int CampId { get; set; }
        public string Name { get; set; }

        public Camp(string name)
        {
            this.Name = name;
        }

    }
}
