using UnityEngine.SceneManagement;

namespace HunterHax
{
    // Token: 0x0200000F RID: 15
    public class DiceCardAbility_repeat4burn2 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 2 Burn next Scene.This die is rolled 4 times";
        // Token: 0x06000029 RID: 41 RVA: 0x00002177 File Offset: 0x00000377
        public override void AfterAction()
        {
            if (!base.owner.IsBreakLifeZero() && this._repeatCount < 3)
            {
                this._repeatCount++;
                base.ActivateBonusAttackDice();
            }
        }

        // Token: 0x0600002A RID: 42 RVA: 0x00002A90 File Offset: 0x00000C90
        public override void OnSucceedAttack()
        {
            BattleUnitModel target = base.card.target;
            if (target == null)
            {
                return;
            }
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Burn, 2, base.owner);
        }

        // Token: 0x17000004 RID: 4
        // (get) Token: 0x0600002C RID: 44 RVA: 0x000021A3 File Offset: 0x000003A3
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "Burn_Keyword"
                };
            }
        }

        // Token: 0x0400000A RID: 10
        private int _repeatCount;

        
    }

}
