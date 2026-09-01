using System.Collections.Generic;

namespace HunterHax
{
    public class DiceCardSelfAbility_Emotion2ZeroPower : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Play] Reduce all damage from enemies to 0. Reduce cost of all Pages by 1. Playable at Emotion Level 2 and above";

        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
            "ZeroPower_Keyword",
                };
            }
        }


        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.emotionDetail.EmotionLevel >= 2;                //Emotion Level 2
        }

        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((this.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
            base.owner.bufListDetail.AddBuf(new DiceCardSelfAbility_Emotion2ZeroPower.BattleUnitbuf_costdown1());
            foreach (BattleUnitModel battleUnitModel in aliveList)
            {
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByEtc(MyKeywords.ZeroPower, 1, null);          //Inflict Zero Power Enemy
            }
            unit.personalEgoDetail.RemoveCard(new LorId("NewMod", 405526));                                         //DestroyCard
            unit.bufListDetail.AddBuf(new DiceCardSelfAbility_Emotion2ZeroPower.destroy());
        }

        public class destroy : BattleUnitBuf
        {
            public override void OnRoundStart()
            {
              this.count++;
              if (this.count >= 7)                  //Return card to hand in 7 scenes
              {
               this._owner.personalEgoDetail.AddCard(new LorId("NewMod", 405526));
               this.Destroy();
              }
                
            }
            private int count;
        }

        public class BattleUnitbuf_costdown1 : BattleUnitBuf              //cost down 1
        {
            public override int GetCardCostAdder(BattleDiceCardModel card)
            {
                return -1;
            }

            public override void OnRoundEnd()
            {
                this.Destroy();
            }
        }

    }
}
