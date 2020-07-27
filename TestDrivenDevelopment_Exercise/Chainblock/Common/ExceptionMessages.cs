namespace Chainblock.Common
{
    public static class ExceptionMessages
    {
        public static string InvalidIDMessage = "IDs cannot be zero or negative";
        public static string InvalidSenderUserNameMessage = "Sender name cannot be empty or whitespace!";
        public static string InvalidReceiverUserNameMessage = "Receiver name cannot be empty or whitespace!";
        public static string InvalidTransactionAmountMessage = "Amount cannot be zero or negative";
        public static string AddingExistingTransactionMessage = "Transaction already exists in our records";
    }
}
