

namespace BlackSilence
{
    public class DiceCardAbility_Cur2Uncontrollable1 : DiceCardAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "Uncontrollable_Keyword",
            "CursedWound_Keyword"
                };
            }
        }
        // Token: 0x06003397 RID: 13207 RVA: 0x0011D9F7 File Offset: 0x0011BBF7
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target == null)
            {
                return;
            }
            if (RandomUtil.valueForProb < 0.3f)                              //30% chance to inflict uncontrollable and cursed wound
            {
                BattleUnitBuf_CursedWound.GainReadyCharge(target, 2);
                BattleUnitBuf_Uncontrollable.GainReadyCharge(target, 1);
                return;
            }           
            BattleUnitBuf_CursedWound.GainReadyCharge(target, 2);
             
        }
        public override bool IsImmuneDestory
        {
            get
            {
                return true;
            }
        }

    }
}
