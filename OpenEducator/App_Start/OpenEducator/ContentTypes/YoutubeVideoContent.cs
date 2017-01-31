using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes
{
	public class YoutubeVideoContent: Content {

        public string VideoID { get; set; } = "";

		public YoutubeVideoContent(string _id) {
            VideoID = _id;
        }

        public override string Render() {
            return Wrap("iframe", "", base.Style, base.Classes, base.ID, Open = $@"src=""https://www.youtube.com/embed/{VideoID}?autoplay=0&frameborder=0&color=white""");           
        }
    }
}