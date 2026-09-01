using static UnityEngine.GraphicsBuffer;

namespace HunterHax
{
    // Token: 0x0200000D RID: 13
    public class DiceCardAbility_fullcounter : DiceCardAbilityBase
    {
        // Token: 0x06000025 RID: 37 RVA: 0x00002129 File Offset: 0x00000329
        public override void OnWinParryingDefense()
        {

            if (this.behavior.TargetDice != null)
            {
                base.card.target.TakeBreakDamage(this.behavior.TargetDice.DiceResultValue, DamageType.Card_Ability, base.owner, AtkResist.Normal, KeywordBuf.None);
                base.card.target.TakeDamage(this.behavior.TargetDice.DiceResultValue, DamageType.Card_Ability, base.owner, KeywordBuf.None);
            }
        }

        public static string Desc = "[On Clash Win] Return blocked damage to the attacker";
    }

}
