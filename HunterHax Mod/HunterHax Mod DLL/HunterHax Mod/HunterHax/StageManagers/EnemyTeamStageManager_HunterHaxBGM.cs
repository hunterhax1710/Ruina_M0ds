using CustomMapUtility;

namespace HunterHax
{
    public class EnemyTeamStageManager_HunterHaxBGM : EnemyTeamStageManager
    {
        public CustomMapHandler cmh = CustomMapHandler.GetCMU("NewMod");
        public override void OnWaveStart()
        {
            // This method must be called somewhere, and only once. StageManager or Passive in the OnWaveStart() method is recommended.
            // You MUST have <MapInfo>Template</MapInfo> inside your StageInfo.xml file. (Replace Template with your stage name)

            // When you call this method, you supply the stage name and then your map manager.
            cmh.InitCustomMap<HunterHaxMapManager>("HunterHaxMap");
            cmh.SetEnemyTheme("HunterHaxBGM.mp3");
            cmh.StartActAsCustomMap<HunterHaxMapManager>("HunterHaxMap");
        }
        public override void OnRoundStart()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList(Faction.Enemy))
            {
                if (BattleUnitBuf_HunterHaxPhase3.GetCharge(battleUnitModel) >= 0)
                {                   
                    cmh.InitCustomMap<HunterHaxPhase3MapManager>("HunterHaxPhase3Map");
                    cmh.SetEnemyTheme("HunterHaxPhase3BGM.mp3");
                    cmh.ChangeToCustomMap<HunterHaxPhase3MapManager>("HunterHaxPhase3Map");
                    cmh.EnforceMap(1);
                    cmh.EnforceTheme();
                    return;
                }             
            }
            cmh.EnforceMap(0);
            cmh.EnforceTheme();
        }


       
    }
}
