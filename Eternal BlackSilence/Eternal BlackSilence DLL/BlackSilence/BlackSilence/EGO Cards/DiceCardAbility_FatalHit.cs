

namespace BlackSilence
{
    public class DiceCardAbility_FatalHit : DiceCardAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "Fatal_Keyword",
                };
            }
        }
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target != null)
            {
                BattleUnitBuf_Fatal.GainReadyCharge(target, 0);
            }
            
        }

    }
}
