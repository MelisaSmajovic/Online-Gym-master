using OnlineGym_Model;
using OnlineGym_Model.Requests;
using ProbnoRS2_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProbnoRS2_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProizvodiPage : ContentPage
	{
		private ProizvodiVM model = null;
		private readonly APIService _narudzbe = new APIService("Narudzba");
		private readonly APIService _narudzbaId = new APIService("Narudzba/GetMaxNarudzbaId");
		private readonly APIService _stavke = new APIService("NarudzbaStavka");
		public ProizvodiPage()
		{
			InitializeComponent();
			BindingContext = model = new ProizvodiVM();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await model.Init();
		}

		private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as Proizvod;

			await Navigation.PushAsync(new ProizvodDetaljiPage(item));
		}
		private async void PretragaPoNazivu_Clicked(object sender, EventArgs e)
		{
		
			await model.PretragaPoNazivu();

		}
		async void OnTextChanged(object sender, EventArgs e)
		{
			await model.PretragaPoNazivu();
		}
		private async void CheckBox_Changed(object sender, EventArgs e)
		{
			
			await model.PretragaPoNazivu();
		}
		private async void Dodaj_Clicked(object sender, EventArgs e)
		{
			var proID = ((Button)sender).BindingContext;
			int proizvodID = int.Parse(proID.ToString());
			if (Global.NarudzbaId ==0)
			{
				NarudzbaUpsertRequest query = new NarudzbaUpsertRequest();
				query.BrojNarudzbe = "123";
				query.ClanID = Global.LogiraniClanId;
				query.Datum = DateTime.Now;
				query.Procesirana = false;				
				int maxId = await _narudzbaId.Get<int>(null) + 1;
				Global.NarudzbaId = maxId;
				query.NarudzbaId = maxId;
				Narudzbe entity = null;
				entity = await _narudzbe.Insert<Narudzbe>(query);

			}
				NarudzbaStavkaUpsertRequest stavka = new NarudzbaStavkaUpsertRequest();
				stavka.ProizvodId = proizvodID;
				stavka.Kolicina = 1;
				stavka.NarudzbaId = Global.NarudzbaId;
				NarudzbeStavke entityStavka = null;
				entityStavka = await _stavke.Insert<NarudzbeStavke>(stavka);
			var stringBuilder = new StringBuilder();
			await Application.Current.MainPage.DisplayAlert("Proizvod je dodan u košaricu!", stringBuilder.ToString(), "OK");

		
		}
	}
	}