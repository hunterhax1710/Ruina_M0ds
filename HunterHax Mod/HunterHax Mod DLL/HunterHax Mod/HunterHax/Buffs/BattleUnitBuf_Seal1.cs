using AutoKeywordUtil;

namespace HunterHax
{
    public class BattleUnitBuf_Seal1 : BattleUnitBuf, IRefKeywordBuf
    {
        public override string keywordId => "Seal1";
        public string KeywordBufName => "Seal1";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.Seal1;
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
        public override bool IsNullifiedPower()
        {
            return !this._owner.IsImmune(this.bufType) || base.IsNullifiedPower();
        }
        public override void OnAddBuf(int addedStack)                   //Limit Buff to 999
        {
            int num = 999;
            if (this.stack > num)
            {
                this.stack = num;
            }
            if (this._owner.IsImmune(this.bufType))
            {
                this.stack = 0;

            }
        }
        public override void OnRoundEnd()
        {
            base.OnRoundEnd();
            this.Destroy();
        }

    }

}
