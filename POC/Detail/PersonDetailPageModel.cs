using System;
using System.Collections;
using System.Collections.Generic;
using POC.Core.Base;
using POC.DataBase;
using POC.Models;
using Xamarin.Forms;

namespace POC.Detail
{
    public class PersonDetailPageModel : BasePageModel
    {
        public bool IsEditable { get; set; }

        public Person Personobj { get; set; }

        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public IPersonListDataStore _personListDataStore;

        public PersonDetailPageModel(IPersonListDataStore personListDataStore)
        {
            _personListDataStore = personListDataStore;
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            Personobj = initData as Person;
            if(Personobj != null)
            {
                IsEditable = Personobj.IsEditEnabel;

                Name = Personobj.Name;
                ContactNumber = Personobj.ContactNumber;
                Address = Personobj.Address;
            }
            else
            {
                IsEditable = true;
            }
           
        }

        public Command SaveCommand
        {
            get => new Command(async () =>
            {
             
                Personobj = new Person();
                Personobj.Name = Name;
                Personobj.ContactNumber = ContactNumber;
                Personobj.Address = Address;
                Personobj.IsEditEnabel = false;

                bool value = await _personListDataStore.InsertOrReplace(Personobj);

                if(value)
                {
                  await CoreMethods.PopToRoot(true);
                }
                
            });
        }


    }
}

