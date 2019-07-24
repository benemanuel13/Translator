using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Models
{
    public class Language
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public Language(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }
}
