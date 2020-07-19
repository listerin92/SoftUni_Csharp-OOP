using System;
using System.Linq;
using System.Reflection;
using Logger.Models.Contracts;
using Logger.Models.Layouts;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        /// <summary>
        /// Currently with Instantiate with Reflection
        /// </summary>
        /// <param name="layoutType"></param>
        /// <returns></returns>
        public ILayout ProduceLayout(string layoutType)
        {
            //ILayout layout;
            //if (layoutType == "SimpleLayout")
            //{
            //    layout = new SimpleLayout();
            //}
            //else if (layoutType == "XmlLayout")
            //{
            //    layout = new XmlLayout();
            //}
            //else if (layoutType == "JsonLayout")
            //{
            //    layout = new JsonLayout();
            //}
            //else
            //{
            //    throw new ArgumentException("Invalid layout layoutType!");
            //}

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(x => x.Name == layoutType);
            object[] args = new object[] { };
            ILayout layout = (ILayout)Activator.CreateInstance(type, args);
            return layout;
        }
    }
}