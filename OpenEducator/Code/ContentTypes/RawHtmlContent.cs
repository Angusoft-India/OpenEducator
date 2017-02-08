namespace OpenEducator.Code.ContentTypes {

    public class RawHtmlContent: Content {

        public string Data { get; set; }

        public RawHtmlContent(string data) {
            Data = data;
        }

        public override string Render() {
            return Data;
        }
    }

}