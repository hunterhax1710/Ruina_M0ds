namespace HunterHax
{
    public class PassiveAbility_VowMod_TrunkPassive : PassiveAbilityBase
    {
        public static string Name = "Speedy Delivery";

        public static string Desc = "At the End of Scene. At 10+ Courier Trunk, gain 1 Haste. At 20+ Courier Trunk, gain 1 Strength and 2 Haste. At 30 Courier Trunk, gain 2 Strength and 2 Haste";

        public override void OnRoundEnd()
        {
            if (owner.bufListDetail.GetKewordBufStack(MyKeywords.VowMod_CourierTrunk) >= 30)
            {
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 2, this.owner);
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 2, this.owner);
                return;
            }
            if (owner.bufListDetail.GetKewordBufStack(MyKeywords.VowMod_CourierTrunk) >= 20)
            {
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 1, this.owner);
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 2, this.owner);
                return;
            }
            if (owner.bufListDetail.GetKewordBufStack(MyKeywords.VowMod_CourierTrunk) >= 10)
            {
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 1, this.owner);
                return;
            }
            
            
        }
       
    }

}
