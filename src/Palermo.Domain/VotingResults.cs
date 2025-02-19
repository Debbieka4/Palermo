using Palermo.Domain.Core.Logic.Players;

namespace Palermo.Domain
{
    public class VotingResults
    {
        public Player EliminatedPlayer { get; }
        public IReadOnlyDictionary<Player, int> FinalVotes { get; }

        public VotingResults(Player eliminatedPlayer, Dictionary<Player, int> finalVotes)
        {
            EliminatedPlayer = eliminatedPlayer;
            FinalVotes = finalVotes;
        }
    }
}
