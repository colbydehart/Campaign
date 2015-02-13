using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignMaker.Model
{
    public class Relationship
    {
        public int RelationshipId {get; set;}
        public int ChildId { get; set; }
        public int ParentId { get; set; }

        public Relationship() { }
        public Relationship(int child, int parent)
        {
            ChildId = child;
            ParentId = parent;
        }
    }
}
