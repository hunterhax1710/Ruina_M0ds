
namespace BlackSilence
{
    public class PassiveAbility_Eternity : PassiveAbilityBase
    {
        public static string Name = "Eternal Silence";
        public static string Desc = "Every 10 Scenes. Reduce 1 stack of Returner";

        public override void OnRoundStart()
        {
            round++;
        }

        public override void OnRoundEnd()                 
        {
            if (round == 10)
            {
                round = 0;
                BattleUnitBuf_Returner.ReduceCharge(owner, 1);
            }
            this.owner.bufListDetail.RemoveBufAll(typeof(BattleUnitBuf_Returner2));
            if (round > 0)
            {
                this.owner.bufListDetail.AddBuf(new PassiveAbility_Eternity.BattleUnitBuf_Returner2
                {
                    stack = round
                });
            }
        }


        public class BattleUnitBuf_Returner2 : BattleUnitBuf
        {
            public override string keywordId => "Returner2";
            public string KeywordBufName => "Returner2";
            public ref KeywordBuf KeywordBuf => ref MyKeywords.Returner2;
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
                    return BufPositiveType.None;
                }
            }           
            public override void OnRoundStart()
            {
                if (this.stack >= 10)
                {
                    this.stack = 10;
                }
                if (this.stack == 0)
                {
                    this.Destroy();
                }
            }
            public override void OnRoundEnd()
            {
                if (this.stack >= 10)
                {
                    this.stack = 10;
                }
                if (this.stack == 0)
                {
                    this.Destroy();
                }
            }
        }



        private int round;
    }
}
