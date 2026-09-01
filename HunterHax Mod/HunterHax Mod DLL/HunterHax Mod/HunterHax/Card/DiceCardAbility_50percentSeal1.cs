namespace HunterHax
{
    // Token: 0x0200000E RID: 14
    public class DiceCardAbility_50percentSeal1 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] 50% chance to inflict 1 Strong Seal";

        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "Seal1_Keyword",
                };
            }
        }

        // Token: 0x06000027 RID: 39 RVA: 0x00002163 File Offset: 0x00000363
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            bool flag = RandomUtil.valueForProb < 0.50f;
            if (flag)
            {
             target.bufListDetail.AddKeywordBufByCard(MyKeywords.Seal1, 1, base.owner);
            }
        }
    }

}
