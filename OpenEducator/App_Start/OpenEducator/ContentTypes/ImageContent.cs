using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes {

    public class ImageContent: Content {

        public string Source { get; set; } = "";

        public ImageContent(string src) {
            Source = src;
        }

        public override string Render() {
            return WrapSelfClosing("img", base.Style, base.Classes, base.ID, $@"src=""{Source}""");
        }

    }

}