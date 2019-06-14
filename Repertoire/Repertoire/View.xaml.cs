using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Repertoire.Modele;
using WebServiceTutorial;

namespace Repertoire
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View : ContentPage
    {
        public Contact contact { get; set; }

        public RestService _restService { get; set; }
        public View(Contact C)
        {
            InitializeComponent();
            _restService = new RestService();
            contact = C;
            Nom.Text = C.Nom;
            Prenom.Text = C.Prenom;
            Tel.Text = C.Tel;
            Ville.Text = C.Ville;
            Adresse.Text = C.Adress;
            Twitter.Text = C.PseudoTwitter;
            
        }

        async void Modify_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Modifier(contact));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!string.IsNullOrWhiteSpace(Ville.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherDataAsync(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }

        private string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={Ville.Text}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}