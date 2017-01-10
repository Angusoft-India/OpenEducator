using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OpenEducator
{
    public class Course {              
        public static string CourseDirectory {
            get {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Courses");
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

        public static bool Exists(string courseName) {
            string[] files = Directory.GetFiles(CourseDirectory, "*.json", SearchOption.TopDirectoryOnly);
                
            foreach(string file in files) {
                if(Path.GetFileNameWithoutExtension(file).ToLower().Equals(courseName.ToLower())) { return true; }
            }
            return false;
        }

        public static List<Course> GetAll() {
            return new List<Course>() {
                new Course() {
                    Name = "Introduction To Calculus",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras et posuere augue. Nam accumsan enim ut maximus dignissim. Pellentesque habitant morbi tristique senectus et netus.",
                    Author = "Aryan Mann University",
                    SnapshotUrl = "http://www.placehold.it/160x160"
                }
            };
        }
    }

    /*  EXAMPLE
        Calculus 101
    */
}