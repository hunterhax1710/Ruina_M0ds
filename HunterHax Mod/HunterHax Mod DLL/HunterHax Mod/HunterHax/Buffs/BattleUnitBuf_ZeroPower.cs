using AutoKeywordUtil;

namespace HunterHax
{
    public class BattleUnitBuf_ZeroPower : BattleUnitBuf, IRefKeywordBuf
    {

        public override string keywordId => "ZeroPower";
        public string KeywordBufName => "ZeroPower";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.ZeroPower;
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
            this.stack = 0;                                
        }
        public override void OnRoundEndTheLast()
        {
            this.Destroy();             //Last for 1 Scene

        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (this._owner.IsImmune(this.bufType))
            {
                return;
            }
            if (base.IsAttackDice(behavior.Detail))
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus                  //Reduce power to 0 in case immune nullify power
                {
                    power = -999999
                });
            }
        }
        public override bool IsNullifiedPower()                             //Nullify power buff
        {
            return !this._owner.IsImmune(this.bufType) || base.IsNullifiedPower();
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            foreach (BattleDiceBehavior battleDiceBehavior in curCard.GetDiceBehaviorList())
            {
                battleDiceBehavior.behaviourInCard = battleDiceBehavior.behaviourInCard.Copy();
                battleDiceBehavior.behaviourInCard.Dice = 1;                          //Max dice is 1
            } 
        }
        public override int paramInBufDesc
        {
            get
            {
                return this.stack + 1;
            }
        }       
    }
}
