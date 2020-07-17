namespace Logger.Models.Contracts
{
    interface IIOManager
    {
        string CurrentDirectoryPath { get; }
        string CurrentFilePath { get; }
        string GetCurrentDirectory();
        void EnsureDirectoryAndFileExist();
    }
}