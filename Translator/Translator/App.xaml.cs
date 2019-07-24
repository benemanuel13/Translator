using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Translator;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Translator
{
    public partial class App : Application
    {
        public static event EventHandler<GotSpeechTextEventArgs> GotSpeech;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public void GotAndroidSpeech(string speech)
        {
            GotSpeech(this, new GotSpeechTextEventArgs(speech));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
