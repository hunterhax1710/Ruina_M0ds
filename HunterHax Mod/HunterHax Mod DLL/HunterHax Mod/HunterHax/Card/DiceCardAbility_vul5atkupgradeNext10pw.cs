namespace HunterHax
{
    public class DiceCardAbility_vul5atkupgradeNext10pw : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 5 Fragile this Scene and Boost next die's max value by +10";
        // Token: 0x0600002F RID: 47 RVA: 0x00002AC0 File Offset: 0x00000CC0
        public override void OnSucceedAttack()
        {
            base.card.AddDiceMaxValue(DiceMatch.NextDice, 10);
            BattleUnitModel target = base.card.target;
            if (target == null)
            {
                return;
            }
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vulnerable, 5, base.owner);
        }

        // Token: 0x17000005 RID: 5
        // (get) Token: 0x06000031 RID: 49 RVA: 0x000021C8 File Offset: 0x000003C8
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "Vulnerable_Keyword"
                };
            }
        }
    }

}
