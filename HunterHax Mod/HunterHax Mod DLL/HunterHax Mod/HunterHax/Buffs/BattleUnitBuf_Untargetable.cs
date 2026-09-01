using AutoKeywordUtil;

namespace HunterHax
{
    public class BattleUnitBuf_Untargetable : BattleUnitBuf, IRefKeywordBuf
    {
        public override string keywordId => "Untargetable";
        public string KeywordBufName => "Untargetable";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.Untargetable;
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
        public override bool IsTargetable()
        {
            return false;
        }
        public override BufPositiveType positiveType
        {
            get
            {
                return BufPositiveType.None;
            }
        }

        // Token: 0x0600885F RID: 34911 RVA: 0x000894B0 File Offset: 0x000876B0
        public override bool DirectAttack()
        {
            return true;
        }
        public override void OnRoundEnd()
        {
            base.OnRoundEnd();
            this.Destroy();
        }

    }
}
