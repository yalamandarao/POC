using System;
using System.Collections.Generic;
using POC.Core.Base;
using Xamarin.Forms;

namespace POC.Home.Cell
{
    public partial class PersonListCell : ViewCell
    {
        public PersonListCell()
        {
            InitializeComponent();
        }

        #region Bindable Properties

        public PersonListCellModel CellViewModel
        {
            get { return (PersonListCellModel)GetValue(CellViewModelProperty); }
            set { SetValue(CellViewModelProperty, value); }
        }

        public static readonly BindableProperty CellViewModelProperty
            = BindableProperty.Create(
                "CellViewModel",
                typeof(PersonListCellModel),
                typeof(PersonListCell),
                default(PersonListCellModel),
                BindingMode.OneWay,
                propertyChanged: CellViewModelPropertyChanged);

        static void CellViewModelPropertyChanged(BindableObject bindable,
                                                 object oldValue, object newValue)
        {
            var control = (PersonListCell)bindable;
            var vm = (PersonListCellModel)newValue;

            if (vm == null)
            {
                return;
            }

            control.TitleLabel.Text = vm.TitleLabel;

        }
        #endregion
    }
}
