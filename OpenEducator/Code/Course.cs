using Newtonsoft.Json;
using OpenEducator.Code.ContentTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace OpenEducator.Code {

    public interface IHasContent {
        List<Content> Contents { get; set; }
    }

    public interface ICanJsonSerialized {
        string JsonString();
    }

    public class Course: IHasContent, ICanJsonSerialized {

        /// <summary>
        /// Where all the courses are stored
        /// </summary>
        public static string CourseDirectory => HttpContext.Current.Server.MapPath("~/Courses"); //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Courses");

        /// <summary>
        /// Where the JSON of the course is stored
        /// </summary>
        public string CoursePath => Path.Combine(CourseDirectory, ID.ToString() + ".json");

        public string Name { get; set; }
        /// <summary>
        /// Unique
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Used when in a list of courses
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Acts as a description when users view this course
        /// </summary>
        public List<Content> Contents { get; set; }
        /// <summary>
        /// Picture of the course when displayed as a part of a list
        /// </summary>
        public string SnapshotUrl { get; set; }
        /// <summary>
        /// Optional Youtube video that plays when SnapshotUrl image is clicked
        /// </summary>
        public string YoutubeVideoID { get; set; }
        /// <summary>
        /// The university of organization
        /// </summary>
        public string Author { get; set; }
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public List<Chapter> Chapters { get; set; } = new List<Chapter>();

        /* JSON IGNORE */
        [JsonIgnore]
        public string YoutubeEmbedUrl => $@"http://www.youtube.com/embed/{YoutubeVideoID}?modestbranding=1";

        public static JsonSerializerSettings DefaultSettings { get; set; } = new JsonSerializerSettings() {
            Formatting = Formatting.Indented,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Objects
        };

        public void Save() {
            string jsonData = JsonConvert.SerializeObject(this, DefaultSettings);
            File.WriteAllText(CoursePath, jsonData);
        }

        /* STATIC METHODS */
        public static bool Exists(int courseId) {
            string fileDir = Path.Combine(CourseDirectory, $"{courseId}.json");
            return File.Exists(fileDir);
        }

        public static Course New { get; set; } = new Course() {
            Name = "Course",
            ID = new Random(DateTime.Now.Second).Next(200000, int.MaxValue),
            Contents = new List<Content>() { new TextContent("An OpenEducator Course") },
            SnapshotUrl = @"http://www.placehold.it/400x400"
        };

        public static Course GetFromId(int courseId) {
            return GetFromFilename($"{courseId}.json");
        }
        public static Course GetFromFilename(string filename) {
            string coursePath = Path.Combine(CourseDirectory, filename);
            if(!File.Exists(coursePath)) { return null; }

            string jsonData = File.ReadAllText(coursePath);

            return JsonConvert.DeserializeObject<Course>(jsonData, DefaultSettings);
        }

        public static List<Course> GetAll() {
            List<Course> Courses = new List<Course>();

            string[] files = Directory.GetFiles(CourseDirectory, "*.json");
            foreach(string path in files) {
                Courses.Add(GetFromFilename(Path.GetFileName(path)));
            }

            return Courses;
        }

        static Random rand = new Random(DateTime.Now.Second);
        /// <summary>
        /// Gets an 
        /// </summary>
        /// <returns></returns>
        public static int GetAvailableID() {
            int id;
            do {
                id = rand.Next(10000, 100000);
            } while(!Exists(id));
            return id;
        }

        /* DEBUG */
        public string JsonString() {
            return JsonConvert.SerializeObject(this, DefaultSettings);
        }
        public string EncodedJsonString() {
            string data = JsEncode(JsonConvert.SerializeObject(this));
            return data.Substring(1, data.Length - 2);
        }
        string JsEncode(string data) {
            StringBuilder sb = new StringBuilder();
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
                        int i = c;
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

        public static Course Current => new Course() {

            Name = "Introduction To Web Development",
            Author = "Aryan Mann",
            Description = "This is the description.",
            ID = 13370,
            Instructors = new List<Instructor>() {
            new Instructor() {
                Name = "Aryan Mann",
                ID = 1337
            }
        },
            Contents = new List<Content>() {
            new TextContent(@"Web development is the coding or programming that enables website functionality, per the owner's requirements. It mainly deals with the non-design aspect of building websites, which includes coding and writing markup.
                              Web development ranges from creating plain text pages to complex Web-based applications, social network applications and electronic business applications.
                              The Web development hierarchy is as follows:-"),
            new ListContent(new List<Content>() {
                new RawHtmlContent("Client-side coding"),
                new RawHtmlContent("Server-side coding"),
                new RawHtmlContent("Database technology")
            }, true)
        },
            Chapters = new List<Chapter>() {
                new Chapter() {
                    Name = "How the web functions",
                    Description = "Functioning of the web",
                    Contents = new List<Content>() {
                        new TextContent(@"Essentially, the web is just a bunch of interconnected computers. When you visit a website, you are requesting data from another computer who sends the requested data back to your computer through huge cables that can also run under sea. We can call this relationship the 'Client-Server' relationship."),
                        new TextContent(@"The client requests data and the server fulfills that request."),
                        new TextContent("What are webpages?", TextContent.TextType.H1),
                        new TextContent(@"Webpages are essentially a combination of these three elements:- "),
                        new ListContent(new List<Content>(){
                            new RawHtmlContent(@"<strong>HTML</strong> - HyperText Markup Language - In essence, it is a way to structure and display data. When you visit a website, it sends you data in a format that your browser can understand and present for you."),
                            new RawHtmlContent(@"<strong>CSS</strong> - Cascading Stylesheets - Through CSS, we can control how items on our webpage look; their color, size, animation, etc."),
                            new RawHtmlContent(@"<strong>Javascript</strong> - It is a programming language and thus allows us to control what happens to and through those HTML elements.")
                        })
                    }
                }
            }

        };

    }
}