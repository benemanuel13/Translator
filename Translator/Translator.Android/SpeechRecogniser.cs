using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Speech;

using Translator.Droid;
using Translator.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(SpeechRecogniser))]
namespace Translator.Droid
{
    public class SpeechRecogniser : ISpeechRecogniser
    {
        private string LangCode { get; set; } = "en";

        public void StartListening(string langCode)
        {
            LangCode = langCode;

            StartRecordingAndRecognizing();
        }

        public void StopListening()
        { }

        private readonly int VOICE = 10;

        private Activity activity;

        public SpeechRecogniser()
        {
            activity = MainActivity.HomeActivity;
        }

        private void StartRecordingAndRecognizing()
        {
            Java.Util.Locale locale = GetLocale();

            string rec = global::Android.Content.PM.PackageManager.FeatureMicrophone;

            if (rec == "android.hardware.microphone")

            {
                var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);

                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
                voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Speak now");
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
                voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, locale);

                activity.StartActivityForResult(voiceIntent, VOICE);
            }
        }

        private Java.Util.Locale GetLocale()
        {
            Java.Util.Locale locale = Java.Util.Locale.GetAvailableLocales().Where(l => l.Language == LangCode).FirstOrDefault();

            return locale;
        }
    }
}