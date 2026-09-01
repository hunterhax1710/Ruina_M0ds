using AutoKeywordUtil;
using LOR_DiceSystem;


namespace HunterHax
{
    public class BattleUnitBuf_HaxArmor : BattleUnitBuf, IRefKeywordBuf
    {
        public override string keywordId => "HaxArmor";
        public string KeywordBufName => "HaxArmor";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.HaxArmor;
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
        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            this.stack = 0;
            this.round = 4;                      //Last 3 Scenes 
        }

        public override double ChangeDamage(BattleUnitModel attacker, double dmg)
        {
            bool flag = dmg > (double)((float)this._owner.MaxHp * 0.05f);             //Takes 5% Max Hp as Max Damage
            double result;
            if (flag)
            {
                result = (double)((float)this._owner.MaxHp * 0.05f);
            }
            else
            {
                result = base.ChangeDamage(attacker, dmg);
            }
            return result;
        }
        public override void OnRoundStart()
        {
            this.round--;
            this.UpdateResist();
            bool flag = this._owner.Book.GetBookClassInfoId() == new LorId("NewMod", 2) || this._owner.Book.GetBookClassInfoId() == new LorId("NewMod", 10000002);
        }

        public override void OnRoundEnd()
        {
            if (this.round == 1)
            {
                this._owner.Book.SetResistHP(BehaviourDetail.Slash, AtkResist.Endure);
                this._owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Normal);
                this._owner.Book.SetResistHP(BehaviourDetail.Hit, AtkResist.Endure);
                this._owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Normal);
                this._owner.Book.SetResistBP(BehaviourDetail.Penetrate, AtkResist.Endure);
                this._owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Normal);
                this.Destroy();
            }
        }

        private void UpdateResist()
        {
            BehaviourDetail detail = RandomUtil.SelectOne<BehaviourDetail>(new BehaviourDetail[]
            {
                BehaviourDetail.Slash,
                BehaviourDetail.Penetrate,
                BehaviourDetail.Hit
            });
            this._owner.Book.SetResistHP(BehaviourDetail.Slash, AtkResist.Endure);
            this._owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Normal);
            this._owner.Book.SetResistHP(BehaviourDetail.Hit, AtkResist.Endure);
            this._owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Normal);
            this._owner.Book.SetResistBP(BehaviourDetail.Penetrate, AtkResist.Endure);
            this._owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Normal);
            this._owner.Book.SetResistHP(detail, AtkResist.Immune);
            this._owner.Book.SetResistBP(detail, AtkResist.Immune);
        }

        public override int paramInBufDesc
        {
            get
            {
                return this.round;
            }
        }


        private int round;
    }
}
