using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes
{
	public class YoutubeVideoContent: Content {

        public string VideoID { get; set; } = "";
        public int Width { get; set; } = 400;
        public int Height { get; set; } = 300;

		public YoutubeVideoContent(string _id, int _width = 400, int _height = 300) {
            VideoID = _id;
            Width = _width;
            Height = _height;
        }

        public override string Render() {
            return $@"<iframe width=""{Width}"" height=""{Height}"" src=""https://www.youtube.com/embed/{VideoID}?autoplay=1&frameborder=0&modestbranding=1""></iframe>";
        }
    }
}