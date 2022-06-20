using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CinemaMApplication.Behavior
{
    class FirtstNameValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BinableOnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BinableOnTextChanged;
        }
        private void BinableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var firstName = e.NewTextValue;
            var firstNameEntry = sender as Entry;

            if (firstName.Length == 0 || firstNameEntry.Text.Length > 10)
            {
                firstNameEntry.TextColor = Color.Red;
            }

            if (firstName.Length > 5)
            {
                firstNameEntry.TextColor = Color.Green;
            }
        }
    }
}
