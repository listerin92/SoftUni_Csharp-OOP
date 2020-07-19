using System;
using System.Globalization;

using Logger.Common;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }
        public ILayout Layout { get; }
        public Level Level { get; }
        public long MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;
            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            string formattedMessage = string.Format(format
                , dateTime.ToString(GlobalConstants.DATE_FORMAT, CultureInfo.InvariantCulture)
                , level.ToString().ToUpper()
                , message);

            Console.WriteLine(formattedMessage);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, " +
                $"Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.Level.ToString().ToUpper()}, " +
                $"Messages appended: {this.MessagesAppended}";
        }
    }
}