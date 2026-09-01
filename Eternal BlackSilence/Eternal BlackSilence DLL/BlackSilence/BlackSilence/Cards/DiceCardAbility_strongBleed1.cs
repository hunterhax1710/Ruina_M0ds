

namespace BlackSilence
{
    public class DiceCardAbility_strongBleed1 : DiceCardAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "strongBleed_Keyword"
                };
            }
        }

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            BattleUnitBuf_strongBleed.GainReadyCharge(target, 1);
            if (target == null)
            {
                return;
            }           
        }
    }
}
