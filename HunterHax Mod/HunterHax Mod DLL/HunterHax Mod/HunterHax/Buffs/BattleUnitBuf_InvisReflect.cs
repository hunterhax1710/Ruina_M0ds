using AutoKeywordUtil;
using LOR_DiceSystem;
using UnityEngine;

namespace HunterHax
{
    public class BattleUnitBuf_InvisReflect : BattleUnitBuf, IRefKeywordBuf
    {
        public override string keywordId => "InvisReflect";
        public string KeywordBufName => "InvisReflect";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.InvisReflect;
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
        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
        }

        public override void OnAddBuf(int addedStack)
        {
            int num = 1;
            if (this.stack > 1)
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