

using System.Collections.Generic;

namespace BlackSilence
{
    public class DiceCardAbility_upgradeMaxLast150pw : DiceCardAbilityBase
    {
        public override bool IsImmuneDestory
        {
            get
            {
                return true;
            }
        }
        public override void OnSucceedAttack()
        {
            BattlePlayingCardDataInUnitModel currentDiceAction = base.owner.currentDiceAction;
            if (currentDiceAction == null)
            {
                return;
            }
            currentDiceAction.ApplyDiceStatBonus(DiceMatch.LastDice, new DiceStatBonus
            {
                min = 150
            }); ;
            currentDiceAction.AddDiceMaxValue(DiceMatch.LastDice, 150);

        }
    }
}
