using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes {

    public class ConstructedHtmlContent: Content {

        public string Element { get; set; }
        public Content Data { get; set; }

        public ConstructedHtmlContent(string element, Content data) {
            Element = element;
            Data = data;
        }

        public override string Render() {
            return Wrap(Element, Data.Render(), base.Style, base.Classes, base.ID);
        }

    }

}