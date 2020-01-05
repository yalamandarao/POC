using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using POC.Core.Base;
using POC.DataBase;
using POC.Detail;
using POC.Home.Cell;
using POC.Models;
using Xamarin.Forms;

namespace POC.Home
{
    public class PersonListPageModel : BasePageModel
    {
        public ObservableCollection<PersonListCellModel> PersonObservableList { get; set; }

        public IList<Models.Person> PersonListItem { get; set; }

        public IPersonListDataStore _personListDataStore;

        public PersonListPageModel(IPersonListDataStore personListDataStore)
        {
            _personListDataStore = personListDataStore;

            MessagingCenter.Subscribe<PersonListCellModel, Person>(this, "OnEdit", (sender1, arg) =>
            {
                Person obj = arg as Person;
                Person PersonObjNew = new Person();
                PersonObjNew.Name = obj.Name;
                PersonObjNew.ContactNumber = obj.ContactNumber;
                PersonObjNew.Address = obj.Address;
                PersonObjNew.IsEditEnabel = true;

                CoreMethods.PushPageModel<PersonDetailPageModel>(PersonObjNew);

            });
            MessagingCenter.Subscribe<PersonListCellModel, Person>(this, "OnDelete", async(sender1, arg) =>
            {
               bool value = await _personListDataStore.DeletePerson(arg.ContactNumber);

                if(value)
                {
                  await GetPersonList();
                }
            });
        }


        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await GetPersonList();
        }


       async Task GetPersonList()
        {

            PersonListItem = new List<Models.Person>();
            PersonObservableList = new ObservableCollection<PersonListCellModel>();
            try
            {
                PersonListItem = await _personListDataStore.Get();

                if(PersonListItem != null)
                {
                    foreach (Person obj in PersonListItem)
                    {
                        PersonObservableList.Add(new PersonListCellModel(obj));
                    }
                }
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public Command PersonTapped
        {
            get => new Command(async (obj) =>
            {
                    PersonListCellModel value = obj as PersonListCellModel;
                    await CoreMethods.PushPageModel<PersonDetailPageModel>(value.PersonObj);
            });
        }


        public Command AddCommand
        {
            get => new Command(() =>
            {
               CoreMethods.PushPageModel<PersonDetailPageModel>();
            });
        }
    }
}

