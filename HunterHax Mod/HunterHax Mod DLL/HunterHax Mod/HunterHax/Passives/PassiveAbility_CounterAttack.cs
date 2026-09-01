using System.Collections.Generic;
using LOR_DiceSystem;

namespace HunterHax
{
    public class PassiveAbility_CounterAttack : PassiveAbilityBase
    {
        // Token: 0x0600003D RID: 61 RVA: 0x00002202 File Offset: 0x00000402
        public override void OnStartBattle()
        {
            BattleDiceCardModel battleDiceCardModel = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("NewMod", 405525)));
            if (battleDiceCardModel != null)
            {
                foreach (BattleDiceBehavior behaviour in battleDiceCardModel.CreateDiceCardBehaviorList())
                {
                    this.owner.cardSlotDetail.keepCard.AddBehaviourForOnlyDefense(battleDiceCardModel, behaviour);
                }
            }
        }
    }
}
