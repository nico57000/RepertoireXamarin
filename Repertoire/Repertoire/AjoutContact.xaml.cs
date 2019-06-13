using Repertoire.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repertoire
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjoutContact : ContentPage
    {
        public AjoutContact()
        {
            InitializeComponent();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var C = (Contact)BindingContext;
            await App.Database.SaveContactAsync(C);
            await Navigation.PopAsync();
        }
    }
}