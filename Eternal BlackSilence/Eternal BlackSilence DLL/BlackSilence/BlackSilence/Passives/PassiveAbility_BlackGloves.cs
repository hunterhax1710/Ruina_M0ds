

namespace BlackSilence
{
    public class PassiveAbility_BlackGloves : PassiveAbilityBase
    {
        public static string Name = "Black Gloves";
        public static string Desc = "All dice on the page selected in the third Speed dice slot gain +3 Power.";
        
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            base.OnUseCard(curCard);
            if (curCard.slotOrder == 2)                      //3rd slot gain +3 power
            {
                curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 3
                });
                BattleUnitModel owner = this.owner;
                if (owner == null)
                {
                    return;
                }
                BattleCardTotalResult battleCardResultLog = owner.battleCardResultLog;
                if (battleCardResultLog == null)
                {
                    return;
                }
                battleCardResultLog.SetPassiveAbility(this);
            }
        }
    }

}
