using System;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private const int STAT_MIN_VALUE = 0;
        private const int STAT_MAX_VALUE = 100;

        public Stats(int endurance
                    , int sprint
                    , int dribble
                    , int passing
                    , int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance
        {
            get => endurance;
            private set
            {
                this.ValidateStat(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                this.ValidateStat(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                this.ValidateStat(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                this.ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                this.ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }
        public double AverageStat
            => (this.Endurance
                + this.Sprint
                + this.Dribble
                + this.Passing
                + this.Shooting) / 5.0;
        private void ValidateStat(int value, string statName)
        {
            if (value < STAT_MIN_VALUE || value > STAT_MAX_VALUE)
            {
                throw new ArgumentException(String.Format(GlobalConstants.InvalidStatExceptionMEssage, statName,
                    STAT_MIN_VALUE, STAT_MAX_VALUE));
            }
        }
    }
}