

namespace BlackSilence
{
    public class PassiveAbility_Grudge : PassiveAbilityBase
    {
        public static string Name = "Relentless Grudge";
        public static string Desc = "Recover 1-3 Stagger Resist or Recover 1-3 HP on hit (Untransferable)";

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {                                
            BattleUnitModel owner = this.owner;
            if (owner == null)
            {
                return;
            }           
            if (RandomUtil.valueForProb < this._prob)
            {
                this.owner.RecoverHP(chance);
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
                this.owner.breakDetail.RecoverBreak(chance);
                BattleCardTotalResult battleCardResultLog = owner.battleCardResultLog;
                if (battleCardResultLog == null)
                {
                    return;
                }
                battleCardResultLog.SetPassiveAbility(this);
                return;
            }
        }


        int chance = RandomUtil.Range(1, 3);
        private float _prob = 0.5f;
    }

}
