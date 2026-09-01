using AutoKeywordUtil;
using LOR_DiceSystem;


namespace HunterHax
{
    public class BattleUnitBuf_FatalResist : BattleUnitBuf, IRefKeywordBuf
    {
        public override string keywordId => "FatalResist";
        public string KeywordBufName => "FatalResist";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.FatalResist;
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
        public override AtkResist GetResistBP(AtkResist origin, BehaviourDetail detail)
        {
            return AtkResist.Weak;
        }

        // Token: 0x06004A3F RID: 19007 RVA: 0x000894B0 File Offset: 0x000876B0
        public override AtkResist GetResistHP(AtkResist origin, BehaviourDetail detail)
        {
            return AtkResist.Weak;
        }

        public override void OnRoundEnd()
        {
            this._owner.bufListDetail.AddKeywordBufByCard(MyKeywords.Seal1, 1, null);
            this.Destroy();
        }


    }
}
