using LOR_DiceSystem;
using UnityEngine;

namespace HunterHax
{
    public class PassiveAbility_HunterHaxProwess : PassiveAbilityBase
    {
        // Token: 0x06004DC7 RID: 19911 RVA: 0x001A3378 File Offset: 0x001A1578
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            int speedDiceResultValue = curCard.speedDiceResultValue;
            BattleUnitModel target = curCard.target;
            int targetSlotOrder = curCard.targetSlotOrder;
            if (targetSlotOrder >= 0 && targetSlotOrder < target.speedDiceResult.Count)
            {
                SpeedDice speedDice = target.speedDiceResult[targetSlotOrder];
                if (speedDiceResultValue > speedDice.value)
                {
                    int num = speedDiceResultValue - speedDice.value;
                    int num2 = Mathf.Min(6, num / 2);
                    if (num2 > 0)
                    {
                        curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                        {
                            power = num2
                        });
                    }
                }
            }
        }
    }

}
