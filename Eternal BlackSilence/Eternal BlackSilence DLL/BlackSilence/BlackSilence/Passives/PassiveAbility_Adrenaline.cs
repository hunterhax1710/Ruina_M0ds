

using LOR_DiceSystem;

namespace BlackSilence
{
    public class PassiveAbility_Adrenaline : PassiveAbilityBase
    {
        public static string Name = "You Have to Try Harder than that!";
        public static string Desc = "Choose the Speed dice with the lowest value; the Speed values of the dice change to the maximum possible value. Boost the *maximum* roll value of all dice by +3. (Untransferable)";



        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {            
            int max = 3;
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {               
                max = max
            });
        }
        public override void OnRollSpeedDice()
        {
            int minValue = 999;
            foreach (SpeedDice speedDice in this.owner.speedDiceResult)
            {
                if (speedDice.value < minValue)
                {
                    minValue = speedDice.value;
                }
            }
            foreach (SpeedDice speedDice2 in this.owner.speedDiceResult.FindAll((SpeedDice x) => x.value == minValue))
            {
                speedDice2.value = 999;
            }
            this.owner.speedDiceResult.Sort(delegate (SpeedDice d1, SpeedDice d2)
            {
                if (d1.breaked && d2.breaked)
                {
                    if (d1.value > d2.value)
                    {
                        return -1;
                    }
                    if (d1.value < d2.value)
                    {
                        return 1;
                    }
                    return 0;
                }
                else
                {
                    if (d1.breaked && !d2.breaked)
                    {
                        return -1;
                    }
                    if (!d1.breaked && d2.breaked)
                    {
                        return 1;
                    }
                    if (d1.value > d2.value)
                    {
                        return -1;
                    }
                    if (d1.value < d2.value)
                    {
                        return 1;
                    }
                    return 0;
                }
            });
        }
    }
}
