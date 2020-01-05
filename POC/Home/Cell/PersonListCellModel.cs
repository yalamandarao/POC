using System;
using System.Collections.ObjectModel;
using POC.Core.Base;
using POC.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POC.Home.Cell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public class PersonListCellModel : ObservableCollection<PersonListCellModel>
    {
        public string TitleLabel { get; set; }
        public Person PersonObj { get; set; }

        public PersonListCellModel()
        {
           
        }

        public PersonListCellModel(Person obj)
        {
            TitleLabel = obj.Name;
            PersonObj = obj;
        }

        public Command OnEditCommand
        {
            get => new Command(() =>
            {
                MessagingCenter.Send<PersonListCellModel, Person>(this, "OnEdit", PersonObj);
            });
        }


        public Command OnDeleteCommand
        {
            get => new Command(() =>
            {
                MessagingCenter.Send<PersonListCellModel, Person>(this, "OnDelete", PersonObj);
            });
        }
    }
}

