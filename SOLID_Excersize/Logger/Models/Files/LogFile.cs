using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Logger.Common;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.IOManagement;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private readonly IIOManager IOManager;

        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
            this.IOManager.EnsureDirectoryAndFileExist();
        }
        public void Write()
        {

        }

        public ILayout Layout { get; }
        public string Path => this.IOManager.CurrentFilePath;
        public long Size => this.GetFileSize();
        /// <summary>
        /// Returns formatted message in provided layout with provied error's data
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;
            string formattedMessage = string.Format(format
                , dateTime.ToString(GlobalConstants.DATE_FORMAT
                , CultureInfo.InvariantCulture)
                , level.ToString().ToUpper()
                , message) +  Environment.NewLine;
            return formattedMessage;
        }

        private long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);
            long size = (long)text
                .Where(char.IsLetter)
                .Sum(ch => ch);
            return size;
        }
    }
}