using LOR_DiceSystem;

namespace HunterHax
{
    // Token: 0x02000013 RID: 19
    public class DiceCardSelfAbility_powerup5highspeed : DiceCardSelfAbilityBase
    {
        // Token: 0x06000036 RID: 54 RVA: 0x00002BE0 File Offset: 0x00000DE0
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
                        power = 5
                    });
                }
            }
        }
    }

}
