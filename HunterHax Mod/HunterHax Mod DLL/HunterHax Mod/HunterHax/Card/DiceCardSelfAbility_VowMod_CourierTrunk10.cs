namespace HunterHax
{
    public class DiceCardSelfAbility_VowMod_CourierTrunk10 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Gain 10 Courier Trunk";
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "VowMod_CourierTrunk_Keyword",
                };
            }
        }
        public override void OnUseCard()
        {
            this.owner.bufListDetail.AddKeywordBufThisRoundByCard(MyKeywords.VowMod_CourierTrunk, 10, this.owner);
        }
    }
}
