namespace HunterHax
{
    public class PassiveAbility_SoulHarvest25 : PassiveAbilityBase
    {
        public override void OnKill(BattleUnitModel target)
        {
            int num = this.owner.MaxHp / 4;
            int num2 = this.owner.breakDetail.GetDefaultBreakGauge() / 4;
            this.owner.ShowPassiveTypo(this);
            this.owner.RecoverHP(num);
            this.owner.breakDetail.RecoverBreak(num2);
        }
    }

}
