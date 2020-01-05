using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace POC.Core.Base
{
    public partial class BasePage : ContentPage
    {
        public BasePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
