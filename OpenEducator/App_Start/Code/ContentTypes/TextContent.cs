namespace OpenEducator.Code.ContentTypes
{
    public class TextContent: Content {

        public enum TextType {
            H1, H2, H3, H4, H5, H6, P, A, Span
        }

        public TextType Tag { get; set; }
        public string Text { get; set; }
        
        public TextContent(string text, TextType tag = TextType.P) {
            Tag = tag;
            Text = text;
        }

        public override string Render() {
            return Wrap(Tag.ToString().ToLower(), Text, Style, Classes, ID, Open);
        }
    }
}