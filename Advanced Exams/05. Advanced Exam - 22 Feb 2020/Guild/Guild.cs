namespace Guild
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Guild
    {
        private IList<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = null;
            if (this.roster.Any(p => p.Name == name))
            {
                playerToRemove = this.roster.First(p => p.Name == name);
                this.roster.Remove(playerToRemove);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player playerToPromote = null;
            if (this.roster.Any(p => p.Name == name))
            {
                playerToPromote = this.roster.First(p => p.Name == name);
                if (playerToPromote.Rank.Equals("Trial"))
                {
                    playerToPromote.Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            Player playerToDemote = null;
            if (this.roster.Any(p => p.Name == name))
            {
                playerToDemote = this.roster.First(p => p.Name == name);
                if (!(playerToDemote.Rank.Equals("Trial")))
                {
                    playerToDemote.Rank = "Trial";
                }
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> kickedPlayers = new List<Player>();
            Player playerToKick = null;
            foreach (var player in this.roster.ToList())
            {
                if (player.Class.Equals(@class))
                {
                    playerToKick = player;
                    kickedPlayers.Add(player);
                    this.roster.Remove(playerToKick);                    
                }
            }

            return kickedPlayers.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
