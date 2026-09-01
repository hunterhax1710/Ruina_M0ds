

namespace BlackSilence
{
    public class BattleUnitBuf_Concussion : BattleUnitBuf
    {
        public override string keywordId => "Concussion";
        public string KeywordBufName => "Concussion";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.Concussion;
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
        public BattleUnitBuf_Concussion(BattleUnitModel model)
        {
            this._owner = model;
            this.stack = 0;
        }
        public override void OnRoundEnd()
        {
            if (this._owner != null && !this._owner.IsBreakLifeZero())                   //Minus stack if owner not staggered
            {
                this.stack--;
                if (this.stack == 0)
                {
                    this.Destroy();
                    return;
                }
            }
        }
        public override int paramInBufDesc
        {
            get
            {
                return this.stack;
            }
        }
        public static void GainCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_Concussion battleUnitBuf_Concussion = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Concussion) as BattleUnitBuf_Concussion;
            if (battleUnitBuf_Concussion == null)
            {
                battleUnitBuf_Concussion = new BattleUnitBuf_Concussion(model);
                battleUnitBuf_Concussion.Add(add);
                model.bufListDetail.AddBuf(battleUnitBuf_Concussion);
                return;
            }
            battleUnitBuf_Concussion.Add(add);
        }
        public static void GainReadyCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_Concussion battleUnitBuf_Concussion = model.bufListDetail.GetReadyBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Concussion) as BattleUnitBuf_Concussion;
            if (battleUnitBuf_Concussion == null)
            {
                battleUnitBuf_Concussion = new BattleUnitBuf_Concussion(model);
                battleUnitBuf_Concussion.Add(add);
                model.bufListDetail.AddReadyBuf(battleUnitBuf_Concussion);
                return;
            }
            battleUnitBuf_Concussion.Add(add);
        }

        // Token: 0x06001063 RID: 4195 RVA: 0x000497C8 File Offset: 0x000479C8
        public static int GetCharge(BattleUnitModel model)
        {
            BattleUnitBuf_Concussion battleUnitBuf_Concussion = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Concussion) as BattleUnitBuf_Concussion;
            int result;
            if (battleUnitBuf_Concussion == null)
            {
                result = 0;
            }
            else
            {
                result = battleUnitBuf_Concussion.stack;
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
        public override void OnSuccessAttack(BattleDiceBehavior behavior)                  //50% chance destroy next die if attacking
        {                        
            if (RandomUtil.valueForProb < 0.5f)                          
            {
                BattlePlayingCardDataInUnitModel currentDiceAction = this._owner.currentDiceAction;
                if (currentDiceAction != null)
                {
                    currentDiceAction.DestroyDice(DiceMatch.NextDice, DiceUITiming.Start);
                }
            }
        }
        public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)              //50% chance destroy next die if take damage
        {           
            if (RandomUtil.valueForProb < 0.5f)
            {
                BattlePlayingCardDataInUnitModel currentDiceAction = this._owner.currentDiceAction;                
                if (currentDiceAction != null)
                {
                    currentDiceAction.DestroyDice(DiceMatch.NextDice, DiceUITiming.Start);
                }
            }
        }
    }
}
