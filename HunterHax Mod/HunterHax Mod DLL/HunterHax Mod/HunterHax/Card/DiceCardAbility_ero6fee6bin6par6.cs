namespace HunterHax
{
    public class DiceCardAbility_ero6fee6bin6par6 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 6 Erosion, 6 Feeble, 6 Bind and 6 Paralysis this Scene and next Scene";
        // Token: 0x0600001F RID: 31 RVA: 0x000029D4 File Offset: 0x00000BD4
        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            if (target == null)
            {
                return;
            }
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Decay, 6, base.owner);
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Paralysis, 6, base.owner);
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Binding, 6, base.owner);
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Weak, 3, base.owner);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Decay, 6, base.owner);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, 6, base.owner);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Binding, 6, base.owner);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Weak, 3, base.owner);
        }

        // Token: 0x17000003 RID: 3
        // (get) Token: 0x06000021 RID: 33 RVA: 0x000020C1 File Offset: 0x000002C1
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "Decay_Keyword",
                    "Paralysis_Keyword",
                    "Binding_Keyword",
                    "Weak_Keyword"
                };
            }
        }

    }
}
