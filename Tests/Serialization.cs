using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenEducator.ContentTypes;
using OpenEducator;
using System.Collections.Generic;

namespace Tests {

    [TestClass]
    public class JsonSerialization {
                
        [TestMethod]
        public void Reserialization() {

            /*  
                PURPOSE: To test if serialized and reserialized objects have the same string value
                METHODOLOGY: Serailize and object, deserialize it, and the reserialized it and compare              
            */

            object obj = new ListContent(new List<Content>() {
                new TextContent("Dude"),
                new TextContent("Stuff"),
                new ImageContent("http://www.placehold.it/400x300")
            });

            string serailizedObjString = JsonConvert.SerializeObject(obj);
            Type t = obj.GetType();

            object deserializedObj = JsonConvert.DeserializeObject(serailizedObjString, t, new JsonConverter[] { new ContentConverter() });
            string deseralizedObjString = JsonConvert.SerializeObject(deserializedObj);

            Assert.IsTrue(serailizedObjString.Equals(deseralizedObjString));
        }
    }
}
