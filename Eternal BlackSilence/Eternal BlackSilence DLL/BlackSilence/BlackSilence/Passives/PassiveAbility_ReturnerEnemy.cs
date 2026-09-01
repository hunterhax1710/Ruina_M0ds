
using LOR_DiceSystem;

namespace BlackSilence
{
    public class PassiveAbility_ReturnerEnemy : PassiveAbilityBase
    {
        public static string Name = "The Returner";
        public static string Desc = "Starts at Emotional Level 2. “Returner” triggers upon taking fatal damage, restores all HP and Stagger. “Returner” triggers up to the current emotion level. When “Returner” is triggered, max health value is increased by 50, max break value is increased by 30 and become invulnerable to status ailments. (Untransferable)";
        public override void OnWaveStart()
        {
            if (this.owner.Book.GetBookClassInfoId() == new LorId("BlackSilence", 1) || this.owner.Book.GetBookClassInfoId() == new LorId("BlackSilence", 1000000))
            {
                BattleUnitBuf_Returner.GainCharge(this.owner, 0);
                if (this.owner.emotionDetail.EmotionLevel <= 2)                                   //Set Emotion to 2
                {
                    this.owner.emotionDetail.SetEmotionLevel(2);
                    foreach (BattleUnitBuf battleUnitBuf in this.owner.bufListDetail.GetReadyBufList())
                    {
                        if (battleUnitBuf.positiveType == BufPositiveType.Negative)
                        {
                            battleUnitBuf.Destroy();
                        }
                    }
                    foreach (BattleUnitBuf battleUnitBuf2 in this.owner.bufListDetail.GetActivatedBufList())
                    {
                        if (battleUnitBuf2.positiveType == BufPositiveType.Negative)
                        {
                            battleUnitBuf2.Destroy();
                        }
                    }
                }
            }
            if (this.owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Returner) == null)
            {
                BattleUnitBuf_Returner.GainCharge(this.owner, 0);
            }
        }      
        public override int GetMaxHpBonus()                             //Max HP: 80 + 250 = 330
        {
            if (BattleUnitBuf_Returner.GetCharge(this.owner) >= 1)
            {
                return 50 * BattleUnitBuf_Returner.GetCharge(this.owner);
            }
            return 0;
        }
        public override int GetMaxBpBonus()                            //Max BP: 60 + 150 = 210
        {
            if (BattleUnitBuf_Returner.GetCharge(this.owner) >= 1)
            {
                return 30 * BattleUnitBuf_Returner.GetCharge(this.owner);
            }
            return 0;
        }       
        public override bool IsImmune(KeywordBuf buf)
        {
         if(Immune)
         {
            return buf == KeywordBuf.Seal || buf == KeywordBuf.SealKeyword || buf == KeywordBuf.NullifyPower || base.IsImmune(buf);
         }
           return base.IsImmune(buf);
        }
        public override void OnRoundStart()
        {
            ChangeResist();
            BattleUnitBuf activatedBuf = this.owner.bufListDetail.GetActivatedBuf(MyKeywords.Returner);
            if (activatedBuf != null && activatedBuf.stack >= 3)                  
            {
                if (!base.owner.passiveDetail.HasPassive<PassiveAbility_BlackSilenceChange>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_BlackSilenceChange>())
                {
                    base.owner.passiveDetail.AddPassive(new LorId("BlackSilence", (21)));         //Change Skin
                }
                if (!base.owner.passiveDetail.HasPassive<PassiveAbility_Eternity>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_Eternity>())
                {
                    base.owner.passiveDetail.AddPassive(new LorId("BlackSilence", (21111)));        //Gain Eternal Silence
                }
                if (!base.owner.passiveDetail.HasPassive<PassiveAbility_Adrenaline>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_Adrenaline>())
                {
                    base.owner.passiveDetail.AddPassive(new LorId("BlackSilence", (7)));           //Gain Adrenaline
                }
                if (!base.owner.passiveDetail.HasPassive<PassiveAbility_Grudge>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_Grudge>())
                {
                    base.owner.passiveDetail.AddPassive(new LorId("BlackSilence", (4)));           //Gain Grudge
                }
            }
            if (activatedBuf == null)                                                    //Gain returner again if it is purged
            {
                BattleUnitBuf_Returner.GainCharge(this.owner, 0);
            }
            foreach (BattleUnitBuf battleUnitBuf in this.owner.bufListDetail.GetActivatedBufList())
            {
                if (battleUnitBuf.bufType == KeywordBuf.Seal || battleUnitBuf.bufType == KeywordBuf.NullifyPower || battleUnitBuf.bufType == KeywordBuf.SealKeyword)
                {
                    battleUnitBuf.Destroy();
                }
            }
            foreach (BattleUnitBuf battleUnitBuf in this.owner.bufListDetail.GetReadyBufList())
            {
                if (battleUnitBuf.bufType == KeywordBuf.Seal || battleUnitBuf.bufType == KeywordBuf.NullifyPower || battleUnitBuf.bufType == KeywordBuf.SealKeyword)
                {
                    battleUnitBuf.Destroy();
                }
            }
         
        }
        public override void OnRoundEnd()
        {
            ChangeResist();
            BattleUnitBuf activatedBuf = this.owner.bufListDetail.GetActivatedBuf(MyKeywords.Returner);
            if (activatedBuf != null && activatedBuf.stack >= 3)
            {
                if (!base.owner.passiveDetail.HasPassive<PassiveAbility_BlackSilenceChange>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_BlackSilenceChange>())
                {
                    base.owner.passiveDetail.AddPassive(new LorId("BlackSilence", (21)));         //Change Skin
                }
                if (!base.owner.passiveDetail.HasPassive<PassiveAbility_Eternity>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_Eternity>())
                {
                    base.owner.passiveDetail.AddPassive(new LorId("BlackSilence", (21111)));        //Gain Eternal Silence
                }
                if (!base.owner.passiveDetail.HasPassive<PassiveAbility_Adrenaline>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_Adrenaline>())
                {
                    base.owner.passiveDetail.AddPassive(new LorId("BlackSilence", (7)));           //Gain Adrenaline
                }
                if (!base.owner.passiveDetail.HasPassive<PassiveAbility_Grudge>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_Grudge>())
                {
                    base.owner.passiveDetail.AddPassive(new LorId("BlackSilence", (4)));           //Gain Grudge
                }
            }
            if (activatedBuf == null)                                                    //Gain returner again if it is purged
            {
                BattleUnitBuf_Returner.GainCharge(this.owner, 0);
            }
        }
        public void ChangeResist()                //Change Resistance
        {
            if (BattleUnitBuf_Returner.GetCharge(owner) == 2 && stage != 2 && stage != 3 && stage != 4 && stage != 5)
            {
                stage = 2;
                this.owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Endure);
            }
            if (BattleUnitBuf_Returner.GetCharge(owner) == 3 && stage != 3 && stage != 4 && stage != 5)
            {
                stage = 3;
                this.owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Endure);
            }
            if (BattleUnitBuf_Returner.GetCharge(owner) == 4 && stage != 4 && stage != 5)
            {
                stage = 4;
                this.owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Endure);
            }
            if (BattleUnitBuf_Returner.GetCharge(owner) == 5 && stage != 5)
            {
                stage = 5;
                this.owner.Book.SetResistHP(BehaviourDetail.Hit, AtkResist.Resist);
            }           

            if (stage == 2)
            {
                this.owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Endure);                
            }
            if (stage == 3)
            {
                this.owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Endure);
                this.owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Endure);                
            }
            if (stage == 4)
            {
                this.owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Endure);
                this.owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Endure);
                this.owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Endure);               
            }
            if (stage == 5)
            {
                this.owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Endure);
                this.owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Endure);
                this.owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Endure);
                this.owner.Book.SetResistHP(BehaviourDetail.Hit, AtkResist.Endure);
            }
        }

       

        private int stage;
        public bool Immune = false;
    }
}












    


