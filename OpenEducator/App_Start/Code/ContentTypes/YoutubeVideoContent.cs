namespace OpenEducator.Code.ContentTypes {
	public class YoutubeVideoContent: Content {

        public string VideoId { get; set; }

		public YoutubeVideoContent(string id) {
            VideoId = id;
        }

        public override string Render() {
            return Wrap("iframe", "", Style, Classes, ID, Open = $@"src=""https://www.youtube.com/embed/{VideoId}?autoplay=0&frameborder=0&color=white""");           
        }
    }
}