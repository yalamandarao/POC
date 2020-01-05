using System;
using System.Collections.Generic;
using System.Diagnostics;
using POC.Core.Base;
using POC.Home.Cell;
using Xamarin.Forms;

namespace POC.Home
{
    public partial class PersonListPage : BasePage
    {
        public PersonListPage()
        {
            InitializeComponent();

            PersonList.ItemTapped += (sender, e) =>
            {
                PersonListCellModel eventCellViewModel = (PersonListCellModel)e.Item;
                Debug.WriteLine("item text: " + eventCellViewModel.TitleLabel);
                ((ListView)sender).SelectedItem = null;
                var pageModel = BindingContext as PersonListPageModel;
                pageModel.PersonTapped.Execute(eventCellViewModel);
            };
        }
    }
      
}
