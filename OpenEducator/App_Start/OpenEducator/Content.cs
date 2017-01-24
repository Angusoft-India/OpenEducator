using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator {
    public abstract class Content {     

        public string ContentType {
            get {
                return GetType().FullName;
            }
        }
        public Content() { }

        public abstract string Render();

    }
}