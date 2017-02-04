using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.App_Start
{
    public static class DataProvider
    {
        // STRINGS
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

        // MENUS
        public struct Menu {
            public Dictionary<string, string> Links { get; set; }
        }
        private static Dictionary<string, Menu> PredefinedMenus = new Dictionary<string, Menu>() {
            #region Hardcoded Menus
            ["TopBar"] = new Menu() { Links = new Dictionary<string, string>() {
                ["Dashboard"] = "/Dashboard", ["Courses"] = "/Course", ["Maker"] = "/Maker",
                ["Edit 13370"] = "/Maker/Edit/13370", ["Test"] = "/Dashboard/Test"
            }}
            #endregion
        };
        public static Menu GetMenu(string key) {
            if (PredefinedMenus.Keys.Contains(key)) { return PredefinedMenus[key]; }
            else { return new Menu() { Links = new Dictionary<string, string>() }; }
        }
        
        // JSON ENCODE
        public static string JsonEncode(object obj) {
            return JsonConvert.SerializeObject(obj);
        }
        
    }
}