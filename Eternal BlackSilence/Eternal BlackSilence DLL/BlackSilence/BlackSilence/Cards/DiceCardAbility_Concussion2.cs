

using LOR_DiceSystem;

namespace BlackSilence
{
    public class DiceCardAbility_Concussion2 : DiceCardAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "Councussion_Keyword",
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
            BattleUnitBuf_Concussion.GainReadyCharge(target, 2);
                     
        }
        
    }
}
