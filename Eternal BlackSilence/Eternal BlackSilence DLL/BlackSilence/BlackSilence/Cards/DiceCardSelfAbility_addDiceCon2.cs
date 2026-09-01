

using LOR_DiceSystem;

namespace BlackSilence
{
    public class DiceCardSelfAbility_addDiceCon2 : DiceCardSelfAbilityBase
    {
        // Token: 0x0600390B RID: 14603 RVA: 0x0013A5E0 File Offset: 0x001387E0
        public override void OnUseCard()
        {
            int speedDiceResultValue = this.card.speedDiceResultValue;
            BattleUnitModel target = this.card.target;
            int targetSlotOrder = this.card.targetSlotOrder;
            if (targetSlotOrder >= 0 && targetSlotOrder < target.speedDiceResult.Count)
            {
                SpeedDice speedDice = target.speedDiceResult[targetSlotOrder];
                if (speedDiceResultValue > speedDice.value)
                {
                    DiceCardXmlInfo cardItem = ItemXmlDataList.instance.GetCardItem(new LorId("BlackSilence", 2000), false);
                    BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                    battleDiceBehavior.behaviourInCard = cardItem.DiceBehaviourList[0].Copy();
                    battleDiceBehavior.AddAbility(Singleton<AssemblyManager>.Instance.CreateInstance_DiceCardAbility(cardItem.DiceBehaviourList[0].Script));
                    battleDiceBehavior.SetIndex(5);
                    base.card.AddDice(battleDiceBehavior);
                }
            }
        }        


    }
}
