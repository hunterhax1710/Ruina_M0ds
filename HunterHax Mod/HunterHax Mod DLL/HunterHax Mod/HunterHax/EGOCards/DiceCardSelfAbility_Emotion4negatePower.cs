using static UnityEngine.UI.CanvasScaler;

namespace HunterHax
{
    public class DiceCardSelfAbility_Emotion4negatePower : DiceCardSelfAbilityBase
    {
        public static string Desc = "Dice on this page and the page clashing with it are unaffected by Power gain or loss. Playable at Emotion Level 4 and above";


        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.emotionDetail.EmotionLevel >= 4;                //Emotion Level 4
        }


        public override void OnUseCard()
        {
            this.card.ignorePower = true;
            this.owner.personalEgoDetail.RemoveCard(new LorId("NewMod", 405528));                                         //DestroyCard
            this.owner.bufListDetail.AddBuf(new DiceCardSelfAbility_Emotion4negatePower.destroy());
        }     
        public override void OnStartParrying()
        {
            BattleUnitModel target = this.card.target;
            if (target == null || target.currentDiceAction == null)
            {
                return;
            }
            target.currentDiceAction.ignorePower = true;
        }
        public class destroy : BattleUnitBuf
        {
            public override void OnRoundStart()
            {
                this.count++;
                if (this.count >= 7)                  //Return card to hand in 7 scenes
                {
                    this._owner.personalEgoDetail.AddCard(new LorId("NewMod", 405528));
                    this.Destroy();
                }

            }
            private int count;
        }

    }
}
