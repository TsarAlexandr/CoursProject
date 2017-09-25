using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursProjet.Models
{
    public class ProjectListView
    {
        
            public IEnumerable<Projects> Project { get; set; }
            public ECategory CurrentCategory { get; set; }
        
    }
}
