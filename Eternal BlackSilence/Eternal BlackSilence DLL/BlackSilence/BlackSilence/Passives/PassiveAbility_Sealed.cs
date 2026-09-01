

namespace BlackSilence
{
    public class PassiveAbility_Sealed : PassiveAbilityBase
    {
        public static string Name = "Unstable Shackle";
        public static string Desc = "Take 1-5 extra Stagger Damage or Damage from all sources. Destroy this passive when Returner stacks is equal or above 3 (Untransferable)";

        public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)
        {          
                BattleUnitModel owner = this.owner;
                if (owner == null)
                {
                    return;
                }
                if (RandomUtil.valueForProb < this._prob)
                {
                    this.owner.TakeBreakDamage(chance, DamageType.Card_Ability, base.owner, AtkResist.Normal, KeywordBuf.None);
                    BattleCardTotalResult battleCardResultLog = owner.battleCardResultLog;
                    if (battleCardResultLog == null)
                    {
                        return;
                    }
                    battleCardResultLog.SetPassiveAbility(this);
                    return;
                }
                else
                {
                    this.owner.TakeDamage(chance);
                    BattleCardTotalResult battleCardResultLog = owner.battleCardResultLog;
                    if (battleCardResultLog == null)
                    {
                        return;
                    }
                    battleCardResultLog.SetPassiveAbility(this);
                    return;
                }           
        }

        public override void OnRoundStart()
        {
            if (BattleUnitBuf_Returner.GetCharge(owner) >= 3)
            {
                this.owner.passiveDetail.DestroyPassive(this);
            }           
        }
        public override void OnRoundEnd()
        {
            if (BattleUnitBuf_Returner.GetCharge(owner) >= 3)
            {
                this.owner.passiveDetail.DestroyPassive(this);
            }
        }
        int chance = RandomUtil.Range(1, 5);
        private float _prob = 0.5f;
    }
}
