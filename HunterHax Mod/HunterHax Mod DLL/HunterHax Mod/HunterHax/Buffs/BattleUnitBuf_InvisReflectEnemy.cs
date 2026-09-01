using AutoKeywordUtil;
using LOR_DiceSystem;
using static UnityEngine.GraphicsBuffer;

namespace HunterHax
{
    public class BattleUnitBuf_InvisReflectEnemy : BattleUnitBuf, IRefKeywordBuf
    {
        public override string keywordId => "InvisReflectEnemy";
        public string KeywordBufName => "InvisReflectEnemy";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.InvisReflectEnemy;
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

        public override void OnSuccessAttack(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            if (target != null && target.bufListDetail.GetKewordBufStack(MyKeywords.InvisReflect) == 1)             //Check have InvisReflect
            {
                if (base.IsAttackDice(behavior.Detail) && behavior.card.card.GetSpec().Ranged == CardRange.Far)       //Ranged Atk
                {
                    if (!this._owner.IsImmune(this.bufType))
                    {
                        this._owner.TakeDamage(behavior.DiceResultValue, DamageType.Buf, null, this.bufType);          //Reflect dmg to self
                        
                    }
                }
                if (base.IsAttackDice(behavior.Detail) && behavior.card.card.GetSpec().Ranged == CardRange.FarArea)   //Mass Atk
                {
                    if (!this._owner.IsImmune(this.bufType))
                    {
                        this._owner.TakeDamage(behavior.DiceResultValue, DamageType.Buf, null, this.bufType);          //Reflect dmg to self
                       
                    }
                }
                if (base.IsAttackDice(behavior.Detail) && behavior.card.card.GetSpec().Ranged == CardRange.FarAreaEach)   //Mass Individual Atk
                {
                    if (!this._owner.IsImmune(this.bufType))
                    {
                        this._owner.TakeDamage(behavior.DiceResultValue, DamageType.Buf, null, this.bufType);          //Reflect dmg to self
                       
                    }

                }



            }
        }
        public override void BeforeGiveDamage(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            if (target != null && target.bufListDetail.GetKewordBufStack(MyKeywords.InvisReflect) == 1)             //Check have InvisReflect
            {
                if (base.IsAttackDice(behavior.Detail) && behavior.card.card.GetSpec().Ranged == CardRange.Far)       //Ranged Atk
                {
                    if (!this._owner.IsImmune(this.bufType))
                    {                        
                        behavior.ApplyDiceStatBonus(new DiceStatBonus
                        {
                            dmgRate = -50,                  //-50% dmg and stagger dmg
                            breakRate = -50
                        });
                    }
                }
                if (base.IsAttackDice(behavior.Detail) && behavior.card.card.GetSpec().Ranged == CardRange.FarArea)   //Mass Atk
                {
                    if (!this._owner.IsImmune(this.bufType))
                    {                       
                        behavior.ApplyDiceStatBonus(new DiceStatBonus
                        {
                            dmgRate = -50,
                            breakRate = -50
                        });
                    }
                }
                if (base.IsAttackDice(behavior.Detail) && behavior.card.card.GetSpec().Ranged == CardRange.FarAreaEach)   //Mass Individual Atk
                {
                    if (!this._owner.IsImmune(this.bufType))
                    {
                       
                        behavior.ApplyDiceStatBonus(new DiceStatBonus
                        {
                            dmgRate = -50,
                            breakRate = -50
                        });
                    }

                }
            }



        }
    }
}
