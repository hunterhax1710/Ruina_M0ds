using Sound;
using UnityEngine;
using LOR_DiceSystem;

namespace BlackSilence
{
    public class BattleUnitBuf_Returner : BattleUnitBuf
    {
        public override string keywordId => "Returner";
        public string KeywordBufName => "Returner";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.Returner;
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
        public BattleUnitBuf_Returner(BattleUnitModel model)
        {
            this._owner = model;
            this.stack = 0;
            this.returns = 0;
        }
        public static void GainCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_Returner battleUnitBuf_Returner = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Returner) as BattleUnitBuf_Returner;
            if (battleUnitBuf_Returner == null)
            {
                battleUnitBuf_Returner = new BattleUnitBuf_Returner(model);
                battleUnitBuf_Returner.Add(add);
                model.bufListDetail.AddBuf(battleUnitBuf_Returner);
                return;
            }
            battleUnitBuf_Returner.Add(add);
        }
        public static void ReduceCharge(BattleUnitModel model, int reduce)
        {
            BattleUnitBuf_Returner battleUnitBuf_Returner = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Returner) as BattleUnitBuf_Returner;            
            battleUnitBuf_Returner.Reduce(reduce);
        }
        public static int GetCharge(BattleUnitModel model)
        {
            BattleUnitBuf_Returner battleUnitBuf_Returner = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Returner) as BattleUnitBuf_Returner;
            int result;
            if (battleUnitBuf_Returner == null)
            {
                result = 0;
            }
            else
            {
                result = battleUnitBuf_Returner.stack;
            }
            return result;
        }
        public void Add(int add)
        {
            this.stack += add;
            if (this.stack >= 100)
            {
                this.stack = 100;
            }
        }
        public void Reduce(int reduce)
        {
            this.stack -= reduce;
            if (this.stack <= 0)
            {
                this.stack = 0;
            }
        }

        public override void OnHpZero()
        {
        }
        private void SetParticle()
        {
            UnityEngine.Object @object = Resources.Load("Prefabs/Battle/SpecialEffect/RedMistRelease_ActivateParticle");
            if (@object != null)
            {
                GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
                gameObject.transform.parent = this._owner.view.charAppearance.transform;
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.transform.localRotation = Quaternion.identity;
                gameObject.transform.localScale = Vector3.one;
            }
            SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Battle/Kali_Change", false, 1f, null);
        }
        public override int paramInBufDesc
        {
            get
            {
                return this.returns;
            }
        }

        //Buff effects                
        public override void BeforeRollDice(BattleDiceBehavior behavior)         //Power
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                power = this.returns
            });
        }
        public override StatBonus GetStatBonus()                               //Damage Reduction to self
        {
            if (this._owner.IsImmune(this.bufType))
            {
                return base.GetStatBonus();
            }
            return new StatBonus
            {
                dmgAdder = -this.returns
            };
        }
        public override int SpeedDiceNumAdder()                                //Dice adder Max: 4
        {
            return this.returns - this.count;
        }

        //Revive System
        public override void OnRoundEnd()
        {
            if (this.stack > this._owner.emotionDetail.EmotionLevel)                           //Limits Max Revive = 5
            {
                this._owner.Die(null, true);
                this.Destroy();
            }
            if (this.stack <= this._owner.emotionDetail.EmotionLevel)
            {
                this._OnDie = false;
            }
            if (this._owner.emotionDetail.EmotionLevel >= 4)                                   //Limits Max Die Added to 4
            {
                this.count = 1;
            }
        }
        public override void OnRoundStart()
        {
            if (this.stack > this._owner.emotionDetail.EmotionLevel)                           //Limits Max Revive = 5
            {
                this._owner.Die(null, true);
                this.Destroy();
            }           
            if (this.stack <= this._owner.emotionDetail.EmotionLevel)
            {
            this._OnDie = false;
            }
            if (this._owner.emotionDetail.EmotionLevel >= 4)                                   //Limits Max Die Added to 4 at Emotion Level 5
            {
                    this.count = 1;
            }
            if (this._owner.faction == Faction.Player)                                         //Draw Cards & Playpoint
            {
                this._owner.allyCardDetail.DrawCards(this.returns);
                this._owner.cardSlotDetail.RecoverPlayPoint(this.returns);
                if (this.returns >= 6)                                                         //Cost Reduction after 5 returns
                {
                    int reduction = this.returns - 5;
                    if (reduction <= 0 )
                    {
                        reduction = 0;
                    }
                    foreach (BattleDiceCardModel battleDiceCardModel in this._owner.allyCardDetail.GetHand())
                    {
                        battleDiceCardModel.SetCurrentCost(battleDiceCardModel.GetOriginCost() - reduction);
                    }
                }
            }
            if (this._owner.faction == Faction.Enemy)                                          //Enemy Cost Reduction
            {
                    foreach (BattleDiceCardModel battleDiceCardModel in this._owner.allyCardDetail.GetHand())
                    {
                        battleDiceCardModel.SetCurrentCost(battleDiceCardModel.GetOriginCost() - this.returns);
                    }
            }
            
        }
        public override void OnRoundStartAfter()
        {
            base.OnRoundStartAfter();
            if (this.stack > this._owner.emotionDetail.EmotionLevel)                             //Limits Max Revive = 5
            {
                this._owner.Die(null, true);
                this.Destroy();
            }
        }
        public override void OnDie()
        {
            if (this._owner.Book.GetBookClassInfoId() == new LorId("BlackSilence", 1) || this._owner.Book.GetBookClassInfoId() == new LorId("BlackSilence", 1000000))
            {
                if (this.stack > this._owner.emotionDetail.EmotionLevel)                          //Limit Max Revive = 5
                {
                    this._owner.Die(null, true);
                    this.Destroy();
                    return;
                }
                if (this.stack <= this._owner.emotionDetail.EmotionLevel)
                {
                    this.returns++;
                    this.stack++;
                    this._owner.Revive(1);
                    this._owner.SetHp(this._owner.MaxHp);
                    this.SetParticle();
                    BattleUnitBuf_Stability.GainCharge(this._owner, 2);
                    this._owner.breakDetail.RecoverBreakLife(this._owner.MaxBreakLife, false);
                    this._owner.breakDetail.nextTurnBreak = false;
                    this._owner.turnState = BattleUnitTurnState.WAIT_CARD;
                    this._owner.breakDetail.RecoverBreak(this._owner.breakDetail.GetDefaultBreakGauge());
                    this._owner.breakDetail.RecoverBreakLife(this._owner.MaxBreakLife, false);
                    BattleDiceCardModel battleDiceCardModel = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("BlackSilence", 1000)));        //Get Retaliate counter dice
                    if (battleDiceCardModel != null)
                    {
                        foreach (BattleDiceBehavior behaviour in battleDiceCardModel.CreateDiceCardBehaviorList())
                        {
                            this._owner.cardSlotDetail.keepCard.AddBehaviourForOnlyDefense(battleDiceCardModel, behaviour);
                        }
                    }
                    foreach (BattleUnitBuf battleUnitBuf in this._owner.bufListDetail.GetActivatedBufList())
                    {
                        if (battleUnitBuf.positiveType == BufPositiveType.Negative)
                        {
                            battleUnitBuf.Destroy();
                        }
                    }
                    foreach (BattleUnitBuf battleUnitBuf2 in this._owner.bufListDetail.GetReadyBufList())
                    {
                        if (battleUnitBuf2.positiveType == BufPositiveType.Negative)
                        {
                            battleUnitBuf2.Destroy();
                        }
                    }

                    if (this.stack == 2)                                                                  //Change Resistance
                    {                      
                        this._owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Endure);
                    }
                    if (this.stack == 3)
                    {                       
                        this._owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Endure);
                    }
                    if (this.stack == 4)
                    {                      
                        this._owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Endure);
                    }
                    if (this.stack == 5)
                    {                       
                        this._owner.Book.SetResistHP(BehaviourDetail.Hit, AtkResist.Endure);
                    }                    
                }
            }
        }
        
        private int returns;
        private int count;
        private bool _OnDie;
        private int _OnRoundStart;
    }
}
