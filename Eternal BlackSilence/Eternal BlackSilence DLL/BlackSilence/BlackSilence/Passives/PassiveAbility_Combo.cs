

namespace BlackSilence
{
    public class PassiveAbility_Combo : PassiveAbilityBase
    {
        public static string Name = "Combo";
        public static string Desc = "All dice on every 5th Combat Page used gain +5 Power.";
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (this._count == 5)
            {
                curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 5
                });
                this._count = 0;
            }
            else
            {
                this._count++;
            }
            this.owner.bufListDetail.RemoveBufAll(typeof(BattleUnitBuf_ComboCardCount));
            if (this._count > 0)
            {
                this.owner.bufListDetail.AddBuf(new PassiveAbility_Combo.BattleUnitBuf_ComboCardCount
                {
                    stack = this._count
                });
            }
        }    
        public class BattleUnitBuf_ComboCardCount : BattleUnitBuf
        {
            public override string keywordId => "ComboCardCount";
            public string KeywordBufName => "ComboCardCount";
            public ref KeywordBuf KeywordBuf => ref MyKeywords.ComboCardCount;
            public override KeywordBuf bufType
            {
                get
                {
                    return this.KeywordBuf;

                }
            }
            public override BufPositiveType positiveType
            {
                get
                {
                    return BufPositiveType.Positive;
                }
            }
            public override void OnRoundStart()
            {
                if (this.stack >= 5)
                {
                    this.stack = 5;
                }
                if (this.stack == 0)
                {
                    this.Destroy();
                }
            }
            public override void OnRoundEnd()
            {
                if (this.stack >= 5)
                {

                    this.stack = 5;
                }
                if (this.stack == 0)
                {
                    this.Destroy();
                }
            }
        }



        private int _count;
    }
}
