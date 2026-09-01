using AutoKeywordUtil;
using System.Collections.Generic;


namespace HunterHax
{
    public class BattleUnitBuf_Distortion : BattleUnitBuf, IRefKeywordBuf
    {
        public override string keywordId => "Distortion";
        public string KeywordBufName => "Distortion";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.Distortion;
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
            this.count = 1;                       //Last for 1 Scenes, If owner is staggered buff does not decrease
            this._bControlable = false;
        }


        public override BufPositiveType positiveType
        {
            get
            {
                return BufPositiveType.None;
            }
        }
        public override bool TeamKill()
        {
            return true;
        }


        public override void OnRoundStart()
        {           
            if (this.count <= 0)
            {
                this._owner.bufListDetail.AddKeywordBufThisRoundByEtc(MyKeywords.PurgeBuf, 1, null);
                this.Destroy();
            }
        }
        public override void OnRoundEnd()
        {
            if (this._owner != null && !this._owner.IsBreakLifeZero())           //Count down if owner not staggered
            {
                this.count--;
            }          
        }
        public override int paramInBufDesc
        {
            get
            {
                return this.count;
            }
        }
        public override bool IsControllable
        {
            get
            {
                return this._owner.faction == Faction.Enemy;
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
        public override void BeforeGiveDamage(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            if (target != null && target.faction == this._owner.faction)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus                    //+10 power and +10 stagger dmg
                {
                    breakDmg = 10,
                    dmg = 10
                });
            }

        }      
        public bool _bControlable;

        private int count;
    }
}
