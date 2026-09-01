namespace HunterHax
{
    public class DiceCardSelfAbility_TestPhase3 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Gain 3 Phase 3";
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "HunterHaxPhase3_Keyword",
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.bufListDetail.AddKeywordBufThisRoundByCard(MyKeywords.HunterHaxPhase3, 3, this.owner);
        }
    }

}
