using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes
{
    public class TextContent: Content {

        public string Text { get; set; } = "Lorem Ipsum";

        public TextContent() { }
        public TextContent(string text) {
            Text = text;
        }

        public override string Render() {
            return $@"<p>{Text}</p>";   
        }
    }
}