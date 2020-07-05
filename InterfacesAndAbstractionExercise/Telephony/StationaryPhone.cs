using System;
using System.Linq;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        private string phoneNumber;

        public string PhoneNumber
        {
            get => this.phoneNumber;
            set
            {
                if (value.Any(char.IsLetter) && value.Length != 10)
                {
                    throw new ArgumentException("Invalid number!");
                }
                this.phoneNumber = value;
            }
        }

        public string CallOtherPhone()
        {
            return $"Dialing... {this.phoneNumber}";
        }
    }
}