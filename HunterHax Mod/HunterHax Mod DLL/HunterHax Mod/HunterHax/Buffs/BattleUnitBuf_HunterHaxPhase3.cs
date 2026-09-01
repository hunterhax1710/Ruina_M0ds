using AutoKeywordUtil;
using System.Collections.Generic;

namespace HunterHax
{
    public class BattleUnitBuf_HunterHaxPhase3 : BattleUnitBuf, IRefKeywordBuf
    {
        public override string keywordId => "HunterHaxPhase3";
        public string KeywordBufName => "HunterHaxPhase3";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.HunterHaxPhase3;
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
            this.round = 5;
        }
        public override BufPositiveType positiveType
        {
            get
            {
                return BufPositiveType.None;
            }
        }       
        public override int paramInBufDesc                             //Allow X to be defined in Effects.xml
        {

            get
            {
                return this.round;
            }
        }
        public static int GetCharge(BattleUnitModel model)
        {
            BattleUnitBuf_HunterHaxPhase3 battleUnitBuf_HunterHaxPhase3 = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_HunterHaxPhase3) as BattleUnitBuf_HunterHaxPhase3;
            int result;
            if (battleUnitBuf_HunterHaxPhase3 == null)
            {
                result = 0;
            }
            else
            {
                result = battleUnitBuf_HunterHaxPhase3.stack;
            }
            return result;
        }




        public override void OnRoundStart()
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((this._owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
            if (this.round <= 0)              //When round becomes 0, starts at round = 5 (5 scenes)                       
            {
                this._owner.cardSlotDetail.RecoverPlayPoint(10);
                this._owner.bufListDetail.AddKeywordBufThisRoundByCard(MyKeywords.Untargetable, 1, base._owner);
                this._owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Strength, 3, base._owner);
                foreach (BattleUnitModel battleUnitModel in aliveList)       //Inflict all Enemies
                {
                    battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(MyKeywords.FatalResist, 1, null);

                }
            }

        }
        public override void OnRoundEnd()
        {         
          if (this._owner.IsImmune(this.bufType))
          {
                this.Destroy();
          }
          if (this.round == 0)
          {
           this.round = 5;
           return;
          }
          this.round--;
        }


        private int round;

    }

}
