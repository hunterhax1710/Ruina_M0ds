

namespace BlackSilence
{
    public class PassiveAbility_Retaliate : PassiveAbilityBase
    {
        // Token: 0x0600003D RID: 61 RVA: 0x00002202 File Offset: 0x00000402
        public override void OnStartBattle()
        {
            BattleDiceCardModel battleDiceCardModel = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("BlackSilence", 1000)));
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
