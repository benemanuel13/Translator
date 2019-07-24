using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Translator.Models;
using Translator.Presentation.ViewModels;
using Translator.Presentation.Views.LanguagePicker;

namespace Translator.Presentation.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePicker : ContentPage
    {
        private ContentPage ParentPage { get; set; }
        private bool IsUserLanguage {get; set;}

        LanguagesModel viewModel;
		public LanguagePicker (bool isUserLanguage, ContentPage parent, LanguagesModel model)
		{
			InitializeComponent ();

            IsUserLanguage = isUserLanguage;
            ParentPage = parent;

            viewModel = model;
            //viewModel.LanguagesLoaded += ViewModel_LanguagesLoaded;

            Languages.ItemsSource = viewModel.Languages;
            Languages.ItemTemplate = new DataTemplate(typeof(LanguagePickerListItemCell));

            Languages.ItemTapped += Languages_ItemTapped;

            if (isUserLanguage)
                Title.Text = "Pick Your Language";
            else
                Title.Text = "Pick Translation Language";
        }

        private void ViewModel_LanguagesLoaded(object sender, LanguagesLoadedEventArgs e)
        {
            
        }

        private void Languages_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Language language = (Language)e.Item;

            if (IsUserLanguage)
            {
                ((MainPage)ParentPage).UserLangCode = language.Id;
                ((MainPage)ParentPage).SetCurrentLanguageText(language.Name);
            }
            else
            {
                ((MainPage)ParentPage).LangCode = language.Id;
                ((MainPage)ParentPage).SetCurrentToLanguageText(language.Name);
            }

            viewModel.LanguagesLoaded -= ViewModel_LanguagesLoaded;
            Languages.ItemTapped -= Languages_ItemTapped;

            ParentPage = null;

            Navigation.PopAsync();
        }
    }
}