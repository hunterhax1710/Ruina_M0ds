

namespace BlackSilence
{
    public class DiceCardAbility_upgradeMax10pw : DiceCardAbilityBase
    {
        // Token: 0x060034B6 RID: 13494 RVA: 0x00132382 File Offset: 0x00130582
        public override void OnWinParrying()
        {
            base.card.AddDiceMaxValue(DiceMatch.NextDice, 10);
        }
    }
}
