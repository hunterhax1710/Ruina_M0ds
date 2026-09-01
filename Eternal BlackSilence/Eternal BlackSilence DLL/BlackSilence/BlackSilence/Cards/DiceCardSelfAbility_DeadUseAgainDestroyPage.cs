
using System.Collections.Generic;
namespace BlackSilence
{
    public class DiceCardSelfAbility_DeadUseAgainDestroyPage : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {           
            this._isBreakedStart = false;
            if (this.card.target != null && this.card.target.IsBreakLifeZero())
            {
                this._isBreakedStart = true;
            }
        }        
        public override void OnEndBattle()
        {
            if (this.card.target != null && (this.card.target.IsDead() || (!this._isBreakedStart && this.card.target.IsBreakLifeZero())))
            {
                base.owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Strength, 3, base.owner);
                List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
                if (aliveList.Count > 0)
                {
                    BattleUnitModel target = RandomUtil.SelectOne<BattleUnitModel>(aliveList);
                    Singleton<StageController>.Instance.AddAllCardListInBattle(this.card, target, -1);
                }
            }
        }       
        public override void OnSucceedAttack()
        {
            if (this.card.target != null)
            {
                BattleUnitModel target = this.card.target;
                int targetSlotOrder = this.card.targetSlotOrder;
                List<BattlePlayingCardDataInUnitModel> list = new List<BattlePlayingCardDataInUnitModel>();
                for (int i = 0; i < target.cardSlotDetail.cardAry.Count; i++)
                {
                    if (i != targetSlotOrder)
                    {
                        BattlePlayingCardDataInUnitModel battlePlayingCardDataInUnitModel = target.cardSlotDetail.cardAry[i];
                        if (battlePlayingCardDataInUnitModel != null && !battlePlayingCardDataInUnitModel.isDestroyed && battlePlayingCardDataInUnitModel.GetDiceBehaviorList().Count > 0)
                        {
                            list.Add(battlePlayingCardDataInUnitModel);
                        }
                    }
                }
                if (list.Count > 0)
                {
                    RandomUtil.SelectOne<BattlePlayingCardDataInUnitModel>(list).DestroyPlayingCard();
                }
            }
        }
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "Strength_Keyword"
                };
            }
        }




        private bool _isBreakedStart;
    }
}
