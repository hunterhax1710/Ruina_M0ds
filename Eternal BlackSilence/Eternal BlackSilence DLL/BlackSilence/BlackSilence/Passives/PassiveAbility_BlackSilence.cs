using CustomMapUtility;

namespace BlackSilence
{
    public class PassiveAbility_BlackSilence : PassiveAbilityBase
    {
        public static string Name = "The Black Silence";
        public static string Desc = "Has unique EGO pages and BGM. (Untransferrable)";

        public CustomMapHandler cmh = CustomMapHandler.GetCMU("BlackSilence");

        public override void OnWaveStart()
        {
            this.owner.personalEgoDetail.AddCard(new LorId("BlackSilence", 1003));                      
            this.owner.personalEgoDetail.AddCard(new LorId("BlackSilence", 1013));
            this.owner.personalEgoDetail.AddCard(new LorId("BlackSilence", 1009));
            this.owner.personalEgoDetail.AddCard(new LorId("BlackSilence", 1012));            
            BattleUnitBuf activatedBuf = this.owner.bufListDetail.GetActivatedBuf(MyKeywords.Returner);
            if (activatedBuf != null && activatedBuf.stack >= 3 && phase != 2)
            {
                phase = 2;
                cmh.InitCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                cmh.StartActAsCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                cmh.SetEnemyTheme("BlackSilence2BGM.mp3");               
                return;
            }
            if (phase == 2)
            {
                cmh.InitCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                cmh.StartActAsCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                cmh.SetEnemyTheme("BlackSilence2BGM.mp3");
                return;

            }
            cmh.InitCustomMap<BlackSilence1MapManager>("BlackSilenceMap1");
            cmh.StartActAsCustomMap<BlackSilence1MapManager>("BlackSilenceMap1");
            cmh.SetEnemyTheme("BlackSilence1BGM.mp3");
        }
        public override void OnRoundStart()
        {           
            BattleUnitBuf activatedBuf = this.owner.bufListDetail.GetActivatedBuf(MyKeywords.Returner);
            if (activatedBuf != null && activatedBuf.stack >= 3 && phase !=2)
            {
                phase = 2;
                cmh.InitCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                cmh.ChangeToCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                cmh.EnforceMap(1);
                cmh.SetEnemyTheme("BlackSilence2BGM.mp3");
                cmh.EnforceTheme();
                return;
            } 
            if (phase == 2)
            {
                cmh.InitCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                cmh.ChangeToCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                cmh.EnforceMap(1);
                cmh.SetEnemyTheme("BlackSilence2BGM.mp3");
                cmh.EnforceTheme();
                return;
            }         
            cmh.EnforceMap(0);
            cmh.EnforceTheme();
        }
        private int phase;
    }
}

    

