using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenEducator.ContentTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OpenEducator {

    public interface IHasContent {
        List<Content> Contents { get; set; }
    }

    public interface ICanJsonSerialized {
        string JsonString();
    }

    public class Course: IHasContent, ICanJsonSerialized {

        public static string CourseDirectory {
            get {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Courses");
            }
        }
        public string CoursePath {
            get {
                return Path.Combine(CourseDirectory, ID.ToString() + ".json");
            }
        }

        public string Name { get; set; }
        public int ID { get; set; }

        public string Description { get; set; }
        public List<Content> Contents { get; set; }

        public string SnapshotUrl { get; set; }
        public string YoutubeVideoID { get; set; }
        public string Author { get; set; }
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public List<Chapter> Chapters { get; set; } = new List<Chapter>();

        /* JSON IGNORE */
        [JsonIgnore]
        public string YoutubeEmbedUrl {
            get {
                return $@"http://www.youtube.com/embed/{YoutubeVideoID}?modestbranding=1";
            }
        }

        public Course() { }

        public void Save() {
            string jsonData = JsonConvert.SerializeObject(this);
            File.WriteAllText(CoursePath, jsonData);
        }

        /* STATIC METHODS */
        public static bool Exists(int courseID) {
            string[] files = Directory.GetFiles(CourseDirectory, "*.json", SearchOption.TopDirectoryOnly);

            foreach(string file in files) {
                if(Path.GetFileNameWithoutExtension(file).ToString().Equals(courseID.ToString())) { return true; }
            }

            return false;
        }

        public static Course New { get; set; } = new Course() {
            Name = "Course",
            ID = new Random(DateTime.Now.Second).Next(200000, int.MaxValue),
            Contents = new List<Content>() { new TextContent("An OpenEducator Course") },
            SnapshotUrl = @"http://www.placehold.it/400x400"
        };

        public static Course GetFromID(int courseID) {
            return GetFromFilename(courseID.ToString() + ".json");
        }
        public static Course GetFromFilename(string filename) {
            string coursePath = Path.Combine(CourseDirectory, filename);
            if(!File.Exists(coursePath)) { return null; }

            string jsonData = File.ReadAllText(coursePath);

            return JsonConvert.DeserializeObject<Course>(jsonData, new ContentConverter());
        }

        public static List<Course> GetAll() {
            List<Course> Courses = new List<Course>();

            string[] files = Directory.GetFiles(CourseDirectory, "*.json");
            foreach(string path in files) {
                Courses.Add(GetFromFilename(Path.GetFileName(path)));
            }

            return Courses;
        }

        public string JsonString() {
            return JsonConvert.SerializeObject(this);
        }
        public string EncodedJsonString() {
            string data = JsEncode(JsonConvert.SerializeObject(this));
            return data.Substring(1, data.Length - 2);
        }
        string JsEncode(string data) {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("\"");
            foreach(char c in data) {
                switch(c) {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        int i = (int) c;
                        if(i < 32 || i > 127) {
                            sb.AppendFormat("\\u{0:X04}", i);
                        } else {
                            sb.Append(c);
                        }
                        break;
                }
            }
            sb.Append("\"");

            return sb.ToString();
        }

        public class ContentConverter: JsonConverter {

            public override bool CanConvert(Type objectType) {
                return (objectType == typeof(Content));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
                JObject jo = JObject.Load(reader);
                Type t = Type.GetType(jo["ContentType"].Value<string>());

                dynamic dt = jo.ToObject(t);

                return dt;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
                string jsonData = JsonConvert.SerializeObject(value, writer.Formatting);
                File.WriteAllText(writer.Path, jsonData);
            }
        }

        /* DEBUG */
    }
}