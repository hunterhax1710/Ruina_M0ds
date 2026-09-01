

namespace BlackSilence
{
    public class DiceCardAbility_quickness3atk : DiceCardAbilityBase
    {
        // Token: 0x170004DB RID: 1243
        // (get) Token: 0x06003468 RID: 13416 RVA: 0x0011B0B8 File Offset: 0x001192B8
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                "Quickness_Keyword"
                };
            }
        }

        // Token: 0x06003469 RID: 13417 RVA: 0x0012E853 File Offset: 0x0012CA53
        public override void OnSucceedAttack()
        {
            BattleUnitModel owner = base.owner;
            if (owner == null)
            {
                return;
            }
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Quickness, 3, base.owner);
        }
    }
}
