namespace HunterHax
{

    public class DiceCardAbility_escalateStrength : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Boost last die's max value by +10; Deal 50% more damage against targets with 50% or less HP";
        // Token: 0x06000022 RID: 34 RVA: 0x000020E1 File Offset: 0x000002E1
        public override void BeforeGiveDamage(BattleUnitModel target)
        {
            if (target == null)
            {
                return;
            }
            if (target.hp <= (float)target.MaxHp * 0.5f)
            {
                this.behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    dmgRate = 50
                });
            }
        }

        // Token: 0x06000023 RID: 35 RVA: 0x00002114 File Offset: 0x00000314
        public override void OnSucceedAttack()
        {
            base.card.AddDiceMaxValue(DiceMatch.LastDice, 10);
        }
    }
}
