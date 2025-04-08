
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class GalaxyNodeInfo
    {
        public int Id { get; set; }
        public string LocationType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public GalaxyNodeInfo(int id, string type, string name, string description)
        {
            Id = id;
            LocationType = type;
            Name = name;
            Description = description;
        }
    }
}
