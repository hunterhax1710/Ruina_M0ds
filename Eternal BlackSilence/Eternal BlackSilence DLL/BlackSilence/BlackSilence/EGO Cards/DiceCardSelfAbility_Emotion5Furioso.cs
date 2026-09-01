

using System.Collections.Generic;

namespace BlackSilence
{
    public class DiceCardSelfAbility_Emotion5Furioso : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)               //Emotion level 5 and Returner 3
        {
            if (owner.faction == Faction.Enemy)
            {
                return true;
            }
            return owner.emotionDetail.EmotionLevel >= 5 && BattleUnitBuf_Returner.GetCharge(owner) >= 3; 
        }    

        public override void OnUseCard()
        {
            if (owner.faction == Faction.Enemy)
            {
                this.card.ignorePower = true;
                return;
            }
            this.card.ignorePower = true;
            base.owner.personalEgoDetail.RemoveCard(new LorId("BlackSilence", 1012));
            base.owner.bufListDetail.AddBuf(new DiceCardSelfAbility_Emotion5Furioso.BattleUnitBuf_destroy());  
        }
       
        public override void OnSucceedAttack()                                   //On Hit Destroy every page
        {
            if (this.card.target != null)
            {
                BattleUnitModel target = this.card.target;
                int targetSlotOrder = this.card.targetSlotOrder;
                List<BattlePlayingCardDataInUnitModel> list = new List<BattlePlayingCardDataInUnitModel>();
                for (int i = 0; i < target.cardSlotDetail.cardAry.Count; i++)
                {
                    if (i != targetSlotOrder)
                    {
                        BattlePlayingCardDataInUnitModel battlePlayingCardDataInUnitModel = target.cardSlotDetail.cardAry[i];
                        if (battlePlayingCardDataInUnitModel != null && !battlePlayingCardDataInUnitModel.isDestroyed && battlePlayingCardDataInUnitModel.GetDiceBehaviorList().Count > 0)
                        {
                            list.Add(battlePlayingCardDataInUnitModel);
                        }
                    }
                }
                if (list.Count > 0)
                {
                    for (int f = 0; f < 15; f++)                          //Destroy 15 pages
                    {
                        RandomUtil.SelectOne<BattlePlayingCardDataInUnitModel>(list).DestroyPlayingCard();
                    }                    
                }
            }
        }

        public class BattleUnitBuf_destroy : BattleUnitBuf
        {

            public override void OnRoundStart()                                          // 7 Scenes cooldown
            {
                this.count++;
                bool flag = this.count >= 7;
                if (flag)
                {
                    this._owner.personalEgoDetail.AddCard(new LorId("BlackSilence", 1012));
                    this.Destroy();
                }
            }

            // Token: 0x04000030 RID: 48
            private int count;
        }




    }
}
