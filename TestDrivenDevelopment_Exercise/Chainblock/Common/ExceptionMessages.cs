namespace Chainblock.Common
{
    public static class ExceptionMessages
    {
        public static string InvalidIDMessage = "IDs cannot be zero or negative";
        public static string InvalidSenderUserNameMessage = "Sender name cannot be empty or whitespace!";
        public static string InvalidReceiverUserNameMessage = "Receiver name cannot be empty or whitespace!";
        public static string InvalidTransactionAmountMessage = "Amount cannot be zero or negative";
        public static string AddingExistingTransactionMessage = "Transaction already exists in our records";
        public static string RemovingNonExistingTransactionMessage = "You cant remove transaction with non existing ID";
        public static string NotExistingTransactionMessage = "Transaction with given ID not found!";
        public static string EmptyStatusTransactionCollectionMessage = "There are no transactions matching provided transaction status";
        public static string NoTransactionInCollectionMessage = "There are no transactions in the chainblock";
    }
}