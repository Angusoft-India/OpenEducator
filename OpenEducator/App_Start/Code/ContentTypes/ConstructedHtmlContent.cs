namespace OpenEducator.Code.ContentTypes {

    public class ConstructedHtmlContent: Content {

        public string Element { get; set; }
        public Content Data { get; set; }

        public ConstructedHtmlContent(string element, Content data) {
            Element = element;
            Data = data;
        }

        public override string Render() {
            return Wrap(Element, (Data == null ? "" : Data?.Render()), Style, Classes, ID, Open);
        }

    }

}