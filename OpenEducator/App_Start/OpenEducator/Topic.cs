﻿using System.Collections.Generic;

namespace OpenEducator
{
    public class Topic: IHasContent {

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Content> Contents { get; set; }
        public List<Page> Pages { get; set; } = new List<Page>();

    }

    /*  EXAMPLE
        Differentiation
    */
}