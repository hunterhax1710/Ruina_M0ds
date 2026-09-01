using LOR_DiceSystem;
using LOR_Localize;
using System.Collections.Generic;

namespace HunterHax
{
    public class PassiveAbility_RangeReflection : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((this.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
            foreach (BattleUnitModel battleUnitModel in aliveList)
            {
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(MyKeywords.InvisReflectEnemy, 1, null);       //Inflict InvisReflect Enemy
            }
            this.owner.bufListDetail.AddKeywordBufThisRoundByCard(MyKeywords.InvisReflect, 1, this.owner);   //Inflict Reflect Self

        }

        public override int GetDamageReduction(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            if (behavior.card.card.GetSpec().Ranged == CardRange.Far)
            {
                return 999999;
            }
            if (behavior.card.card.GetSpec().Ranged == CardRange.FarArea)
            {
                return 999999;
            }
            if (behavior.card.card.GetSpec().Ranged == CardRange.FarAreaEach)
            {
                return 999999;
            }
            return 0;
        }
        public override int GetBreakDamageReduction(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            if (behavior.card.card.GetSpec().Ranged == CardRange.Far)
            {
                return 999999;
            }
            if (behavior.card.card.GetSpec().Ranged == CardRange.FarArea)
            {
                return 999999;
            }
            if (behavior.card.card.GetSpec().Ranged == CardRange.FarAreaEach)
            {
                return 999999;
            }
            return 0;
        }


    }
}
