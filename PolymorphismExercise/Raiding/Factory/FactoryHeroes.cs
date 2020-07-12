using System;
using Raiding.Models;
using Vehicles.Exceptions;

namespace Raiding.Factory
{
    public class FactoryHeroes
    {
        /// <summary>
        /// CreateHero
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public static BaseHero CreateHero(string type, string name)
        {
            BaseHero hero = null;
            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            if (hero == null)
            {
                string msg = ExceptionMessages.InvalidTypeExceptionMessage;
                throw new ArgumentException(msg);
            }

            return hero;
        }
    }
}
