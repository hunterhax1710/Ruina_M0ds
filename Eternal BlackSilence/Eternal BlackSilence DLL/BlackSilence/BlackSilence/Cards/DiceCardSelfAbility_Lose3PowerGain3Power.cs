

using LOR_DiceSystem;

namespace BlackSilence
{
    public class DiceCardSelfAbility_Lose3PowerGain3Power : DiceCardSelfAbilityBase
    {
        // Token: 0x060036DA RID: 14042 RVA: 0x00135752 File Offset: 0x00133952
        public override void OnStartParrying()
        {
            BattleUnitModel target = this.card.target;
            if (target == null)
            {
                return;
            }
            BattlePlayingCardDataInUnitModel currentDiceAction = target.currentDiceAction;
            if (currentDiceAction == null)
            {
                return;
            }
            currentDiceAction.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = -3
            });
        }
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
                    this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                    {
                        power = 3
                    });
                }
            }
        }
    }
}
