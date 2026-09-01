

namespace BlackSilence
{
    public class BattleUnitBuf_breakDice : BattleUnitBuf
    {
        public override string keywordId => "breakDice";
        public string KeywordBufName => "breakDice";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.breakDice;
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
        public BattleUnitBuf_breakDice(BattleUnitModel model)
        {
            this._owner = model;
            this.stack = 0;
        }
        public override void OnRoundEnd()
        {
            if (this._owner != null && !this._owner.IsBreakLifeZero())                   //Minus stack if owner not staggered
            {              
                    this.Destroy();
                    return;
            }
            
        }
        public static void GainCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_breakDice battleUnitBuf_breakDice = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_breakDice) as BattleUnitBuf_breakDice;
            if (battleUnitBuf_breakDice == null)
            {
                battleUnitBuf_breakDice = new BattleUnitBuf_breakDice(model);
                battleUnitBuf_breakDice.Add(add);
                model.bufListDetail.AddBuf(battleUnitBuf_breakDice);
                return;
            }
            battleUnitBuf_breakDice.Add(add);
        }
        public static void GainReadyCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_breakDice battleUnitBuf_breakDice = model.bufListDetail.GetReadyBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_breakDice) as BattleUnitBuf_breakDice;
            if (battleUnitBuf_breakDice == null)
            {
                battleUnitBuf_breakDice = new BattleUnitBuf_breakDice(model);
                battleUnitBuf_breakDice.Add(add);
                model.bufListDetail.AddReadyBuf(battleUnitBuf_breakDice);
                return;
            }
            battleUnitBuf_breakDice.Add(add);
        }
        // Token: 0x06001063 RID: 4195 RVA: 0x000497C8 File Offset: 0x000479C8
        public static int GetCharge(BattleUnitModel model)
        {
            BattleUnitBuf_breakDice battleUnitBuf_breakDice = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_breakDice) as BattleUnitBuf_breakDice;
            int result;
            if (battleUnitBuf_breakDice == null)
            {
                result = 0;
            }
            else
            {
                result = battleUnitBuf_breakDice.stack;
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

        public override int paramInBufDesc
        {
            get
            {
                return this.stack;
            }
        }

        public override int SpeedDiceBreakedAdder()
        {
            return this.stack;
        }
    }
}
