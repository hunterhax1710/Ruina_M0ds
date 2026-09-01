

namespace BlackSilence
{
    public class DiceCardAbility_powerDownAll3 : DiceCardAbilityBase
    {
        // Token: 0x060034B4 RID: 13492 RVA: 0x00132359 File Offset: 0x00130559
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
                power = -3
            });
        }
    }

}
