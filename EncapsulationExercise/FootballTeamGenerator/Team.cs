using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.players = new List<Player>();
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameException);
                }
                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }
                return (int)Math.Round(this.players.Sum(x => x.OverallSkill) / this.players.Count);
            }
        }
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == name);
            if (playerToRemove == null)
            {
                string excMsg = String.Format(GlobalConstants.RemovingMissingPlayerExceptionMessage, name, this.Name);
                throw new ArgumentException(excMsg);
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}