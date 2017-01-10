using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes
{
    public class TextContent: Content {
        string text;

        public TextContent(string content) {
            text = content;
        }

        public override string HTML {
            get {
                return $@"<p>{text}</p>";
            }
        }
    }
}