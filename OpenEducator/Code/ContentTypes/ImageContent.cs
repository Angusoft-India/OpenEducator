namespace OpenEducator.Code.ContentTypes {

    public class ImageContent: Content {

        public string Source { get; set; }  

        public ImageContent(string src) {
            Source = src;
        }

        public override string Render() {
            return WrapSelfClosing("img", Style, Classes, ID, $@"src=""{Source}""");
        }

    }

}