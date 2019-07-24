using System;
using System.Collections.Generic;
using System.Text;

using Translator.Models;

using Xamarin.Essentials;

namespace Translator.Presentation.ViewModels
{
    public class LanguagesModel
    {
        public List<Language> Languages = new List<Language>();

        public event EventHandler<LanguagesLoadedEventArgs> LanguagesLoaded;

        public LanguagesModel()
        {
            GetLanguages();
        }

        private async void GetLanguages()
        {
            IEnumerable<Locale> locales = await TextToSpeech.GetLocalesAsync();

            foreach (Locale locale in locales)
            {
                Language lang = new Language(locale.Name, locale.Language);
                Languages.Add(lang);
            }
        }
    }
}
