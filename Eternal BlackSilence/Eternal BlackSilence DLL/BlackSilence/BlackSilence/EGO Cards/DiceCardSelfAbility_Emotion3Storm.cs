

namespace BlackSilence
{
    public class DiceCardSelfAbility_Emotion3Storm : DiceCardSelfAbilityBase
    {
        
        public override void OnUseCard()
        {
            this.card.ignorePower = true;
            base.owner.personalEgoDetail.RemoveCard(new LorId("BlackSilence", 1003));
            base.owner.bufListDetail.AddBuf(new DiceCardSelfAbility_Emotion3Storm.BattleUnitBuf_destroy1());
        }
        public override bool OnChooseCard(BattleUnitModel owner)               //Emotion level 3
        {
            return owner.emotionDetail.EmotionLevel >= 3;
        }

        public class BattleUnitBuf_destroy1 : BattleUnitBuf
        {
           
            public override void OnRoundStart()                                          // Every 7 Scenes
            {
                this.count++;
                bool flag = this.count >= 6;
                if (flag)
                {
                    this._owner.personalEgoDetail.AddCard(new LorId("BlackSilence", 1003));
                    this.Destroy();
                }
            }

            // Token: 0x04000030 RID: 48
            private int count;
        }

    }
}
