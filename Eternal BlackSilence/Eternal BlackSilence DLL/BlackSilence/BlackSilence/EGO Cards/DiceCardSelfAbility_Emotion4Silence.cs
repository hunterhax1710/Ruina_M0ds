

namespace BlackSilence
{
    public class DiceCardSelfAbility_Emotion4Silence : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)               //Emotion level 4
        {
            if (owner.faction == Faction.Enemy)
            {
                return true;
            }
            return owner.emotionDetail.EmotionLevel >= 4;
        }

        public override void OnUseCard()
        {
            if (owner.faction == Faction.Enemy)
            {
                return;
            }
            base.owner.personalEgoDetail.RemoveCard(new LorId("BlackSilence", 1013));
            base.owner.bufListDetail.AddBuf(new DiceCardSelfAbility_Emotion4Silence.BattleUnitBuf_destroy());
        }

        public class BattleUnitBuf_destroy : BattleUnitBuf
        {

            public override void OnRoundStart()                                          // Every 9 Scenes
            {
                this.count++;
                bool flag = this.count >= 9;
                if (flag)
                {
                    this._owner.personalEgoDetail.AddCard(new LorId("BlackSilence", 1013));
                    this.Destroy();
                }
            }

            // Token: 0x04000030 RID: 48
            private int count;
        }




    }
}
