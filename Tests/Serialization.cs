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
        public void Coupling() {
            object obj = new ListContent(new List<Content>() {
                new TextContent("Dude"),
                new TextContent("Triggly"),
                new ImageContent("http://www.placehold.it/400x300")
            });

            string serailizedObjString = JsonConvert.SerializeObject(obj);
            Type t = obj.GetType();

            object deserializedObj = JsonConvert.DeserializeObject(serailizedObjString, t);
            string deseralizedObjString = JsonConvert.SerializeObject(deserializedObj);

            Assert.IsTrue(serailizedObjString == deseralizedObjString);
        }
    }
}
