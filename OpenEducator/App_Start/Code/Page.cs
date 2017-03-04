using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenEducator.Code {

    public class Page: IHasContent, ICanJsonSerialized {
        public string Name { get; set; }
        public List<Content> Contents { get; set; } = new List<Content>();

        public string JsonString() {
            return JsonConvert.SerializeObject(this);
        }
    }

}