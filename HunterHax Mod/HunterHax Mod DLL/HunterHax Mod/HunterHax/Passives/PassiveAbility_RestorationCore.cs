using CustomMapUtility;
using System.Collections.Generic;

namespace HunterHax
{
    public class PassiveAbility_RestorationCore : PassiveAbilityBase
    {
        
        
        public int activated
        {
            get
            {
                return this._activated;
            }
        }
        // Token: 0x06000038 RID: 56 RVA: 0x00002C58 File Offset: 0x00000E58
        public override bool BeforeTakeDamage(BattleUnitModel attacker, int dmg)
        {
            bool result = false;
            if (this.owner.UnitData.floorBattleData.param1 == 1 && (int)(this.owner.hp - (float)dmg) < 1)           //Phase 3
            {
             this.owner.emotionDetail.LevelUp_Forcely(1);
             this.owner.bufListDetail.AddKeywordBufByCard(MyKeywords.Untargetable, 1, this.owner);
             this.owner.bufListDetail.AddKeywordBufByCard(MyKeywords.HunterHaxPhase3, 1, this.owner);   //Phase 3 Buff
             this.owner.bufListDetail.AddKeywordBufThisRoundByCard(MyKeywords.InvisPhase, 1, this.owner);
             this.owner.bufListDetail.AddBuf(new PassiveAbility_20020.OscarBuf());
             BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
             if (battleCardResultLog != null)
             {
                    battleCardResultLog.SetTakeDamagedEvent(new BattleCardBehaviourResult.BehaviourEvent(this.PrintEffect));
             }
             BattleCardTotalResult battleCardResultLog2 = this.owner.battleCardResultLog;
             if (battleCardResultLog2 != null)
             {
                    battleCardResultLog2.SetPassiveAbility(this);
             }
             List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((this.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
                foreach (BattleUnitModel battleUnitModel in aliveList)
                {
                    battleUnitModel.bufListDetail.AddKeywordBufByEtc(MyKeywords.FatalResist, 1, null);          //Inflict Fatal Resist Enemy
                }
             this.owner.SetHp(this.owner.MaxHp);
             this.owner.cardSlotDetail.RecoverPlayPoint(10);
             this.owner.allyCardDetail.DrawCards(1);
             result = true;
             this._activated++;
             this.owner.UnitData.floorBattleData.param1 = this._activated;
             this.owner.breakDetail.RecoverBreakLife(this.owner.MaxBreakLife, false);
             this.owner.breakDetail.nextTurnBreak = false;
             this.owner.turnState = BattleUnitTurnState.WAIT_CARD;
             this.owner.breakDetail.RecoverBreak(this.owner.breakDetail.GetDefaultBreakGauge());
             this.owner.breakDetail.RecoverBreakLife(this.owner.MaxBreakLife, false);
             BattleDiceCardModel battleDiceCardModel = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("NewMod", 405525)));

            }
            if (this.owner.UnitData.floorBattleData.param1 == 0 && (int)(this.owner.hp - (float)dmg) < 1)         //Phase 2
            {
                this.owner.emotionDetail.LevelUp_Forcely(1);
                this.owner.bufListDetail.AddKeywordBufByCard(MyKeywords.HunterHaxPhase2, 1, this.owner);   //Phase 2 Buff
                this.owner.bufListDetail.AddKeywordBufThisRoundByCard(MyKeywords.InvisPhase,1, this.owner);
                this.owner.bufListDetail.AddKeywordBufByCard(MyKeywords.Untargetable,1, this.owner);
                this.owner.bufListDetail.AddBuf(new PassiveAbility_20020.OscarBuf());
                BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
                if (battleCardResultLog != null)
                {
                    battleCardResultLog.SetTakeDamagedEvent(new BattleCardBehaviourResult.BehaviourEvent(this.PrintEffect));
                }
                BattleCardTotalResult battleCardResultLog2 = this.owner.battleCardResultLog;
                if (battleCardResultLog2 != null)
                {
                    battleCardResultLog2.SetPassiveAbility(this);
                }
                List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((this.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
                foreach (BattleUnitModel battleUnitModel in aliveList)
                {
                    battleUnitModel.bufListDetail.AddKeywordBufByEtc(MyKeywords.FatalResist, 1, null);   //Inflict Fatal Resist Enemy
                }
                this.owner.SetHp(this.owner.MaxHp);
                this.owner.cardSlotDetail.RecoverPlayPoint(10);
                this.owner.allyCardDetail.DrawCards(1);
                result = true;
                this._activated++;
                this.owner.UnitData.floorBattleData.param1 = this._activated;
                this.owner.breakDetail.RecoverBreakLife(this.owner.MaxBreakLife, false);
                this.owner.breakDetail.nextTurnBreak = false;
                this.owner.turnState = BattleUnitTurnState.WAIT_CARD;
                this.owner.breakDetail.RecoverBreak(this.owner.breakDetail.GetDefaultBreakGauge());
                this.owner.breakDetail.RecoverBreakLife(this.owner.MaxBreakLife, false);
                BattleDiceCardModel battleDiceCardModel = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("NewMod", 405525)));

            }
            return result;
        }
      
        // Token: 0x06000039 RID: 57 RVA: 0x00002D60 File Offset: 0x00000F60
        public override void OnRoundEndTheLast()
        {
            if (this._recoverBreak)
            {
                if (this.owner.breakDetail.IsBreakLifeZero())
                {
                    this.owner.RecoverBreakLife(this.owner.MaxBreakLife, false);
                    this.owner.breakDetail.nextTurnBreak = false;
                }
                this.owner.breakDetail.RecoverBreak(this.owner.breakDetail.GetDefaultBreakGauge());
                this._recoverBreak = false;
            }
        }

        public override void OnRoundStart()
        {
            if(owner.faction == Faction.Enemy)
            {
                this.owner.allyCardDetail.DrawCards(10);
                this.owner.cardSlotDetail.RecoverPlayPoint(10);
            }
        }






        // Token: 0x0600003A RID: 58 RVA: 0x000021F0 File Offset: 0x000003F0
        private void PrintEffect()
        {
        }

        // Token: 0x0400000C RID: 12
        private int _activated;
        

        // Token: 0x0400000E RID: 14
        private bool _recoverBreak;
    }

}
