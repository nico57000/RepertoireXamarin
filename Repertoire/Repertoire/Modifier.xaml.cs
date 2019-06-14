using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repertoire.Modele;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repertoire
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modifier : ContentPage
    {
        public Contact contact { get; set; }
        public Modifier(Contact C)
        {
            InitializeComponent();
            contact = C;
            Nom.Text = contact.Nom;
            prenom.Text = contact.Prenom;
            tel.Text = contact.Tel;
            mail.Text = contact.mail;
            Adresse.Text = contact.Adress;
            Twitter.Text = contact.PseudoTwitter;
        }

        async void Modify_Clicked(object sender, EventArgs e)
        {
            contact.Nom = Nom.Text;
            contact.Prenom = prenom.Text;
            contact.Tel = tel.Text;
            contact.mail = mail.Text;
            await App.Database.SaveContactAsync(contact);
            await Navigation.PopAsync();

        }

        async void Supp_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Supprimer?", "Voulez vous supprimer le contact", "Oui", "Non");
            if (answer)
            {
                await App.Database.DeleteContactAsync(contact);
                OnAppearing();
                await Navigation.PopAsync();
            }
        }
    }
}