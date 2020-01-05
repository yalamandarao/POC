using System;
using FreshMvvm;
using POC.DataBase;
using POC.Detail;
using POC.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Assemble();

            var page = FreshPageModelResolver.ResolvePageModel<PersonListPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page, "person")
            {
                BarTextColor = Color.White
            };
            App.Current.MainPage = basicNavContainer;
        }

        void Assemble()
        {
            FreshIOC.Container.Register<IPersonListDataStore, PersonListDataStore>();
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
