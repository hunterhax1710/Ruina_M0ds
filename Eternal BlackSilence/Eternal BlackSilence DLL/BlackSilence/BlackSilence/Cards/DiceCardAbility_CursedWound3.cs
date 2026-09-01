

namespace BlackSilence
{
    public class DiceCardAbility_CursedWound3 : DiceCardAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "CursedWound_Keyword",
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
            BattleUnitBuf_CursedWound.GainReadyCharge(target, 3);
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
