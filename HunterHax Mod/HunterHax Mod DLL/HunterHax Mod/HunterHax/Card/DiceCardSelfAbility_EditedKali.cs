using System.Collections.Generic;

namespace HunterHax
{
    // Token: 0x02000012 RID: 18
    public class DiceCardSelfAbility_EditedKali : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Gain 2 Strength this Scene. If target is defeated or Staggered, use this page again on a random enemy";
        // Token: 0x06000032 RID: 50 RVA: 0x00002B04 File Offset: 0x00000D04
        public override void OnUseCard()
        {
            base.owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Strength, 2, base.owner);
            this._isBreakedStart = false;
            if (this.card.target != null && this.card.target.IsBreakLifeZero())
            {
                this._isBreakedStart = true;
            }
        }

        // Token: 0x06000033 RID: 51 RVA: 0x00002B58 File Offset: 0x00000D58
        public override void OnEndBattle()
        {
            if (this.card.target != null && (this.card.target.IsDead() || (!this._isBreakedStart && this.card.target.IsBreakLifeZero())))
            {
                List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
                if (aliveList.Count > 0)
                {
                    BattleUnitModel target = RandomUtil.SelectOne<BattleUnitModel>(aliveList);
                    Singleton<StageController>.Instance.AddAllCardListInBattle(this.card, target, -1);
                }
            }
        }
        

        // Token: 0x17000006 RID: 6
        // (get) Token: 0x06000035 RID: 53 RVA: 0x000021E0 File Offset: 0x000003E0
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "Strength_Keyword"
                };
            }
        }

        // Token: 0x0400000B RID: 11
        private bool _isBreakedStart;
    }

}
