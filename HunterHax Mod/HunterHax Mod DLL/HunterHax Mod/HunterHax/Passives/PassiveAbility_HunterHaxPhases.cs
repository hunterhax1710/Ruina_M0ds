using CustomMapUtility;
using System.Runtime.CompilerServices;

namespace HunterHax
{
    public class PassiveAbility_HunterHaxPhases : PassiveAbilityBase
    {
        public static string Name = "Phases";
        public static string Desc = "Phase 2 and Phase 3; 50% more Hp and Break. Has unique EGO pages";

        public CustomMapHandler cmh = CustomMapHandler.GetCMU("NewMod");

        public override void OnWaveStart()
        {
            owner.personalEgoDetail.AddCard(new LorId("NewMod", 405526));
            owner.personalEgoDetail.AddCard(new LorId("NewMod", 405527));
            owner.personalEgoDetail.AddCard(new LorId("NewMod", 405528));
            //BGM Start
            cmh.InitCustomMap<HunterHaxMapManager>("HunterHaxMap");
            cmh.StartActAsCustomMap<HunterHaxMapManager>("HunterHaxMap");
            cmh.SetEnemyTheme("HunterHaxBGM.mp3");
        }

        public override void OnRoundStart()
        {
            BattleUnitBuf activatedBuf = this.owner.bufListDetail.GetActivatedBuf(MyKeywords.HunterHaxPhase3);
            if (activatedBuf != null && activatedBuf.stack >= 0)
            {              
               cmh.InitCustomMap<HunterHaxPhase3MapManager>("HunterHaxPhase3Map");
               cmh.ChangeToCustomMap<HunterHaxPhase3MapManager>("HunterHaxPhase3Map");
               cmh.SetEnemyTheme("HunterHaxPhase3BGM.mp3");
               cmh.EnforceMap(1);
               cmh.EnforceTheme();
               return;
            }                     
            cmh.EnforceMap(0);
            cmh.EnforceTheme();                   
        }
        //BGM END

        public override int GetMaxHpBonus()
        {
            BattleUnitBuf activatedBuf = this.owner.bufListDetail.GetActivatedBuf(MyKeywords.InvisPhase);
            if (activatedBuf != null && activatedBuf.stack == 1)
            {
                return 50;
            }
            if (activatedBuf != null && activatedBuf.stack == 2)
            {
                return 100;
            }
            return 0;
         }

        public override int GetMaxBpBonus()
        {
            BattleUnitBuf activatedBuf = this.owner.bufListDetail.GetActivatedBuf(MyKeywords.InvisPhase);
            if (activatedBuf != null && activatedBuf.stack == 1)
            {
                return 30;
            }
            if (activatedBuf != null && activatedBuf.stack == 2)
            {
                return 60;
            }
            return 0;
        }


        
    }     
}

    


