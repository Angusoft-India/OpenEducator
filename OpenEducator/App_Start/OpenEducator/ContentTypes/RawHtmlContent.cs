using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.ContentTypes {

    public class RawHtmlContent: Content {

        string Data { get; set; }
        public RawHtmlContent(string data) {
            Data = data;
        }

        public override string Render() {
            return Data;
        }
    }

}