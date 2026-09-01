

namespace BlackSilence
{
    public class DiceCardAbility_absorblight1 : DiceCardAbilityBase
    {       
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
        public override void OnSucceedAttack(BattleUnitModel target)
        {           
            if (target != null)
            {               
                target.cardSlotDetail.LoseWhenStartRound(1);
                if (target.cardSlotDetail.PlayPoint > 0)
                {
                    base.owner.cardSlotDetail.RecoverPlayPointByCard(1);
                }                           
            }
        }
     
    }
}
