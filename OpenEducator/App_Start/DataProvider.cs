using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenEducator
{
    public static class DataProvider {

        private static string SaveDirectory => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        public static void Save() {
            SaveLocal(StringsData);
            SaveLocal(PredefinedMenus);
        }
        public static void Load() {
            LoadLocal(out StringsData);
            LoadLocal(out PredefinedMenus);
        }

        // - Strings
        private static Dictionary<string, string> StringsData = new Dictionary<string, string>() {
            #region Hardcoded Strings
            ["SiteTitle"] = "OpenEducator",
            ["AccountSID"] = "AC736811825b32c5e592bfc38445cd4466",
            ["AuthToken"] = "fb745f21cfb1de32c6ac19baef224e1f",
            ["Number"] = "+15133344931"
            #endregion
        };
        public static string GetString(string key) {
            if (StringsData.Keys.Contains(key)) { return StringsData[key]; }
            else return default(string);
        }

        // - Menus
        public struct Menu {
            public Dictionary<string, string> Links { get; set; }
        }
        private static Dictionary<string, Menu> PredefinedMenus = new Dictionary<string, Menu>() {
            #region Hardcoded Menus
            ["TopBar"] = new Menu() { Links = new Dictionary<string, string>() {
                ["Dashboard"] = "/Dashboard", ["Courses"] = "/Course", ["Maker"] = "/Maker",
                ["Temp Course Saver"] = "/Maker/TempCreate", ["College App Course"] = "/Course/10001",
                ["Test"] = "/Dashboard/Test"
            }}
            #endregion
        };
        public static Menu GetMenu(string key) {
            if (PredefinedMenus.Keys.Contains(key)) { return PredefinedMenus[key]; }
            else { return new Menu() { Links = new Dictionary<string, string>() }; }
        }
        
        // <-> JSON ENCODE
        private static void SaveLocal<T>(T thing) {
            string data = JsonConvert.SerializeObject(thing);
            File.WriteAllText(Path.Combine(SaveDirectory, typeof(T).FullName), data);
        }

        private static void LoadLocal<T>(out T thing) {
            string data = File.ReadAllText(Path.Combine(SaveDirectory, typeof(T).FullName));
            thing = JsonConvert.DeserializeObject<T>(data);
        }
        
    }
}