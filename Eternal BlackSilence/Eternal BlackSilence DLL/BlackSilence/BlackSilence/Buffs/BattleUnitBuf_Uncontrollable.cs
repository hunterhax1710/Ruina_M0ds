

using Battle.CreatureEffect;
using System.Collections.Generic;

namespace BlackSilence
{
    public class BattleUnitBuf_Uncontrollable : BattleUnitBuf
    {
        public override string keywordId => "Uncontrollable";
        public string KeywordBufName => "Uncontrollable";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.Uncontrollable;
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
        public BattleUnitBuf_Uncontrollable(BattleUnitModel model)
        {
            this._owner = model;
            this._bControlable = false;
            this.stack = 0;
        }
        public override bool TeamKill()
        {
            return true;
        }
        public override bool IsControllable
        {
            get
            {
                return this._owner.faction == Faction.Enemy;
            }
        }

        public override void OnRoundEnd()
        {
            if (this._owner != null && !this._owner.IsBreakLifeZero())                   //Minus stack if owner not staggered
            { 
               
                  if (this.aura2 != null)
                  {
                    this.aura2.ManualDestroy();
                   }
                this.Destroy();
                return;
               
            }
        }
        public override void OnRoundEndTheLast()
        {
            BattleUnitBuf_Uncontrollable battleUnitBuf_Uncontrollable = this._owner.bufListDetail.GetReadyBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Uncontrollable) as BattleUnitBuf_Uncontrollable;
            if (!base.IsDestroyed() && battleUnitBuf_Uncontrollable != null)
            {
                battleUnitBuf_Uncontrollable.Add(this.stack);
                this.Destroy();
            }
        }
        public override void Destroy()
        {
            base.Destroy();
            if (this.aura2 != null)
            {
                UnityEngine.Object.Destroy(this.aura2);
                this.aura2 = null;
            }
        }
        public static void GainCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_Uncontrollable battleUnitBuf_Uncontrollable = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Uncontrollable) as BattleUnitBuf_Uncontrollable;
            if (battleUnitBuf_Uncontrollable == null)
            {
                battleUnitBuf_Uncontrollable = new BattleUnitBuf_Uncontrollable(model);
                battleUnitBuf_Uncontrollable.Add(add);
                model.bufListDetail.AddBuf(battleUnitBuf_Uncontrollable);
                return;
            }
            battleUnitBuf_Uncontrollable.Add(add);
        }
        public static void GainReadyCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_Uncontrollable battleUnitBuf_Uncontrollable = model.bufListDetail.GetReadyBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Uncontrollable) as BattleUnitBuf_Uncontrollable;
            if (battleUnitBuf_Uncontrollable == null)
            {
                battleUnitBuf_Uncontrollable = new BattleUnitBuf_Uncontrollable(model);
                battleUnitBuf_Uncontrollable.Add(add);
                model.bufListDetail.AddReadyBuf(battleUnitBuf_Uncontrollable);
                return;
            }
            battleUnitBuf_Uncontrollable.Add(add);
        }
        // Token: 0x06001063 RID: 4195 RVA: 0x000497C8 File Offset: 0x000479C8
        public static int GetCharge(BattleUnitModel model)
        {
            BattleUnitBuf_Uncontrollable battleUnitBuf_Uncontrollable = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Uncontrollable) as BattleUnitBuf_Uncontrollable;
            int result;
            if (battleUnitBuf_Uncontrollable == null)
            {
                result = 0;
            }
            else
            {
                result = battleUnitBuf_Uncontrollable.stack;
            }
            return result;
        }

        // Token: 0x06001064 RID: 4196 RVA: 0x00007A6A File Offset: 0x00005C6A
        public void Add(int add)
        {
            if (this.aura2 == null)
            {
                this.aura2 = SingletonBehavior<DiceEffectManager>.Instance.CreateCreatureEffect("3/Spider_RedEye", 1f, this._owner.view, this._owner.view, -1f);
            }
            this.stack += add;
            if (this.stack >= 1)
            {
                this.stack = 1;
            }
        }
        public override BattleUnitModel ChangeAttackTarget(BattleDiceCardModel card, int idx)         //Attack allies
        {
            BattleUnitModel result = RandomUtil.SelectOne<BattleUnitModel>(BattleObjectManager.instance.GetAliveList_opponent(this._owner.faction).FindAll((BattleUnitModel x) => x.IsTargetable(this._owner)));
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(this._owner.faction);
            aliveList.Remove(this._owner);
            if (aliveList != null && aliveList.Count == 0)
            {
                aliveList.AddRange(BattleObjectManager.instance.GetAliveList(this._owner.faction));
            }
            if (aliveList != null && aliveList.Count > 0)
            {
                result = RandomUtil.SelectOne<BattleUnitModel>(aliveList);
            }
            return result;
        }

        public bool _bControlable;
        private CreatureEffect aura2;
    }
}
