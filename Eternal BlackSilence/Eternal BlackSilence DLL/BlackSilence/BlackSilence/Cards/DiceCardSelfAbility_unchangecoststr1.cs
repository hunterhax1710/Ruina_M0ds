

namespace BlackSilence
{
    public class DiceCardSelfAbility_unchangecoststr1 : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "Strength_Keyword"
                };
            }
        }       
        public override bool IsFixedCost()
        {
            return true;
        }       
        public override void OnUseCard()
        {
            base.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Strength, 1, base.owner);
        }
    }
}
