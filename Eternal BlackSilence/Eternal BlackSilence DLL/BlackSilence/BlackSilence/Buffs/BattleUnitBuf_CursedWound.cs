

namespace BlackSilence
{
    public class BattleUnitBuf_CursedWound : BattleUnitBuf
    {
        public override string keywordId => "CursedWound";
        public string KeywordBufName => "CursedWound";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.CursedWound;
        public override KeywordBuf bufType
        {
            get
            {
                return this.KeywordBuf;

            }
        }
        public override BufPositiveType positiveType
        {
            get
            {
                return BufPositiveType.Negative;
            }
        }
        public override int paramInBufDesc
        {
            get
            {
                return this.stack;
            }
        }
        public BattleUnitBuf_CursedWound(BattleUnitModel model)
        {
            this._owner = model;
            this.stack = 0;
        }
        public override void OnRoundEnd()
        {
            this.stack--;
            if (this.stack == 0)
            {
                this.Destroy();
                return;
            }
        }
        public static void GainCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_CursedWound battleUnitBuf_CursedWound = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_CursedWound) as BattleUnitBuf_CursedWound;
            if (battleUnitBuf_CursedWound == null)
            {
                battleUnitBuf_CursedWound = new BattleUnitBuf_CursedWound(model);
                battleUnitBuf_CursedWound.Add(add);
                model.bufListDetail.AddBuf(battleUnitBuf_CursedWound);
                return;
            }
            battleUnitBuf_CursedWound.Add(add);
        }
        public static void GainReadyCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_CursedWound battleUnitBuf_CursedWound = model.bufListDetail.GetReadyBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_CursedWound) as BattleUnitBuf_CursedWound;
            if (battleUnitBuf_CursedWound == null)
            {
                battleUnitBuf_CursedWound = new BattleUnitBuf_CursedWound(model);
                battleUnitBuf_CursedWound.Add(add);
                model.bufListDetail.AddReadyBuf(battleUnitBuf_CursedWound);               
                return;
            }
            battleUnitBuf_CursedWound.Add(add);
        }
        // Token: 0x06001063 RID: 4195 RVA: 0x000497C8 File Offset: 0x000479C8
        public static int GetCharge(BattleUnitModel model)
        {
            BattleUnitBuf_CursedWound battleUnitBuf_CursedWound = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_CursedWound) as BattleUnitBuf_CursedWound;
            int result;
            if (battleUnitBuf_CursedWound == null)
            {
                result = 0;
            }
            else
            {
                result = battleUnitBuf_CursedWound.stack;
            }
            return result;
        }

        // Token: 0x06001064 RID: 4196 RVA: 0x00007A6A File Offset: 0x00005C6A
        public void Add(int add)
        {
            this.stack += add;
            if (this.stack >= 100)
            {
                this.stack = 100;
            }
        }
        public override bool CanRecoverHp(int amount)
        {
            return false;
        }

        // Token: 0x06004F86 RID: 20358 RVA: 0x00005931 File Offset: 0x00003B31
        public override bool CanRecoverBreak(int amount)
        {
            return false;
        }

        public override int GetDamageIncreaseRate()
        {
            return 50;
        }

        // Token: 0x0600006D RID: 109 RVA: 0x00003BBE File Offset: 0x00001DBE
        public override int GetBreakDamageIncreaseRate()
        {
            return 50;
        }
    }
}
