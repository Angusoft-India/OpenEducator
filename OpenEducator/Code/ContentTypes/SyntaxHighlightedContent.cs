using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenEducator.Code.ContentTypes {

    public class SyntaxHighlightedContent: Content {

        /*
             HIGHLIGHT JS  9.9.0
            ---------------------
             SUPPORTED LANGUAGES
            ---------------------
            Apache  Bash  C#  C++  CSS  CoffeeScript  Diff  HTML
            XML  HTTP  Ini  JSON  Java  JavaScript  Makefile  
            Markdown  Nginx  Objective-C  PHP  Perl  Python  Ruby  SQL 
        */

        public enum Languages {
            Apache, Bash, CSharp, Css, CoffeeScript, Diff, Html, Xml,
            Http, Ini, Json, Java, JavaScript, MakeFile, Markdown,
            Nginx, ObjectiveC, Php, Perl, Python, Ruby, Sql
        }

        private const string ScriptCdn = @"//cdnjs.cloudflare.com/ajax/libs/highlight.js/9.9.0/highlight.min.js";
        private const string CssCdn = @"//cdnjs.cloudflare.com/ajax/libs/highlight.js/9.9.0/styles/default.min.css";
        public Languages Language { get; set; }

        public string Text { get; set; }

        public SyntaxHighlightedContent(string text, Languages lang = Languages.Html) {
            Text = text;
            Language = lang;

            base.IncludeScripts = new[] {
                ScriptCdn
            };
            base.IncludeStylesheets = new[] {
                CssCdn
            };

            base.Activators = "hljs.initHighlightingOnLoad();";
        }

        /*
            <link rel="stylesheet" href="/path/to/styles/default.css">
            <script src="/path/to/highlight.pack.js"></script>
            <pre>
                <code class="html">
                    {{Text}}
                </code>
            </pre>
            <script>$(function){ hljs.initHighlightingOnLoad(); }</script>
         
        */
        public override string Render() {
            return Wrap("pre", Wrap("code", Text, classes: new[] { Language.ToString().ToLower() }), classes: new[] { "syntax-highlighter" }.Concat(base.Classes ?? new string[]{}).ToArray(), id: base.ID, style: base.Style, open: base.Open);
        }

    }

}