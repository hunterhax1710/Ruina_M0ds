using Battle.CreatureEffect;
using LOR_DiceSystem;

namespace BlackSilence
{
    public class BattleUnitBuf_Fatal : BattleUnitBuf
    {
        public override string keywordId => "Fatal";
        public string KeywordBufName => "Fatal";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.Fatal;
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
                return BufPositiveType.None;
            }
        }
        public BattleUnitBuf_Fatal(BattleUnitModel model)
        {
            this._owner = model;
            this.stack = 0;
        }
        public override void Destroy()
        {
            base.Destroy();
            if (this.aura != null)
            {
                UnityEngine.Object.Destroy(this.aura);
                this.aura = null;
            }
        }
        public override void OnRoundEnd()
        {
            foreach (BattleUnitBuf battleUnitBuf in this._owner.bufListDetail.GetActivatedBufList())
            {
                if (battleUnitBuf.positiveType == BufPositiveType.Positive)
                {
                    battleUnitBuf.Destroy();
                }
            }
            foreach (BattleUnitBuf battleUnitBuf2 in this._owner.bufListDetail.GetReadyBufList())
            {
                if (battleUnitBuf2.positiveType == BufPositiveType.Positive)
                {
                    battleUnitBuf2.Destroy();
                }
            }
            this.stack--;
            if (this.stack <= 0)
            {
                if (this.aura != null)
                {
                    this.aura.ManualDestroy();
                }
                this.Destroy();
                return;                            
            }
        }
        public static void GainCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_Fatal battleUnitBuf_Fatal = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Fatal) as BattleUnitBuf_Fatal;
            if (battleUnitBuf_Fatal == null)
            {
                battleUnitBuf_Fatal = new BattleUnitBuf_Fatal(model);
                battleUnitBuf_Fatal.Add(add);
                model.bufListDetail.AddBuf(battleUnitBuf_Fatal);
                return;
            }
            battleUnitBuf_Fatal.Add(add);
        }
        public static void GainReadyCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_Fatal battleUnitBuf_Fatal = model.bufListDetail.GetReadyBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Fatal) as BattleUnitBuf_Fatal;
            if (battleUnitBuf_Fatal == null)
            {
                battleUnitBuf_Fatal = new BattleUnitBuf_Fatal(model);
                battleUnitBuf_Fatal.Add(add);
                model.bufListDetail.AddReadyBuf(battleUnitBuf_Fatal);
                return;
            }
            battleUnitBuf_Fatal.Add(add);
        }
        // Token: 0x06001063 RID: 4195 RVA: 0x000497C8 File Offset: 0x000479C8
        public static int GetCharge(BattleUnitModel model)
        {
            BattleUnitBuf_Fatal battleUnitBuf_Fatal = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Fatal) as BattleUnitBuf_Fatal;
            int result;
            if (battleUnitBuf_Fatal == null)
            {
                result = 0;
            }
            else
            {
                result = battleUnitBuf_Fatal.stack;
            }
            return result;
        }

        // Token: 0x06001064 RID: 4196 RVA: 0x00007A6A File Offset: 0x00005C6A
        public void Add(int add)
        {
            this.stack += add;
            if (this.aura == null)
            {
                this.aura = SingletonBehavior<DiceEffectManager>.Instance.CreateCreatureEffect("3/Latitia_Boom", 1f, this._owner.view, this._owner.view, -1f);
            }
            if (this.stack >= 1)
            {
                this.stack = 1;
            }
        }
        public override AtkResist GetResistBP(AtkResist origin, BehaviourDetail detail)
        {
            return AtkResist.Weak;
        }

        
        public override AtkResist GetResistHP(AtkResist origin, BehaviourDetail detail)
        {
            return AtkResist.Weak;
        }
        public override bool IsImmune(BattleUnitBuf buf)
        {
            return buf.positiveType == BufPositiveType.Positive;
        }
        public override void OnRoundStart()                   //Destroy all positive buffs
        {
            foreach (BattleUnitBuf battleUnitBuf in this._owner.bufListDetail.GetActivatedBufList())
            {
                if (battleUnitBuf.positiveType == BufPositiveType.Positive)
                {
                    battleUnitBuf.Destroy();
                }
            }
            foreach (BattleUnitBuf battleUnitBuf2 in this._owner.bufListDetail.GetReadyBufList())
            {
                if (battleUnitBuf2.positiveType == BufPositiveType.Positive)
                {
                    battleUnitBuf2.Destroy();
                }
            }
        }


        private CreatureEffect aura;
    }
}
