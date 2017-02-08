using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenEducator.Code;
using System.Collections.Generic;
using OpenEducator.Code.ContentTypes;

namespace Tests {

    [TestClass]
    public class JsonSerialization {
                
        [TestMethod]
        public void Reserialization() {

            /*  
                PURPOSE: To test if serialized and reserialized objects have the same string value
                METHODOLOGY: Serailize and object, deserialize it, and the reserialized it and compare              
            */

            Course c = new Course() {
                Contents = new List<Content>() {
                    new ListContent(new List<Content>() {
                        new TextContent("A"),
                        new TextContent("B"),
                        new TextContent("C")
                    })
                }
            };

            string jsonData = c.JsonString();

            Course cCopy = (Course) JsonConvert.DeserializeObject(jsonData, Course.DefaultSettings);
            string jsonDataCopy = cCopy.JsonString();

            Assert.IsTrue(jsonData.Equals(jsonDataCopy));
        }
    }
}
