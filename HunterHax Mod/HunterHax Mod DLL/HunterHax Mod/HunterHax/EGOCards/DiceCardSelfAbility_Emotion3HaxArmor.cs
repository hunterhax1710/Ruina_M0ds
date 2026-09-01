using System.Collections.Generic;

namespace HunterHax
{
    public class DiceCardSelfAbility_Emotion3HaxArmor : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Play] Gain Hax Armor next Scene. Playable at Emotion Level 3 and above";

        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "HaxArmor_Keyword",
                };
            }
        }


        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.emotionDetail.EmotionLevel >= 3;                //Emotion Level 3
        }

        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            this.owner.bufListDetail.AddKeywordBufByEtc(MyKeywords.HaxArmor, 1, null);                     //Gain Hax Armor
            unit.personalEgoDetail.RemoveCard(new LorId("NewMod", 405527));                                         //DestroyCard
            unit.bufListDetail.AddBuf(new DiceCardSelfAbility_Emotion3HaxArmor.destroy());                         //RestoreCard 
        }

        public class destroy : BattleUnitBuf
        {
            public override void OnRoundStart()
            {
                this.count++;
                if (this.count >= 7)                  //Return card to hand in 7 scenes
                {
                    this._owner.personalEgoDetail.AddCard(new LorId("NewMod", 405527));
                    this.Destroy();
                }

            }
            private int count;
        }

    }

}
