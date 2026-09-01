namespace HunterHax
{
    using System;

    // Token: 0x020011A1 RID: 4513
    public class PassiveAbility_20020 : PassiveAbilityBase
    {
        // Token: 0x1700098A RID: 2442
        // (get) Token: 0x060056B2 RID: 22194 RVA: 0x001C9EB8 File Offset: 0x001C80B8
        public bool IsActivated
        {
            get
            {
                return this._activated;
            }
        }

        // Token: 0x1700098B RID: 2443
        // (get) Token: 0x060056B3 RID: 22195 RVA: 0x001C9EB8 File Offset: 0x001C80B8
        public override bool isHide
        {
            get
            {
                return this._activated;
            }
        }

        // Token: 0x060056B4 RID: 22196 RVA: 0x001C9EC0 File Offset: 0x001C80C0
        public override void OnWaveStart()
        {
            this._activated = false;
        }

        // Token: 0x060056B5 RID: 22197 RVA: 0x001C9EC9 File Offset: 0x001C80C9
        public override void OnRoundEndTheLast_ignoreDead()
        {
            base.OnRoundEndTheLast_ignoreDead();
        }

        // Token: 0x060056B6 RID: 22198 RVA: 0x001C9ED1 File Offset: 0x001C80D1
        public override bool BeforeTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (this._activated)
            {
                return false;
            }
            if (this.owner.hp <= (float)dmg)
            {
                this._activated = true;
                this.owner.bufListDetail.AddBuf(new PassiveAbility_230024.OscarBuf());
            }
            return false;
        }

        // Token: 0x04003A80 RID: 14976
        private bool _activated;

        // Token: 0x02001E65 RID: 7781
        public class OscarBuf : BattleUnitBuf
        {
            // Token: 0x060091C9 RID: 37321 RVA: 0x002A9AB6 File Offset: 0x002A7CB6
            public OscarBuf()
            {
                this.stack = 99999999;
            }

            // Token: 0x060091CA RID: 37322 RVA: 0x00103408 File Offset: 0x00101608
            public override int GetDamageReductionAll()
            {
                return this.stack;
            }

            // Token: 0x060091CB RID: 37323 RVA: 0x001036F1 File Offset: 0x001018F1
            public override void OnRoundEnd()
            {
                this.Destroy();
            }
        }
    }


}
