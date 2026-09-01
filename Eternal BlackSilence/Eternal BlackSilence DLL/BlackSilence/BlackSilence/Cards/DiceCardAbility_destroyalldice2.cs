

namespace BlackSilence
{
    public class DiceCardAbility_destroyalldice2 : DiceCardAbilityBase
    {
        // Token: 0x06003397 RID: 13207 RVA: 0x0011D9F7 File Offset: 0x0011BBF7
        public override void OnWinParrying()
        {
            BattlePlayingCardDataInUnitModel card = base.card;
            if (card == null)
            {
                return;
            }
            BattleUnitModel target = card.target;
            if (target == null)
            {
                return;
            }
            BattlePlayingCardDataInUnitModel currentDiceAction = target.currentDiceAction;
            if (currentDiceAction == null)
            {
                return;
            }
            currentDiceAction.DestroyDice(DiceMatch.AllDice, DiceUITiming.Start);
        }
        public override void OnLoseParrying()
        {
            base.card.AddDiceMaxValue(DiceMatch.NextDice, 5);
        }
    }
}
