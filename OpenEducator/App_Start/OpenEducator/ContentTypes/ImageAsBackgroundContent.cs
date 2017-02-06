using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes {

    public class ImageAsBackgroundContent: Content {

        public string Source { get; set; } = "http://www.placehold.it/400x400";

        public ImageAsBackgroundContent(string source) {
            Source = source;

            base.Style = "width: 100%; min-height: 400px;";
        }

        public override string Render() {
            return Wrap("div", "", base.Style + $"background: url('{Source}'); background-size: cover;", base.Classes, base.ID, base.Open);
        }

    }

}