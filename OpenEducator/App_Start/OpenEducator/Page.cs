using System.Collections.Generic;

namespace OpenEducator
{
    public class Page: IHasContent {
        public string Title { get; set; }
        public List<Content> Contents { get; set; } = new List<Content>();
    }

    /*  EXAMPLE
        The Chain Rule
    */
}