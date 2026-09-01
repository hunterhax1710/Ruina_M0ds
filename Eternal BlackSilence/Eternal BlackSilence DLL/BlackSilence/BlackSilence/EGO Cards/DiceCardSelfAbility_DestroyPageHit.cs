

using System.Collections.Generic;

namespace BlackSilence
{
    public class DiceCardSelfAbility_DestroyPageHit : DiceCardSelfAbilityBase
    {       
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
    }
}
