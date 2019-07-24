using System;
using System.Collections.Generic;
using System.Text;

using Translator.Models;

namespace Translator
{
    public class LanguageSelectedEventArgs : EventArgs
    {
        public Language Language { get; set; }

        public LanguageSelectedEventArgs(Language language)
        {
            Language = language;
        }
    }
}
