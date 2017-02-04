using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes {

    public class ListContent: Content {

        public List<Content> Items { get; set; } = new List<Content>();
        public string[] ItemClasses { get; set; }
        public bool Unordered { get; set; } = true;

        public ListContent(List<Content> items, bool unordered = true, string[] itemClasses = null) {
            Items = items;
            ItemClasses = itemClasses;
            Unordered = unordered;
        }

        public override string Render() {
            string data = "";
            foreach(Content c in Items) {
                data += Wrap("li", c.Render(), classes: ItemClasses);
            }
            return Wrap(Unordered ? "ul" : "ol", data, base.Style, base.Classes, base.ID, base.Open);
        }

    }

}