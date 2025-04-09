using OOPConsoleProject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject
{
    public class Addon
    {
        public string Name { get; set; }
        public AddonType Type { get; set; }
        public AddonGrade Grade { get; set; }
        public string Description { get; set; }

        public Addon(string name, AddonType type, AddonGrade grade, string description)
        {
            Name = name;
            Type = type;
            Grade = grade;
            Description = description;
        }
    }
}
