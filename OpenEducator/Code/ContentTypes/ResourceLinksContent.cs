using System.Collections.Generic;

namespace OpenEducator.Code.ContentTypes {

    public class ResourceLinksContent: Content {

        /// <summary>
        /// [Url -> Title] Dictionary
        /// </summary>
        public Dictionary<string,string> Links { get; set; }
        public string Header { get; set; }

        public ResourceLinksContent(Dictionary<string, string> links, string header = "Links:- ") {
            Links = links;
            Header = header;
        }

        public override string Render() {

            string listItems = "";
            foreach (KeyValuePair<string, string> link in Links) {
                listItems += $"<li><a href=\"{link.Key}\">{link.Value}</a></li>";
            }

            return Wrap("div", 
                   Header + Wrap("ul", listItems, classes:new []{"resource-list"})
            , classes: new[] {"resources"});
        }

    }

}