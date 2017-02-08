using System.Collections.Generic;

namespace OpenEducator.Code.ContentTypes {

    public class ListContent: Content {

        public List<Content> Items { get; set; }
        public string[] ItemClasses { get; set; }
        public bool Unordered { get; set; }

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
            return Wrap(Unordered ? "ul" : "ol", data, Style, Classes, ID, Open);
        }

    }

}