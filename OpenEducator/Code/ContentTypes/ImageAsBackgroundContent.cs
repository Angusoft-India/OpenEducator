namespace OpenEducator.Code.ContentTypes {

    public class ImageAsBackgroundContent: Content {

        public string Source { get; set; }

        public ImageAsBackgroundContent(string source) {
            Source = source;
            Style = "width: 100%; min-height: 400px;";
        }

        public override string Render() {
            return Wrap("div", "", Style + $"background: url('{Source}'); background-size: cover;", Classes, ID, Open);
        }

    }

}