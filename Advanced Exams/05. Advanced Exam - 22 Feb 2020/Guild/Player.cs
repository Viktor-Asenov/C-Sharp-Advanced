﻿namespace Guild
{
    using System.Text;

    public class Player
    {
        public Player(string name, string @class)
        {
            this.Name = name;
            this.Class = @class;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public string Name { get; private set; }

        public string Class { get; private set; }

        public string Rank { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player {this.Name}: {Class}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.AppendLine($"Description: {this.Description}");

            return sb.ToString().TrimEnd();
        }
    }
}