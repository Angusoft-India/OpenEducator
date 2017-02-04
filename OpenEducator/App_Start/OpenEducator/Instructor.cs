using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator
{
    public class Instructor: ICanJsonSerialized {
        public string Name { get; set; }
        public int ID { get; set; }

        public string JsonString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}