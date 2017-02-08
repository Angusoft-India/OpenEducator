using Newtonsoft.Json;

namespace OpenEducator.Code {
    public class Instructor: ICanJsonSerialized {
        public string Name { get; set; }
        public int ID { get; set; }

        public string JsonString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}