using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace CinemaMApplication.Behavior
{
    class PasswordValidationBehavior : Behavior<Entry>
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
            var password = e.NewTextValue;
            var passwordEntry = sender as Entry;
            /*
             * Has minimum 8 characters in length. Adjust it by modifying {8,}
At least one uppercase English letter. You can remove this condition by removing (?=.*?[A-Z])
At least one lowercase English letter.  You can remove this condition by removing (?=.*?[a-z])
At least one digit. You can remove this condition by removing (?=.*?[0-9])

             */

            string regexpattern = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{5,}$";

            if (password.Length == 0 || !Regex.IsMatch(password, regexpattern))
            {
                passwordEntry.TextColor = Color.Red;
            }
            if (password.Length > 5)
            {
                passwordEntry.TextColor = Color.Green;
            }
        }
    
    }
}
