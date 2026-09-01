

namespace BlackSilence
{
    public class DiceCardAbility_destroyalldiceImmune : DiceCardAbilityBase
    {
        private int rawDamage;



        public override bool IsImmuneDestory
        {
            get
            {
                return true;
            }
        }
        public override void BeforeGiveDamage(BattleUnitModel target)
        {
            // Save the natural dice roll result
            rawDamage = this.behavior.DiceResultValue;

            this.behavior.SetDamageRedution(this.behavior.DiceResultValue);                 //Removes Dice Dmg and change it so that it only deal bonus Dmg
        }
        // Token: 0x06003397 RID: 13207 RVA: 0x0011D9F7 File Offset: 0x0011BBF7
        public override void OnSucceedAttack()
        {
            BattlePlayingCardDataInUnitModel card = base.card;
            if (card == null)
            {
                return;
            }
            BattleUnitModel target = card.target;
            if (target == null)
            {
                return;
            }
            BattlePlayingCardDataInUnitModel currentDiceAction = target.currentDiceAction;
            if (currentDiceAction == null)
            {
                return;
            }
            target.TakeDamage(rawDamage, DamageType.Card_Ability, base.owner, KeywordBuf.None);                                //Bypass Resistance
            target.TakeBreakDamage(rawDamage, DamageType.Card_Ability, base.owner, AtkResist.Normal, KeywordBuf.None);   //Bypass Stagger Resistance
            currentDiceAction.DestroyDice(DiceMatch.AllDice, DiceUITiming.Start);
        }
    }
}
