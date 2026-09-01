namespace HunterHax
{
    public class DiceCardAbility_FatalResistMass : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 1 Omni-Vulnerable next Scene";
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "FatalResist_Keyword",
                };
            }
        }
        public override void OnSucceedAreaAttack(BattleUnitModel target)
        { 
           
            if (target != null)
            {             
              target.bufListDetail.AddKeywordBufByCard(MyKeywords.FatalResist, 1, base.owner);              
            }
        }
    }

}
