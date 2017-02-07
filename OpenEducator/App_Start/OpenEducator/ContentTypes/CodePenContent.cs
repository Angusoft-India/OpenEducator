using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes {

    public class CodePenContent: Content {

        public enum CodePenTabs {
            Html, Css, Js, HtmlResult, CssResult, JsResult, Result
        }

        public string Title { get; set; }
        public string User { get; set; }
        public string Slug { get; set; }
        public string ThemeID { get; set; } = "dark";
        public string Height { get; set; } = "300px";

        public bool Preview { get; set; }
        [JsonIgnore]
        private string PreviewHTML {
            get {
                return (Preview) ? " data-preview=\"true\"" : "";
            }
        }

        public CodePenTabs DefaultTab { get; set; } = CodePenTabs.HtmlResult;
        [JsonIgnore]
        public string DefaultTabHTML {
            get {

                /* I know this is not the best way but considering how simple it is, 
                 * it really is the best way */
                switch(DefaultTab) {
                    case CodePenTabs.Html: return "html";
                    case CodePenTabs.Css: return "css";
                    case CodePenTabs.Js: return "js";
                    case CodePenTabs.HtmlResult: return "html,result";
                    case CodePenTabs.CssResult: return "css,result";
                    case CodePenTabs.JsResult: return "js,result";
                    case CodePenTabs.Result: return "result";
                    default: return "result";
                }
            }
        }

        public CodePenContent(string user, string slug_hash, string title, string height = "300px", bool waitBeforeLoading = false, string themeID = "dark") {
            User = user;
            Slug = slug_hash;
            Title = title;
            ThemeID = themeID;
            Preview = waitBeforeLoading;
            Height = height;
        }

        public override string Render() {
            /*
                
                <p data-height="265" data-theme-id="light" data-slug-hash="PNaGbb" data-default-tab="js,result" data-user="codepen" data-embed-version="2" data-pen-title="Example Editable Embed" class="codepen">
                    See the Pen 
                    <a href="http://codepen.io/team/codepen/pen/PNaGbb/">Example Editable Embed</a> 
                    by CodePen (<a href="http://codepen.io/codepen">@codepen</a>) on <a href="http://codepen.io">CodePen</a>.
                </p>
                <script async src="https://production-assets.codepen.io/assets/embed/ei.js"></script>
            

            */

            return Wrap("p", "See The Pen <a href=\"http://codepen.io/team/codepen/pen/PNaGbb/\">Example Editable Embed</a>" , base.Style, base.Classes.Concat(new string[] { "codepen" }).ToArray(), base.ID, base.Open + " " + OpenMaker(new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("data-theme-id", ThemeID),
                new KeyValuePair<string, string>("data-slug-hash", Slug),
                new KeyValuePair<string, string>("data-default-tab", DefaultTabHTML),
                new KeyValuePair<string, string>("data-user", User),
                new KeyValuePair<string, string>("data-embed-version", "2"),
                new KeyValuePair<string, string>("data-pen-title", Title),
                new KeyValuePair<string, string>("data-preview", Preview ? "true" : "false"),
                new KeyValuePair<string, string>("data-height", Height)
            })) + Wrap("script", "", open: $"async src=\"https://production-assets.codepen.io/assets/embed/ei.js\"");
        }

    }

}