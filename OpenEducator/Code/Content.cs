using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace OpenEducator.Code {

    public abstract class Content: ICanJsonSerialized {

        public string[] Classes { get; set; }
        public string ID { get; set; }
        public string Style { get; set; }
        /// <summary>
        /// Put directly inside tag
        /// </summary>
        public string Open { get; set; }
        public string[] xContentClasses { get; set; }
        public string xContentStyle { get; set; }

        public string[] IncludeScripts { get; set; }
        public string[] IncludeStylesheets { get; set; }
        public string Activators { get; set; }
        
        [JsonIgnore]
        public string TypeShortName => GetType().Name.Replace("Content", "");

        public abstract string Render();

        public string JsonString() {
            return JsonConvert.SerializeObject(this);
        }

        /* CONTENT TYPE HELPER FUNCTIONS */

        /// <summary>
        /// Wrap data into a tag with optional properties.
        /// </summary>
        /// <param name="domElement">Tag (div, p, etc.)</param>
        /// <param name="data">InnerHTML</param>
        /// <param name="style">Inline Style</param>
        /// <param name="classes">List of Classes</param>
        /// <param name="id">ID</param>
        /// <param name="open">Stuff directly inserted into the element</param>
        /// <returns></returns>
        public static string Wrap(string domElement, string data, string style = "", string[] classes = null, string id = null, string open = null) {
            return $@"<{domElement}" +
                ((classes == null || classes.Length == 0) ? "" : (" class=\"" + string.Join(" ", classes) + "\"")) +
                (string.IsNullOrWhiteSpace(id) ? "" : (" id=\"" + id + "\"")) +
                (string.IsNullOrWhiteSpace(style) ? "" : (" style=\"" + style + "\"")) +
                (string.IsNullOrWhiteSpace(open) ? "" : $" {open}") +
                $@">{data}</{domElement}>";
        }

        /// <summary>
        /// Create a self-closing tag with optional properties.
        /// </summary>
        /// <param name="domElement">Tag (div, p, etc.)</param>
        /// <param name="style">Inline Style</param>
        /// <param name="classes">List of Classes</param>
        /// <param name="id">ID</param>
        /// <param name="open">Stuff directly inserted into the element</param>
        /// <returns></returns>
        public static string WrapSelfClosing(string domElement, string style = null, string[] classes = null, string id = null, string open = null) {
            return $@"<{domElement}" +
                ((classes == null || classes.Length == 0) ? "" : (" class=\"" + string.Join(" ", classes) + "\"")) +
                (string.IsNullOrWhiteSpace(id) ? "" : (" id=\"" + id + "\"")) +
                (string.IsNullOrWhiteSpace(style) ? "" : (" style=\"" + style + "\"")) +
                (string.IsNullOrWhiteSpace(open) ? "" : $"{open}") +
                $@"/{domElement}>";
        }

        /// <summary>
        /// Creates a string from a list of properties that can be put inside an HTML tag
        /// </summary>
        /// <param name="lKvp"></param>
        /// <returns></returns>
        public static string OpenMaker(List<KeyValuePair<string,string>> lKvp) {
            string _open = "";
            List<KeyValuePair<string, string>> Inserted = new List<KeyValuePair<string, string>>();

            foreach(var kvp in lKvp) {
                if(!Inserted.Contains(kvp)) {
                    _open += $@" {kvp.Key}" + (string.IsNullOrWhiteSpace(kvp.Value) ? "" : $"=\"{kvp.Value}\"");
                    Inserted.Add(kvp);
                }
            }

            return _open;
        }
    
    }
    
}