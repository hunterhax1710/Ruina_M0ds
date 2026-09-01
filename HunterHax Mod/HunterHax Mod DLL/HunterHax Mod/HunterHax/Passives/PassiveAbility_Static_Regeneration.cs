namespace HunterHax
{
    // Token: 0x02000017 RID: 23
    public class PassiveAbility_Static_Regeneration : PassiveAbilityBase
    {
        // Token: 0x06000041 RID: 65 RVA: 0x0000225D File Offset: 0x0000045D
        public override void OnRoundStart()
        {
            base.OnRoundStart();
            this.istakeDamaged = false;
        }

        // Token: 0x06000042 RID: 66 RVA: 0x0000226C File Offset: 0x0000046C
        public override void AfterTakeDamage(BattleUnitModel attacker, int dmg)
        {
            this.istakeDamaged = true;
        }

        // Token: 0x06000043 RID: 67 RVA: 0x00002DD8 File Offset: 0x00000FD8
        public override void OnRoundEndTheLast()
        {
            if (!this.istakeDamaged)
            {
                this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.BreakProtection, 3, base.Owner);
                this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Protection, 3, base.Owner);
                this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 3, base.Owner);
                this.owner.RecoverHP(30);
                this.owner.breakDetail.RecoverBreak(30);
            }
        }

        // Token: 0x0400000F RID: 15
        private bool istakeDamaged;
    }

}
