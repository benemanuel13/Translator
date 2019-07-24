using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Translator.Models;

namespace Translator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LanguageView : ContentView
	{
        public event EventHandler<LanguageSelectedEventArgs> LanguageSelected;

        public Language Language;

		public LanguageView (Language language)
		{
			InitializeComponent ();

            Name.Text = language.Name;
            Language = language;
		}

        private void Select_Clicked(object sender, EventArgs e)
        {
            LanguageSelected(this, new LanguageSelectedEventArgs(Language));
        }
    }
}