using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Interfaces
{
    public interface ISpeechRecogniser
    {
        void StartListening(string langCode);
        void StopListening();
    }
}
