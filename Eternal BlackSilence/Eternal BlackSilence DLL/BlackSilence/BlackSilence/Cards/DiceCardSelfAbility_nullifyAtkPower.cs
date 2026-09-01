

namespace BlackSilence
{
    public class DiceCardSelfAbility_nullifyAtkPower : DiceCardSelfAbilityBase
    {
        // Token: 0x0600389D RID: 14493 RVA: 0x00120B74 File Offset: 0x0011ED74
        public override void OnUseCard()
        {
            this.card.ignorePower = true;
        }

        // Token: 0x0600389E RID: 14494 RVA: 0x001397D8 File Offset: 0x001379D8
        public override void OnStartParrying()
        {
            BattleUnitModel target = this.card.target;
            if (target == null || target.currentDiceAction == null)
            {
                return;
            }
            target.currentDiceAction.ignorePower = true;
        }
    }
}
