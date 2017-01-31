using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes
{
    public class TextContent: Content {

        public enum TextType {
            H1, H2, H3, H4, H5, H6, P, A, SPAN
        }

        public TextType Tag { get; set; } = TextType.P;
        public string Text { get; set; } = "Lorem Ipsum";

        public TextContent() { }

        public TextContent(string text, TextType tag = TextType.P) {
            Tag = tag;
            Text = text;
        }

        public override string Render() {
            return Wrap(Tag.ToString().ToLower(), Text, base.Style, base.Classes, base.ID, base.Open);
        }
    }
}