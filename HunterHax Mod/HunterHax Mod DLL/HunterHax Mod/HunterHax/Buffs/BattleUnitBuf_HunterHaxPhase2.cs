using AutoKeywordUtil;
using LOR_DiceSystem;

namespace HunterHax

{
    public class BattleUnitBuf_HunterHaxPhase2 : BattleUnitBuf, IRefKeywordBuf
    {
        public override string keywordId => "HunterHaxPhase2";
        public string KeywordBufName => "HunterHaxPhase2";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.HunterHaxPhase2;
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


        public override void OnRoundStart()
        {
            this._owner.cardSlotDetail.RecoverPlayPoint(this._owner.cardSlotDetail.RecoverPlayPoint(4));          //Gain 4 Light
            this._owner.allyCardDetail.DrawCards(2);                                                              //Draw 2 Cards
            foreach (BattleUnitBuf battleUnitBuf in this._owner.bufListDetail.GetActivatedBufList())                  // Destroy Negative Ailments
            {
                if (battleUnitBuf.positiveType == BufPositiveType.Negative)
                {
                    battleUnitBuf.Destroy();
                }
            }
            foreach (BattleUnitBuf battleUnitBuf in this._owner.bufListDetail.GetReadyBufList())                  // Destroy Negative Ailments
            {
                if (battleUnitBuf.positiveType == BufPositiveType.Negative)
                {
                    battleUnitBuf.Destroy();
                }
            }

        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (base.IsAttackDice(behavior.Detail))
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus                  
                {
                    power = 3                                 //All Dice Power +3
                });

            }

        }
        public override StatBonus GetStatBonus()
        {
            return new StatBonus
            {
                breakAdder = 3,                                            //Stagger Protection 3
                dmgAdder = -3                                             //Protection 3
            };

        }
        public override int SpeedDiceNumAdder()                              //new Dice Add
        {
            return 1;
        }
            
        public override bool IsImmune(BattleUnitBuf buf)                 //Immune Nullify Power
        {
            return buf.positiveType == BufPositiveType.Negative || buf.bufType == KeywordBuf.NullifyPower;
        }
         
        // Token: 0x06001062 RID: 4194 RVA: 0x00007A5A File Offset: 0x00005C5A
        public virtual bool IsImmuneDmg(DamageType type)                                           //Immune Dmg Ailments
        {
            return type == DamageType.Buf || base.IsImmuneDmg(type, KeywordBuf.None);
        }


    }
}
