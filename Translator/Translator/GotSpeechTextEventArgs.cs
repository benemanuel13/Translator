using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Translator
{
    public class GotSpeechTextEventArgs : EventArgs
    {
        public string Text { get; set; }

        public GotSpeechTextEventArgs(string text)
        {
            Text = text;
        }
    }
}