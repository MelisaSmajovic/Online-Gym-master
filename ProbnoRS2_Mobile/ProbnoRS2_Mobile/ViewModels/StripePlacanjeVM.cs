using Acr.UserDialogs;
using OnlineGym_Model;
using OnlineGym_Model.Requests;
using Prism.Commands;
using Prism.Mvvm;
using ProbnoRS2_Mobile.Models;
using ProbnoRS2_Mobile.Views;
using Stripe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Application = Xamarin.Forms.Application;

namespace ProbnoRS2_Mobile.ViewModels
{
  public class StripePlacanjeVM: BindableBase
    {
        private readonly APIService _tipoviClanarine = new APIService("TipClanarine");
        private readonly APIService _clanteretana = new APIService("ClanTeretana");
        private readonly APIService _uplateClanarine = new APIService("PlacanjeClanarine");
        public INavigation Navigation { get; set; }
        private readonly APIService _izlazi = new APIService("Izlaz");
        #region Variable
        private KreditnaKarticaModel _kreditnaKarticaModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;

        #endregion Variable

        public ObservableCollection<TipClanarine> tipoviClanarineList { get; set; } = new ObservableCollection<TipClanarine>();
        public ObservableCollection<ClanTeretana> teretaneList { get; set; } = new ObservableCollection<ClanTeretana>();
        TipClanarine _selectedTip = null;
        ClanTeretana _selectedTeretana = null;
        public TipClanarine SelectedTip
        {
            get { return _selectedTip; }
            set
            {
                SetProperty(ref _selectedTip, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }
        public ClanTeretana SelectedTeretana
        {
            get { return _selectedTeretana; }
            set
            {
                SetProperty(ref _selectedTeretana, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            if (tipoviClanarineList.Count == 0)
            {
                var tipoviList = await _tipoviClanarine.Get<List<TipClanarine>>(null);

                foreach (var tip in tipoviList)
                {
                    tipoviClanarineList.Add(tip);
                }
            }
            if (teretaneList.Count == 0)
            {
                ClanTeretanaSearchRequest request = new ClanTeretanaSearchRequest();
                request.ClanId = Global.LogiraniClanId;
                var teretanelist = await _clanteretana.Get<List<ClanTeretana>>(request);

                teretaneList.Clear();
                foreach (var teretana in teretanelist)
                {
                    teretaneList.Add(teretana);
                }
            }
        }



        #region Public Property
        private string StripeTestApiKey = "sk_test_51GrL1XGmb0EjKtojg7qSbouyz5CuWL2r5vzg3qGSW8dDBuS9Qh58hwSx36A25VcULpkuHD06FoRuI5zUrVqHD6db00FU9VasDa";
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }

        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }

        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }

        public KreditnaKarticaModel KreditnaKartica
        {
            get { return _kreditnaKarticaModel; }
            set { SetProperty(ref _kreditnaKarticaModel, value); }
        }

        #endregion Public Property

        #region Constructor

        public StripePlacanjeVM()
        {
            KreditnaKartica = new KreditnaKarticaModel();
            Title = "Card Details";
            InitCommand = new Command(async () => await Init());
        }

        #endregion Constructor

        #region Command


        public DelegateCommand SubmitCommandClanarine => new DelegateCommand(async () =>
        {

            KreditnaKartica.ExpMonth = Convert.ToInt64(ExpMonth);
            KreditnaKartica.ExpYear = Convert.ToInt64(ExpYear);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                UserDialogs.Instance.ShowLoading("Izvršavanje uplate...");
                await Task.Run(async () =>
                {

                    var Token = CreateToken();
                    Console.Write("Payment Gateway" + "Token :" + Token);
                    if (Token != null)
                    {
                        IsTransectionSuccess = MakePayment(Token);
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Unesite ispravne podatke o kartici", null, "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                IsTransectionSuccess = false;
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
                Console.Write("Payment Gatway" + ex.Message);
            }
            finally
            {
                if (IsTransectionSuccess)
                {
                    Console.Write("Payment Gateway" + "Payment Successful ");
                    var request = new PlacanjeClanarineUpsertRequest
                    {
                        ClanId = Global.LogiraniClanId,
                        TeretanaId = SelectedTeretana.TeretanaId,
                        TipClanarineId = SelectedTip.TipClanarineId,
                        DatumUplate = DateTime.Now,
                        UkupanIznos = SelectedTip.Cijena

                    };

               
                    PlacanjeClanarine entity = null;
                    entity = await _uplateClanarine.Insert<PlacanjeClanarine>(request);



                    UserDialogs.Instance.Alert("Uspješno ste izvršili uplatu", "OK", "OK");
                    UserDialogs.Instance.HideLoading();



                    await Navigation.PushAsync(new PlaceneClanarinePage(SelectedTeretana.TeretanaId));
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert("Greška", "Uplata nije izvršena", "OK");
                    Console.Write("Plaćanje" + "Uplata neuspješna ");
                }
            }

        });



        public DelegateCommand SubmitCommand => new DelegateCommand(async () =>
        {
            if (Global.NarudzbaId != 0)
            {
                KreditnaKartica.ExpMonth = Convert.ToInt64(ExpMonth);
                KreditnaKartica.ExpYear = Convert.ToInt64(ExpYear);
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                CancellationToken token = tokenSource.Token;
                try
                {
                    UserDialogs.Instance.ShowLoading("Izvršavanje uplate...");
                    await Task.Run(async () =>
                    {

                        var Token = CreateToken();
                        Console.Write("Payment Gateway" + "Token :" + Token);
                        if (Token != null)
                        {
                            IsTransectionSuccess = MakePayment(Token);
                        }
                        else
                        {
                            UserDialogs.Instance.Alert("Unesite ispravne podatke o kartici", null, "OK");
                        }
                    });
                }
                catch (Exception ex)
                {
                    IsTransectionSuccess = false;
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert(ex.Message, null, "OK");
                    Console.Write("Payment Gatway" + ex.Message);
                }
                finally
                {
                    if (IsTransectionSuccess)
                    {
                        Console.Write("Plaćanje" + "Uplata izvršena uspješno");
                        IzlazUpsertRequest uplata = new IzlazUpsertRequest();
                        uplata.NarudzbaId = Global.NarudzbaId;
                        uplata.Zakljucen = true;
                        uplata.Datum = DateTime.Now;
                        uplata.IznosSaPdv = Global.NarudzbaTotal;

                        Izlazi entity = null;
                        entity = await _izlazi.Insert<Izlazi>(uplata);

                        Global.NarudzbaId = 0;
                        UserDialogs.Instance.Alert("Uspješno ste izvršili uplatu", "OK", "OK");
                        UserDialogs.Instance.HideLoading();

                        ////Application.Current.MainPage = new NarudzbaPage();
                        for (int PageIndex = Navigation.NavigationStack.Count; PageIndex > 1; PageIndex--)
                        {
                            Navigation.RemovePage(Navigation.NavigationStack[PageIndex - 1]);
                        }
                        await Navigation.PushAsync(new ClanProizvodiPage());
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        UserDialogs.Instance.Alert("Greška!", "Uplata nije izvršena", "OK");
                        Console.Write("Plaćanje" + "Plaćanje neuspješno ");
                    }
                }
            }
            else
            {
                UserDialogs.Instance.Alert("Već ste platili narudžbu!", "OK", "OK");
            }
        });

        #endregion Command

        #region Method

        private string CreateToken()
        {
            try
            {
                StripeConfiguration.SetApiKey(StripeTestApiKey);
                var service = new ChargeService();
                var Tokenoptions = new TokenCreateOptions
                {
                    Card = new CreditCardOptions
                    {
                        Number = KreditnaKartica.Broj,
                        ExpYear = KreditnaKartica.ExpYear,
                        ExpMonth = KreditnaKartica.ExpMonth,
                        Cvc = KreditnaKartica.Cvc,
                        Name=Global.LogiraniClan.Ime+" "+Global.LogiraniClan.Prezime,                    
                        AddressCity=Global.LogiraniClan.Grad.Naziv,              
                        AddressCountry = "Bosna i Hercegovina",
                        Currency = "bam",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool MakePayment(string token)
        {
            try
            {
              
                StripeConfiguration.SetApiKey(StripeTestApiKey);
                var options = new ChargeCreateOptions
                {
                    Amount = (long)float.Parse("20000"),
                    Currency = "bam",
                    Description = "Uplata na ime: "+ Global.LogiraniClan.Ime+" "+Global.LogiraniClan.Prezime,
                
                    Source = stripeToken.Id,
                    StatementDescriptor = "Custom descriptor", 
                    Capture = true,
                    ReceiptEmail =Global.LogiraniClan.Email,
                };
              
                var service = new ChargeService();
                Charge charge = service.Create(options);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gatway (CreateCharge)" + ex.Message);
                throw ex;
            }
        }

        private bool ValidateCard()
        {
            if (KreditnaKartica.Broj.Length == 16 && ExpMonth.Length == 2 && ExpYear.Length == 2 && KreditnaKartica.Cvc.Length == 3)
            {
            }
            return true;
        }

        #endregion Method
    }
}
