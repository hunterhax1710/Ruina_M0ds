using AutoKeywordUtil;

namespace HunterHax
{
    public class BattleUnitBuf_PurgeBuf : BattleUnitBuf, IRefKeywordBuf
    {
        public override string keywordId => "PurgeBuf";
        public string KeywordBufName => "PurgeBuf";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.PurgeBuf;
        public override KeywordBuf bufType
        {
            get
            {
                return this.KeywordBuf;

            }
        }
        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            this.stack = 0;
        }
        public override BufPositiveType positiveType
        {
            get
            {
                return BufPositiveType.None;
            }
        }

        public override void OnRoundEnd()
        {
            foreach (BattleUnitBuf battleUnitBuf in this._owner.bufListDetail.GetReadyBufList())
            {
                if (battleUnitBuf.positiveType == BufPositiveType.Positive || battleUnitBuf.positiveType == BufPositiveType.None)
                {
                    battleUnitBuf.Destroy();
                }
            }
            foreach (BattleUnitBuf battleUnitBuf2 in this._owner.bufListDetail.GetActivatedBufList())
            {
                if (battleUnitBuf2.positiveType == BufPositiveType.Positive || battleUnitBuf2.positiveType == BufPositiveType.None)
                {
                    battleUnitBuf2.Destroy();
                }
            }
            this.Destroy();
        }

    }
}