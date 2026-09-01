using AutoKeywordUtil;
using HarmonyLib;
using Sound;
using UnityEngine;

namespace HunterHax
{
    public class BattleUnitBuf_VowMod_CourierTrunk : BattleUnitBuf, IRefKeywordBuf
    {

        public override string keywordId => "VowMod_CourierTrunk";
        public string KeywordBufName => "VowMod_CourierTrunk";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.VowMod_CourierTrunk;
        public override KeywordBuf bufType
        {
            get
            {
                return this.KeywordBuf;

            }
        }
        public override void OnRoundEnd()
        {
            if (!this._owner.IsImmune(this.bufType))
            {
                this._owner.TakeDamage(this.stack / 2, DamageType.Buf, null, this.bufType);
                
                if (this.stack < 0)
                {
                    this.stack = 0;
                }
                
               
                
            }
   
        }
        public override void OnAddBuf(int addedStack)
        {
            int num = 30;
                if (this.stack > num)
            { 
                this.stack = num;
            }
                if (this._owner.IsImmune(this.bufType))
            { 
                this.stack = 0;
            }
        }
        public override int paramInBufDesc
        {
            get
            {
                return this.stack / 2;
            }
        }
        


        

    }

          

    
}