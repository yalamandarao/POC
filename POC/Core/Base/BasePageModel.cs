using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace POC.Core.Base
{
    public class BasePageModel : FreshMvvm.FreshBasePageModel, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        public Command BackCommand
        {
            get => new Command(async (obj) =>
            {
                await CoreMethods.PopPageModel(false, true);
            });
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}

