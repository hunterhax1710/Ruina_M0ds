
namespace HunterHax
{
    
    public class DiceCardAbility_drainBreak5atk : DiceCardAbilityBase
    {
        // Token: 0x06000001 RID: 1 RVA: 0x0000227C File Offset: 0x0000047C
        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            bool flag = target == null;
            if (!flag)
            {
                base.owner.breakDetail.RecoverBreak(5);
                target.TakeBreakDamage(5, DamageType.Card_Ability, base.owner, AtkResist.Normal, KeywordBuf.None);
            }
        }

        
    }
   
}
