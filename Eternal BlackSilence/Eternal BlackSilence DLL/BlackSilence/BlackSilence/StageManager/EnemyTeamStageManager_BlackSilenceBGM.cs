using CustomMapUtility;
using HarmonyLib;
using System.Collections.Generic;

namespace BlackSilence
{
    public class EnemyTeamStageManager_BlackSilenceBGM : EnemyTeamStageManager
    {
        public CustomMapHandler cmh = CustomMapHandler.GetCMU("BlackSilence");
        public override void OnWaveStart()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList(Faction.Enemy))
            {
                if (BattleUnitBuf_Returner.GetCharge(battleUnitModel) >= 3 && phase != 2)
                {
                    phase = 2;
                    cmh.InitCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                    cmh.ChangeToCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                    cmh.SetEnemyTheme("BlackSilence2BGM.mp3");
                    return;
                }
                if (phase == 2)
                {
                    cmh.InitCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                    cmh.ChangeToCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                    cmh.SetEnemyTheme("BlackSilence2BGM.mp3");
                    return;
                }

            }           
            cmh.InitCustomMap<BlackSilence1MapManager>("BlackSilenceMap1");
            cmh.StartActAsCustomMap<BlackSilence1MapManager>("BlackSilenceMap1");
            cmh.SetEnemyTheme("BlackSilence1BGM.mp3");
        }
        public override void OnRoundStart()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList(Faction.Enemy))
            {
               if (BattleUnitBuf_Returner.GetCharge(battleUnitModel) >= 3 && phase != 2)
               {
                    phase = 2;
                    cmh.InitCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                    cmh.ChangeToCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                    cmh.SetEnemyTheme("BlackSilence2BGM.mp3");
                    cmh.EnforceMap(1);
                    cmh.EnforceTheme();
                    return;
               }
                if (phase == 2)
                {
                    cmh.InitCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                    cmh.ChangeToCustomMap<BlackSilence2MapManager>("BlackSilenceMap2");
                    cmh.SetEnemyTheme("BlackSilence2BGM.mp3");
                    return;

                }
            }           
            cmh.EnforceMap(0);
            cmh.EnforceTheme();
        }


        private int phase;
    }
}
