namespace HunterHax
{
    // Token: 0x02000003 RID: 3
    public class DiceCardAbility_drainEnergy2atk : DiceCardAbilityBase
    {
        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000003 RID: 3 RVA: 0x000022C4 File Offset: 0x000004C4
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "Energy_Keyword"
                };
            }
        }

        // Token: 0x06000004 RID: 4 RVA: 0x000022E4 File Offset: 0x000004E4
        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            bool flag = target == null;
            if (!flag)
            {
                base.owner.cardSlotDetail.RecoverPlayPointByCard(2);
                target.cardSlotDetail.LoseWhenStartRound(2);
            }
        }
    }

}
