namespace HunterHax
{
    // Token: 0x02000015 RID: 21
    public class PassiveAbility_BlessingLight : PassiveAbilityBase
    {
        // Token: 0x0600003D RID: 61 RVA: 0x00002202 File Offset: 0x00000402
        public override void OnRoundStart()
        {
            if (RandomUtil.valueForProb < 0.5f)
            {
                this.owner.ShowPassiveTypo(this);
                this.owner.cardSlotDetail.RecoverPlayPoint(10);
            }
        }
    }

}
