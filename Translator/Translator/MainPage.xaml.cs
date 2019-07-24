using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using BensTranslator.Translation;

using Translator.Models;
using Translator.Presentation.ViewModels;
using Translator.Interfaces;
using Translator.Presentation.Pages;

using Xamarin.Essentials;

namespace Translator
{
    public partial class MainPage : ContentPage
    {
        string langCode = "de";

        LanguagesModel model = new LanguagesModel();

        public string UserLangCode { get; set; } = "en";

        public string LangCode
        {
            get
            {
                return langCode;
            }

            set
            {
                langCode = value;
            }
        }

        public MainPage()
        {
            InitializeComponent();

            App.GotSpeech += App_GotSpeech;
        }

        private async void App_GotSpeech(object sender, GotSpeechTextEventArgs e)
        {
            TranslationClient client = new TranslationClient();

            TextTranslation trans = client.Translate(langCode, e.Text);

            Translation.Text = trans.Text;

            await SpeakNow(trans.Text);
        }

        private async void Translate_Clicked(object sender, EventArgs e)
        {
            if (TextToTranslate.Text == "")
                return;

            TranslationClient client = new TranslationClient();

            TextTranslation trans = client.Translate(langCode, TextToTranslate.Text);

            Translation.Text = trans.Text;

            await SpeakNow(trans.Text);
        }

        private void TranslateSpeech_Clicked(object sender, EventArgs e)
        {
            ISpeechRecogniser rec = DependencyService.Get<ISpeechRecogniser>();

            rec.StartListening(UserLangCode);
        }

        private void PopulateLanguages()
        {
            Language english = new Language("English", "en");
            Language german = new Language("German", "de");
            Language french = new Language("French", "fr");
            Language polish = new Language("Polish", "pl");
            Language greek = new Language("Greek", "el");

            List<Language> languages = new List<Language>();
            languages.Add(english);
            languages.Add(german);
            languages.Add(french);
            languages.Add(polish);
            languages.Add(greek);

            foreach (Language language in languages)
            {
                LanguageView view = new LanguageView(language);
                view.LanguageSelected += View_LanguageSelected;

                //Languages.Children.Add(view);
            }
        }

        private void View_LanguageSelected(object sender, LanguageSelectedEventArgs e)
        {
            langCode = e.Language.Id;
        }

        public async Task SpeakNow(string text)
        {
            IEnumerable<Locale> locales = await TextToSpeech.GetLocalesAsync();

            Locale locale = locales.Where(l => l.Language == langCode).FirstOrDefault();

            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 1.0f,
                Locale = locale
            };

            await TextToSpeech.SpeakAsync(text, settings);
        }

        private async void PickLanguage_Clicked(object sender, EventArgs e)
        {
            LanguagePicker picker = new LanguagePicker(true, this, model);
            await Navigation.PushAsync(picker, true);
        }

        private async void PickToLanguage_Clicked(object sender, EventArgs e)
        {
            LanguagePicker picker = new LanguagePicker(false, this, model);
            await Navigation.PushAsync(picker, true);
        }

        public void SetCurrentLanguageText(string language)
        {
            CurrentLanguage.Text = "Your Current Language: " + language;
        }

        public void SetCurrentToLanguageText(string language)
        {
            ToLanguage.Text = "Translating To: " + language;
        }
    }
}
