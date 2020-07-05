using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        private string phoneNumber;
        private string website;

        public string PhoneNumber
        {
            get => this.phoneNumber;
            set
            {
                if (value.Any(char.IsLetter) && value.Length != 7)
                {
                    throw new ArgumentException("Invalid number!");
                }
                this.phoneNumber = value;
            }
        }

        public string Website
        {
            get => this.website;
            set
            {
                if (value.Any(char.IsDigit))
                {
                    throw new ArgumentException("Invalid URL!");
                }
                this.website = value;
            }
        }

        public string CallOtherPhone()
        {
            return $"Calling... {this.phoneNumber}";
        }

        public string Browse()
        {
            return $"Browsing: {this.Website}!";
        }

    }
}