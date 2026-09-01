using AutoKeywordUtil;
using LOR_DiceSystem;

namespace HunterHax
{
    public class BattleUnitBuf_InvisPhase : BattleUnitBuf, IRefKeywordBuf
    {
        public override string keywordId => "InvisPhase";
        public string KeywordBufName => "InvisPhase";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.InvisPhase;
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
                return BufPositiveType.Positive;
            }
        }
        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
        }

        public override void OnAddBuf(int addedStack)
        {
            int num = 2;
            if (this.stack > 2)
            {
                this.stack = num;
            }
            if (this._owner.IsImmune(this.bufType))
            {
                this.stack = 0;
            }
        }

    }

}
