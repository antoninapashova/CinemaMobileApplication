using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace CinemaMApplication.Behavior
{
    class EmailValidationBehavior: Behavior<Entry>
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
            var email = e.NewTextValue;

            var emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"; ;
            var emailEntry = sender as Entry;

            if (!Regex.IsMatch(email, emailPattern) || emailEntry.Text.Length <= 8)
            {
                emailEntry.TextColor = Color.Red;
            }

            if (emailEntry.Text.Length > 8 && Regex.IsMatch(email, emailPattern))
            {
                emailEntry.TextColor = Color.Green;
            }

        }
    }
}
