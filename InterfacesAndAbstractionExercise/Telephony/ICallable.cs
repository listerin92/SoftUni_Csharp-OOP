using System.Collections.Generic;

namespace Telephony
{
    public interface ICallable
    {
        public string PhoneNumber { get; }
        string CallOtherPhone();
    }
}