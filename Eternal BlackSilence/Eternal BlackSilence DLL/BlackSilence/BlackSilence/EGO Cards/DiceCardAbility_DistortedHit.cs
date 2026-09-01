

namespace BlackSilence
{
    public class DiceCardAbility_DistortedHit : DiceCardAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "Distorted_Keyword",
                };
            }
        }
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target != null)
            {
                BattleUnitBuf_Distorted.GainCharge(target, 1);
            }
        }
    }

}
