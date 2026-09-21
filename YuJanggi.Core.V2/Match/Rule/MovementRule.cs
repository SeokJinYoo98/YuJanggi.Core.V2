using System;
using System.Collections.Generic;
using YuJanggi.Core.V2.MovementRule;

namespace YuJanggi.Core.V2.Rule
{
    using Board;
    using Domain;



    public class MovementRule
    {

        //
        public void FindCandidateWays(
            IBoardModel board,
            Pos from,
            List<Pos> buffer)
        {
            var piece = board.GetPiece(from);
            if (!_rules.TryGetValue(piece.Type, out var rule))
                throw new Exception("길찾기 타입 에러: " + piece.Type);

            rule.FindWays(board, from, buffer);
        }
        //
        readonly Dictionary<PieceType, Movement> _rules;
        public MovementRule()
        {
            var kg = new KingGuardMovement();
            _rules = new()
            {
                {PieceType.Soldier,     new SoldierMovement() },
                {PieceType.Chariot,     new ChariotMovement() },
                {PieceType.Cannon,      new CannonMovement() },
                {PieceType.Horse,       new Horsemovement() },
                {PieceType.Elephant,    new ElephantMovement() },
                {PieceType.King,        kg },
                {PieceType.Guard,       kg }
            };
        }

    }
}