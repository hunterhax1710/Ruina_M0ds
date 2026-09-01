
namespace BlackSilence
{
    public class DiceCardSelfAbility_Emotion4Eternal : DiceCardSelfAbilityBase
    {
        // Token: 0x0600113C RID: 4412 RVA: 0x0004D518 File Offset: 0x0004B718
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            if (!base.owner.passiveDetail.HasPassive<PassiveAbility_Eternity>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_Eternity>())
            {
                base.owner.passiveDetail.AddPassive(new LorId("BlackSilence", (21111)));                       //Gain Eternal Silence
            }
            self.exhaust = true;
            unit.personalEgoDetail.RemoveCard(new LorId("BlackSilence", 1009));          
        }

        
        public override bool OnChooseCard(BattleUnitModel owner)               //Emotion level 4 and Retuner charge above 3
        {
            return owner.emotionDetail.EmotionLevel >= 4 && BattleUnitBuf_Returner.GetCharge(owner) >= 3;
        }          
    }
}

