using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CinemaMApplication.Behaviors
{
    class UsernameValidationBehavior : Behavior<Entry>
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
            var username = e.NewTextValue;
            var usernameEntry = sender as Entry;

            if (usernameEntry.Text.Length == 0 || usernameEntry.Text.Length > 10)
            {
                usernameEntry.TextColor = Color.Red;
            }

            if (usernameEntry.Text.Length >= 4)
            {
                usernameEntry.TextColor = Color.Green;
            }

        }
    }
}
