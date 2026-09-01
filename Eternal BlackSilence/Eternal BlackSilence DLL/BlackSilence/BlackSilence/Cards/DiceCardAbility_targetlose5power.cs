

namespace BlackSilence
{
    public class DiceCardAbility_targetlose5power : DiceCardAbilityBase
    {
        public override void OnWinParrying()
        {
            BattleUnitModel target = base.card.target;
            if (target == null)
            {
                return;
            }
            BattlePlayingCardDataInUnitModel currentDiceAction = target.currentDiceAction;
            if (currentDiceAction == null)
            {
                return;
            }
            currentDiceAction.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = -5
            });
        }
    }

}