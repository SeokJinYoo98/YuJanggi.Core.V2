using YuJanggi.Core.V2.Board;
using YuJanggi.Core.V2.Domain;
using YuJanggi.Core.V2.Rule;

namespace YuJanggi.Core.V2.Match
{
    public readonly struct MatchOptions
    {
        public float     TurnTime { get; }
        public Formation ChoFormation { get; }
        public Formation HanFormation { get; }

        public MatchOptions(
            float turnTime         = 30f,
            Formation choFormation = Formation.EHHE,
            Formation hanFormation = Formation.EHHE)
        {
            if (turnTime < 10f)
                TurnTime = 30f;
            else
                TurnTime = turnTime;
            ChoFormation = choFormation;
            HanFormation = hanFormation;
        }
    }
    public static class MatchFactory
    {
        public static MatchModel LocalCreate(MatchOptions options)
        {
            var match = new MatchModel(
                new Turn(options.TurnTime),
                new Record(),
                new Score(),
                new BoardModel(),
                new JanggiRule());

            match.InitGame(
                options.ChoFormation,
                options.HanFormation);

            return match;
        }
    }
}
