using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes {

    public class ConstructedHtmlContent: Content {

        public string Element { get; set; } = "div";
        public Content Data { get; set; } = null;

        public ConstructedHtmlContent(string element, Content data) {
            Element = element;
            Data = data ?? null;
        }

        public override string Render() {
            return Wrap(Element, (Data == null ? "" : Data?.Render()), base.Style, base.Classes, base.ID, base.Open);
        }

    }

}