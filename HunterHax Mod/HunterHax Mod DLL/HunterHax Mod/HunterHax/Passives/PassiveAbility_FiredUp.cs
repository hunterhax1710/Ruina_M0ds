namespace HunterHax
{
    // Token: 0x02000016 RID: 22
    public class PassiveAbility_FiredUp : PassiveAbilityBase
    {
        // Token: 0x0600003F RID: 63 RVA: 0x0000222F File Offset: 0x0000042F
        public override void OnRoundEnd()
        {
            base.OnRoundEnd();
            if (this.owner.history.damageAtOneRound >= 10)
            {
                this.owner.cardSlotDetail.RecoverPlayPoint(3);
            }
        }
    }

}
