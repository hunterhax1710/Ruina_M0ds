
using LOR_DiceSystem;
namespace BlackSilence
{
    public class BattleUnitBuf_Distorted : BattleUnitBuf
    {
        public override string keywordId => "Distorted";
        public string KeywordBufName => "Distorted";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.Distorted;
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
        public override int paramInBufDesc
        {
            get
            {
                return this.stack;
            }
        }
        public BattleUnitBuf_Distorted(BattleUnitModel model)
        {
            this._owner = model;
            this.stack = 0;
        }
        public static void GainCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_Distorted battleUnitBuf_Distorted = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Distorted) as BattleUnitBuf_Distorted;
            if (battleUnitBuf_Distorted == null)
            {
                battleUnitBuf_Distorted = new BattleUnitBuf_Distorted(model);
                battleUnitBuf_Distorted.Add(add);
                model.bufListDetail.AddBuf(battleUnitBuf_Distorted);
                return;
            }
            battleUnitBuf_Distorted.Add(add);
        }

        // Token: 0x06001063 RID: 4195 RVA: 0x000497C8 File Offset: 0x000479C8
        public static int GetCharge(BattleUnitModel model)
        {
            BattleUnitBuf_Distorted battleUnitBuf_Distorted = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Distorted) as BattleUnitBuf_Distorted;
            int result;
            if (battleUnitBuf_Distorted == null)
            {
                result = 0;
            }
            else
            {
                result = battleUnitBuf_Distorted.stack;
            }
            return result;
        }

        // Token: 0x06001064 RID: 4196 RVA: 0x00007A6A File Offset: 0x00005C6A
        public void Add(int add)
        {
            this.stack += add;
            if (this.stack >= 100)
            {
                this.stack = 100;
            }
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)         //Power -1
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                power = -this.stack
            });
        }
        public override bool IsNullifiedPower()
        {
            return !this._owner.IsImmune(this.bufType) || base.IsNullifiedPower();
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)                      //Dice Change = stacks
        {
            if (this.count <= this.stack)
            {
                this.count++;
                foreach (BattleDiceBehavior battleDiceBehavior in curCard.GetDiceBehaviorList())
                {
                    if (battleDiceBehavior.behaviourInCard.Detail == BehaviourDetail.Guard)
                    {
                        battleDiceBehavior.behaviourInCard = battleDiceBehavior.behaviourInCard.Copy();
                        int num = RandomUtil.Range(1, 5);
                        if (num == 1)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Slash;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.J;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_J";                           
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num == 2)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Hit;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.H;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_H";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num == 3)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Penetrate;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.Z;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_Z";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num == 4)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Guard;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Def;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.G;
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num == 5)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Evasion;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Def;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.E;
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                    }
                    if (battleDiceBehavior.behaviourInCard.Detail == BehaviourDetail.Hit)
                    {
                        battleDiceBehavior.behaviourInCard = battleDiceBehavior.behaviourInCard.Copy();
                        int num2 = RandomUtil.Range(1, 5);
                        if (num2 == 1)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Slash;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.J;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_J";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num2 == 2)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Hit;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.H;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_H";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num2 == 3)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Penetrate;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.Z;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_Z";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num2 == 4)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Guard;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Def;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.G;
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num2 == 5)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Evasion;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Def;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.E;
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                    }
                    if (battleDiceBehavior.behaviourInCard.Detail == BehaviourDetail.Penetrate)
                    {
                        battleDiceBehavior.behaviourInCard = battleDiceBehavior.behaviourInCard.Copy();
                        int num3 = RandomUtil.Range(1, 5);
                        if (num3 == 1)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Slash;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.J;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_J";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num3 == 2)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Hit;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.H;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_H";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num3 == 3)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Penetrate;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.Z;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_Z";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num3 == 4)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Guard;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Def;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.G;
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num3 == 5)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Evasion;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Def;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.E;
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                    }
                    if (battleDiceBehavior.behaviourInCard.Detail == BehaviourDetail.Slash)
                    {
                        DiceBehaviour diceBehaviour = battleDiceBehavior.behaviourInCard.Copy();
                        int num4 = RandomUtil.Range(1, 5);
                        if (num4 == 1)
                        {
                            diceBehaviour.Detail = BehaviourDetail.Slash;
                            diceBehaviour.Type = BehaviourType.Atk;
                            diceBehaviour.MotionDetail = MotionDetail.J;
                            diceBehaviour.EffectRes = "Kali_J";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num4 == 2)
                        {
                            diceBehaviour.Detail = BehaviourDetail.Hit;
                            diceBehaviour.Type = BehaviourType.Atk;
                            diceBehaviour.MotionDetail = MotionDetail.H;
                            diceBehaviour.EffectRes = "Kali_H";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num4 == 3)
                        {
                            diceBehaviour.Detail = BehaviourDetail.Penetrate;
                            diceBehaviour.Type = BehaviourType.Atk;
                            diceBehaviour.MotionDetail = MotionDetail.Z;
                            diceBehaviour.EffectRes = "Kali_Z";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num4 == 4)
                        {
                            diceBehaviour.Detail = BehaviourDetail.Guard;
                            diceBehaviour.Type = BehaviourType.Def;
                            diceBehaviour.MotionDetail = MotionDetail.G;
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num4 == 5)
                        {
                            diceBehaviour.Detail = BehaviourDetail.Evasion;
                            diceBehaviour.Type = BehaviourType.Def;
                            diceBehaviour.MotionDetail = MotionDetail.E;
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                    }
                    if (battleDiceBehavior.behaviourInCard.Detail == BehaviourDetail.Evasion)
                    {
                        battleDiceBehavior.behaviourInCard = battleDiceBehavior.behaviourInCard.Copy();
                        int num5 = RandomUtil.Range(1, 5);
                        if (num5 == 1)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Slash;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.J;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_J";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";

                        }
                        if (num5 == 2)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Hit;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.H;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_H";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num5 == 3)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Penetrate;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Atk;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.Z;
                            battleDiceBehavior.behaviourInCard.EffectRes = "Kali_Z";
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num5 == 4)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Guard;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Def;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.G;
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                        if (num5 == 5)
                        {
                            battleDiceBehavior.behaviourInCard.Detail = BehaviourDetail.Evasion;
                            battleDiceBehavior.behaviourInCard.Type = BehaviourType.Def;
                            battleDiceBehavior.behaviourInCard.MotionDetail = MotionDetail.E;
                            battleDiceBehavior.behaviourInCard.Script = "snowqueen_child_def";
                        }
                    }
                }
            }
        }
        public override void OnRoundStart()
        {
            if (this.stack >= 7)                                             //Insta Die on 7 stacks
            {
                this._owner.Die(null, true);
            }
        }


        public override void OnRoundEnd()
        {
            if (this.stack >= 7)                                             //Insta Die on 7 stacks
            {
                this._owner.Die(null, true);
            }
            this.count = 0;
            for (int i = 0; i < this.stack; i++)                              //Discard cards = stacks
            {
                this._owner.allyCardDetail.DisCardACardRandom();
            }
        }             
        private int count;
    }
}
