using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator
{
    public class Chapter: IHasContent {

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Content> Contents { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();

    }

    /*  EXAMPLE
        Differentiation
    */
}