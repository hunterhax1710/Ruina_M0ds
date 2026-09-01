using LOR_DiceSystem;

namespace BlackSilence
{
    public class BattleUnitBuf_NoRange : BattleUnitBuf
    {
        public override string keywordId => "NoRange";
        public string KeywordBufName => "NoRange";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.NoRange;
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
        public BattleUnitBuf_NoRange(BattleUnitModel model)
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
            BattleUnitBuf_NoRange battleUnitBuf_NoRange = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_NoRange) as BattleUnitBuf_NoRange;
            if (battleUnitBuf_NoRange == null)
            {
                battleUnitBuf_NoRange = new BattleUnitBuf_NoRange(model);
                battleUnitBuf_NoRange.Add(add);
                model.bufListDetail.AddBuf(battleUnitBuf_NoRange);
                return;
            }
            battleUnitBuf_NoRange.Add(add);
        }

        // Token: 0x06001063 RID: 4195 RVA: 0x000497C8 File Offset: 0x000479C8
        public static int GetCharge(BattleUnitModel model)
        {
            BattleUnitBuf_NoRange battleUnitBuf_NoRange = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_NoRange) as BattleUnitBuf_NoRange;
            int result;
            if (battleUnitBuf_NoRange == null)
            {
                result = 0;
            }
            else
            {
                result = battleUnitBuf_NoRange.stack;
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
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.card.GetSpec().Ranged == CardRange.Far || curCard.card.GetSpec().Ranged == CardRange.FarArea || curCard.card.GetSpec().Ranged == CardRange.FarAreaEach)
            {
                curCard.DestroyDice(DiceMatch.AllAttackDice, DiceUITiming.Start);
            }
        }
    }
}
