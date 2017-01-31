using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace OpenEducator {
    public abstract class Content {     

        public string ContentType {
            get {
                return GetType().FullName;
            }
        }

        public string[] Classes { get; set; } = new string[] { };
        public string ID { get; set; } = "";
        public string Style { get; set; } = "";
        /// <summary>
        /// Put directly inside tag
        /// </summary>
        public string Open { get; set; } = "";
        
        /// <summary>
        /// Wrap data into a tag with optional properties.
        /// </summary>
        /// <param name="domElement">Tag (div, p, etc.)</param>
        /// <param name="data">InnerHTML</param>
        /// <param name="style">Inline Style</param>
        /// <param name="classes">List of Classes</param>
        /// <param name="id">ID</param>
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
        /// <returns></returns>
        public static string WrapSelfClosing(string domElement, string style = null, string[] classes = null, string id = null, string open = null) {
            return $@"<{domElement}" +
                ((classes == null || classes.Length == 0) ? "" : (" class=\"" + string.Join(" ", classes) + "\"")) +
                (string.IsNullOrWhiteSpace(id) ? "" : (" id=\"" + id + "\"")) +
                (string.IsNullOrWhiteSpace(style) ? "" : (" style=\"" + style + "\"")) +
                (string.IsNullOrWhiteSpace(open) ? "" : $"{open}") +
                $@"/{domElement}>";
        }
        
        public abstract string Render();

        public static List<PropertyInfo> GetPropertiesOfType(string typeFullName) {
            return Type.GetType(typeFullName).GetProperties(BindingFlags.DeclaredOnly).ToList();
        }

        public static List<Type> AvailableContentTypes() {
            return Assembly.GetExecutingAssembly().GetTypes().Where(t =>
                (!t.IsAbstract) && (t.IsClass) && (t.Namespace == "OpenEducator.ContentTypes")
                && (t.BaseType.FullName == "OpenEducator.Content")
            ).ToList();
        }

        public static string AllContentTypeProperties() {
            List<Type> contentTypes = AvailableContentTypes();
            Dictionary<string, List<string>> contentProps = new Dictionary<string, List<string>>();
            
            foreach(Type t in contentTypes) {
                List<PropertyInfo> propInfo = t.GetProperties(BindingFlags.Public).ToList();
                List<string> props = new List<string>();

                foreach(PropertyInfo pi in propInfo) {
                    if(pi.Name == "ContentType") { continue; }
                    props.Add(pi.Name);
                }

                contentProps.Add(t.FullName, props);
            }

            return JsonConvert.SerializeObject(contentProps);
        }
    }
}