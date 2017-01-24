using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenEducator.ContentTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OpenEducator {
    public class Course {

        public static string CourseDirectory {
            get {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Courses");
            }
        }
        public string CoursePath {
            get {
                return Path.Combine(CourseDirectory, Name.Replace(" ","") + ".json");
            }
        }

        public string Name { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public string SnapshotUrl { get; set; }
        public string YoutubeVideoID { get; set; }
        public string Author { get; set; }
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public List<Chapter> Chapters { get; set; } = new List<Chapter>();

        public Course() { }

        public void Save() {
            string jsonData = JsonConvert.SerializeObject(this);
            File.WriteAllText(CoursePath, jsonData);
        }

        /* STATIC METHODS */
        public static bool Exists(string courseName) {
            string[] files = Directory.GetFiles(CourseDirectory, "*.json", SearchOption.TopDirectoryOnly);

            foreach(string file in files) {
                if(Path.GetFileNameWithoutExtension(file).ToLower().Equals(courseName.ToLower())) { return true; }
            }
            return false;
        }

        public static Course New { get; set; } = new Course() {
            Name = "Course",
            ID = new Random(DateTime.Now.Second).Next(200000, int.MaxValue),
            Description = "An OpenEducator Course",
            SnapshotUrl = @"http://www.placehold.it/400x400"
        };

        public static Course GetFromName(string courseName) {
            return GetFromFilename(courseName + ".json");
        }
        public static Course GetFromFilename(string filename) {
            string coursePath = Path.Combine(CourseDirectory, filename);
            string jsonData = File.ReadAllText(coursePath);

            return (Course) JsonConvert.DeserializeObject<Course>(jsonData, new ContentConverter());
        }

        public static List<Course> GetAll() {
            List<Course> Courses = new List<Course>();

            string[] files = Directory.GetFiles(CourseDirectory, "*.json");
            foreach(string path in files) {
                Courses.Add(GetFromFilename(Path.GetFileName(path)));
            }

            return Courses;
        }
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
}