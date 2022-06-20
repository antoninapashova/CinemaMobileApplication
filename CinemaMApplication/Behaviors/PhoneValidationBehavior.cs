using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace CinemaMApplication.Behaviors
{
    class PhoneValidationBehavior : Behavior<Entry>
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
            var phone = e.NewTextValue;
            var phoneEntry = sender as Entry;
            string regexpattern = "^\\+?[1-9][0-9]{7,14}$";

            if (phone.Length == 0 || !Regex.IsMatch(phone, regexpattern))
            {
                phoneEntry.TextColor = Color.Red;
            }
            bool containsLetter = Regex.IsMatch(phone, "[A-Z]");

            if (phone.Length >= 7 && !containsLetter)
            {
                phoneEntry.TextColor = Color.Green;
            }
        }
    }
}
