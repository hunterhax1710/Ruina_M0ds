namespace HunterHax
{
    // Token: 0x02000010 RID: 16
    public class DiceCardAbility_upgradeNext10pw : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Boost next die's max value by +10";
        // Token: 0x0600002D RID: 45 RVA: 0x000021B3 File Offset: 0x000003B3
        public override void OnSucceedAttack()
        {
            base.card.AddDiceMaxValue(DiceMatch.NextDice, 10);
        }
    }

}
