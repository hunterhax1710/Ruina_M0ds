using static UnityEngine.UI.CanvasScaler;

namespace HunterHax
{
    public class DiceCardAbility_DistortionBlade : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Enemies become Uncontrollable and attacks allies.";

        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "Distortion_Keyword",
                };
            }
        }     
        public override void OnSucceedAreaAttack(BattleUnitModel target)
        {

            if (target != null)
            {
                target.bufListDetail.AddKeywordBufByCard(MyKeywords.Distortion, 1, base.owner);
            }
        }
    }
}
