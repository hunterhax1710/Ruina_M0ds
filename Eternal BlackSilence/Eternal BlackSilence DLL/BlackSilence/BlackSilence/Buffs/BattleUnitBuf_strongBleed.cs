

using Sound;
using UnityEngine;

namespace BlackSilence
{
    public class BattleUnitBuf_strongBleed : BattleUnitBuf
    {
        public override string keywordId => "strongBleed";
        public string KeywordBufName => "strongBleed";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.strongBleed;
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
                return BufPositiveType.Negative;
            }
        }
        public BattleUnitBuf_strongBleed(BattleUnitModel model)
        {
            this._owner = model;
            this.stack = 0;
        }
        public override int paramInBufDesc
        {
            get
            {
                return this.stack;
            }
        }
        public static void GainCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_strongBleed battleUnitBuf_strongBleed = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_strongBleed) as BattleUnitBuf_strongBleed;
            if (battleUnitBuf_strongBleed == null)
            {
                battleUnitBuf_strongBleed = new BattleUnitBuf_strongBleed(model);
                battleUnitBuf_strongBleed.Add(add);
                model.bufListDetail.AddBuf(battleUnitBuf_strongBleed);
                return;
            }
            battleUnitBuf_strongBleed.Add(add);
        }
        public static void GainReadyCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_strongBleed battleUnitBuf_strongBleed = model.bufListDetail.GetReadyBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_strongBleed) as BattleUnitBuf_strongBleed;
            if (battleUnitBuf_strongBleed == null)
            {
                battleUnitBuf_strongBleed = new BattleUnitBuf_strongBleed(model);
                battleUnitBuf_strongBleed.Add(add);
                model.bufListDetail.AddReadyBuf(battleUnitBuf_strongBleed);
                return;
            }
            battleUnitBuf_strongBleed.Add(add);
        }


        // Token: 0x06001063 RID: 4195 RVA: 0x000497C8 File Offset: 0x000479C8
        public static int GetCharge(BattleUnitModel model)
        {
            BattleUnitBuf_strongBleed battleUnitBuf_strongBleed = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_strongBleed) as BattleUnitBuf_strongBleed;
            int result;
            if (battleUnitBuf_strongBleed == null)
            {
                result = 0;
            }
            else
            {
                result = battleUnitBuf_strongBleed.stack;
            }
            return result;
        }

        // Token: 0x06001064 RID: 4196 RVA: 0x00007A6A File Offset: 0x00005C6A
        public void Add(int add)
        {
            this.stack += add;
            if (this.stack >= 20)
            {
                this.stack = 20;
            }
        }
        private void PrintEffect()
        {
            GameObject gameObject = Util.LoadPrefab("Battle/DiceAttackEffects/New/FX/DamageDebuff/FX_DamageDebuff_Blooding");
            if (gameObject != null)
            {
                BattleUnitModel owner = this._owner;
                if (((owner != null) ? owner.view : null) != null)
                {
                    gameObject.transform.parent = this._owner.view.camRotationFollower;
                    gameObject.transform.localPosition = Vector3.zero;
                    gameObject.transform.localScale = Vector3.one;
                    gameObject.transform.localRotation = Quaternion.identity;
                }
            }
            SoundEffectPlayer.PlaySound("Buf/Effect_Bleeding");
        }
        public override void OnRoundEnd()
        {
            if (this.stack <= 0)
            {
                this.Destroy();
            }
        }
        public override void AfterDiceAction(BattleDiceBehavior behavior)
        {               
            if (base.IsAttackDice(behavior.Detail))
            {
                if (!this._owner.IsImmune(this.bufType))
                {                  
                    float dmg = (float)this._owner.MaxHp * 0.01f * this.stack;                                       //Take 1% x stack damage per offensive dice roll
                    this._owner.TakeDamage((int)dmg, DamageType.Buf, null, this.bufType);
                    BattleCardTotalResult battleCardResultLog = this._owner.battleCardResultLog;
                    if (battleCardResultLog != null)
                    {
                        battleCardResultLog.SetAfterActionEvent(new BattleCardBehaviourResult.BehaviourEvent(this.PrintEffect));
                    }
                    this.stack--;
                    if (this.stack <= 0)
                    {
                        this.Destroy();
                    }
                }               
            }
        }


     

    }
}
