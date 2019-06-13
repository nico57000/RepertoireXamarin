using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Repertoire.Modele;

namespace Repertoire
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public IList<Contact> ListeContact { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            ListeContact = new List<Contact>();
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AjoutContact
            {
                BindingContext = new Contact()
            });
        }

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListView.ItemsSource = await App.Database.GetContactsAsync();
            
        }

        async void SupprimerContact(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Supprimer?", "Voulez vous supprimer le contact", "Oui", "Non");
            if (answer)
            {
                var C = (Contact)ListView.SelectedItem;
                await App.Database.DeleteContactAsync(C);
                OnAppearing();
            }
        }
    }
}
